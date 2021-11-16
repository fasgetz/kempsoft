using kempsoft.Services.Email;
using kempsoft.Services.EmailSenders;
using kempsoft.Services.SberbankService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace kempsoft.Controllers.Api
{

    /// <summary>
    /// CallBack контроллер для 
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class CallbackController : ControllerBase
    {
        private readonly ISberbankService sberbankService;
        private readonly IEmailService emailService;
        private readonly IEmailsSendersService emailsSendersService;
        private readonly IServiceScopeFactory serviceScopeFactory;

        public CallbackController(ISberbankService sberbankService, IEmailService emailService, IEmailsSendersService emailsSendersService, IServiceScopeFactory _serviceScopeFactory)
        {
            this.sberbankService = sberbankService;
            this.emailService = emailService;
            this.emailsSendersService = emailsSendersService;
            serviceScopeFactory = _serviceScopeFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string mdOrder, string orderNumber, string operation, byte status)
        {
            bool successPayment = await sberbankService.checkSuccessPayment(mdOrder);

            // Если оплата успешно произведена
            if (successPayment == true)
            {

                // В отдельном потоке отправляем рассылку об успешном платеже
                _ = Task.Run(async () =>
                  {
                    using var scope = serviceScopeFactory.CreateScope();

                    // Скоуп контексты
                    var emailServiceScope = scope.ServiceProvider.GetRequiredService<IEmailService>();
                    var emailsSendersServiceScope = scope.ServiceProvider.GetRequiredService<IEmailsSendersService>();
                    var sberServiceScope = scope.ServiceProvider.GetRequiredService<ISberbankService>();

                    // Получаем список емейлов, которым отправлять уведомление
                    var listEmails = await emailsSendersServiceScope.getEmails();

                    System.IO.File.AppendAllText("test.txt", $"{DateTime.Now} | {mdOrder} | {orderNumber} | {operation} | {status} | оплата успешно прошла" + Environment.NewLine);
                    string messageSuccessPayment = $"Оплата заказа <b>{mdOrder}</b> от {DateTime.Now} успешно произведена!";
                    await emailServiceScope.SendEmailAsync(listEmails.Select(i => i.email), $"Успешная оплата платежа {mdOrder}", messageSuccessPayment);

                    // Ожидание две минуты для формирования платежки в налоговой
                    Thread.Sleep(120000);
                    // Теперь проверяем, есть ли чек в налоговой
                    var reciept = await sberServiceScope.getReciept(mdOrder);

                    // Если чек найден, то отправить на емейл
                    if (reciept != null && reciept.errorCode == "0" && reciept.receipt.FirstOrDefault().receiptStatus == 1)
                      {
                          StringBuilder str = new StringBuilder();
                          str.Append($"<p>Данные чека заказа №{mdOrder} от {DateTime.Now}:</p>");
                          str.Append($"<p><b>OrderId (SBER): </b> {reciept.orderId}</p>");
                          str.Append($"<p><b>orderNumber (SBER): </b> {reciept.orderNumber}</p>");
                          str.Append($"<p></p>");
                          str.Append($"<p><b>Сумма платежа: </b> {reciept.receipt.FirstOrDefault().amount_total / 100} рублей</p>");
                          str.Append($"<p><b>ecr_registration_number: </b> {reciept.receipt.FirstOrDefault().ecr_registration_number}</p>");
                          str.Append($"<p><b>fiscal_document_attribute: </b> {reciept.receipt.FirstOrDefault().fiscal_document_attribute}</p>");
                          str.Append($"<p><b>fiscal_document_number: </b> {reciept.receipt.FirstOrDefault().fiscal_document_number}</p>");
                          str.Append($"<p><b>fiscal_receipt_number: </b> {reciept.receipt.FirstOrDefault().fiscal_receipt_number}</p>");
                          str.Append($"<p><b>fnsSite: </b> {reciept.receipt.FirstOrDefault().fnsSite}</p>");
                          str.Append($"<p><b>fn_number: </b> {reciept.receipt.FirstOrDefault().fn_number}</p>");
                          str.Append($"<p><b>receipt_date_time: </b> {reciept.receipt.FirstOrDefault().receipt_date_time}</p>");


                          await emailServiceScope.SendEmailAsync(listEmails.Select(i => i.email), $"Чек заказа {mdOrder}", str.ToString());
                          System.IO.File.AppendAllText("test.txt", $"{DateTime.Now} | !!! чек найден и создан {mdOrder} - {JsonConvert.SerializeObject(reciept)} !!!" + Environment.NewLine);
                      }
                      else
                      {
                          messageSuccessPayment = $"Чек заказа №{mdOrder} в налоговой от {DateTime.Now} не зарегистрирован, но вы сможете посмотреть его позже на сайте ФНС/Эватола";


                          await emailServiceScope.SendEmailAsync(listEmails.Select(i => i.email), $"Чек еще не зарегистрирован {mdOrder}", messageSuccessPayment);
                          System.IO.File.AppendAllText("test.txt", $"{DateTime.Now} | чек не найден {mdOrder}" + Environment.NewLine);
                      }
                  });

                


            }
            else
            {
                // В отдельном потоке отправляем рассылку о неудачном платеже
                _ = Task.Run(async () =>
                {
                    using var scope = serviceScopeFactory.CreateScope();

                    // Скоуп контексты
                    var emailServiceScope = scope.ServiceProvider.GetRequiredService<IEmailService>();
                    var emailsSendersServiceScope = scope.ServiceProvider.GetRequiredService<IEmailsSendersService>();

                    // Получаем список емейлов, которым отправлять уведомление
                    var listEmails = await emailsSendersServiceScope.getEmails();

                    await emailServiceScope.SendEmailAsync(listEmails.Select(i => i.email), $"Неудачная оплата платежа {mdOrder}", $"Платеж №{mdOrder} произвести не удалось");

                    System.IO.File.AppendAllText("test.txt", $"{DateTime.Now} | {mdOrder} | {orderNumber} | {operation} | {status} | оплата неуспешна!__!! | successPayment: {successPayment}" + Environment.NewLine);
                });


                
            }

            

            return Ok($"{DateTime.Now} success writed!");
        }
    }
}

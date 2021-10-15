using kempsoft.Models.ViewModels;
using kempsoft.Services.PaymentDbService;
using kempsoft.Services.Price;
using Microsoft.Extensions.Configuration;
using Sberbank.NetCore;
using Sberbank.NetCore.Integration.Implementation.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kempsoft.Services.SberbankService
{

    /// <summary>
    /// Сервис по работе с методами сбербанка
    /// </summary>
    public class SberbankService : ISberbankService
    {
        private readonly IConfiguration config;
        private readonly IPriceService priceService;
        private readonly IPaymentService paymentService;
        private readonly SberbankClient client;

        public SberbankService(IConfiguration config, IPriceService priceService, IPaymentService paymentService)
        {
            this.config = config;
            this.priceService = priceService;
            this.paymentService = paymentService;

            // Инициализируем клиент сбербанка
            client = new SberbankClient(config.GetValue<string>("sberbankSettings:login"), config.GetValue<string>("sberbankSettings:password"), config.GetValue<bool>("sberbankSettings:sandbox"));
        }


        /// <summary>
        /// Метод по созданию платежа
        /// </summary>
        /// <param name="model">Модель данных платежа от юзера</param>
        /// <param name="userName">Нейм юзера, который создает платежку</param>
        /// <returns>Возвращает url страницы платежа</returns>
        public async Task<string> createOrder(PaymentForm model, string userName = null)
        {
            // проверяем есть ли прайс в бд и формируем платежку
            var price = await priceService.getPriceAsync(model.idPrice);

            // Если платежку не нашли
            if (price == null)
            {
                throw new Exception($"Платежка не найдена в бд");
            }

            // Сумма платежа
            decimal sum = price.Price1.Value;

            // Если тип платежа доработка, то умножить сумму на количество дней доработки
            if (price.IdTypePrice == 2)
            {
                sum *= model.countDays;
            }


            // Создаем платеж в сбербанке
            var order = client.RegisterOrder(new RegisterPaymentParameters()
            {
                Amount = new Sberbank.NetCore.Tools.Price(Convert.ToDouble(sum)),
                Description = $"Оплата платежа {price.Name}",
                ReturnUrl = config.GetValue<string>("sberbankSettings:successUrl"),
                FailUrl = config.GetValue<string>("sberbankSettings:successUrl"),
                SessionTimeoutSeconds = 3600,
                TaxSystem = Sberbank.NetCore.Integration.Implementation.Payment.TaxSystem.Common,
            });



            // Если платеж успешный, то добавить его в БД
            if (order.IsSuccess == true)
            {
                // Создаем модель платежки
                CreatePaymentViewModel vmPayment = new CreatePaymentViewModel()
                {
                    paymentForm = model,
                    totalPrice = sum,
                    userId = userName,
                    orderId = order.OrderId
                };

                // Сохраняем в БД
                bool addedDb = paymentService.createPayment(vmPayment);

            }
            // Иначе генерируем платеж
            else
            {
                throw new Exception($"Ошибка создания платежа! - {order.ErrorMessage}");
            }

            return order.FormUrl;
        }


        /// <summary>
        /// Проверка на успешность оплаты
        /// </summary>
        /// <param name="idPayment">Номер платежа сбербанка</param>
        /// <returns></returns>
        public async Task<bool> checkSuccessPayment(string idPayment)
        {
            var orderStatus = await client.GetOrderStatusAsync(idPayment);

            // Если платеж успешно оплачен
            if (orderStatus.IsSuccess == true)
            {
                // Добавляем статус, что оплачен заказ в БД
                bool addSuccessPayment = await paymentService.addSuccessPaymentStatus(idPayment);

                // Если статус успешно добавлен в бд, то соответственно вернуть true
                if (addSuccessPayment == true)
                {
                    return true;
                }

            }

            return false;
        }
    }
}

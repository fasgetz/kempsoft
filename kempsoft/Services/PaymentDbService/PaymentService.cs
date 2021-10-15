using kempsoft.Models.DataBase;
using kempsoft.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kempsoft.Services.PaymentDbService
{
    public class PaymentService : IPaymentService
    {
        private readonly softkempContext db;

        public PaymentService(softkempContext db)
        {
            this.db = db;
        }


        /// <summary>
        /// Создание платежа в БД
        /// </summary>
        /// <param name="model">Модель данных</param>
        /// <returns>true в случае успешного занесения платежа в БД</returns>
        public bool createPayment(CreatePaymentViewModel model)
        {
            // Формируем платежку
            Payment payment = new Payment()
            {
                ContactName = model.paymentForm.contactName,
                ContactPhone = model.paymentForm.contactPhone,
                Description = model.paymentForm.description,
                OrderId = model.orderId,
                CountDays = (short)model.paymentForm.countDays,
                SumPayment = model.totalPrice,
                UserId = model.userId,
                PriceId = (short)model.paymentForm.idType,
                PaymentsStatuses = new List<PaymentsStatus>()
                {
                    new PaymentsStatus()
                    {
                        DateCreated = DateTime.Now,
                        IdStatus = 1
                    } 
                }
            };

            db.Payments.Add(payment);
            db.SaveChanges();

            return true;
        }


        /// <summary>
        /// Добавление статуса платежа как успешного
        /// </summary>
        /// <param name="idPayment">Айди платежа сбербанка, который соответствует платежу в БД</param>
        /// <returns>false в случае успешного добавления платежа. True - в случае успешного</returns>
        public async Task<bool> addSuccessPaymentStatus(string idPayment)
        {
            // Ищем платежку в бд
            var findPayment = await db.Payments.FirstOrDefaultAsync(i => i.OrderId == idPayment);

            // Если платежку не нашли, то вернуть false
            if (findPayment == null)
            {
                return false;
            }

            // Добавляем статус платежа, как успешно добавленный
            findPayment.PaymentsStatuses.Add(new PaymentsStatus() { DateCreated = DateTime.Now, IdStatus = 2 });
            db.SaveChanges();


            return true;
        }
    }
}

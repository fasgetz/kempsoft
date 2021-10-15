using kempsoft.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kempsoft.Services.PaymentDbService
{
    public interface IPaymentService
    {
        /// <summary>
        /// Создание платежа в БД
        /// </summary>
        /// <param name="model">Модель данных</param>
        /// <returns>true в случае успешного занесения платежа в БД</returns>
        public bool createPayment(CreatePaymentViewModel model);

        /// <summary>
        /// Добавление статуса платежа как успешного
        /// </summary>
        /// <param name="idPayment">Айди платежа сбербанка, который соответствует платежу в БД</param>
        /// <returns>false в случае успешного добавления платежа. True - в случае успешного</returns>
        public Task<bool> addSuccessPaymentStatus(string idPayment);
    }
}

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
    }
}

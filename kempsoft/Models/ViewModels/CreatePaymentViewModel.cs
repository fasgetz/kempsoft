using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kempsoft.Models.ViewModels
{

    /// <summary>
    /// Модель для добавления платежа в БД
    /// </summary>
    public class CreatePaymentViewModel
    {
        /// <summary>
        /// Данные платежа с формы
        /// </summary>
        public PaymentForm paymentForm { get; set; }

        /// <summary>
        /// Общая сумма платежа
        /// </summary>
        public decimal totalPrice { get; set; }


        /// <summary>
        /// Айди юзера
        /// </summary>
        public string userId { get; set; }

        /// <summary>
        /// Айди платежки в сбера
        /// </summary>
        public string orderId { get; set; }
    }
}

using kempsoft.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kempsoft.Services.SberbankService
{


    public interface ISberbankService
    {

        /// <summary>
        /// Метод по созданию платежа
        /// </summary>
        /// <param name="model">Модель данных платежа от юзера</param>
        /// <param name="userName">Нейм юзера, который создает платежку</param>
        /// <returns>Возвращает url страницы платежа</returns>
        public Task<string> createOrder(PaymentForm model, string userName = null);


        /// <summary>
        /// Проверка на успешность оплаты
        /// </summary>
        /// <param name="idPayment">Номер платежа сбербанка</param>
        /// <returns></returns>
        public Task<bool> checkSuccessPayment(string idPayment);
    }
}

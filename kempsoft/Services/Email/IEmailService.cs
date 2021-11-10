using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kempsoft.Services.Email
{
    public interface IEmailService
    {
        /// <summary>
        /// Метод отправки сообщения на email
        /// </summary>
        /// <param name="emailTo">Адрес</param>
        /// <param name="subject">Тема сообщения</param>
        /// <param name="message">Сообщение</param>
        /// <param name="description">Дескрипшен к почте (предисловие в письме)</param>
        /// <returns></returns>
        public Task SendEmailAsync(string emailTo, string subject, string message, string description = "Сообщение от студии разработки kempsoft");

        /// <summary>
        /// Метод отправки сообщения на список email
        /// </summary>
        /// <param name="emailsTo">Адреса</param>
        /// <param name="subject">Тема сообщения</param>
        /// <param name="message">Сообщение</param>
        /// <param name="description">Дескрипшен к почте (предисловие в письме)</param>
        /// <returns></returns>
        Task SendEmailAsync(IEnumerable<string> emailsTo, string subject, string message, string description = "Сообщение от студии разработки kempsoft");
    }
}

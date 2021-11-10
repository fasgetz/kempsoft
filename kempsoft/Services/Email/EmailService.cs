using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace kempsoft.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly string emailFrom;
        private readonly string emailPassword;
        private readonly string smtpHost;
        private readonly short smtpPort;

        public EmailService(IConfiguration config)
        {
            emailFrom = config.GetValue<string>("emailSettings:email");
            emailPassword = config.GetValue<string>("emailSettings:password");
            smtpHost = config.GetValue<string>("emailSettings:smtpHost");
            smtpPort = config.GetValue<short>("emailSettings:smtpPort");
        }


        /// <summary>
        /// Метод отправки сообщения на email
        /// </summary>
        /// <param name="emailTo">Адрес</param>
        /// <param name="subject">Тема сообщения</param>
        /// <param name="message">Сообщение</param>
        /// <param name="description">Дескрипшен к почте (предисловие в письме)</param>
        /// <returns></returns>
        public async Task SendEmailAsync(string emailTo, string subject, string message, string description = "Сообщение от студии разработки kempsoft")
        {

            var mess = File.ReadAllText("wwwroot/htmlTemplates/template.html");
            mess = mess.Replace("messageTo", message);
            mess = mess.Replace("messageSubject", subject);
            mess = mess.Replace("descriptionMessage", description);

            // SMTP YANDEX
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("kempsoft", emailFrom));
            emailMessage.To.Add(new MailboxAddress(emailTo, emailTo));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = mess
            };


            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(smtpHost, smtpPort, true);
                await client.AuthenticateAsync(emailFrom, emailPassword);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }

        }

        /// <summary>
        /// Метод отправки сообщения на список email
        /// </summary>
        /// <param name="emailsTo">Адреса</param>
        /// <param name="subject">Тема сообщения</param>
        /// <param name="message">Сообщение</param>
        /// <param name="description">Дескрипшен к почте (предисловие в письме)</param>
        /// <returns></returns>
        public async Task SendEmailAsync(IEnumerable<string> emailsTo, string subject, string message, string description = "Сообщение от студии разработки kempsoft")
        {

            var mess = File.ReadAllText("wwwroot/htmlTemplates/template.html");
            mess = mess.Replace("messageTo", message);
            mess = mess.Replace("messageSubject", subject);
            mess = mess.Replace("descriptionMessage", description);

            // Формируем сообщение
            MimeMessage emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("kempsoft", emailFrom));            
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = mess
            };


            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(smtpHost, smtpPort, true);
                await client.AuthenticateAsync(emailFrom, emailPassword);

                // Отправляем сообщение на каждый мейл
                foreach (string email in emailsTo)
                {
                    emailMessage.To.Add(new MailboxAddress(email, email));
                    await client.SendAsync(emailMessage);
                }

                // Дисконнект после операций с почтой
                await client.DisconnectAsync(true);
            }

        }
    }
}

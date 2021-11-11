using kempsoft.Models.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kempsoft.Services.EmailSenders
{
    public class EmailSendersService : IEmailsSendersService
    {
        private readonly softkempContext db;


        public EmailSendersService(softkempContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<EmailsSender>> getEmails()
        {
            var emails = await db.sendersEmail.ToListAsync();

            return emails;
        }
    }
}

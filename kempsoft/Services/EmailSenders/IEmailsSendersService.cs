using kempsoft.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kempsoft.Services.EmailSenders
{
    public interface IEmailsSendersService
    {
        public Task<IEnumerable<EmailsSender>> getEmails();
    }
}

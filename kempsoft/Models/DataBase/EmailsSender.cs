using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kempsoft.Models.DataBase
{
    /// <summary>
    /// Сущность емейлов, которым делать рассылку
    /// </summary>
    public class EmailsSender
    {
        public int Id { get; set; }
        public string email { get; set; }
    }
}

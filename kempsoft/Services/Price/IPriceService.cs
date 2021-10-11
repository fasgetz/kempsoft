using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kempsoft.Services.Price
{
    public interface IPriceService
    {
        /// <summary>
        /// Получить полный перечень цен
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Models.DataBase.Price>> getPricesAsync();
    }
}

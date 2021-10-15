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


        /// <summary>
        /// Получить прайс
        /// </summary>
        /// <param name="priceId">Айди прайса</param>
        /// <returns></returns>
        public Task<Models.DataBase.Price> getPriceAsync(int priceId);
    }
}

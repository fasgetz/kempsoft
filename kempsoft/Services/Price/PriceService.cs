using kempsoft.Models.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kempsoft.Services.Price
{
    public class PriceService : IPriceService
    {
        private readonly softkempContext db;

        public PriceService(softkempContext db)
        {
            this.db = db;
        }


        /// <summary>
        /// Получить полный перечень цен
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Models.DataBase.Price>> getPricesAsync()
        {
            IEnumerable<Models.DataBase.Price> prices = await db.Prices.ToListAsync();

            return prices;
        }
    }
}

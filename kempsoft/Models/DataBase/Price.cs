using System;
using System.Collections.Generic;

#nullable disable

namespace kempsoft.Models.DataBase
{
    public partial class Price
    {
        public Price()
        {
            Payments = new HashSet<Payment>();
        }

        public short Id { get; set; }
        public decimal? Price1 { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public short? IdTypePrice { get; set; }

        public virtual TypePrice IdTypePriceNavigation { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}

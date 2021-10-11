using System;
using System.Collections.Generic;

#nullable disable

namespace kempsoft.Models.DataBase
{
    public partial class TypePrice
    {
        public TypePrice()
        {
            Prices = new HashSet<Price>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Price> Prices { get; set; }
    }
}

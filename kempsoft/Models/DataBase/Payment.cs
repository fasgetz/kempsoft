using System;
using System.Collections.Generic;

#nullable disable

namespace kempsoft.Models.DataBase
{
    public partial class Payment
    {
        public Payment()
        {
            PaymentsStatuses = new HashSet<PaymentsStatus>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public short? PriceId { get; set; }
        public short? CountDays { get; set; }
        public string OrderId { get; set; }
        public decimal? SumPayment { get; set; }
        public string ContactName { get; set; }
        public string Description { get; set; }
        public string ContactPhone { get; set; }

        public virtual Price Price { get; set; }
        public virtual ICollection<PaymentsStatus> PaymentsStatuses { get; set; }
    }
}

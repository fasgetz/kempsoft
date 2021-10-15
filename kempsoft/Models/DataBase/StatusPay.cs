using System;
using System.Collections.Generic;

#nullable disable

namespace kempsoft.Models.DataBase
{
    public partial class StatusPay
    {
        public StatusPay()
        {
            PaymentsStatuses = new HashSet<PaymentsStatus>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PaymentsStatus> PaymentsStatuses { get; set; }
    }
}

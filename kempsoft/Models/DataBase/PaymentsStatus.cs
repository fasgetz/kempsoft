using System;
using System.Collections.Generic;

#nullable disable

namespace kempsoft.Models.DataBase
{
    public partial class PaymentsStatus
    {
        public int Id { get; set; }
        public short? IdStatus { get; set; }
        public int? IdPayment { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual Payment IdPaymentNavigation { get; set; }
        public virtual StatusPay IdStatusNavigation { get; set; }
    }
}

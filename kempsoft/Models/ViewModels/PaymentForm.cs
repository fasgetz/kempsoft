using kempsoft.Models.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kempsoft.Models.ViewModels
{
    /// <summary>
    /// Модель для оплаты
    /// </summary>
    public class PaymentForm
    {

        /// <summary>
        /// Количество дней разработки (если тип 2)
        /// </summary>
        public int countDays { get; set; }

        /// <summary>
        /// Тип прайса
        /// </summary>
        [Required]
        public int idType { get; set; }


        [Required]
        [Display(Name = "idPrice")]
        public int idPrice { get; set; }

        [Required]
        [Display(Name = "Контактное имя")]
        public string contactName { get; set; }

        [Required]
        [Display(Name = "Номер телефона")]
        public string contactPhone { get; set; }

        [Required]
        [Display(Name = "Ваши пожелания")]
        public string description { get; set; }

    }
}

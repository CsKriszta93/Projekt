using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CurrencyConverter.Models.ViewModels
{
    public class CurrencyFormViewModel
    {
        public List<Money> Currencies { get; set; }

        [Required]
        public decimal? Amount { get; set; }

        [Required]
        public decimal? Result { get; set; }

        public int IdFrom { get; set; }

        public int IdTo { get; set; }
    }
}

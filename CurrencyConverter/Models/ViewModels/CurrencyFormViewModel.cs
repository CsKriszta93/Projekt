using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CurrencyConverter.Models.ViewModels
{
    public class CurrencyFormViewModel
    {
        public List<Money> Currencies { get; set; }

        public int? Id { get; set; }

        [Required]
        public decimal? Amount { get; set; }

        [Required]
        public decimal? Result { get; set; }

        [Required]
        [Display(Name = "From Currency:")]
        public int FromCurrId { get; set; }

        [Required]
        [Display(Name = "To Currency:")]
        public int ToCurrId { get; set; }
    }
}

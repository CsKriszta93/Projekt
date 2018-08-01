using System;

namespace CurrencyConverter.Models
{
    public class Money
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public decimal Rate { get; set; }
        public DateTime Time { get; set; }
    }
}

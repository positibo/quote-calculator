using System;
using System.Collections.Generic;

#nullable disable

namespace QuoteCalculator.Entities
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public bool HasInterest { get; set; }
        public string Duration { get; set; }
        public int? FreeMonthInterest { get; set; }
    }
}

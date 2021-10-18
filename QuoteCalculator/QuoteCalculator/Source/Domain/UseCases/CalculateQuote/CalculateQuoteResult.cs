using System;

namespace QuoteCalculator.Source.Domain.UseCases.CalculateQuote
{
    public class CalculateQuoteResult
    {
        public string Email { get; set; }

        public decimal EstablishmentFee { get; set; }

        public decimal FinanceAmount { get; set; }

        public string FinanceFrequency { get; set; }

        public decimal Interest { get; set; }

        public string MobileNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string RepaymentsFrequency { get; set; }

        public decimal RepaymentsFrom { get; set; }

        public int Term { get; set; }

        public string Title { get; set; }

        public DateTime DateOfBirth { get; set; }

        public decimal TotalRepayments { get; set; }
    }
}

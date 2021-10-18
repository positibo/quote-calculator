using System;
using System.ComponentModel.DataAnnotations;

namespace QuoteCalculator.Source.Domain.UseCases.ApplyLoan
{
    public class ApplyLoanDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public decimal EstablishmentFee { get; set; }

        [Required]
        public decimal FinanceAmount { get; set; }

        [Required]
        public string FinanceFrequency { get; set; }

        [Required]
        public decimal Interest { get; set; }

        [Required]
        public string MobileNumber { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string RepaymentsFrequency { get; set; }

        [Required]
        public decimal RepaymentsFrom { get; set; }

        [Required]
        public int Term { get; set; }

        [Required]
        public decimal TotalRepayments { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}

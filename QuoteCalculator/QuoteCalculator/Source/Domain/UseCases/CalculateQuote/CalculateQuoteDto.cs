using System;
using System.ComponentModel.DataAnnotations;

namespace QuoteCalculator.Source.Domain.UseCases.CalculateQuote
{
    public class CalculateQuoteDto
    {
        [Required]
        public decimal AmountRequired { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Product { get; set; }

        [Required]
        public int Term { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public double Interest { get; set; }
    }
}

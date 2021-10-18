using System;
using System.Collections.Generic;

#nullable disable

namespace QuoteCalculator.Entities
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int LoanId { get; set; }

        public virtual Loan Loan { get; set; }
    }
}

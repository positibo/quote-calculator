using System;
using System.Collections.Generic;

#nullable disable

namespace QuoteCalculator.Entities
{
    public partial class Loan
    {
        public Loan()
        {
            Customers = new HashSet<Customer>();
        }

        public int LoanId { get; set; }
        public decimal AmountRequired { get; set; }
        public decimal? TotalInterest { get; set; }
        public decimal RepaymentAmount { get; set; }
        public decimal EstablishmentFee { get; set; }
        public string Frequency { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}

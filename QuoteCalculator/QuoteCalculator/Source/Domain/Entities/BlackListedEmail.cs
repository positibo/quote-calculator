using System;
using System.Collections.Generic;

#nullable disable

namespace QuoteCalculator.Entities
{
    public partial class BlackListedEmail
    {
        public int BlackListedEmailId { get; set; }
        public string Email { get; set; }
    }
}

using QuoteCalculator.Source.Domain.BusinessRules.Base;
using System.Net;

namespace QuoteCalculator.Source.Domain.BusinessRules
{
    public class BlackListedEmailException: BusinessRulesException
    {
        private const string message = "The email is blacklisted.";

        public BlackListedEmailException() : base(HttpStatusCode.BadRequest, message) { }
    }
}

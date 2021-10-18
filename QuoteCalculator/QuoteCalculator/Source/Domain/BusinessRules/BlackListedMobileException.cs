using QuoteCalculator.Source.Domain.BusinessRules.Base;
using System.Net;

namespace QuoteCalculator.Source.Domain.BusinessRules
{
    public class BlackListedMobileException : BusinessRulesException
    {
        private const string message = "The mobile number is blacklisted.";

        public BlackListedMobileException() : base(HttpStatusCode.BadRequest, message) { }
    }
}

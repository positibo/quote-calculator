using QuoteCalculator.Source.Domain.BusinessRules.Base;
using System.Net;

namespace QuoteCalculator.Source.Domain.BusinessRules
{
    public class AgeNotAllowedException : BusinessRulesException
    {
        private const string message = "The Applicant must be at least 18 years old.";

        public AgeNotAllowedException() : base(HttpStatusCode.BadRequest, message) { }
    }
}

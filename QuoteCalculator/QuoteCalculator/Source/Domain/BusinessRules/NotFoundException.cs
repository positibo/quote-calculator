using QuoteCalculator.Source.Domain.BusinessRules.Base;
using System.Net;

namespace QuoteCalculator.Source.Domain.BusinessRules
{
    public class NotFoundException : BusinessRulesException
    {
        private const string message = "Record Not Found.";

        public NotFoundException() : base(HttpStatusCode.NotFound, message) { }
    }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using QuoteCalculator.Entities;
using QuoteCalculator.Source.Domain.BusinessRules;
using QuoteCalculator.Source.Domain.Enums;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuoteCalculator.Source.Domain.UseCases.CalculateQuote
{
    public class CalculateQuoteCommand : IRequest<CalculateQuoteResult>
    {
        public CalculateQuoteDto Dto { get; }

        public CalculateQuoteCommand(CalculateQuoteDto dto) => this.Dto = dto;

        public class RequestHandler : IRequestHandler<CalculateQuoteCommand, CalculateQuoteResult>
        {
            private readonly DataContext context;

            public RequestHandler(DataContext context) => this.context = context;

            public async Task<CalculateQuoteResult> Handle(CalculateQuoteCommand request, CancellationToken cancellationToken)
            {
                var product = await context.Products.FirstOrDefaultAsync(o => o.ProductName == request.Dto.Product);
                if(product == null)
                {
                    throw new NotFoundException();
                }

                var interest = product.HasInterest ? request.Dto.Interest : 0;
                var numberOfPayments = request.Dto.Term * 12;
                numberOfPayments = (int)(product.FreeMonthInterest.GetValueOrDefault() > 0 ? (numberOfPayments - product.FreeMonthInterest) : numberOfPayments);
                var paymentAmount = Pmt(interest, numberOfPayments, (double)request.Dto.AmountRequired);

                var establishmentFee = 300M;
                var interestRate = (paymentAmount * numberOfPayments) - request.Dto.AmountRequired;
                return new CalculateQuoteResult
                {
                    FirstName =request.Dto.FirstName,
                    LastName = request.Dto.LastName,
                    Email = request.Dto.Email,
                    MobileNumber = request.Dto.Mobile,
                    FinanceAmount = request.Dto.AmountRequired,
                    Term = request.Dto.Term,
                    FinanceFrequency = FrequencyEnum.Monthly.ToString(),
                    RepaymentsFrom = Math.Round(paymentAmount, 2),
                    RepaymentsFrequency = FrequencyEnum.Monthly.ToString(),
                    TotalRepayments  = Math.Round((request.Dto.AmountRequired + establishmentFee + interestRate), 2),
                    EstablishmentFee = establishmentFee,
                    Interest = Math.Round(interestRate, 2),
                    Title = request.Dto.Title,
                    DateOfBirth = request.Dto.DateOfBirth
                };
            }

            private decimal Pmt(double yearlyInterestRate, int totalNumberOfMonths, double loanAmount)
            {
                if (yearlyInterestRate > 0)
                {
                    var rate = (double)yearlyInterestRate / 100 / 12;
                    var denominator = Math.Pow((1 + rate), totalNumberOfMonths) - 1;
                    return new decimal((rate + (rate / denominator)) * loanAmount);
                }
                return totalNumberOfMonths > 0 ? new decimal(loanAmount / totalNumberOfMonths) : 0;
            }
        }
    }
}

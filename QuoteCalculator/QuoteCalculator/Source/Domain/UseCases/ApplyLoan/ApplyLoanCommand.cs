using MediatR;
using Microsoft.EntityFrameworkCore;
using QuoteCalculator.Entities;
using QuoteCalculator.Source.Domain.BusinessRules;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QuoteCalculator.Source.Domain.UseCases.ApplyLoan
{
    public class ApplyLoanCommand : IRequest
    {
        public ApplyLoanDto Dto { get; }

        public ApplyLoanCommand(ApplyLoanDto dto) => this.Dto = dto;

        public class RequestHandler : IRequestHandler<ApplyLoanCommand>
        {
            private readonly DataContext context;

            public RequestHandler(DataContext context) => this.context = context;

            public async Task<Unit> Handle(ApplyLoanCommand request, CancellationToken cancellationToken)
            {
                await Validate(request);

                var loan = new Loan
                {
                    AmountRequired = request.Dto.FinanceAmount,
                    Frequency = request.Dto.FinanceFrequency,
                    TotalInterest = request.Dto.Interest,
                    RepaymentAmount = request.Dto.RepaymentsFrom,
                    EstablishmentFee = request.Dto.EstablishmentFee
                };

                var customer = new Customer
                {
                    DateOfBirth = request.Dto.DateOfBirth,
                    Email = request.Dto.Email,
                    FirstName = request.Dto.FirstName,
                    LastName = request.Dto.LastName,
                    Mobile = request.Dto.MobileNumber,
                    Title = request.Dto.Title,
                    Loan = loan
                };

                context.Customers.Add(customer);
                await context.SaveChangesAsync();

                return Unit.Value;
            }

            private async Task Validate(ApplyLoanCommand request)
            {
                if (!IsValidAge(request.Dto.DateOfBirth))
                {
                    throw new AgeNotAllowedException();
                }

                if (await context.BlackListedMobiles.AnyAsync(o => o.MobileNumber == request.Dto.MobileNumber))
                {
                    throw new BlackListedMobileException();
                }

                if (await context.BlackListedEmails.AnyAsync(o => o.Email == request.Dto.Email))
                {
                    throw new BlackListedEmailException();
                }
            }

            private bool IsValidAge(DateTime birthdate)
            {
                // Save today's date.
                var today = DateTime.Today;

                // Calculate the age.
                var age = today.Year - birthdate.Year;

                // Go back to the year in which the person was born in case of a leap year
                if (birthdate.Date > today.AddYears(-age))
                {
                    age--;
                }

                if(age >= 18)
                {
                    return true;
                }

                return false;
            }
        }
    }
}

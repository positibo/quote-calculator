using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuoteCalculator.Entities;
using QuoteCalculator.Source.Domain.BusinessRules;
using QuoteCalculator.Source.Domain.Enums;
using QuoteCalculator.Source.Domain.UseCases.ApplyLoan;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QuoteCalculator.Tests
{
    [TestClass]
    public class Loan
    {
        private DataContext context = null;
        private IMapper mapper = null;

        [TestInitialize]
        public void Initialize()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            context = new DataContext(options);

            context.BlackListedMobiles.Add(new BlackListedMobile
            {
                MobileNumber = "09314567891"
            });

            context.BlackListedEmails.Add(new BlackListedEmail
            {
                Email = "test2@gmail.com"
            });

            context.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            context.Dispose();
            context = null;
        }

        [TestMethod]
        [ExpectedException(typeof(AgeNotAllowedException))]
        public async Task ApplyLoan_AgeNotAllowed()
        {
            var dto = new ApplyLoanDto
            {
                DateOfBirth = new DateTime(2021, 10, 16),
                Email = "test@gmail.com",
                FinanceAmount = 5000,
                FinanceFrequency = FrequencyEnum.Monthly.ToString(),
                FirstName = "John",
                LastName = "Doe",
                MobileNumber = "09314567892",
                RepaymentsFrom = 233,
                RepaymentsFrequency = FrequencyEnum.Monthly.ToString(),
                Title = "Mr."
            };

            var useCase = new ApplyLoanCommand(dto);
            var request = new ApplyLoanCommand.RequestHandler(context);

            await request.Handle(useCase, new CancellationToken());
        }

        [TestMethod]
        [ExpectedException(typeof(BlackListedMobileException))]
        public async Task ApplyLoan_BlackListedMobile()
        {
            var dto = new ApplyLoanDto
            {
                DateOfBirth = new DateTime(2000, 10, 16),
                Email = "test@gmail.com",
                FinanceAmount = 5000,
                FinanceFrequency = FrequencyEnum.Monthly.ToString(),
                FirstName = "John",
                LastName = "Doe",
                MobileNumber = "09314567891",
                RepaymentsFrom = 233,
                RepaymentsFrequency = FrequencyEnum.Monthly.ToString(),
                Title = "Mr."
            };

            var useCase = new ApplyLoanCommand(dto);
            var request = new ApplyLoanCommand.RequestHandler(context);

            await request.Handle(useCase, new CancellationToken());
        }

        [TestMethod]
        [ExpectedException(typeof(BlackListedEmailException))]
        public async Task ApplyLoan_BlackListedEmail()
        {
            var dto = new ApplyLoanDto
            {
                DateOfBirth = new DateTime(2000, 10, 16),
                Email = "test2@gmail.com",
                FinanceAmount = 5000,
                FinanceFrequency = FrequencyEnum.Monthly.ToString(),
                FirstName = "John",
                LastName = "Doe",
                MobileNumber = "09314567892",
                RepaymentsFrom = 233,
                RepaymentsFrequency = FrequencyEnum.Monthly.ToString(),
                Title = "Mr."
            };

            var useCase = new ApplyLoanCommand(dto);
            var request = new ApplyLoanCommand.RequestHandler(context);

            await request.Handle(useCase, new CancellationToken());
        }
    }
}

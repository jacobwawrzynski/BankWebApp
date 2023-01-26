using BankSystem.Data;
using BankSystem.Controllers;
using BankSystem.Models.Interfaces;
using BankSystem.Models;

namespace LoanApplicationTest
{
    public class LoanApplicationRESTControllerTest
    {
        private readonly ILoanService _loanService;

        [Fact]
        public async void TestGet()
        {
            // Given
            var controller = new LoanApplicationRESTController(_loanService);
            var expected = new LoanApplication
            {
                IDnumber = "1111",
                EmploymentType = "Standard",
                MonthlyIncome = 9000,
                Status = LoanStatus.Declined,
            };

            // When
            var actual = await controller.Get(7);
            
            // Then
            Assert.NotNull(actual);
            Assert.Equal(expected.IDnumber, actual.IDnumber);
            Assert.Equal(expected.EmploymentType, actual.EmploymentType);
            Assert.Equal(expected.Status, actual.Status);
            Assert.Equal(expected.MonthlyIncome, actual.MonthlyIncome);

        }
    }
}
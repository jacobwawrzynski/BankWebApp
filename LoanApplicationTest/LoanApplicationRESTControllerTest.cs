using BankSystem.Data;
using BankSystem.Controllers;
using BankSystem.Models.Interfaces;
using BankSystem.Models;
using System.Drawing.Text;
using BankSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoanApplicationTest
{
    public class LoanApplicationRESTControllerTest
    {
        private ILoanService service = new TestLoanService();
        private LoanApplicationRESTController controller;

        public LoanApplicationRESTControllerTest() 
        {
            controller = new LoanApplicationRESTController(service);
            var loanApplication = new LoanViewModel()
            {
                Firstname = "Testfirstname",
                Lastname = "Testname",
                EmploymentType = "Employmenttest",
                MonthlyIncome = 1,
                Currency = Currency.Dollar,
                MonthsToPayOff = 1,
                Amount = 1,
                Status = LoanStatus.Considered
            };
            var loanApplication2 = new LoanViewModel()
            {
                Firstname = "TestfirstnameB",
                Lastname = "TestnameB",
                EmploymentType = "EmploymenttestB",
                MonthlyIncome = 2,
                Currency = Currency.Euro,
                MonthsToPayOff = 2,
                Amount = 2,
                Status = LoanStatus.Declined

            };

            service.SendLoanApplication(loanApplication, null);
            service.SendLoanApplication(loanApplication2, null);
        }

        [Fact]
        public async Task TestLoanApplicationRESTControllerGetById()
        {
            var loan1 = await controller.Get(1);
            var loan2 = await controller.Get(2);

            Assert.IsType<OkObjectResult>(loan1);
            Assert.IsType<OkObjectResult>(loan2);
        }

        [Fact]
        public async Task TestLoanApplicationRESTControllerGetAll()
        {
            var loan = await controller.Get();

            Assert.IsType<OkObjectResult>(loan);
        }

        [Fact]
        public async Task TestLoanApplicationRESTControllerDelete()
        {
            var loan = controller.Delete(1).Result;

            Assert.True(loan);
        }

        [Fact]
        public async Task TaskLoanApplicationRESTControllerPut()
        {
            var loan = new LoanApplication()
            {
                Id = 1,
                IDnumber = "0000",
                Firstname = "TestfirstnameB",
                Lastname = "TestnameB",
                EmploymentType = "EmploymenttestB",
                MonthlyIncome = 2,
                Currency = Currency.Euro,
                MonthsToPayOff = 2,
                Amount = 2,
                Status = LoanStatus.Declined,
                ClientFK = "0000",
                _Client = new Client()
            };

            var loanApplication = controller.Put(loan).Result;
            
            Assert.True(loanApplication);
        }

        [Fact]
        public async Task TaskLoanApplicationRESTControllerPost()
        {
            var loanApplication = new LoanViewModel()
            {
                Firstname = "Testfirstname",
                Lastname = "Testname",
                EmploymentType = "Employmenttest",
                MonthlyIncome = 1,
                Currency = Currency.Dollar,
                MonthsToPayOff = 1,
                Amount = 1,
                Status = LoanStatus.Considered
            };

            var loan = await controller.Post(loanApplication, null);

            Assert.IsType<CreatedResult>(loan);
        }
    }
}
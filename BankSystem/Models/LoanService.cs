using BankSystem.Data;
using BankSystem.Models.Interfaces;
using BankSystem.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Models
{
	public class LoanService : ILoanService
	{
		private readonly ApplicationDbContext _context;
		public LoanService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task SendLoanApplication(LoanViewModel loanModel, string clientId)
		{
			var loanApplication = new LoanApplication();

			loanApplication.IDnumber = loanModel.IDnumber;
			loanApplication.Firstname = loanModel.Firstname;
			loanApplication.Lastname = loanModel.Lastname;
			loanApplication.Currency = loanModel.Currency;
			loanApplication.EmploymentType = loanModel.EmploymentType;
			loanApplication.MonthlyIncome = loanModel.MonthlyIncome;
			loanApplication.Amount = loanModel.Amount;
			loanApplication.MonthsToPayOff = loanModel.MonthsToPayOff;
			loanApplication.ClientFK = clientId;

			_context.Add(loanApplication);
			await _context.SaveChangesAsync();
		}
	}
}

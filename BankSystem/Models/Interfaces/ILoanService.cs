using BankSystem.Models.ViewModels;

namespace BankSystem.Models.Interfaces
{
	public interface ILoanService
	{
		Task SendLoanApplication(LoanViewModel loanModel, string clientId);
	}
}

using BankSystem.Data;
using BankSystem.Models.ViewModels;

namespace BankSystem.Models.Interfaces
{
	public interface ILoanService
	{
		public Task SendLoanApplication(LoanViewModel loanModel, string clientId);
		public Task<ICollection<LoanApplication>> GetAllLoans();
		public Task<LoanApplication?> FindBy(int? id);
		public Task<bool> Accept(int? id);
		public Task<bool> Decline(int? id);
	}
}

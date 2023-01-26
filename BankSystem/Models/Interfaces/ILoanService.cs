using BankSystem.Data;
using BankSystem.Models.ViewModels;

namespace BankSystem.Models.Interfaces
{
	public interface ILoanService
	{
		public Task SendLoanApplication(LoanViewModel loanModel, string clientId);
		public Task<ICollection<LoanApplication>> GetAllLoans();
		public Task<LoanApplication?> FindBy(int? id);
		public Task Accept(int? id);
		public Task Decline(int? id);
		public Task<bool> Update(LoanApplication loanApplication);
		public Task<bool> Delete(int? id);
	}
}

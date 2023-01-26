using BankSystem.Data;
using BankSystem.Models.Interfaces;
using BankSystem.Models.ViewModels;

namespace BankSystem.Models
{
    public class TestLoanService : ILoanService
    {
        public TestLoanService() { }

        private readonly Dictionary<int, LoanApplication?> repository = 
            new Dictionary<int, LoanApplication?>();
        private int counter = 1;
        private int UniqId()
        {
            return counter++;
        }

        public async Task SendLoanApplication(LoanViewModel loanModel, string clientId)
        {
            var loan = new LoanApplication();
            loan.Id = UniqId();
            repository.Add(loan.Id, loan);
        }

        public async Task Accept(int? id)
        {
            if (id is not null)
            {
                int notNullId = (int)id;
                repository[notNullId].Status = LoanStatus.Accepted;
            }
        }

        public async Task Decline(int? id)
        {
            if (id is not null)
            {
                int notNullId = (int)id;
                repository[notNullId].Status = LoanStatus.Declined;
            }
        }

        public async Task<bool> Delete(int? id)
        {
            if (id is not null)
            {
                return repository.Remove(id??1);
            }
            return false;
        }

        public async Task<bool> Update(LoanApplication loan)
        {
            if (repository.ContainsKey(loan.Id))
            {
                repository[loan.Id] = loan;
                return true;
            }
            return false;
        }

        public async Task<ICollection<LoanApplication>> GetAllLoans()
        {
            return repository.Values;
        }

        public async Task<LoanApplication?> FindBy(int? id)
        {
            if (id is not null)
            {
                return repository.TryGetValue(id ?? 1, out var loan) ? loan : null;
            }
            return null;
        }
    }
}

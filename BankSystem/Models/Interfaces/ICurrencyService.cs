using BankSystem.Data;
using BankSystem.Models.ViewModels;

namespace BankSystem.Models.Interfaces
{
    public interface ICurrencyService
    {
        public IAccountHistory Transfer(TransferViewModel transfer, IAccountHistory history);
        public Task EuroTransfer(TransferViewModel transfer, EuroAccountHistory euroAccountHistory);
        public Task PoundTransfer(TransferViewModel transfer, PoundAccountHistory poundAccountHistory);

        public Task Deposit(double amount, IAccount account);
        public Task EuroDeposit(double amount, string accountNumber);
        public Task PoundDeposit(double amount, string accountNumber);
        
        public Task Withdrawal(double amount, IAccount account);
        public Task EuroWithdrawal(double amount, string accountNumber);
        public Task PoundWithdrawal(double amount, string accountNumber);
        
        
        public Task<List<DollarAccountHistory>> DollarHistory(string clientAccount);
        public Task<List<EuroAccountHistory>> EuroHistory(string clientAccount);
        public Task<List<PoundAccountHistory>> PoundHistory(string clientAccount);

        public void TransferToHistory(TransferViewModel transfer, IAccountHistory history);
    }
}

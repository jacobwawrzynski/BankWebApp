using BankSystem.Data;
using BankSystem.Models.ViewModels;

namespace BankSystem.Models.Interfaces
{
    public interface ICurrencyService
    {
        public Task DollarTransfer(TransferViewModel transfer, DollarAccountHistory dollarAccountHistory);
        public Task EuroTransfer(TransferViewModel transfer, EuroAccountHistory euroAccountHistory);
        //public Task PoundTransfer(TransferViewModel transfer, PoundAccountHistory poundAccountHistory);

        public Task DollarDeposit(double amount, string accountNumber);
        public Task EuroDeposit(double amount, string accountNumber);
        //public Task PoundDeposit(double amount, string accountNumber);
        
        public Task DollarWithdrawal(double amount, string accountNumber);
        public Task EuroWithdrawal(double amount, string accountNumber);
        //public Task PoundWithdrawal(double amount, string accountNumber);
        
        
        public Task<List<DollarAccountHistory>> DollarHistory(string clientAccount);
        public Task<List<EuroAccountHistory>> EuroHistory(string clientAccount);
        //public Task<List<PoundAccountHistory>> PoundHistory(string clientAccount);

        public void TransferToHistory(TransferViewModel transfer, IAccountHistory history);
    }
}

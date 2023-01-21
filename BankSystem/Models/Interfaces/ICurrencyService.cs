using BankSystem.Models.ViewModels;

namespace BankSystem.Models.Interfaces
{
    public interface ICurrencyService
    {
        public void DollarTransfer(TransferViewModel transfer);
        public void EuroTransfer(TransferViewModel transfer);
        public void PoundTransfer(TransferViewModel transfer);
        
        public Task DollarDeposit(double amount, string accountNumber);
        public void EuroDeposit(double amount, string accountNumber);
        public void PoundDeposit(double amount, string accountNumber);
        
        public void DollarWithdrawal(double amount, string accountNumber);
        public void EuroWithdrawal(double amount, string accountNumber);
        public void PoundWithdrawal(double amount, string accountNumber);
        
        
        public IQueryable<DollarAccountHistory> DollarHistory();
        public IQueryable<EuroAccountHistory> EuroHistory();
        public IQueryable<PoundAccountHistory> PoundHistory();
    }
}

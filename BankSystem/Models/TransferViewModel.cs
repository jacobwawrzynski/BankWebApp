using BankSystem.Models.Interfaces;

namespace BankSystem.Models
{
    public class TransferViewModel : ITransfer
    {
        public double Amount { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; }
        public string BeneficiaryName { get; set; }
        public string? Address { get; set; }
        public string FromAccountNumber { get; }
        public string BeneficiaryAccountNumber { get; set; }
        public Currency Currency { get; }
    }
}

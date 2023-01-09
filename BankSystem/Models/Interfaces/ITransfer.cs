using BankSystem.Models.RelationModels;

namespace BankSystem.Models.Interfaces
{
    public interface ITransfer
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; }
        public string BeneficiaryName { get; set; }
        public string? Address { get; set; }
        public IAccount FromAccount { get; set; }
        public string BeneficiaryAccountNumber { get; set; }
        public Currency Currency { get; }
        public ICollection<Account_Transfers> Account_Transfers { get; set; }
    }
}

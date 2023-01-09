namespace BankSystem.Models.Interfaces
{
    public interface ITransactionHistory
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string BeneficiaryName { get; set; }
        public string? Address { get; set; }
        public IAccount BeneficiaryAccount { get; }
    }
}

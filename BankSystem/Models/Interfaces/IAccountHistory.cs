namespace BankSystem.Models.Interfaces
{
    public interface IAccountHistory
    {
        public string Title { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; }
        public string FromAccount { get; }
        public string BeneficiaryAccount { get; set; }
        public Currency Currency { get; }
        public string Address { get; set; }
        public string BeneficiaryName { get; set; }
    }
}

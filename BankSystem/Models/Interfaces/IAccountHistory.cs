namespace BankSystem.Models.Interfaces
{
    public interface IAccountHistory
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string BeneficiaryAccount { get; set; }
        public Currency Currency { get; }
        public string Address { get; set; }
        public string BeneficiaryName { get; set; }
    }
}

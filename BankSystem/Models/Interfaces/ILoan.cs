namespace BankSystem.Models.Interfaces
{
    public interface ILoan
    {
        public string IDnumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Currency Currency { get; set; }
        public int MonthsToPayOff { get; set; }
        public int Amount { get; set; }
        public LoanStatus Status { get; set; }
    }
}

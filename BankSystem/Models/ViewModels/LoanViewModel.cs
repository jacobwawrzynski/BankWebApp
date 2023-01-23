using BankSystem.Models.Interfaces;

namespace BankSystem.Models.ViewModels
{
    public class LoanViewModel : ILoan
    {
        public string IDnumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Currency Currency { get; set; }
        public string EmploymentType { get; set; }
        public double MonthlyIncome { get; set; }
        public int MonthsToPayOff { get; set; }
        public int Amount { get; set; }
        public LoanStatus Status { get; set; } = LoanStatus.Considered;
    }
}

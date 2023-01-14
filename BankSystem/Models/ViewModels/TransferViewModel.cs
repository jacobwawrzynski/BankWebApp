using BankSystem.Models.Interfaces;
using System.ComponentModel;

namespace BankSystem.Models.ViewModels
{
    public class TransferViewModel : IAccountHistory
    {
        [DefaultValue("Standard trasaction")]
        public string Title { get; set; }
        
        public double Amount { get; set; }

        public DateTime Date { get; set; } 

        [DisplayName("From Account")]
        public string FromAccount { get; set; }

        [DisplayName("Beneficiary Account")]
        public string BeneficiaryAccount { get; set; }
        
        public Currency Currency { get; set; }
        public string Address { get; set; } = string.Empty;
        public string BeneficiaryName { get; set; }

    }
}

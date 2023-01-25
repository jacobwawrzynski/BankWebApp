using BankSystem.Models.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [RegularExpression("^(US|GB|EU)[A-Za-z0-9 ]+$", ErrorMessage = "Provide the proper account number.")]
        public string BeneficiaryAccount { get; set; }
        
        public Currency Currency { get; set; }
        public string Address { get; set; }

        [DisplayName("Beneficiary Name")]
        public string BeneficiaryName { get; set; }

    }
}

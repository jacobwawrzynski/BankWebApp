using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BankSystem.Models
{
    public class Transfer
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [RegularExpression("^[0-9]*$")]
        public string BeneficiaryAccount { get; set; }

        [Required]
        public string BeneficiaryName { get; set; }

        public string Address { get; set; } = string.Empty;

        [Required]
        public Currency Currency { get; set; }
        
        [Required]
        [DefaultValue("Money transfer")]
        public string Title { get; set; }
        
        [Required]
        public double Amount { get; set; }
        
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
        
        public bool IsInstant { get; set; } = false;

        //One-to-one relationship with HistoryOfTransaction
        public HistoryOfTransaction Transaction { get; set; }

        // Many-to-one relationships with Accounts
        public string EuroAccountFK { get; set; }
        public EuroAccount EuroAcc { get; set; }

        public string DollarAccountFK { get; set; }
        public DollarAccount DollarAcc { get; set; }

        public string PoundAccountFK { get; set; }
        public PoundAccount PoundAcc { get; set; }
    }
}

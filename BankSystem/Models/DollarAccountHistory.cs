using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using BankSystem.Models.Interfaces;

namespace BankSystem.Models
{
    public class DollarAccountHistory : IAccountHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DefaultValue("Standard trasaction")]
        public string Title { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        public Currency Currency { get; } = Currency.Dollar;

        [Required]
        public string BeneficiaryAccount { get; set; }

        public string Address { get; set; } = string.Empty;

        [Required]
        public string BeneficiaryName { get; set; }

        // Many-to-one realationship with DollarAccount
        public string DollarAccountFK { get; set; }
        public DollarAccount DollarAcc { get; set; }
        
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using BankSystem.Models.Interfaces;

namespace BankSystem.Models
{
    public class EuroAccountHistory : IAccountHistory
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
        public Currency Currency { get; } = Currency.Euro;

        [Required]
        public string BeneficiaryAccount { get; set; }

        // Many-to-one realationship with EuroAccount
        public string EuroAccountFK { get; set; }
        public EuroAccount EuroAcc { get; set; }
    }
}

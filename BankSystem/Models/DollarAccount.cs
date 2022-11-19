using BankSystem.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BankSystem.Models
{
    public class DollarAccount : IAccount
    {
        [Key]
        [RegularExpression("^[0-9]*$")]
        public string AccountNumber { get; set; }

        [Required]
        public double Funds { get; set; }

        [Required]
        public Currency Currency { get; } = Currency.Dollar;

        // One-to-one relationship with Client
        public Client _Client { get; set; }
        public string IDnumberFK { get; set; }

        // One-to-many relationship with Account History 
        public List<DollarAccountHistory> DollarAH { get; set; }

    }
}

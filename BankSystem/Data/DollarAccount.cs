using BankSystem.Models;
using BankSystem.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BankSystem.Data
{
    public class DollarAccount : IAccount
    {
        [Key]
        [Required]
        [RegularExpression("^[A-Za-z0-9 ]+$")]
        public string AccountNumber { get; set; }

        [Required]
        public double Funds { get; set; }

        [Required]
        public Currency Currency { get; } = Currency.Dollar;

        // One-to-one relationship with Client
        public Client _Client { get; set; }
        public string ClientFK { get; set; }

        // One-to-many relationship with Account History 
        public List<DollarAccountHistory> DollarAH { get; set; }

    }
}

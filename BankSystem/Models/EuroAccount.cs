using BankSystem.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BankSystem.Models
{
    public class EuroAccount : IAccount
    {
        [Key]
        public int Id { get; set; }

        [RegularExpression("^[0-9]*$")]
        public string AccountNumber { get; set; }

        [Required]
        public double Funds { get; set; }

        [Required]
        public Currency Currency { get; } = Currency.Euro;

        // One-to-one relationship with Client
        public Client _Client { get; set; }
        public int ClientFK { get; set; }

        // One-to-many relationship with AccountHistory
        public List<EuroAccountHistory> EuroAH { get; set; }
    }
}

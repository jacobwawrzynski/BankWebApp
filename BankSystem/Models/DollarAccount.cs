using BankSystem.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Models
{
    public class DollarAccount : IAccount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public double Funds { get; set; } = 0;

        [Required]
        public Currency Currency { get; } = Currency.Dollar;

        [NotMapped]
        public ICollection<Client_Accounts> Client_Accounts { get; set; }
    }
}

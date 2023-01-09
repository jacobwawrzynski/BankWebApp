using BankSystem.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        public ITransactionHistory TransactionHistory { get; } = new DollarTransactionHistory();

    }
}

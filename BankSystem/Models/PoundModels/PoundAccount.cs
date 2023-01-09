using BankSystem.Models.Interfaces;
using BankSystem.Models.RelationModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Models.PoundModels
{
    public class PoundAccount : IAccount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public double Funds { get; set; } = 0;

        [Required]
        public Currency Currency { get; } = Currency.Pound;

        [NotMapped]
        public ICollection<Client_Accounts> Client_Accounts { get; set; }
    }
}

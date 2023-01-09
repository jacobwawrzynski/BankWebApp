using BankSystem.Models.Interfaces;
using BankSystem.Models.RelationModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Models.EuroModels 
{
    public class EuroTransfer : ITransfer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; } = DateTime.Now;

        [Required]
        public string BeneficiaryName { get; set; }

        public string? Address { get; set; }

        [Required]
        public string BeneficiaryAccountNumber { get; set; }

        [Required]
        public Currency Currency { get; } = Currency.Euro;

        [NotMapped]
        public IAccount FromAccount { get; set; }

        [NotMapped]
        public ICollection<Account_Transfers> Account_Transfers { get; set; }
    }
}

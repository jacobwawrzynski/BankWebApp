using BankSystem.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BankSystem.Models
{
    public class TransferHistory : ITransfer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        public string BeneficiaryName { get; set; }
        
        public string? Address { get; set; }
        
        [Required]
        public string FromAccountNumber { get; set; }
        
        [Required]
        public string BeneficiaryAccountNumber { get; set; }
        
        [Required]
        public Currency Currency { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using BankSystem.Models.Interfaces;

namespace BankSystem.Models
{
    public class DollarTransactionHistory : ITransactionHistory
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
        public IAccount FromAccount { get; }
        
        [Required]
        public string BeneficiaryAccountNumber { get; set; }
    }
}

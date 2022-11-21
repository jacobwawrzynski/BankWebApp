using System.ComponentModel.DataAnnotations;

namespace BankSystem.Models
{
    public class Deposit
    {
        [Required]
        public double Amount { get; set; }

        [Required]
        public string AccountNumber { get; set; }
    }
}

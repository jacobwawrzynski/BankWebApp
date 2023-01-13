using System.ComponentModel.DataAnnotations;

namespace BankSystem.Models.ViewModels
{
    public class DepositViewModel
    {
        [Required]
        public double Amount { get; set; }

        [Required]
        public string AccountNumber { get; set; }
    }
}

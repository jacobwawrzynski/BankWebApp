using System.ComponentModel.DataAnnotations;

namespace BankSystem.Models.ViewModels
{
    public class DepositViewModel
    {
        [Required]
        [Range(1, 500000, ErrorMessage = "Value must be between 1 and 500 000")]
        public double Amount { get; set; }

        [Required]
        public string AccountNumber { get; set; }
    }
}

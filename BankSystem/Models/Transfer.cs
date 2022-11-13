using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BankSystem.Models
{
    public class Transfer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string BeneficiaryAccount { get; set; }

        [Required]
        public string BeneficiaryName { get; set; }

        public string Address { get; set; } = string.Empty;

        [Required]
        public Currency Currency { get; set; }

        [Required]
        [DefaultValue("Money transfer")]
        public string Title { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public bool IsInstant { get; set; } = false;

        // Foreign key to HistoryOfTransacion
    }
}

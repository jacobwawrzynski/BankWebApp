using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BankSystem.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double DollarAccount { get; set; }

        [Required]
        public double EuroAccount { get; set; }

        [Required]
        public double PoundAccount { get; set; }

        // Foreign key to Clients
        [Required]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Provide the proper ID number")]
        [RegularExpression("^[A-Za-z0-9 ]+$", ErrorMessage = "Provide the proper ID number")]
        public string IDnumber { get; set; }
    }
}

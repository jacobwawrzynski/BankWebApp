using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BankSystem.Models
{
    public class HistoryOfTransaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DefaultValue("Standard trasaction")]
        public string Title { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public Currency Currency { get; set; }

        [Required]
        public TrasactionStatus Status { get; set; }

        // Foreign key to Clients
        [Required]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Provide the proper ID number")]
        [RegularExpression("^[A-Za-z0-9 ]+$", ErrorMessage = "Provide the proper ID number")]
        public string IDnumber { get; set; }

        // Many-to-one relationship with Accounts
        public int EuroAccountFK { get; set; }
        public EuroAccount EuroAcc { get; set; }

        public int DollarAccountFK { get; set; }
        public DollarAccount DollarAcc { get; set; }

        public int PoundAccountFK { get; set; }
        public PoundAccount PoundAcc { get; set; }


    }
}

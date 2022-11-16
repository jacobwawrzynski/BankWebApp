using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BankSystem.Models
{
    public class DollarAccount
    {
        [Key]
        [RegularExpression("^[0-9]*$")]
        public string AccountNumber { get; set; }

        [Required]
        public double DollarFunds { get; set; }

        // One-to-one relationship with Client
        public Client _Client { get; set; }
        public string IDnumberFK { get; set; }

        // One-to-many relationship with HistoryOfTrasaction
        public List<HistoryOfTransaction> Transaction { get; set; }

        // One-to-many relationship with Transfers
        public List<Transfer> Transfers { get; set; }
    }
}

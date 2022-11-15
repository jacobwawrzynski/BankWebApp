using System.ComponentModel.DataAnnotations;

namespace BankSystem.Models
{
    public class PoundAccount
    {
        [Key]
        public int AccountNumber { get; set; }

        [Required]
        public double PoundFunds { get; set; }

        // One-to-one relationship with Client
        public Client _Client { get; set; }
        public string IDnumberFK { get; set; }

        // One-to-many relationship with HistoryOfTrasaction
        public List<HistoryOfTransaction> Transaction { get; set; }
    }
}

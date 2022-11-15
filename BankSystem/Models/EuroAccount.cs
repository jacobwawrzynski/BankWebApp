using System.ComponentModel.DataAnnotations;

namespace BankSystem.Models
{
    public class EuroAccount
    {
        [Key]
        public int AccountNumber { get; set; }

        [Required]
        public double EuroFunds { get; set; }

        // One-to-one relationship with Client
        public Client _Client { get; set; }
        public string IDnumberFK { get; set; }

        // One-to-many relationship with HistoryOfTrasaction
        public List<HistoryOfTransaction> Transaction { get; set; }
    }
}

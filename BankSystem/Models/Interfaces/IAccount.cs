using System.ComponentModel.DataAnnotations;

namespace BankSystem.Models.Interfaces
{
    public interface IAccount
    {
        public string AccountNumber { get; set; }
        public double Funds { get; set; }
        public Client _Client { get; set; }
        public string IDnumberFK { get; set; }
    }
}

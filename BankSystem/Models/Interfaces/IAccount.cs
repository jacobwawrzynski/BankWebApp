using System.ComponentModel.DataAnnotations;

namespace BankSystem.Models.Interfaces
{
    public interface IAccount
    {
        public string AccountNumber { get; set; }
        public double Funds { get; set; }
        public Currency Currency { get; }
        public Client _Client { get; set; }
        public string ClientFK { get; set; }
    }
}

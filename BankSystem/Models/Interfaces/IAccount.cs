using System.ComponentModel.DataAnnotations;
using BankSystem.Models.RelationModels;

namespace BankSystem.Models.Interfaces
{
    public interface IAccount
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public double Funds { get; set; }
        public Currency Currency { get; }
        public ICollection<Client_Accounts> Client_Accounts { get; set; }
    }
}

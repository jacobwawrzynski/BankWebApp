using BankSystem.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Models.RelationModels
{
    public class Client_Accounts
    {
        [Key]
        public int Id { get; set; }

        public int ClientId { get; set; }
        public int AccountId { get; set; }

        [NotMapped]
        public Client Client { get; set; }

        [NotMapped]
        public IAccount Account { get; set; }
    }
}
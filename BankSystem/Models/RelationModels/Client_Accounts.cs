using BankSystem.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Models.RelationModels
{
    public class Client_Accounts
    {
        public int Client_ID { get; set; }
        [NotMapped]
        public Client Client { get; set; }

        public int AccountID { get; set; }
        [NotMapped]
        public IAccount Account { get; set; }
    }
}
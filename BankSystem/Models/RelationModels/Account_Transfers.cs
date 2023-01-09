using BankSystem.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Models.RelationModels
{
    public class Account_Transfers
    {
        [Key]
        public int Id { get; set; }

        public int AccountId { get; set; }
        public int TransferId { get; set; }

        [NotMapped]
        public IAccount Account { get; set; }

        [NotMapped]
        public ITransfer Transfer { get; set; }
    }
}

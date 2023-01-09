﻿using System.ComponentModel.DataAnnotations;

namespace BankSystem.Models.Interfaces
{
    public interface IAccount
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public double Funds { get; set; }
        public Currency Currency { get; }
        public ITransactionHistory TransactionHistory { get; }
    }
}

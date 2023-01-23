﻿using BankSystem.Models;
using BankSystem.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BankSystem.Data
{
    public class PoundAccount : IAccount
    {
        [Key]
        [Required]
        [RegularExpression("^[A-Za-z0-9 ]+$")]
        public string AccountNumber { get; set; }

        [Required]
        public double Funds { get; set; }

        [Required]
        public Currency Currency { get; } = Currency.Pound;

        // One-to-one relationship with Client
        public Client _Client { get; set; }
        public string ClientFK { get; set; }

        // One-to-many relationship with AccountHistory
        public List<PoundAccountHistory> PoundAH { get; set; }
    }
}

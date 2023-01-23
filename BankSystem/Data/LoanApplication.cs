﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BankSystem.Models;
using BankSystem.Models.Interfaces;

namespace BankSystem.Data
{
    public class LoanApplication : ILoan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string IDnumber { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Provide the proper forename")]
        public string Firstname { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Provide the proper lastname")]
        public string Lastname { get; set; }

        [Required]
        public Currency Currency { get; set; }

        [Required]
        public int MonthsToPayOff { get; set; }

        [Required]
        public int Amount { get; set; }

        // Many-to-one relationship with Client
        public string ClientFK { get; set; }
        public Client _Client { get; set; }
    }
}
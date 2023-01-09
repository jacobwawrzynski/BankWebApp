﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using BankSystem.Models.Interfaces;

namespace BankSystem.Models
{
    public class EuroAccountHistory : ITransactionHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DefaultValue("Money transfer")]
        public string Title { get; set; }

        [Required]
        public double Amount { get; set; }

        public string Address { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        public Currency Currency { get; } = Currency.Euro;

        [Required]
        [DisplayName("Beneficiary Name")]
        public string BeneficiaryName { get; set; }

        [Required]
        [DisplayName("Beneficiary Account")]
        public string BeneficiaryAccount { get; set; }

        // Many-to-one realationship with EuroAccount
        [DisplayName("Account Number")]
        public string EuroAccountFK { get; set; }
        public EuroAccount EuroAcc { get; set; }
    }
}

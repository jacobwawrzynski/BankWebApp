using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Models
{
    public class Client : IdentityUser
    {
        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Provide the proper ID number")]
        [RegularExpression("^[A-Za-z0-9 ]+$", ErrorMessage = "Provide the proper ID number")]
        [PersonalData]
        public string IDnumber { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Provide the proper forename")]
        [PersonalData]
        public string Firstname { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Provide the proper lastname")]
        [PersonalData]
        public string Lastname { get; set; }

        [Required]
        [PersonalData]
        public DateTime BirthDate { get; set; }

        [Required]
        [Phone]
        [PersonalData]
        public string Phone { get; set; }

        [PersonalData]
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Provide the proper city")]
        public string City { get; set; }

        [Required]
        [PersonalData]
        [StringLength(10, MinimumLength = 2)]
        public string PostalCode { get; set; }

        [PersonalData]
        public string? Street { get; set; }

        [PersonalData]
        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Provide the proper house/apartment number")]
        public string ApartmentNumber { get; set; }

        // One-to-one relationship with EuroAccount, DollarAccount, PoundAccount
        public DollarAccount DollarAcc { get; set; }
        public EuroAccount EuroAcc { get; set; }
        public PoundAccount PoundAcc { get; set; }

        // One-to-many relationship with LoanApplication
        public List<LoanApplication> LoanApplications { get; set; }
    }
}

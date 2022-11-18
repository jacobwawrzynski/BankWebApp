using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Models
{
    public class Client : IdentityUser
    {
        [NotMapped]
        [Key]
        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Provide the proper ID number")]
        [RegularExpression("^[A-Za-z0-9 ]+$", ErrorMessage = "Provide the proper ID number")]
        [PersonalData]
        public string IDnumber { get; set; }

        [NotMapped]
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Provide the proper forename")]
        [RegularExpression("^([^\\p{N}\\p{S}\\p{C}\\\\\\/]{2,20})$")]
        [PersonalData]
        public string Firstname { get; set; }

        [NotMapped]
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Provide the proper lastname")]
        [RegularExpression("^([^\\p{N}\\p{S}\\p{C}\\\\\\/]{2,20})$")]
        [PersonalData]
        public string Lastname { get; set; }

        [Required]
        [NotMapped]
        [PersonalData]
        public DateTime BirthDate { get; set; }

        [NotMapped]
        [Required]
        [Phone]
        [PersonalData]
        public string Phone { get; set; }

        [NotMapped]
        [PersonalData]
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Provide the proper city")]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Provide the proper city")]
        public string City { get; set; }

        [NotMapped]
        [Required]
        [PersonalData]
        [StringLength(10, MinimumLength = 2)]
        public string PostalCode { get; set; }

        [NotMapped]
        [PersonalData]
        [RegularExpression("^[A-Za-z0-9 ]+$", ErrorMessage = "Provide the proper street")]
        public string? Street { get; set; }

        [NotMapped]
        [PersonalData]
        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Provide the proper house/apartment number")]
        [RegularExpression("^[A-Za-z0-9 ]+$", ErrorMessage = "Provide the proper house/apartment number")]
        public string ApartmentNumber { get; set; }

        // One-to-one relationship with EuroAccount, DollarAccount, PoundAccount
        public DollarAccount DollarAcc { get; set; }
        public EuroAccount EuroAcc { get; set; }
        public PoundAccount PoundAcc { get; set; }

        // One-to-many relationship with LoanApplication
        public List<LoanApplication> LoanApplications { get; set; }
    }
}

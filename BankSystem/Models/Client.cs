using BankSystem.Models.RelationModels;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Models
{
    public class Client : IdentityUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "ID needs 4 to 10 characters")]
        [RegularExpression("[A-Za-z0-9]+$", ErrorMessage = "Provide the proper ID number")]
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

        // One-to-many relationship with ClientAccounts
        public ICollection<Client_Accounts> Client_Accounts { get; set; }

        // One-to-many relationship with LoanApplication
        public List<LoanApplication> LoanApplications { get; set; }
    }
}

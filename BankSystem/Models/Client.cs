using System.ComponentModel.DataAnnotations;

namespace BankSystem.Models
{
    public class Client
    {
        [Key]
        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Provide the proper ID number")]
        [RegularExpression("^[A-Za-z0-9 ]+$", ErrorMessage = "Provide the proper ID number")]
        public string IDnumber { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Provide the proper forename")]
        [RegularExpression("^([^\\p{N}\\p{S}\\p{C}\\\\\\/]{2,20})$")]
        public string Firstname { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Provide the proper lastname")]
        [RegularExpression("^([^\\p{N}\\p{S}\\p{C}\\\\\\/]{2,20})$")]
        public string Lastname { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Provide the proper city")]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Provide the proper city")]
        public string City { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 2)]
        public string PostalCode { get; set; }

        [RegularExpression("^[A-Za-z0-9 ]+$", ErrorMessage = "Provide the proper street")]
        public string Street { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Provide the proper house/apartment number")]
        [RegularExpression("^[A-Za-z0-9 ]+$", ErrorMessage = "Provide the proper house/apartment number")]
        public string ApartmentNumber { get; set; }

        // One-to-one relationship with EuroAccount, DollarAccount, PoundAccount
        public DollarAccount DollarAcc { get; set; }
        public EuroAccount EuroAcc { get; set; }
        public PoundAccount PoundAcc { get; set; }
    }
}

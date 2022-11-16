using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Models
{
    public class LoanApplication
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Provide the proper forename")]
        [RegularExpression("^([^\\p{N}\\p{S}\\p{C}\\p{P}]{2,20})$")]
        public string Firstname { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Provide the proper lastname")]
        [RegularExpression("^([^\\p{N}\\p{S}\\p{C}\\p{P}]{2,20})$")]
        public string Lastname { get; set; }

        [Required]
        public double NetIncome { get; set; }

        [Required]
        public string EmploymentType { get; set; }

        [Required]
        public Currency Currency { get; set; }

        [Required]
        public int MonthToPayOff { get; set; }

        [Required]
        public int Amount { get; set; }

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

        // Many-to-one relationship with Client
        public string IDnumberFK { get; set; }
        public Client _Client { get; set; }
    }
}

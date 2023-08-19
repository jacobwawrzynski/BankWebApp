using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Models
{
    public class Client
    {
        public string IdNumber { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }

        // Relations
        public IEnumerable<Account> Accounts { get; set; }
        public IEnumerable<LoanApplication> LoanApplications { get; set; }
    }
}

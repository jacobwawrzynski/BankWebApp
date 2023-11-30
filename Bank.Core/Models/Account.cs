using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Models
{
    public class Account : BaseModel
    {
        public string AccountNumber { get; set; }
        public double Balance { get; set; }
        public Currency Currency { get; set; }

        // Relations
        public string ClientFK { get; set; }
        public Client _Client { get; set; }

        public IEnumerable<AccountHistory> _AccountHistory { get; set; }
    }
}

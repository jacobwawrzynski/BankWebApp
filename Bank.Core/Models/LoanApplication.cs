using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Models
{
    public class LoanApplication : BaseModel
    {
        public int Id { get; set; }
        public string IdNumber { get; set; }
        public Currency Currency { get; set; }
        public int MonthsToPayOff { get; set; }
        public int Amount { get; set; }

        // Relations
        public string ClientFK { get; set; }
        public Client _Client { get; set; }
    }
}

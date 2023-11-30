using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Models
{
    public class AccountHistory : BaseModel
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string FromAccount { get; set; }
        public Currency Currency { get; set; }

        // Relations
        public string AccountFK { get; set; }
        public Account _Account { get; set; }
    }
}

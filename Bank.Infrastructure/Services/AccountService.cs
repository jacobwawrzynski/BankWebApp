using Bank.Core.Models;
using Bank.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        public Task<bool> CreateAsync(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Account?> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Account? account)
        {
            throw new NotImplementedException();
        }
    }
}

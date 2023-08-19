using Bank.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infrastructure.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllAsync();
        Task<Account?> GetByIdAsync(string id);
        Task<bool> CreateAsync(Account account);
        Task<bool> UpdateAsync(Account? account);
        Task<bool> DeleteAsync(string id);
    }
}

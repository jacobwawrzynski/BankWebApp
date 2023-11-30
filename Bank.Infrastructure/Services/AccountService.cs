using Bank.Core.Models;
using Bank.Infrastructure.DataContext;
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
        private IBaseRepository<Account> _accountRepo;
        
        public AccountService(IBaseRepository<Account> accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public async Task<bool> CreateAsync(Account account)
        {
            return await _accountRepo.CreateAsync(account);
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            var account = await _accountRepo.GetByAsync(id);
            return await _accountRepo.DeleteAsync(account);
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _accountRepo.GetAllAsync();
        }

        public async Task<Account?> GetByAsync(int? id)
        {
            return await _accountRepo.GetByAsync(id);
        }

        public async Task<bool> UpdateAsync(int? id, Account accountUpdate)
        {
            var account = await _accountRepo.GetByAsync(id);
            account.Balance = accountUpdate.Balance;
            return await _accountRepo.UpdateAsync(account);
        }
    }
}

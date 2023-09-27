using Bank.Core.Models;
using Bank.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infrastructure.Services
{
    public class LoanService : ILoanService
    {
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LoanApplication>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LoanApplication> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync(LoanApplication loanApplication)
        {
            throw new NotImplementedException();
        }
    }
}

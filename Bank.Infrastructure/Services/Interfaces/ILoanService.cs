using Bank.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infrastructure.Services.Interfaces
{
    public interface ILoanService
    {
        public Task<IEnumerable<LoanApplication>> GetAllAsync();
        public Task<LoanApplication> GetByIdAsync(int? id);
        public Task<bool> CreateAsync(LoanApplication loanApplication);
        public Task<bool> DeleteAsync(int? id);
    }
}

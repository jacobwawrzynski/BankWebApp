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
        private IBaseRepository<LoanApplication> _loanRepo;

        public LoanService(IBaseRepository<LoanApplication> loanRepo)
        {
            _loanRepo = loanRepo;
        }

        public async Task<bool> CreateAsync(LoanApplication loanApplication)
        {
            return await _loanRepo.CreateAsync(loanApplication);
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            var loan = await _loanRepo.GetByIdAsync(id);
            return await _loanRepo.DeleteAsync(loan);
        }

        public async Task<IEnumerable<LoanApplication>> GetAllAsync()
        {
            return await _loanRepo.GetAllAsync();
        }

        public async Task<LoanApplication> GetByIdAsync(int? id)
        {
            return await _loanRepo.GetByIdAsync(id);
        }
    }
}

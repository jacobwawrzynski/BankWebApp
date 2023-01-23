using BankSystem.Data;
using BankSystem.Models.Interfaces;
using BankSystem.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Models
{
	public class LoanService : ILoanService
	{
		private readonly ApplicationDbContext _context;
		public LoanService(ApplicationDbContext context)
		{
			_context = context;
		}

        public async Task<bool> Accept(int? id)
        {
            try
			{
				var loan = await _context.LoanApplications.FindAsync(id);
				if (loan is not null)
				{
					loan.Status = LoanStatus.Accepted;
					_context.Update(loan);
					await _context.SaveChangesAsync();
					return true;
				}
				return false;
			}
			catch (DbUpdateConcurrencyException)
			{

				return false;
			}
		}

        public async Task<bool> Decline(int? id)
        {
            try
            {
                var loan = await _context.LoanApplications.FindAsync(id);
                if (loan is not null)
                {
                    loan.Status = LoanStatus.Declined;
                    _context.Update(loan);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (DbUpdateConcurrencyException)
            {

                return false;
            }
        }

        public async Task<LoanApplication?> FindBy(int? id)
        {
            return id is null ? null : await _context.LoanApplications.FindAsync(id);
        }

        public async Task<ICollection<LoanApplication>> GetAllLoans()
        {
            return await _context.LoanApplications.ToListAsync();
        }

        public async Task SendLoanApplication(LoanViewModel loanModel, string clientId)
		{
			var loanApplication = new LoanApplication();

			loanApplication.IDnumber = loanModel.IDnumber;
			loanApplication.Firstname = loanModel.Firstname;
			loanApplication.Lastname = loanModel.Lastname;
			loanApplication.Currency = loanModel.Currency;
			loanApplication.EmploymentType = loanModel.EmploymentType;
			loanApplication.MonthlyIncome = loanModel.MonthlyIncome;
			loanApplication.Amount = loanModel.Amount;
			loanApplication.MonthsToPayOff = loanModel.MonthsToPayOff;
			loanApplication.Status = LoanStatus.Considered;
			loanApplication.ClientFK = clientId;

			_context.Add(loanApplication);
			await _context.SaveChangesAsync();
		}

		//public bool ChangeStatus(int? id)
		//{

		//}

		//public async Task<bool> Update(LoanApplication loan)
		//{
		//	try
		//	{
		//		var find = await _context.LoanApplications.FindAsync(loan.Id);
		//		if (find is not null)
		//		{
		//			find.Amount = loan.Amount;
		//			find.MonthlyIncome = loan.MonthlyIncome;
		//			find.MonthsToPayOff = loan.MonthsToPayOff;
		//			await _context.SaveChangesAsync();
		//			return true;
		//		}
		//		return false;
		//	}
		//	catch (DbUpdateConcurrencyException)
		//	{

		//		return false;
		//	}
		//}
    }
}

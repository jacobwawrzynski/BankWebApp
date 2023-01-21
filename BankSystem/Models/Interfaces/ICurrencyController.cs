using BankSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Models.Interfaces
{
    public interface ICurrencyController
    {
        // GET
        Task<IActionResult> History();
        IActionResult Transfer();
        IActionResult Deposit();
        IActionResult Withdrawal();
        
        // POST
        Task<IActionResult> Transfer([FromForm] TransferViewModel transfer);
        Task<IActionResult> Deposit([FromForm] double amount, [FromForm] string accountNumber);
        Task<IActionResult> Withdrawal([FromForm] double amount, [FromForm] string accountNumber);
    }
}

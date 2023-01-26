using BankSystem.Data;
using BankSystem.Models.Interfaces;
using BankSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanApplicationRESTController : ControllerBase
    {
        private readonly ILoanService _loanService;
        public LoanApplicationRESTController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        // GET: api/<LoanApplicationRESTController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getAllLoans = await _loanService.GetAllLoans();
            if (getAllLoans is not null)
            {
                return Ok(getAllLoans);
            }
            return BadRequest();
        }

        // GET api/<LoanApplicationRESTController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var loanApplication = await _loanService.FindBy(id);
            if (loanApplication is not null)
            {
                return new OkObjectResult(loanApplication);
            }
            return BadRequest();
        }

        // POST api/<LoanApplicationRESTController>
        [HttpPost]
        public async Task<IActionResult> Post(LoanViewModel loanModel, string clientId)
        {
            await _loanService.SendLoanApplication(loanModel, clientId);
            return Created("", loanModel);

        }

        // PUT api/<LoanApplicationRESTController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(LoanApplication loanApplication)
        {
            var isUpdated = await _loanService.Update(loanApplication);
            if (isUpdated)
            {
                return Ok();
            }
            return BadRequest();
        }

        // DELETE api/<LoanApplicationRESTController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _loanService.Delete(id);
            if (isDeleted)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}

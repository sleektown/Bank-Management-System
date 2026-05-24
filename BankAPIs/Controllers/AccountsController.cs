using Bank_Management_System.Exceptions;
using Bank_Management_System.Models;
using BankAPIs.DTOs;
using BankAPIs.Exceptions;
using BankAPIs.Interfaces;
using BankAPIs.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace BankAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("deposit")]
        public IActionResult Deposit(DepositRequestDto depositRequest)
        {
            decimal updatedBalance = _accountService.Deposit(depositRequest.AccountNumber, depositRequest.Amount);

            return Ok(new
            {
                Message = "Amount deposited successfully.",
                AccountNumber = depositRequest.AccountNumber,
                UpdatedBalance = updatedBalance
            });
        }

        [HttpPost("withdraw")]
        public IActionResult Withdraw(WithdrawRequestDto withdrawRequest)
        {
            decimal updatedBalance; 
            try
            {
                updatedBalance = _accountService.Withdraw(withdrawRequest.AccountNumber, withdrawRequest.Amount);
            }
            catch (InsufficientBalanceException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (InvalidAmountException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (MinimumBalanceViolationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (OverdraftLimitExceededException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (AccountNotFoundException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "An unexpected error occurred."
                });
            }

            return Ok(new
            {
                Message = "Amount withdrawn successfully.",
                AccountNumber = withdrawRequest.AccountNumber,
                UpdatedBalance = updatedBalance
            });
        }
    }
}

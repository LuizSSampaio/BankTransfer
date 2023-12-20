using BankTransfer.Data;
using BankTransfer.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankTransfer.Controllers;

public class AccountController(Account account, BankTransferDbContext context) : Controller
{
    [HttpGet]
    public IActionResult GetAccount()
    {
        return Ok(account);
    }

    [HttpGet]
    public IActionResult GetBalance()
    {
        return Ok(account.Balance);
    }

    [HttpPost]
    public IActionResult TransferMoney([FromBody] double amount, [FromBody] string identifier)
    {
        var senderAccount = context.Accounts.Find(account.Identifier);
        var receiverAccount = context.Accounts.Find(identifier);
        
        if (receiverAccount == null || senderAccount == null)
        {
            return NotFound("Account not found");
        }

        var currentAccountTypeValue = context.Entry(senderAccount).Property("Discriminator").CurrentValue;
        if (currentAccountTypeValue == null) return NotFound("Account type not found");
        
        var accountType = currentAccountTypeValue.ToString();
        if (accountType == "Store")
        {
            return BadRequest("Invalid account type");
        }
        
        if (senderAccount.Balance < amount)
        {
            return BadRequest("Insufficient funds");
        }
        
        senderAccount.RemoveMoney(amount);
        receiverAccount.ReceiveMoney(amount);
        
        context.SaveChanges();

        return Ok();
    }

    [HttpPost]
    public IActionResult Login([FromBody] string identifier, [FromBody] string password)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult Register([FromBody] string identifier, [FromBody] string fullName, [FromBody] string email,
        [FromBody] string password)
    {
        return Ok();
    }
}
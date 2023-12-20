using BankTransfer.Services;

namespace BankTransfer.Models;

public class User : Account
{
    // Identifier -> CPF
    public User(string identifier, string fullName, string email) : base(identifier, fullName, email)
    {
    }

    public void SendMoney(double amount, Account account)
    {
        // Validations
        if (!(Balance >= amount)) return;
        if (!ValidateTransfer.Check().Result) return;
        
        Balance -= amount;
        account.ReceiveMoney(amount);
    }
}
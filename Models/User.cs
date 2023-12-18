using BankTransfer.Services;

namespace BankTransfer.Models;

public class User(string fullName, string email, string cpf) : Account(fullName, email)
{
    string CPF { get; set; } = cpf;
    
    public void SendMoney(double amount, Account account)
    {
        // Validations
        if (!(Balance >= amount)) return;
        if (!ValidateTransfer.Check().Result) return;
        
        Balance -= amount;
        account.ReceiveMoney(amount);
    }
}
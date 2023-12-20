using BankTransfer.Services;

namespace BankTransfer.Models;

public class User : Account
{
    // Identifier -> CPF
    public User(string identifier, string fullName, string email) : base(identifier, fullName, email)
    {
    }
}
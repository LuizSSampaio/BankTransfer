namespace BankTransfer.Models;

public class Store : Account
{
    // Identifier -> CNPJ
    public Store(string identifier, string fullName, string email) : base(identifier, fullName, email)
    {
    }
}
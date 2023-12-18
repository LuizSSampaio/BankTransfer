namespace BankTransfer.Models;

public class Store(string fullName, string email, string CNPJ) : Account(fullName, email)
{
    string CNPJ { get; set; } = CNPJ;
}
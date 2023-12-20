using System.ComponentModel.DataAnnotations;
using BankTransfer.Services;
using Microsoft.AspNetCore.Identity;

namespace BankTransfer.Models;

public abstract class Account
{
    [Key]
    public string Identifier { get; private set; }

    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string? Password { get; private set; }
    private readonly PasswordHasher<Account> _passwordHasher = new();
    public double Balance { get; protected set; }
    
    protected Account(string identifier, string fullName, string email, string? password = null)
    {
        Identifier = identifier;
        FullName = fullName;
        Email = email;
        if (password != null)
        {
            Password = _passwordHasher.HashPassword(this, password);
        }
    }

    public void RemoveMoney(double amount)
    {
        Balance -= amount;
    }
    
    public void ReceiveMoney(double amount)
    {
        Notification.Send();
        Balance += amount;
    }
}
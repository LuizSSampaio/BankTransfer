using System.ComponentModel.DataAnnotations;
using BankTransfer.Services;

namespace BankTransfer.Models;

public abstract class Account(string identifier, string fullName, string email)
{
    [Key]
    public string Identifier { get; private set; } = identifier;

    public string FullName { get; private set; } = fullName;
    public string Email { get; private set; } = email;
    public double Balance { get; protected set; }

    public void ReceiveMoney(double amount)
    {
        Notification.Send();
        Balance += amount;
    }
}
using BankTransfer.Services;

namespace BankTransfer.Models;

public abstract class Account(string fullName, string email)
{
    public string FullName { get; } = fullName;
    public string Email { get; } = email;
    public double Balance { get; protected set; }

    public void ReceiveMoney(double amount)
    {
        Notification.Send();
        Balance += amount;
    }
}
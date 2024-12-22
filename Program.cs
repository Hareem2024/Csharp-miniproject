using System;
using System.Collections.Generic;
class User
{
    public string Username;
    public DateTime DateOfBirth;
    public decimal Balance;
    public int AccountNumber;
}

class Bank
{
    private List<User> users;
    private int nextAccountNumber;

    public Bank()
    {
        users = new List<User>();
        nextAccountNumber = 1;
    }

    static void Main()
    {
        Bank bank = new Bank();

        // Register 
        string username = "Reem";
        DateTime dateOfBirth = new DateTime(2000, 07, 11);

        User user = new User();
        user.Username = username;
        user.DateOfBirth = dateOfBirth;
        user.Balance = 0;
        user.AccountNumber = bank.nextAccountNumber++;
        int userIndex = bank.users.Count; 
        bank.users.Add(user);  
        for (int i = bank.users.Count - 1; i > userIndex; i--)
        {
            bank.users[i] = bank.users[i - 1]; 
        }
        bank.users[userIndex] = user; 

        Console.WriteLine("Account Number: " + user.AccountNumber + ", Username: " + user.Username);

        // Deposit 
        int accountNumber = 1;
        decimal depositAmount = 1000;
        for (int i = 0; i < bank.users.Count; i++)
        {
            if (bank.users[i].AccountNumber == accountNumber)
            {
                bank.users[i].Balance += depositAmount;
                Console.WriteLine("Initial Balance for " + bank.users[i].Username + ": " + bank.users[i].Balance);
                break;
            }
        }

        // Withdraw 
        decimal withdrawAmount = 200;
        for (int i = 0; i < bank.users.Count; i++)
        {
            if (bank.users[i].AccountNumber == accountNumber && bank.users[i].Balance >= withdrawAmount)
            {
                bank.users[i].Balance -= withdrawAmount;
                Console.WriteLine("Balance for " + bank.users[i].Username + " after withdrawal: " + bank.users[i].Balance);
                break;
            }
        }

        // Deregister 
        bool userRemoved = false;
        for (int i = 0; i < bank.users.Count; i++)
        {
            if (bank.users[i].AccountNumber == accountNumber)
            {
    
                for (int j = i; j < bank.users.Count - 1; j++)
                {
                    bank.users[j] = bank.users[j + 1];
                }
                bank.users.RemoveAt(bank.users.Count - 1); 
                userRemoved = true;
                Console.WriteLine("User " + username + " deregistered successfully.");
                break;
            }
        }

        if (!userRemoved)
        {
            Console.WriteLine("Failed to deregister user.");
        }
        decimal balanceAfterDeregistration = 0;
        for (int i = 0; i < bank.users.Count; i++)
        {
            if (bank.users[i].AccountNumber == accountNumber)
            {
                balanceAfterDeregistration = bank.users[i].Balance;
                break;
            }
        }

        Console.WriteLine("Balance for " + username + " after deregistration (should not exist): " + balanceAfterDeregistration);
    }
}
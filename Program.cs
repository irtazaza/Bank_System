using System;
using System.IO;
using System.Text;



//Base Class Account
public abstract class Account
{
    //Data Members
    public string AccountName
    {
        get;
        protected set;
    }
    public decimal Balance
    {
        get;
        protected set;
    }


    //Constructor
    public Account(string accountName, decimal balance)
    {
        this.AccountName = accountName;
        this.Balance = balance;
    }


    //Deposit
    public abstract void deposit(decimal amount);


    //Withdraw
    public abstract void withdraw(decimal amount);


    //Display Balance
    public void displayBalance()
    {
        Console.WriteLine($"Balance = ${Balance}. \n\nPress any key to continue...");
    }
}



//Derived Class Basic Account
public class BasicAccount : Account
{
    public BasicAccount(string accountName, decimal balance) : base(accountName, balance) { }


    //Override deposit method
    public override void deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("\nDeposit an amount greater than 0 ('-__-). \n\nPress any key to continue...");
            return;
        }
        Balance += amount;
        Console.WriteLine($"${amount} deposited successfully (^--^). \n\nPress any key to continue...");
    }


    //Override withdraw method
    public override void withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine("\nInsufficient funds ('-__-). \n\nPress any key to continue...");
            return;
        }
        if (amount <= 0)
        {
            Console.WriteLine("\nWithdrawal amount has to be greater than 0 ('-__-). \n\nPress any key to continue...");
            return;
        }
        Balance -= amount;
        Console.WriteLine($"${amount} withdrew successfully (^--^). \n\nPress any key to continue...");
    }
}



//Program class
class Program
{

    //Register function
    static void Register()
    {
        Console.WriteLine("== Register an account ==");
        Console.WriteLine("Enter username: ");
        string username = Console.ReadLine();
        Console.WriteLine("Enter password: ");
        string password = Console.ReadLine();
        Console.WriteLine("Re-enter password to confirm: ");
        string confirmPassword = Console.ReadLine();
        

        if (confirmPassword != password)
        {
            Console.WriteLine("\nPasswords do not match. Press any key to continue.");
            Console.ReadKey();
            return;
        }


        //Check if user is available
        string[] lines = File.Exists("users.txt") ? File.ReadAllLines("users.txt") : new string[0];
        foreach (string line in lines) {

            string[] part = line.Split(',');

            if (part[0] == username)
            {
                Console.WriteLine("Username already exists. Try a different username.\nPress any key to continue...");
                Console.ReadKey();
                return;
            }
        }


        //Save file
        using (StreamWriter sw = File.AppendText("accounts.txt"))
        {
            sw.WriteLine($"{username}, {password}");
        }

        Console.WriteLine($"\nAccount \"{username}\" created succesfully.\nPress any key to continue...");
        Console.ReadKey();
    }

    static void Main(string[] args)
    {

        //Registration Module
        Console.Clear();
        Console.WriteLine("== Welcome to the Banking System ==");
        Console.WriteLine("1. Register");
        Console.WriteLine("2. Exit");

        Console.Write("\nChoose an option: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":   
                Register();
                break;
            case "2":
                Console.WriteLine("Goodbye!");
                return;
            default:
                Console.WriteLine("Invalid choice. Press any key...");
                Console.ReadKey();
                break;
        }



        /* Old module
         * 
         * 
        Console.Write("Enter your name: ");
        string name;
        string input;
        name = Console.ReadLine();

        BasicAccount account = new BasicAccount(name, 0);


        while (true)
        {

            Console.Clear();
            Console.WriteLine("(=__=) Banking System (=__=)");
            Console.WriteLine($"Welcome, {name} (^--^) !\n");
            Console.WriteLine("\n1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. View Balance");
            Console.WriteLine("4. Exit");

            Console.Write("\nSelect an option (1-4): ");
            input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    Console.Write("Enter an amount to deposit: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                    {
                        account.deposit(depositAmount);
                    }
                    else
                    {
                        Console.WriteLine("\nEnter a valid amount ('-__-). \n\nPress any key to continue...");
                    }
                    break;

                case "2":
                    Console.Write("Enter an amount to withdraw: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                    {
                        account.withdraw(withdrawAmount);
                    }
                    else
                    {
                        Console.WriteLine("\nEnter a valid amount ('-__-). \n\nPress any key to continue...");
                    }
                    break;

                case "3":
                    account.displayBalance();
                    break;

                case "4":
                    Console.WriteLine("Thank you for using our banking system (^--^). \n\nPress any key to exit...");
                    Console.ReadKey();
                    return;

                default:
                    Console.WriteLine("\nInvalid option ('-__-). \n\nPress any key to continue...");
                    break;
            }
            Console.ReadKey();
            Console.Clear();
        }*/
    }
        
}

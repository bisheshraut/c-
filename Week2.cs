using System;

namespace SimpleBankSystemApp
{
    class Program
    {
        // Store account balance
        static double balance = 0.0;

        // Correct PIN for login
        static string correctPin = "1234";

        static void Main(string[] args)
        {
            // Attempt counter for PIN login
            int attempts = 0;
            bool accessGranted = false;

            // Login system: user has 3 attempts
            while (attempts < 3)
            {
                Console.Write("Enter your PIN: ");
                string enteredPin = Console.ReadLine();

                if (enteredPin == correctPin)
                {
                    accessGranted = true;
                    break; // PIN correct, exit login loop
                }
                else
                {
                    attempts++;
                    Console.WriteLine("Incorrect PIN. Attempts left: " + (3 - attempts));
                }
            }

            // Lock the system if PIN failed 3 times
            if (!accessGranted)
            {
                Console.WriteLine("Too many incorrect attempts. Your account is locked.");
                return; // Exit the program
            }

            // Main menu loop
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n===== Simple Banking System =====");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                // Switch handles menu selection
                switch (choice)
                {
                    case "1":
                        Deposit(); // Call deposit function
                        break;

                    case "2":
                        Withdraw(); // Call withdraw function
                        break;

                    case "3":
                        CheckBalance(); // Call balance function
                        break;

                    case "4":
                        exit = true;
                        Console.WriteLine("Thank you for using Simple Bank System.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        // Deposit money into account
        static void Deposit()
        {
            Console.Write("Enter amount to deposit: ");
            double amount;

            // Validate user input: must be a positive number
            if (double.TryParse(Console.ReadLine(), out amount) && amount > 0)
            {
                balance += amount;
                Console.WriteLine("Deposit successful. New balance: $" + balance);
            }
            else
            {
                Console.WriteLine("Invalid amount. Deposit must be a positive number.");
            }
        }

        // Withdraw money from account
        static void Withdraw()
        {
            Console.Write("Enter amount to withdraw: ");
            double amount;

            // Validate input: must be positive
            if (double.TryParse(Console.ReadLine(), out amount) && amount > 0)
            {
                // Check if sufficient balance is available
                if (amount <= balance)
                {
                    balance -= amount;
                    Console.WriteLine("Withdrawal successful. New balance: $" + balance);
                }
                else
                {
                    Console.WriteLine("Error: Insufficient balance.");
                }
            }
            else
            {
                Console.WriteLine("Invalid amount. Withdrawal must be a positive number.");
            }
        }

        // Check current balance
        static void CheckBalance()
        {
            Console.WriteLine("Your current balance is: $" + balance);
        }
    }
}

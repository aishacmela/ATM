using System;

using System;
using System.Collections.Generic;

public class CardHolder
{
    string cardId;
    int pin;
    string firstName;
    string lastName;
    double balance;

    // Constructor to initialize the card holder details
    public CardHolder(string cardId, int pin, string firstName, string lastName, double balance)
    {
        this.cardId = cardId;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    // Get methods to retrieve private attributes
    public string GetCardId() => cardId;
    public int GetPin() => pin;
    public string GetFirstName() => firstName;
    public string GetLastName() => lastName;
    public double GetBalance() => balance;

    // Set methods to update private attributes
    public void SetCardId(string newCardId) => cardId = newCardId;
    public void SetPin(int newPin) => pin = newPin;
    public void SetFirstName(string newFirstName) => firstName = newFirstName;
    public void SetLastName(string newLastName) => lastName = newLastName;
    public void SetBalance(double newBalance) => balance = newBalance;

    // Main method to run the ATM program
    public static void Main(string[] args)
    {
        void PrintOptions()
        {
            Console.WriteLine("Please choose from one of the options:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        // Method to handle deposit
        void Deposit(CardHolder currentUser)
        {
            Console.WriteLine("How much would you like to deposit?");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.SetBalance(currentUser.GetBalance() + deposit);
            Console.WriteLine("Thank you for your deposit. Your new balance is: " + currentUser.GetBalance());
        }

        // Method to handle withdrawal
        void Withdraw(CardHolder currentUser)
        {
            Console.WriteLine("How much would you like to withdraw?");
            double withdraw = Double.Parse(Console.ReadLine());

            // Check if the user has enough funds
            if (currentUser.GetBalance() < withdraw)
            {
                Console.WriteLine("Insufficient funds :(");
            }
            else
            {
                currentUser.SetBalance(currentUser.GetBalance() - withdraw);
                Console.WriteLine("Withdrawal successful. Your new balance is: " + currentUser.GetBalance());
            }
        }

        // Method to check balance
        void ShowBalance(CardHolder currentUser)
        {
            Console.WriteLine("Your current balance is: " + currentUser.GetBalance());
        }
        

        // Sample data for testing
        List<CardHolder> cardHolders = new List<CardHolder>
        {
            new CardHolder("1234567890", 1234, "John", "Doe", 500.00),
            new CardHolder("0987654321", 4321, "Jane", "Smith", 1500.00)
        };

        // Simulate the ATM functionality
        Console.WriteLine("Welcome to the ATM");
       
        CardHolder currentUser = null;

        while (currentUser == null)
        {
            Console.WriteLine("Enter your Card ID: ");
            string cardId = Console.ReadLine();
            //search card id from cardHolders list
            currentUser = cardHolders.Find(currentUser => currentUser.GetCardId() == cardId); 
            
            if (currentUser == null)
            {
                Console.WriteLine("Card not recognised, Please try again.");
            }
            else
            {
                bool aunthenticate = false;

                while (!aunthenticate) // continue looping until the user is authenticated 
                {
                    //propmt for pin and authenticate
                    Console.WriteLine("Enter your pin: ");
                    int pin = int.Parse(Console.ReadLine());

                   

                    if (currentUser.GetPin() == pin)
                    {
                        aunthenticate = true; //can handle atm options

                        //display welcome message
                        Console.WriteLine($"Welcome {currentUser.GetFirstName()} {currentUser.GetLastName()}!");
                        
                        int options = 0;

                        while(options != 4)
                        {
                            
                            PrintOptions();
                            options = int.Parse(Console.ReadLine());

                            switch (options)
                            {
                                case 1: Deposit(currentUser);
                                    break;
                                case 2: Withdraw(currentUser);
                                    break;
                                case 3: ShowBalance(currentUser);
                                    break;
                                case 4: Console.WriteLine("Thank you for using our ATM. Goodbye :)");
                                    //to go back to login enter id and pin
                                    currentUser = null;
                                    break;
                                default: Console.WriteLine("Invalid Option. Please try again.");
                                    break;
                            }      
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Pin. Please try again.");
                    }
                }
            }
        }
    }
}


using System;

public class cardHolder
{
    string cardId;
    int pin;
    string firstName;
    string lastName;
    double balance;

    //Initialize constructor and take all the variables created and pass all the them as parameters to the function and instantiate them as new objects
    public cardHolder(string cardId, int pin, string firstName, string lastName, double balance)
    {
        this.cardId = cardId;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    //define get method
    public string getCardId()
    {
        return cardId;
    }

    public int getPin()
    {
        return pin;
    }
    public string getFirstName()
    {
        return firstName;
    }
    public string getLastName()
    {
        return lastName;
    }
    public double getBalance()
    {
        return balance;
    }

    //define set functions

    public void setCardId(string newCardId)
    {
        cardId = newCardId;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }
    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }

    public static void Main(string[] args)
    {
        void printOptionss()
        {
            Console.WriteLine("Please choose from one the options: \n 1. Deposit \n 2. Withdraw \n 3. Show Balance \n 4. Exit ");

        }

        //handle deposit and pass in the user
        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to deposit");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.balance += deposit;
            Console.WriteLine("Thank you for using out Atm, your new balance is: " + currentUser.getBalance());

        }
        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to withdraw.?");
            double withdraw = Double.Parse(Console.ReadLine());
            //check if the user have enought money

            if (currentUser.getBalance() < withdraw)
            {
                Console.WriteLine("Insufficient funds :(");
            } else
            {
                currentUser.balance = withdraw;
            }

        }
    }


}


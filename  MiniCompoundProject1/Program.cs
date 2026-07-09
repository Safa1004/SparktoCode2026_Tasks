namespace MiniCompoundProject1;



class Program
{
    static void Main(string[] args)
    { 
        //Store more than one customer (list)
        List<string> customerNames = new List<string>();
        List<string> accountNumbers = new List<string>();
        List<double> balances = new List<double>();
        
        //Gathering customer info --first step 
        Console.Write("Enter customer name: ");
        string customerName = Console.ReadLine();
        Console.Write("Enter account number: ");
        string accountNumber = Console.ReadLine();
        Console.Write("Enter starting balance: ");
        double startingBalance = double.Parse(Console.ReadLine());
        
        Console.WriteLine("\n--- Account Created ---");
        Console.WriteLine($"Name: {customerName}");
        Console.WriteLine($"Account Number:{accountNumber} ");
        Console.WriteLine($"Balance: {startingBalance}");
        
        // .Add() puts the new value onto the end of the list
        // adding to all 3 lists right after each other, in the same order 
        // so they stay the same length and stay lined up
        customerNames.Add(customerName);
        accountNumbers.Add(accountNumber);
        balances.Add(startingBalance);
    }

}
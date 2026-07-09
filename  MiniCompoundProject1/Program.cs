namespace MiniCompoundProject1;



class Program
{
    static void Main(string[] args)
    { 
        //Gathering customer info 
        Console.Write("Enter customer name: ");
        string customerName = Console.ReadLine();
        Console.Write("Enter account number: ");
        string accountNumber = Console.ReadLine();
        Console.Write("Enter starting balance: ");
        double balance = double.Parse(Console.ReadLine());
        
        Console.WriteLine("\n--- Account Created ---");
        Console.WriteLine($"Name: {customerName}");
        Console.WriteLine($"Account Number:{accountNumber} ");
        Console.WriteLine($"Balance: {balance}");
    }

}
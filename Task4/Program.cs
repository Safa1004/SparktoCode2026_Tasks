namespace Task4;

class Program
{
    //Task 1 ( Personalized Welcome Function)
    public static void PrintWelcome(string name)
    {
        Console.WriteLine($"Welcome balck! {name}");
        
    }
    static void Main(string[] args)
    {
        Console.Write("Enter your name: ");
        string userName = Console.ReadLine();
        PrintWelcome(userName);
        
    }
}
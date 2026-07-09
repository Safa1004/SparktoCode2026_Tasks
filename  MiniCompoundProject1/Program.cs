namespace MiniCompoundProject1;




internal class Program 

{
    
    // moving the 3 lists OUTSIDE of Main, straight into the class itself, and marking them "static"
    // why: if AddAccount() is going to be its own separate function,
    // it needs to be able to reach these lists too - not just Main
    // if the lists stayed inside Main, AddAccount() wouldn't be able
    // to see them at all. making them static + class-level means
    // EVERY function in this class shares the exact same lists,
    // no need to pass them around as parameters.
    public static List<string> customerNames = new List<string>();
    public static List<string> accountNumbers = new List<string>();
    public static List<double> balances = new List<double>();
    
    public static void Main(string[] args)
    { 
        bool exitApp = false;

        while (!exitApp)
        {
            // !exitApp means "while exitApp is NOT true" - so this
            // loop keeps repeating for as long as exitApp is false.
            Console.WriteLine("\n===== Welcome to Spark Bank =====");
            Console.WriteLine("1. Add New Account");
            Console.WriteLine("2. Exit");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddAccount();
                    break;
                case 2:
                    exitApp = true;
                    Console.WriteLine("Thank you for banking with Spark Bank. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option, please choose between 1 and 2.");
                    break;

            }
            
        }
        
        
        
        // Add Account" out into its own function
        // it's "void" because it doesn't need to return something 
        // it takes NO parameters, because it doesn't need any info
        // passed in - it asks the console directly for whatever it
        public static void AddAccount()
        {
            // gather customer info 
            Console.Write("Enter customer name: ");
            string customerName = Console.ReadLine();

            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            Console.Write("Enter starting balance: ");
            double startingBalance = double.Parse(Console.ReadLine());
            
            // .Add() puts the new value onto the end of the list
            // adding to all 3 lists right after each other, in the same order 
            // so they stay the same length and stay lined up

            customerNames.Add(customerName);
            accountNumbers.Add(accountNumber);
            balances.Add(startingBalance);
            Console.WriteLine("Account created successfully!");
            
        }

        
        
        
        
        
        
        
        
    }

}
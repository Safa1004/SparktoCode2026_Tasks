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
    
    static void Main(string[] args)
    { 
        
        
        //Add more than one account in the same run
        //let the user add however many accounts they want, then print all of them at the end
        Console.Write("How many accounts do you want to add? ");
        int numberOfAccounts = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfAccounts; i++)
        {
            // this whole block repeats once per account, exactly
            // numberOfAccounts times. i counts 0, 1, 2... up to
            // (numberOfAccounts - 1).
            Console.WriteLine("\n--- Account " + (i + 1) + " ---");
            AddAccount(); // calling the function 
            
            
            
        }
        // now printing ALL accounts, not just the last one entered
        // this needs its OWN loop, separate from the one above,
        // because by this point all the data is already collected -
        // I'm just reading it back out of the lists.
        Console.WriteLine("\n--- All Accounts ---");
        for (int i = 0; i < customerNames.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + customerNames[i] + " | Acc#: " + accountNumbers[i] + " | Balance: " +
                              balances[i]);
            // customerNames[i], accountNumbers[i], balances[i] - same
            // index i pulls the matching piece out of each list, so
            // this line prints one full account per loop pass.
            
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
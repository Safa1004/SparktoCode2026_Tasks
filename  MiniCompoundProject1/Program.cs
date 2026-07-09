namespace MiniCompoundProject1;



class Program
{
    static void Main(string[] args)
    { 
        //Store more than one customer (list)
        List<string> customerNames = new List<string>();
        List<string> accountNumbers = new List<string>();
        List<double> balances = new List<double>();
        
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
            //Gathering customer info
            Console.Write("Enter customer name: ");
            string customerName = Console.ReadLine();

            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            Console.Write("Enter starting balance: ");
            double startingBalance = double.Parse(Console.ReadLine());
            
            // .Add() puts the new value onto the end of the list
            // adding to all 3 lists right after each other, in the same order 
            // so they stay the same length and stay lined up
            // repeats 
            customerNames.Add(customerName);
            accountNumbers.Add(accountNumber);
            balances.Add(startingBalance);
            
            
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
        
        
        
        
        
        
        
        
    }

}
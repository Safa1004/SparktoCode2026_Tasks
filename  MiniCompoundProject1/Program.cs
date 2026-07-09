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
                    DepositMoney();
                    break;
                case 3:
                    WithdrawMoney();
                    break;
                case 4:
                    exitApp = true;
                    Console.WriteLine("Thank you for banking with Spark Bank. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option, please choose between 1 and 3.");
                    break;

            }
            
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
    // Add deposit Money function 
    public static void DepositMoney()
    {
        Console.Write("Enter account number: ");
        string accNumber = Console.ReadLine();
        // I need to know WHICH index this account lives at, because
        // that same index is what I'll use to update balances.
        // starting foundIndex at -1 as a "not found yet" marker -
        // -1 can never be a real list index, so it's a safe signal.
        int foundIndex = -1;
        for (int i = 0; i < accountNumbers.Count; i++)
        {
            // comparing what the user typed against every account
            // number in the list, one at a time
            if (accountNumbers[i] == accNumber)
            {
                foundIndex = i;
                // once I find a match, I save that index and can
                // stop caring about the rest of the loop - though
                // the loop will still finish running to the end,
                // it just won't overwrite foundIndex again since
                // account numbers are supposed to be unique anyway
            }
        }
        // if the loop never matched anything, foundIndex is still -1
        if (foundIndex == -1)
        {
            Console.WriteLine("Error: account number not found.");
            return;
            // return here exits the function immediately - nothing
            // below this line runs. no point asking for a deposit
            // amount if we don't even know which account to add it to.
        }
        Console.Write("Enter deposit amount: ");
        double amount = double.Parse(Console.ReadLine());
        // foundIndex is the SAME index across all 3 lists, so I use
        // it here to update the correct balance 
        balances[foundIndex] = balances[foundIndex] + amount;
        Console.WriteLine("Deposit successful. New balance: " + balances[foundIndex]);
    }
    //Withdraw Money function 
    public static void WithdrawMoney()
    {
        Console.Write("Enter account number: ");
        string accNumber = Console.ReadLine();
        // same search-by-account-number pattern as DepositMoney -
        // starting at -1 as the "not found yet" marker
        int foundIndex = -1;
        for (int i = 0; i < accountNumbers.Count; i++)
        {
            if (accountNumbers[i] == accNumber)
            {
                foundIndex = i;
            }
        }
        if (foundIndex == -1)
        {
            Console.WriteLine("Error: account number not found.");
            return;
        }
        Console.Write("Enter withdrawal amount: ");
        double amount = double.Parse(Console.ReadLine());
        // this is the new part compared to Deposit - I can't just take
        // the money out blindly, I have to check the account actually
        // HAS enough balance to cover it first.
        if (amount > balances[foundIndex])
        {
            Console.WriteLine("Error: insufficient balance. Current balance is " + balances[foundIndex]);
            return;
            // return here stops the function before any subtraction
            // happens - the balance stays untouched if there isn't
            // enough money.
        }
        // only reaches here if the amount is valid (not more than what's
        // in the account) (now it's safe to actually subtract)
        balances[foundIndex] = balances[foundIndex] - amount;
        Console.WriteLine("Withdrawal successful. New balance: " + balances[foundIndex]);

    }
    

}
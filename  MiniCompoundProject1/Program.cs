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
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("4. Show Balance");
            Console.WriteLine("5. Transfer Amount");
            Console.WriteLine("6. List All Accounts");
            Console.WriteLine("7. Close an Account");
            Console.WriteLine("8. Search Accounts by Customer Name");
            Console.WriteLine("10. Exit");
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
                    ShowBalance();
                    break;
                case 5:
                    TransferAmount();
                    break;
                case 6:
                    ListAllAccounts();
                    break;
                case 7:
                    CloseAccount();
                    break;
                case 8:
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
    //Show Balance function 
    public static void ShowBalance()
    {
        Console.Write("Enter account number: ");
        string accNumber = Console.ReadLine();
        // same search pattern as Deposit and Withdraw # by now this
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
        // nothing gets changed here - just reading the 3 lists at
        // foundIndex and printing them out together
        // the matching name, account number, and balance all at once
        Console.WriteLine("Customer: " + customerNames[foundIndex]);
        Console.WriteLine("Account Number: " + accountNumbers[foundIndex]);
        Console.WriteLine("Balance: " + balances[foundIndex]);
        
    }
    
    //Transfer Amount function 
    public static void TransferAmount()
    {
        Console.Write("Enter sender's account number: ");
        string senderAcc = Console.ReadLine();
        
        Console.Write("Enter receiver's account number: ");
        string receiverAcc = Console.ReadLine();
        
        // finding the sender - same search pattern as always
        int senderIndex = -1;
        for (int i = 0; i < accountNumbers.Count; i++)
        {
            if (accountNumbers[i] == senderAcc)
            {
                senderIndex = i;
            }
        }
        
        // finding the receiver - this needs its OWN separate loop and its
        // OWN separate variable, because I can't reuse senderIndex for
        // this - they're two different searches for two different account
        // numbers, and I need both results at the same time later.
        int receiverIndex = -1;
        for (int i = 0; i < accountNumbers.Count; i++)
        {
            if (accountNumbers[i] == receiverAcc)
            {
                receiverIndex = i;
            }
        }
        // checking BOTH at once with || => (OR) - if EITHER one wasn't found,
        // stop right here. no point checking balance or asking for an
        // amount if we don't even know both accounts exist.
        if (senderIndex == -1 || receiverIndex == -1)
        {
            Console.WriteLine("Error: one or both account numbers were not found.");
            return;
        }
        Console.Write("Enter transfer amount: ");
        double amount = double.Parse(Console.ReadLine());
        // same insufficient-balance check as Withdraw, but only checking
        // the SENDER's balance - the receiver doesn't need any balance
        // check, they're just receiving money.
        if (amount > balances[senderIndex])
        {
            Console.WriteLine("Error: sender has insufficient balance.");
            return;
        }
        // moving the money: subtract from sender, add to receiver.
        // order doesn't actually matter here (both lines just touch
        // different indexes in the same list), but I'm doing subtract
        // first just because that matches how I'd think about it in
        // real life - take it out, then put it in.
        balances[senderIndex] = balances[senderIndex] - amount;
        balances[receiverIndex] = balances[receiverIndex] + amount;
        Console.WriteLine("Transfer successful!");
        Console.WriteLine(customerNames[senderIndex] + "'s new balance: " + balances[senderIndex]);
        Console.WriteLine(customerNames[receiverIndex] + "'s new balance: " + balances[receiverIndex]);
    
    }
    // List All Accounts function 
    public static void ListAllAccounts()
    {
        // edge case first: if the bank has no accounts yet, say so
        // instead of printing an empty list with no explanation - this
        // is worth checking before the loop even starts
        if (customerNames.Count == 0)
        {
            Console.WriteLine("There are no accounts yet.");
            return;
        }
        Console.WriteLine("----- All Accounts -----");
        for (int i = 0; i < customerNames.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + customerNames[i] + " | Acc#: " + accountNumbers[i] + " | Balance: " + balances[i]);
            // (i + 1) again just so the list shows "1., 2., 3." instead
            // of starting at 0 - purely cosmetic, doesn't affect the
            // actual index being read.
        }
    }
    
    // Close an Account function 
    public static void CloseAccount()
    {
        Console.Write("Enter account number to close: ");
        string accNumber = Console.ReadLine();
        // same search pattern as always - find the index first before
        // doing anything
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
        // showing the details before deleting, so the user can confirm
        // what's actually about to be removed
        Console.WriteLine("Closing account: " + customerNames[foundIndex] + " | Acc#: " + accountNumbers[foundIndex] + " | Balance: " + balances[foundIndex]);
        // .RemoveAt() deletes the item at a specific index. 
        // 3 lists, using the SAME foundIndex each time. if I only removed
        // from customerNames and forgot the other two, the lists would
        // become different lengths and every index after this point
        // would point to the WRONG account for the rest of the program.
        customerNames.RemoveAt(foundIndex);
        accountNumbers.RemoveAt(foundIndex);
        balances.RemoveAt(foundIndex);
        Console.WriteLine("Account closed successfully.");
    }
    



}
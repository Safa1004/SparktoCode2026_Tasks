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
            // !exitApp means "while exitApp is NOT true". 
            // so this loop keeps repeating for as long as exitApp is false.
            Console.WriteLine("\n===== Welcome to Spark Bank =====");
            Console.WriteLine("1. Add New Account");
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("4. Show Balance");
            Console.WriteLine("5. Transfer Amount");
            Console.WriteLine("6. List All Accounts");
            Console.WriteLine("7. Close an Account");
            Console.WriteLine("8. Search Accounts by Customer Name");
            Console.WriteLine("9. Find Richest Customer");
            Console.WriteLine("10. Exit");
            Console.Write("Choose an option: ");
            // wrapping the parse in try-catch now instead of letting it crash
            // the whole program the moment someone types a letter instead of a number
            int choice;
            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input. Please enter a number from 1 to 10.");
                continue;
                // continue sends control straight back to the TOP of the
                // while loop and skips the switch entirely and just reprints the menu again
                
            }
            
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
                    SearchByCustomerName();
                    break;
                case 9:
                    FindRichestCustomer();
                    break;
                case 10:
                    exitApp = true;
                    Console.WriteLine("Thank you for banking with Spark Bank. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option, please choose between 1 and 10.");
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
        
        // new fix : checking if this account number already exists BEFORE
        // asking for anything else,  same search pattern I've used in
        // every other function, just used here to REJECT a duplicate
        // instead of finding something to update.
        int existingIndex = -1;
        for (int i = 0; i < accountNumbers.Count; i++)
        {
            if (accountNumbers[i] == accountNumber)
            {
                existingIndex = i;
            }
        }

        if (existingIndex != -1)
        {
            // if not ewual to -1 so this means "if it WAS found"
            // (the opposite of every other function's == -1 check, since
            // here finding a match is the BAD outcome, not the good one)
            Console.WriteLine("Error: that account number is already in use.");
            return;
            // stop here don't even ask for a starting balance if the
            // account number is no good
        }
        // new fix : wrapping the balance parse in try-catch, same pattern as
        // the menu fix - so typing "string" here doesn't crash the app
        double startingBalance;
        
        try
        {
            Console.Write("Enter starting balance: ");
            startingBalance = double.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Error: invalid amount entered. Account not created.");
            return;
        }
        // new fix : rejecting a negative starting balance - can be 0 (opening
        // an account with no money yet is fine) but not below 0
        if (startingBalance < 0)
        {
            Console.WriteLine("Error: initial deposit cannot be negative.");
            return;
        }
        // only reaches here if: account number is unique, balance parsed
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
        // starting foundIndex at -1 as a "not found yet" marker 
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
        // new fix: wrapping the amount parse in try-catch, same pattern as
        // AddAccount - protects against someone typing "twenty" instead
        // of an actual number
        double amount;
        try
        {
            Console.Write("Enter deposit amount: ");
            amount = double.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Error: invalid amount entered.");
            return;
        }
        // new fix : rejecting anything that isn't strictly positive
        // using  (<= )0 catches BOTH zero and negative numbers in one check
        
        // a deposit of 0 doesn't make sense either (nothing actually happens)
        // so it's blocked along with negatives
        if (amount <= 0)
        {
            Console.WriteLine("Error: deposit amount must be positive.");
            return;
        }

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
        //fixes:  same try-catch pattern as Deposit
        double amount;
        try
        {
            Console.Write("Enter withdrawal amount: ");
            amount = double.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Error: invalid amount entered.");
            return;
        }
        if (amount <= 0)
        {
            Console.WriteLine("Error: withdrawal amount must be positive.");
            return;
        }
        // this is the new part compared to Deposit  
        // I can't just take the money out blindly, I have to check the account actually
        // HAS enough balance to cover it first.
        if (amount > balances[foundIndex])
        {
            Console.WriteLine("Error: insufficient balance. Current balance is " + balances[foundIndex]);
            return;
            // return here stops the function before any subtraction
            // happens - the balance stays untouched if there isn't
            // enough money.
        }
        // only reaches here if the amount is valid (not more than what's in the account) 
        // (now it's safe to actually subtract)
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
        //new fixes try-catch 
        double amount;
        try
        {
            Console.Write("Enter transfer amount: ");
            amount = double.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Error: invalid amount entered.");
            return;
        }
        if (amount <= 0)
        {
            Console.WriteLine("Error: transfer amount must be positive.");
            return;
        }
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
    
    //Search Accounts by Customer Name function 
    public static void SearchByCustomerName()
    {
        Console.Write("Enter customer name to search: ");
        string searchName = Console.ReadLine();
        // instead of one "foundIndex" variable like before, I'm using a
        // counter to keep track of how many matches were found. 
        // since there could be zero, one, or several
        int matchesFound = 0;
        Console.WriteLine("----- Search Results -----");
        for (int i = 0; i < customerNames.Count; i++)
        {
            // checking EVERY account, not stopping once something matches -
            // this is the key difference from the account-number searches.
            // there, I could safely assume only one match existed. here,
            // I can't assume that, so the loop has to run all the way
            // through every single time.
            if (customerNames[i] == searchName)
            {
                Console.WriteLine(customerNames[i] + " | Acc#: " + accountNumbers[i] + " | Balance: " + balances[i]);
                matchesFound = matchesFound + 1;
                // counting up each time I print a match, so afterward I
                // know whether anything was actually found at all
            }
            // if the loop finished and matchesFound is still 0, nothing ever
            // matched - only way to know that is by checking this counter
            // after the loop is done, since I never had a single "foundIndex"
            // to check against -1 this time.
        }
        if (matchesFound == 0)
        {
            Console.WriteLine("No accounts found under that name.");
        }
        
    }
    // Find Richest Customer function 
    public static void FindRichestCustomer()
    {
        // edge case first, same as List All Accounts 
        // can't find a richest customer if there are no customers at all
        if (customerNames.Count == 0)
        {
            Console.WriteLine("There are no accounts yet.");
            return;
        }
        // starting by ASSUMING the first account (index 0) is the
        // richest, just as a starting point to compare everyone else against.
        // this isn't a real answer yet,  it's just where the comparison begins.
        int richestIndex = 0;
        // starting the loop at i = 1, NOT i = 0, on purpose 
        // I already (used) index 0 as my starting assumption above 
        // so there's no point comparing it against itself
        for (int i = 1; i < balances.Count; i++)
        {
            // comparing this account's balance against the best one
            // found SO FAR (not against the original index 0 every time
            // richestIndex updates as we go, so this comparison
            // is always against the current leader)
            if (balances[i] > balances[richestIndex])
            {
                richestIndex = i;
                // found someone richer - update richestIndex to point
                // at THIS account instead. the next loop pass will now
                // compare against this new leader.
            }
        }
        // by the time the loop finishes, richestIndex points at whichever
        // account had the highest balance out of everyone checked
        Console.WriteLine("Richest customer: " + customerNames[richestIndex]);
        Console.WriteLine("Account Number: " + accountNumbers[richestIndex]);
        Console.WriteLine("Balance: " + balances[richestIndex]);

        
    }
    
   



}
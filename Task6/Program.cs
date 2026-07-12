namespace Task6;


// BankAccount class ( holds account info and handles deposits/withdrawals)
// using auto-properties ( { get; set; } ) instead of plain fields for
// AccountNumber, HolderName, Balance - same end result as a public field,
//  just the "official" way to expose data on a class
// note: no modifier = "internal" by default, which already covers access
// within this same project - public isn't needed unless another
 // separate project needed to use these classes

class BankAccount 
{
    
   public int AccountNumber { get; set; }
   public string HolderName { get; set; } 
   public double Balance { get; set; }
   
   // Deposit - just adds the amount, then fires off the email notification
   public void Deposit(double amount)
   {
       Balance += amount;
       SendEmail();
       
   }
   // Withdraw - only goes through if Balance can actually cover it
   public void Withdraw(double amount)
   {
       if (amount <= Balance)
       {
           Balance -= amount;
       }
       SendEmail();
       
   }
   //print info first then return balance 
   public double CheckBalance()
   {
       PrintInformation();
       return Balance;
   }
   // private - can only be called from inside this class 
   private void PrintInformation()
   {
       Console.WriteLine("Holder: " + HolderName + " | Balance: " + Balance);
   }
   
   
   private void SendEmail()
   {
       Console.WriteLine("[Email notification sent to " + HolderName + "]");
   }
      
}

class Student
{
    public int Grade { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    private string email;
    int age; // default access - no modifier = private-equivalent for class member
    
    
    // Register - the ONLY way email gets a value from outside this class
    // takes the email in as a parameter, stores it in the private field
    // then triggers the same "notify" pattern as BankAccount's Deposit/Withdraw
    public void Register(string Email)
    {
        email = Email;
        SendEmail();
    }
    
    private void SendEmail()
    {
        Console.WriteLine("[Registration email sent for " + Name + "]");
    }
}

class Product
{
    public string ProductName { get; set; }
    public double Price { get; set; }
    public int StockQuantity { get; set; }

    public void Sell(int quantity)
    {
        if (quantity <= StockQuantity)
        {
            StockQuantity -= quantity;
        }
        else
        {
            Console.WriteLine("Not enough stock to complete this sale.");
        }
        LogTransaction();
    }

    public void Restock(int quantity)
    {
        StockQuantity += quantity;
        LogTransaction();
    }

    public double GetInventoryValue()
    {
        PrintDetails();
        return Price * StockQuantity;
    }
    
    private void PrintDetails()
    {
        Console.WriteLine("Product: " + ProductName + " | Price: " + Price + " | Stock: " + StockQuantity);
    }
    
    private void LogTransaction()
    {
        Console.WriteLine("[Transaction logged for " + ProductName + "]");
    }
   
}


class Program
{
    static void Main(string[] args)
    {
        
    }
}
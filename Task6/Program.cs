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
    // putting the 6 objects as static fields on Program -- static cuz this feild field belongs to the Program class itself
    //every case method needs to reach these objects
    //object initializer syntax cuz it's shorthand that creates the object AND sets its properties all in one statement
    static  BankAccount account1 = new BankAccount { AccountNumber = 1163, HolderName = "Safa", Balance = 100000 };
    static BankAccount account2 = new BankAccount { AccountNumber = 15203, HolderName = "Marwa", Balance = 50000 };

    static Student student1 = new Student { Name = "Ali", Address = "Muscat", Grade = 65 };
    static Student student2 = new Student { Name = "Ahmed", Address = "Muscat", Grade = 70 };

    static Product product1 = new Product { ProductName = "Wireless Mouse", Price = 5.500, StockQuantity = 50 };
    static Product product2 = new Product { ProductName = "Mechanical Keyboard", Price = 15.750, StockQuantity = 20 };
    static void Main(string[] args)
    {
        bool exitApp = false;
        while (!exitApp) //true
        {
            Console.WriteLine("\n===== Task 6 Menu =====");
            Console.WriteLine("1. View Account Details");
            Console.WriteLine("2. Update Student Address");
            Console.WriteLine("3. Make a Deposit");
            Console.WriteLine("4. Make a Withdrawal");
            Console.WriteLine("5. View Product Details");
            Console.WriteLine("6. Register a Student");
            Console.WriteLine("7. Compare Two Account Balances");
            Console.WriteLine("8. Restock Product & Stock Level Check");
            Console.WriteLine("9. Transfer Between Accounts");
            Console.WriteLine("10. Update Student Grade (Validated)");
            Console.WriteLine("11. Student Report Card");
            Console.WriteLine("12. Account Health Status");
            Console.WriteLine("13. Bulk Sale With Revenue Calculation");
            Console.WriteLine("14. Scholarship Eligibility Check");
            Console.WriteLine("15. Full Balance Top-Up Flow");
            Console.WriteLine("16. Quick Account Opening [Parameterized Constructor]");
            Console.WriteLine("17. Total Students Counter [Static]");
            Console.WriteLine("18. Overdrawn Account Check [Read-Only Property]");
            Console.WriteLine("19. Set Student Security PIN [Write-Only Property]");
            Console.WriteLine("20. Exit");
            Console.Write("Choose an option: ");
            //try-catch for error handling 
            int choice;
            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input. Please enter a number from 1 to 20.");
                continue;
            }
            switch (choice)
            {
                case 1: ViewAccountDetails(); break;
                case 2: UpdateStudentAddress(); break;
                case 3: MakeDeposit(); break;
                case 4: MakeWithdrawal(); break;
                case 5: ViewProductDetails(); break;
                case 6: RegisterStudent(); break;
                case 7: CompareAccountBalances(); break;
                case 8: RestockProduct(); break;
                case 9: TransferBetweenAccounts(); break;
                case 10: UpdateStudentGrade(); break;
                case 11: StudentReportCard(); break;
                case 12: AccountHealthStatus(); break;
                case 13: BulkSale(); break;
                case 14: ScholarshipEligibility(); break;
                case 15: FullBalanceTopUp(); break;
                case 16: QuickAccountOpening(); break;
                case 17: TotalStudentsCounter(); break;
                case 18: OverdrawnAccountCheck(); break;
                case 19: SetStudentPin(); break;
                case 20:
                    exitApp = true;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option, please choose between 1 and 20.");
                    break;
            }
           
            
            

        }
        
       

        
        
    }
}
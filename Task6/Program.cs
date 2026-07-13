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
   //--------------------------------
   // new fix : empty constructor (method with nio void) added back - needed because account1/account2
   // use object initializer syntax ( new BankAccount { ... } ), which relies
   // on a parameterless constructor existing. writing the parameterized one
   // below on its own would delete that "free" one C# normally gives you
   public BankAccount() { }
   //--------------------------------
   
   // new fix: (case 16 [Parameterized Constructor])
   // parameterized constructor - takes all 3 values at once
   // and sets them immediately when the object is created, instead of
   // using object initializer syntax like { AccountNumber = ..., etc } 
   public BankAccount(int accountNumber, string holderName, double startingBalance) // parameters 
   {
       AccountNumber = accountNumber; // adds them to the property
       HolderName = holderName;
       Balance = startingBalance;
   }
   
   // new fix : read-only property
   // only has a get accessor, no set at all
   // means I can read values but NEVER assign to it directly 
   // juts returns true when the Balance is below 0
   public bool IsOverdrawn
   {
       get { return Balance < 0; } 
       // get in here is only accessor NO set to assign to it 
       // so i only read the value if Balance 
   }
   
   
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
    
    // new fix : static field - shared ACROSS all Student objects, not
    // tied to any one instance.
    // every time a new Student gets created this number goes up 
    public static int totalStudents = 0;
    
    // new fix : constructor  (method with nio void) - the only reason I'm adding one here is so
    // totalStudents++ runs automatically every time "new Student()" happens
    public Student()
    {
        totalStudents++;
    }
    
    
    // new fix : private backing field for the PIN 
    // since the property itself can't read the value back out (no get)
    // I still need somewhere to actually STORE the pin once it's set
    // same idea as "email" above it - a private field the property
    // writes into
    private string pin;
    
    // new fix : write-only property (only has a set accessor) no get
    //this means from OUTSIDE the class, you can WRITE to student PINs (student1.Pin = "1234")
    //never read (get) it back (Console.WriteLine(student1.Pin)
    // 'value' here its the keyword it outo holds whatever got nd assign it 
    public string Pin
    {
        set { pin = value; }
    }
    
    
    // Register - the ONLY way email gets a value from outside this class
    // takes the email in as a parameter, stores it in the private field
    // then triggers the same "notify" pattern as BankAccount's Deposit/Withdraw
    public void Register(string Email)
    {
        email = Email;
        SendEmail();
    }
    // new fix : static method - returns totalStudents. has to be static too
    // because it needs to run WITHOUT any particular Student object existing
    // called through the class name itself (Student.GetTotalStudents())
    public static int GetTotalStudents()
    {
        return totalStudents;
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
    static Student student2 = new Student { Name = "Ahmed", Address = "Muscat", Grade = 98 };

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
            // new fix : pause + clear after every case EXCEPT exit 
            if (!exitApp)
            {
                Console.Write("\npress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
           
            
           

        }
        
       

       
        
    }
    // ----- case methods, built one at a time -----
    
    //apply case 1 requirements 
    static void ViewAccountDetails()
    {
        Console.Write("Choose account (1 or 2): ");
        // same try-catch
        int pick;
        try
        {
            pick = int.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid input");
            return; 
        }
         if (pick == 1)
    {
        account1.CheckBalance();
        // not storing the return value in anything here since the task
        // just wants us to DISPLAY it - CheckBalance already prints via
        // PrintInformation() internally, so calling it alone is enough
    }
    else if (pick == 2)
    {
        account2.CheckBalance();
    }
    else
    {
        Console.WriteLine("Invalid account choice.");
    }
   
    }

  ////////////////////////////////////////////////////////////////////////////////////////
  // Case 2 - Update Student Address 
    static void UpdateStudentAddress()
    {
        Console.Write("Choose student (1 or 2): ");
        int pick;
        try
        {
            pick = int.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid input.");
            return;
        }
        Console.Write("Enter new address: ");
        string newAddress = Console.ReadLine();
        //same if/else pattern and objects  
        if (pick == 1)
        {
            student1.Address = newAddress;
            Console.WriteLine("Address updated. " + student1.Name + "'s new address: " + student1.Address); 
            // address is the property within Student Class
        }
        else if (pick == 2)
        {
            student2.Address = newAddress;
            Console.WriteLine("Address updated. " + student2.Name + "'s new address: " + student2.Address);
        }
        else
        {
            Console.WriteLine("Invalid student choice.");
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////
    // // Case 3 - Make a Deposit

    static void MakeDeposit()
    {
        Console.Write("Choose account (1 or 2): ");
        int pick;
        try
        {
            pick = int.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid input.");
            return;
        }
        // reject bad account choice BEFORE asking for an amount - no point
        // typing a deposit value for an account that doesn't exist
        if (pick != 1 && pick != 2)
        {
            Console.WriteLine("Invalid account choice.");
            return;
        }
        double amount;
        try
        {
            Console.Write("Enter deposit amount: ");
            amount = double.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid amount entered.");
            return;
        }
        if (pick == 1)
        {
            account1.Deposit(amount);
            Console.WriteLine(account1.HolderName + "'s updated balance: " + account1.Balance);
        }
        else
        {
            account2.Deposit(amount);
            Console.WriteLine(account2.HolderName + "'s updated balance: " + account2.Balance);
        }
    }
    
    ////////////////////////////////////////////////////////////////////////////////////////
    // Case 4 - Make a Withdrawal

    static void MakeWithdrawal()
    {
        Console.Write("Choose account (1 or 2): ");
        int pick;
        try
        {
            pick = int.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        if (pick != 1 && pick != 2)
        {
            Console.WriteLine("Invalid account choice.");
            return;
        }
        double amount;
        try
        {
            Console.Write("Enter withdrawal amount: ");
            amount = double.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid amount entered.");
            return;
        }
        if (pick == 1)
        {
            account1.Withdraw(amount);
            Console.WriteLine("Updated balance: " + account1.Balance);
        }
        else
        {
            account2.Withdraw(amount);
            Console.WriteLine("Updated balance: " + account2.Balance);
        }
    }
    
    ////////////////////////////////////////////////////////////////////////////////////////
    // Case 5 - View Product Details

    static void ViewProductDetails()
    {
        Console.Write("Choose product (1 or 2): ");
        int pick;
        try
        {
            pick = int.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid input.");
            return;
        }
        if (pick == 1)
        {
            double value = product1.GetInventoryValue();
            Console.WriteLine("Total inventory value: " + value);
        }
        else if (pick == 2)
        {
            double value = product2.GetInventoryValue();
            Console.WriteLine("Total inventory value: " + value);
        }
        else
        {
            Console.WriteLine("Invalid product choice.");
        }
    }
    
    ////////////////////////////////////////////////////////////////////////////////////////
    // Case 6 - Register a Student
    // email is private on the Student class, so the ONLY way to get a value
   // into it from here is through Register() I can't do something like student1.email
   // aslo in the case it says " you cannot assign it directly. Print a confirmation message that
   // does NOT reveal the email anywhere."
   //so I'm only printing the student's Name, never the email variable itself
   static void RegisterStudent()
   {
       Console.Write("Choose student (1 or 2): ");
       int pick;
       try
       {
           pick = int.Parse(Console.ReadLine());
       }
       catch (Exception)
       {
           Console.WriteLine("Invalid input.");
           return;
       }

       if (pick != 1 && pick != 2)
       {
           Console.WriteLine("Invalid student choice.");
           return;
       }
       Console.Write("Enter email: ");
       string enteredEmail = Console.ReadLine();
       if (pick == 1)
       {
           student1.Register(enteredEmail);
           Console.WriteLine(student1.Name + " has been registered successfully.");
       }
       else
       {
           student2.Register(enteredEmail);
           Console.WriteLine(student2.Name + " has been registered successfully.");
       }

   }
   ////////////////////////////////////////////////////////////////////////////////////////
   // Case 7 - Compare Two Account Balances
   static void CompareAccountBalances()
   {
       //if-else chain to figure out which one's higher (or if they're equal)
       if (account1.Balance > account2.Balance)
       {
           Console.WriteLine(account1.HolderName + " has more money. Balance: " + account1.Balance);
       }
       else if (account2.Balance > account1.Balance)
       {
           Console.WriteLine(account2.HolderName + " has more money. Balance: " + account2.Balance);
       }
       else
       {
           Console.WriteLine("Both accounts have equal balances: " + account1.Balance);
       }
   }
   
   ////////////////////////////////////////////////////////////////////////////////////////
   // Case 8 - Restock Product & Stock Level Check

   static void RestockProduct()
   {
       Console.Write("Choose product (1 or 2): ");
       int pick;
       try
       {
           pick = int.Parse(Console.ReadLine());
       }
       catch (Exception)
       {
           Console.WriteLine("Invalid input.");
           return;
       }

       if (pick != 1 && pick != 2)
       {
           Console.WriteLine("Invalid product choice.");
           return;
       }
       int quantity;
       try
       {
           Console.Write("Enter quantity to restock: ");
           quantity = int.Parse(Console.ReadLine());
       }
       catch (Exception)
       {
           Console.WriteLine("Invalid quantity entered.");
           return;
       }
       int updatedStock;
       if (pick == 1)
       {
           product1.Restock(quantity);
           updatedStock = product1.StockQuantity;
       }
       else
       {
           product2.Restock(quantity);
           updatedStock = product2.StockQuantity;
       }
       // 3-tier classification - below 10 is Low, 10 to 49 is Moderate,
       // 50+ is Well Stocked 
       if (updatedStock < 10)
       {
           Console.WriteLine("Stock level: Low. Current stock: " + updatedStock);
       }
       else if (updatedStock < 50)
       {
           Console.WriteLine("Stock level: Moderate. Current stock: " + updatedStock);
       }
       else
       {
           Console.WriteLine("Stock level: Well Stocked. Current stock: " + updatedStock);
       }
   }
   
   ////////////////////////////////////////////////////////////////////////////////////////
   // Case 9 - Transfer Between Accounts
   // checking the balance FIRST, before calling Withdraw/Deposit at all
   
   static void TransferBetweenAccounts()
   {
       Console.Write("Choose source account (1 or 2): ");
       int source;
       try
       {
           source = int.Parse(Console.ReadLine());
       }
       catch (Exception)
       {
           Console.WriteLine("Invalid input.");
           return;
       }
       Console.Write("Choose destination account (1 or 2): ");
       int destination;
       try
       {
           destination = int.Parse(Console.ReadLine());
       }
       catch (Exception)
       {
           Console.WriteLine("Invalid input.");
           return;
       }
       // reject bad picks before even asking for an amount 
       if ((source != 1 && source != 2) || (destination != 1 && destination != 2))
       {
           Console.WriteLine("Invalid account choice.");
           return;
       }
       // transferring to yourself doesn't make sense
       if (source == destination)
       {
           Console.WriteLine("Source and destination can't be the same account.");
           return;
       }
       double amount;
       try
       {
           Console.Write("Enter transfer amount: ");
           amount = double.Parse(Console.ReadLine());
       }
       catch (Exception)
       {
           Console.WriteLine("Invalid amount entered.");
           return;
       }
       // grabbing the actual objects based on the picks, so I don't have
       // to write 4 separate if/else branches below for every source/destination
       // ternary operator - shorthand for if/else that returns a value
       // syntax: "condition ? valueIfTrue : valueIfFalse"
       // same as writing: if (source == 1) sourceAccount = account1; else sourceAccount = account2;
       // ? if the condition true // : means otherwise
       BankAccount sourceAccount = (source == 1) ? account1 : account2;
       BankAccount destinationAccount = (destination == 1) ? account1 : account2;
       // checking balance BEFORE touching anything
       if (amount > sourceAccount.Balance)
       {
           Console.WriteLine("Transfer failed: insufficient balance in source account.");
           return;
       }
       sourceAccount.Withdraw(amount);
       destinationAccount.Deposit(amount);
       Console.WriteLine("Transfer successful!");
       Console.WriteLine(sourceAccount.HolderName + "'s new balance: " + sourceAccount.Balance);
       Console.WriteLine(destinationAccount.HolderName + "'s new balance: " + destinationAccount.Balance);
   
       
   }
   
   ////////////////////////////////////////////////////////////////////////////////////////
   // Case 10 - Update Student Grade (Validated)
   static void UpdateStudentGrade()
   {
       Console.Write("Choose student (1 or 2): ");
       int pick;
       try
       {
           pick = int.Parse(Console.ReadLine());
       }
       catch (Exception)
       {
           Console.WriteLine("Invalid input.");
           return;
       }
       if (pick != 1 && pick != 2)
       {
           Console.WriteLine("Invalid student choice.");
           return;
       }
       int newGrade;
       try
       {
           Console.Write("Enter new grade: ");
           newGrade = int.Parse(Console.ReadLine());
       }
       catch (Exception)
       {
           Console.WriteLine("Error: grade must be a valid number. No change made.");
           return;
       }
       // second validation layer - parsing succeeded, but the NUMBER itself
       // could still be garbage like -5 or 150, so this check catches that
       if (newGrade < 0 || newGrade > 100)
       {
           Console.WriteLine("Error: grade must be between 0 and 100. No change made.");
           return;
       }
       // only reaches here if both checks passed - now it's safe to update
       if (pick == 1)
       {
           student1.Grade = newGrade; // update it with the new garde 
           Console.WriteLine(student1.Name + "'s grade updated to " + student1.Grade);
       }
       else
       {
           student2.Grade = newGrade;
           Console.WriteLine(student2.Name + "'s grade updated to " + student2.Grade);
       }
       
   }
   ////////////////////////////////////////////////////////////////////////////////////////
   // Case 11 - Student Report Card
   // pick, then print all 3 properties plus a Pass/Fail label I calculate myself 

   static void StudentReportCard()
   {
       Console.Write("Choose student (1 or 2): ");
       int pick;
       try
       {
           pick = int.Parse(Console.ReadLine());
       }
       catch (Exception)
       {
           Console.WriteLine("Invalid input.");
           return;
       }

       if (pick != 1 && pick != 2)
       {
           Console.WriteLine("Invalid student choice.");
           return;
       }
       // grabbing the right student object first, so the print logic below
       // only has to be written once instead of duplicated per student
       // same ternary operator (shorter)
       Student chosenStudent = (pick == 1) ? student1 : student2;
       string status = (chosenStudent.Grade >= 60) ? "Pass" : "Fail";
       
       Console.WriteLine("----- Report Card -----");
       Console.WriteLine("Name: " + chosenStudent.Name);
       Console.WriteLine("Address: " + chosenStudent.Address);
       Console.WriteLine("Grade: " + chosenStudent.Grade);
       Console.WriteLine("Status: " + status);
   }
   ////////////////////////////////////////////////////////////////////////////////////////
   // Case 12 - Account Health Status
   static void AccountHealthStatus()
   {
       Console.Write("Choose account (1 or 2): ");
       int pick;
       try
       {
           pick = int.Parse(Console.ReadLine());
       }
       catch (Exception)
       {
           Console.WriteLine("Invalid input.");
           return;
       }

       if (pick != 1 && pick != 2)
       {
           Console.WriteLine("Invalid account choice.");
           return;
       }
       // same ternary operator (shorter)
       BankAccount chosenAccount = (pick == 1) ? account1 : account2;
       // 3-tier classification
       // below 50 is Low, 50 up to 1000 is Healthy, above 1000 is Premium
       if (chosenAccount.Balance < 50)
       {
           Console.WriteLine(chosenAccount.HolderName + "'s account status: Low Balance");
       }
       else if (chosenAccount.Balance <= 1000)
       {
           Console.WriteLine(chosenAccount.HolderName + "'s account status: Healthy");
       }
       else
       {
           Console.WriteLine(chosenAccount.HolderName + "'s account status: Premium");
       }
   }
   
   ////////////////////////////////////////////////////////////////////////////////////////
   // Case 13 - Bulk Sale With Revenue Calculation
   // two branches here depending on stock:
   // NOT enough -> calculate the shortfall and stop (don't touch anything)
   // enough -> actually sell, then calculate revenue AFTER the sale goes through
   static void BulkSale()
   {
       Console.Write("Choose product (1 or 2): ");
       int pick;
       try
       {
           pick = int.Parse(Console.ReadLine());
       }
       catch (Exception)
       {
           Console.WriteLine("Invalid input.");
           return;
       }

       if (pick != 1 && pick != 2)
       {
           Console.WriteLine("Invalid product choice.");
           return;
       }
       int quantity;
       try
       {
           Console.Write("Enter quantity to sell: ");
           quantity = int.Parse(Console.ReadLine());
       }
       catch (Exception)
       {
           Console.WriteLine("Invalid quantity entered.");
           return;
       }
       // same ternary operator (shorter) 
       Product chosenProduct = (pick == 1) ? product1 : product2;
       // checking stock BEFORE calling Sell() at all - I need to know which
       // branch I'm in (short vs enough) before doing anything, since the
       // "not enough" branch needs its own math and must NOT call Sell()
       if (quantity > chosenProduct.StockQuantity)
       {
           int shortfall = quantity - chosenProduct.StockQuantity;
           Console.WriteLine("Not enough stock. You need " + shortfall + " more unit(s) to fulfill this order.");
           return;
           // stopping here - task says "do not sell anything" if stock's short
       }

       // only reaches here if stock covers the order - safe to sell now
       chosenProduct.Sell(quantity);
       double revenue = quantity * chosenProduct.Price;
       Console.WriteLine("Sale successful! Revenue from this sale: " + revenue);

   }
   
   ////////////////////////////////////////////////////////////////////////////////////////
   // Case 14 - Scholarship Eligibility Check
   // First pick student then account 

   static void ScholarshipEligibility()
   {
       Console.Write("Choose student (1 or 2): ");
       int studentPick;
       try
       {
           studentPick = int.Parse(Console.ReadLine());
       }
       catch (Exception)
       {
           Console.WriteLine("Invalid input.");
           return;
       }
       Console.Write("Choose account (1 or 2): ");
       int accountPick;
       try
       {
           accountPick = int.Parse(Console.ReadLine());
       }
       catch (Exception)
       {
           Console.WriteLine("Invalid input.");
           return;
       }

       if (studentPick != 1 && studentPick != 2)
       {
           Console.WriteLine("Invalid student choice.");
           return;
       }

       if (accountPick != 1 && accountPick != 2)
       {
           Console.WriteLine("Invalid account choice.");
           return;
       }
       // same ternary operator (shorter) 
       Student chosenStudent = (studentPick == 1) ? student1 : student2;
       BankAccount chosenAccount = (accountPick == 1) ? account1 : account2;
       bool gradeOk = chosenStudent.Grade >= 80;
       bool balanceOk = chosenAccount.Balance >= 100;
       
       // checking both conditions separately (not just one big && check)
       // so I can actually tell the user WHICH one failed, instead of just
       // saying "not eligible" with no explanation
       if (gradeOk && balanceOk)
       {
           Console.WriteLine("Eligible for scholarship!");
       }
       else if (!gradeOk && !balanceOk)
       {
           Console.WriteLine("Not eligible: grade is below 80 AND balance is below 100.");
       }
       else if (!gradeOk)
       {
           Console.WriteLine("Not eligible: grade is below 80.");
       }
       else
       {
           Console.WriteLine("Not eligible: balance is below 100.");
       }

       
   }
   
   ////////////////////////////////////////////////////////////////////////////////////////
   // Case 15 - Full Balance Top-Up Flow
   // It says in here: 
   //Pick an account, check Balance.
   //If below 50, auto-calculate the top-up needed to reach exactly 100, deposit it, print before/after.
   //If already ≥ 50, say no top-up needed.
   static void FullBalanceTopUp()
   {
       Console.Write("Choose account (1 or 2): ");
       int pick;
       try
       {
           pick = int.Parse(Console.ReadLine());
       }
       catch (Exception)
       {
           Console.WriteLine("Invalid input.");
           return;
       }

       if (pick != 1 && pick != 2)
       {
           Console.WriteLine("Invalid account choice.");
           return;
       }
       // same ternary operator (shorter) 
       BankAccount chosenAccount = (pick == 1) ? account1 : account2;
       if (chosenAccount.Balance < 50)
       {
           // grabbing the balance BEFORE Deposit() touches it
           // once I call Deposit(), the old value is gone, so I need this snapshot now
           double balanceBefore = chosenAccount.Balance;
           double topUpAmount = 100 - chosenAccount.Balance; //how many needed to reach 100
           chosenAccount.Deposit(topUpAmount);
           Console.WriteLine("Balance before top-up: " + balanceBefore);
           Console.WriteLine("Balance after top-up: " + chosenAccount.Balance);
       }
       else
       {
           Console.WriteLine("No top-up needed. Current balance: " + chosenAccount.Balance);
       }
   }
   // Cases 16-19 - Own Research
   ////////////////////////////////////////////////////////////////////////////////////////
   // Case 16 - Quick Account Opening [Parameterized Constructor]
   // Task specifically wants us to use ONLY the constructor 
   // No separate property assignments after creating the object
   // so all 3 values MUST go straight into the "new BankAccount(...)" call itself
   static void QuickAccountOpening()
   {
       Console.Write("Enter account number: ");
       int accNum;
       try
       {
           accNum = int.Parse(Console.ReadLine());
       }
       catch (Exception)
       {
           Console.WriteLine("Invalid account number.");
           return;
       }
       Console.Write("Enter holder name: ");
       string holderName = Console.ReadLine();

       double startingBalance;
       try
       {
           Console.Write("Enter starting balance: ");
           startingBalance = double.Parse(Console.ReadLine());
       }
       catch (Exception)
       {
           Console.WriteLine("Invalid balance.");
           return;
       }
       // building the object with the parameterized constructor
       // all 3 values passed in the SAME statement that creates it
       // nothing set afterward like account1/account2 use object initializers for
       BankAccount newAccount = new BankAccount(accNum, holderName, startingBalance);
       Console.WriteLine("New account created!");
       newAccount.CheckBalance();
       
   }
   ////////////////////////////////////////////////////////////////////////////////////////
   // Case 17 - Total Students Counter [Static Fields & Methods]
   static void TotalStudentsCounter()
   {
       int total = Student.GetTotalStudents();
       Console.WriteLine("Total students created: " + total); 
   }
   ////////////////////////////////////////////////////////////////////////////////////////
   // Case 18 - Overdrawn Account Check [Read-Only Property]
   // just reading IsOverdrawn like any other property
   //returns true when the Balance is below 0
   static void OverdrawnAccountCheck()
   {
       Console.Write("Choose account (1 or 2): ");
       int pick;
       try
       {
           pick = int.Parse(Console.ReadLine());
       }
       catch (Exception)
       {
           Console.WriteLine("Invalid input.");
           return;
       }

       if (pick != 1 && pick != 2)
       {
           Console.WriteLine("Invalid account choice.");
           return;
       }
       // same ternary operator (shorter)  
       BankAccount chosenAccount = (pick == 1) ? account1 : account2;
       if (chosenAccount.IsOverdrawn)
       {
           Console.WriteLine(chosenAccount.HolderName + "'s account is currently overdrawn.");
       }
       else
       {
           Console.WriteLine(chosenAccount.HolderName + "'s account is not overdrawn.");
       }
   }
   ////////////////////////////////////////////////////////////////////////////////////////
   // Case 19 - Set Student Security PIN [Write-Only Property]
   static void SetStudentPin()
   {
       Console.Write("Choose student (1 or 2): ");
       int pick;
       try
       {
           pick = int.Parse(Console.ReadLine());
       }
       catch (Exception)
       {
           Console.WriteLine("Invalid input.");
           return;
       }

       if (pick != 1 && pick != 2)
       {
           Console.WriteLine("Invalid student choice.");
           return;
       }
       Console.Write("Enter 4-digit PIN: ");
       string enteredPin = Console.ReadLine();
       // task says "4-digit PIN"
       // so checking length is 4 and every character is a digit before accepting it
       if (enteredPin.Length != 4 || !enteredPin.All(char.IsDigit)) //OR if any character isn't a number
       {
           Console.WriteLine("Error: PIN must be exactly 4 digits.");
           return;
       }
       if (pick == 1)
       {
           student1.Pin = enteredPin;
           Console.WriteLine("PIN set successfully for " + student1.Name);
       }
       else
       {
           student2.Pin = enteredPin;
           Console.WriteLine("PIN set successfully for " + student2.Name);
       }

   }
}
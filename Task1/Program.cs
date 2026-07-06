namespace Task1;

class Program
{
    static void Main(string[] args)
    {
        //Note:
        //I've made a mistake and solve Task 1 in extranl repo
        //(I did't know the logic, then the instructor explained later, while i was already pushed the task solution)
        //repo link : https://github.com/Safa1004/CsharpFundamentals-Part1.git
       
        //solution for reference
        /* //TASK 1 (Personal Info Card) solution
        // Declaring variables with 4 different data types
        string name = "Safa";
        int age = 21;
        double height = 1.59;
        bool Is_A_Student = true;
        // Printing them as a formatted info card
        Console.WriteLine($"Name:{name}");
        Console.WriteLine($"Age:{age}");
        Console.WriteLine($"Height:{height}cm");
        Console.WriteLine($"Student:{Is_A_Student}");
        */
       ////////////////////////////////////////////////////////
       
       /* //TASK 2 (Rectangle Calculator) solution
       // Ask user for length
       Console.Write("Enter the length of the regtangle: ");
       double length = double.Parse(Console.ReadLine());
       // Ask user for width
       Console.Write("Enter the width of the regtangle: ");
       double width = double.Parse(Console.ReadLine());
       //cal
       double area = length * width;
       double perimeter = (length + width) * 2;
       
       // printing the output
       Console.WriteLine($"Area: {area}");
       Console.WriteLine($"Perimeter: {perimeter}"); */
       ////////////////////////////////////////////////////////
       
       /* //TASK 3  (Even or Odd Checker) solution 
       // ask the user for a whole number 
       Console.Write("Enter a whole number: ");
       int number = int.Parse(Console.ReadLine());
       if (number % 2 == 0)
       {
           Console.Write($"{number} is even");
           
       }
       else
       {
           Console.Write($"{number} is odd");
       } */
       ////////////////////////////////////////////////////////
       
       /* //TASK 4 (Voting Eligibility) solution 
       // ask for age
       Console.Write("Enter your age: ");
       int age = int.Parse(Console.ReadLine());
       //ask for ID status
       Console.Write("Do you hold a valid national ID? (yes/no):");
       string nationalID = Console.ReadLine();
       //covert yes/no answer into a bool
       bool is_valid_id = (nationalID == "yes");
       // checking if eligiable
       if (age >= 18 && is_valid_id)
       {
           Console.WriteLine("You are eligible to vote");
       }
       else
       {
           Console.WriteLine("You are not eligible to vote");
       }*/
      
       ////////////////////////////////////////////////////////
       
      /* // TASK 5 (Grade Letter Lookup) solution 
       // ask for a grade 
       Console.Write("Enter your grade (A, B, C, D, F): ");
       char grade = char.Parse(Console.ReadLine());
       //applying switch statment 
       switch (grade)
       {
           case 'A':
               Console.WriteLine("Excellent");
               break;
           case 'B':
               Console.WriteLine("Very Good");
               break;
           case 'C':
               Console.WriteLine("Good");
               break;
           case 'D':    
               Console.WriteLine("Pass");
               break;
           case 'F':
               Console.WriteLine("Fail");
               break;
           default:
               Console.WriteLine("Not a valid grade");
               break;
                
       } */
      
      ////////////////////////////////////////////////////////
      /* // Task 6 (Temperature Converter) solution 
      // Ask user for Celsius temperature
      Console.Write("Enter temperature in Celsius: ");
      double temp_in_cel = double.Parse(Console.ReadLine());
      //convert to fahrenheit
      double fahrenheit = (temp_in_cel * 9 / 5 )+ 32;
      Console.WriteLine($"Fahrenheit : {fahrenheit}");
      // Classify weather based on Celsius value
      if (temp_in_cel < 10)
      {
          Console.WriteLine($"{temp_in_cel} is cold");
      }
      else if  ( temp_in_cel <= 30)
          {
          Console.WriteLine($"{temp_in_cel} is mild");
          }
      else 
      {
          Console.WriteLine($"{temp_in_cel} is hot");
          
      } */
      ////////////////////////////////////////////////////////
      
      /* //TASK 7 (Movie Ticket Pricing) solution 
      // ask for age 
      Console.Write("Enter your age: ");
      int age = int.Parse(Console.ReadLine());
      // Determine category and price
      if (age <= 12)
      {
          Console.WriteLine("Category: Child");
          Console.WriteLine("Ticket Price: 2.000 OMR"); 
      }
      else if (age <= 59)
      {
          Console.WriteLine("Category: Adult");
          Console.WriteLine("Ticket Price: 5.000  OMR");
      }
      else
      {
          Console.WriteLine("Category: Senior"); 
          Console.WriteLine("Ticket Price: 3.000  OMR");
      } */
      
      ////////////////////////////////////////////////////////
      /* // Task 8 (Restaurant Bill with Membership Discount) solution 
      // ask for bill amount 
      Console.Write("Enter your total bill amount (OMR): ");
      double bill = double.Parse(Console.ReadLine());
      // ask for loyalty membership
      Console.Write("Are you a loyal member? (yes/no): ");
      string membership_response = Console.ReadLine();
      bool membership_status = (membership_response == "yes");

      if (bill > 20 && membership_status)
      {
          double discount = bill * 0.15;
          double final_amount = bill -  discount;
          Console.WriteLine($"Origanl Bill: {bill} OMR");
          Console.WriteLine($"Dsicount : {discount} OMR");
          Console.WriteLine($"Final amount to pay : {final_amount} OMR");
      }
      else
      {
          Console.WriteLine($"Origanl Bill: {bill} OMR");
          Console.WriteLine("Dsicount: 0 OMR");
          Console.WriteLine($"Final amount to pay : {bill} OMR");
          
      }*/
      ////////////////////////////////////////////////////////
      /* //TASK 9 (Day Name Finder) solution 
      Console.WriteLine("Find which day of the week");
      Console.WriteLine("Enter a number from 1 to 7: ");
      int day_number = int.Parse(Console.ReadLine());
      switch (day_number)
      {
          case 1:
              Console.WriteLine("Sunday");
              break;
          case 2:
              Console.WriteLine("Monday");
              break;
          case 3:
              Console.WriteLine("Tuesday");
              break;
          case 4:
              Console.WriteLine("Wednesday");
              break;
          case 5:
              Console.WriteLine("Thursday");
              break;
          case 6:
              Console.WriteLine("Friday");
              break;
          case 7:
              Console.WriteLine("Saturday");
              break;
          default:
              Console.WriteLine("nvalid day number");
              break;
                    
              
      }*/
      ////////////////////////////////////////////////////////
      /*// TASK 10 ( Mini Calculator) solution 
      Console.WriteLine("Mini Calculator");
      // Ask user for first number
      Console.Write("Enter the first number: ");
      double num1 = double.Parse(Console.ReadLine());
      // Ask user for operator
      Console.Write("Enter an operator (+, -, *, /, %): ");
      char op = char.Parse(Console.ReadLine());
      // Ask user for second number
      Console.Write("Enter the second number: ");
      double num2 = double.Parse(Console.ReadLine());
      // Perform operation based on operator
      switch (op)
      {
          case '+' :
              Console.WriteLine("Result: " + (num1 + num2));
              break;
          case '-' :
              Console.WriteLine("Result: " + (num1 - num2));
              break;
          case '*' :
              Console.WriteLine("Result: " + (num1 * num2));
              break;
          case '/' :
              Console.WriteLine("Result: " + (num1 / num2));
              break;
          case '%' :
              if (num2 == 0)
              {
                  Console.WriteLine("Cannot divide by zero");
              }
              else
              {
                  Console.WriteLine("Result: " + (num1 % num2));
              }
              break;
          default:
              Console.WriteLine("Invalid operator");
              break;
              
      }*/
      ////////////////////////////////////////////////////////
     /* //Task 11 (Loan Eligibility System) solution 
      // Ask user for age
      Console.Write("Enter your age: ");
      int age = int.Parse(Console.ReadLine());
      // Ask user for monthly income
      Console.Write("Enter your monthly income (OMR): ");
      double monthly_income = double.Parse(Console.ReadLine());
      // Ask user for existing loan status
      Console.Write("Do you have an existing loan? (yes/no): ");
      string loan_response = Console.ReadLine();
      // Convert yes/no into bool
      bool has_existing_loan =( loan_response == "yes");
      // Check overall eligibility using && and !
      if (age >= 21 && age <= 60 && monthly_income >= 400 && !has_existing_loan)
      {
          Console.WriteLine("You are eligible for the loan.");
          
      }
      else
      {
          Console.WriteLine("You are not eligible for the loan.");
          // Determine the specific reason
          if (age < 21 || age > 60)
          {
              Console.WriteLine("Reason: Age out of range.");
          }
          else if (monthly_income < 400)
          {
              Console.WriteLine("Reason: Income too low.");
          }
          else if (has_existing_loan)
          {
              Console.WriteLine("Reason: Has an existing loan.");
          }
      }*/
     ////////////////////////////////////////////////////////
     /* //TASK 12 ( Shipping Cost Calculator)
     Console.WriteLine("Shipping Cost Calculator)");
     // Ask user for region code
     Console.Write("Enter region code (A = local, B = national, C = international): ");
     char region = char.Parse(Console.ReadLine());
     // Ask user for package weight
     Console.Write("Enter package weight (kg): ");
     double weight = double.Parse(Console.ReadLine());
     double base_cost;
     double extra_charge;
     switch (region)
     {
         case 'A':
             base_cost = 1.000;
             if (weight > 10)
             {
                 extra_charge = 5.000;
             }
             else if (weight > 5)
             {
                 extra_charge = 2.000;
             }
             else
             {
                 extra_charge = 0.000;
             }
             Console.WriteLine($"base cost: {base_cost} OMR");
             Console.WriteLine($"extra charge: {extra_charge} OMR");
             Console.WriteLine($"total shipping cost: {base_cost + extra_charge} OMR");
             break;
         case 'B':
             base_cost = 3.000;
             if (weight > 10)
             {
                 extra_charge = 5.000;
             }
             else if (weight > 5)
             {
                 extra_charge = 2.000;
             }
             else
             {
                 extra_charge = 0.000;
             }
             Console.WriteLine($"base cost: {base_cost} OMR");
             Console.WriteLine($"extra charge: {extra_charge} OMR");
             Console.WriteLine($"total shipping cost: {base_cost + extra_charge} OMR");
             break;
         case 'C':
             base_cost = 7.000;
             if (weight > 10)
             {
                 extra_charge = 5.000;
             }
             else if (weight > 5)
             {
                 extra_charge = 2.000;
             }
             else
             {
                 extra_charge = 0.000;
             }
             Console.WriteLine($"base cost: {base_cost} OMR");
             Console.WriteLine($"extra charge: {extra_charge} OMR");
             Console.WriteLine($"total shipping cost: {base_cost + extra_charge} OMR");
             break;
         default:
             Console.WriteLine("Invalid region");
             break;
             
  
             
     }*/
     ////////////////////////////////////////////////////////
     /*//TASK 13 ( Triangle Type Classifier)
     Console.WriteLine("Triangle Type Classifier)");
     // Ask user for the three sides
     Console.Write("Enter side A: ");
     double A = double.Parse(Console.ReadLine());
     Console.Write("Enter side B: ");
     double B = double.Parse(Console.ReadLine());
     Console.Write("Enter side C: ");
     double C = double.Parse(Console.ReadLine());
     // Check validity: sum of any two sides must be greater than the third
     if (A + B > C && A + C > B && B + C > A)
     {
         Console.WriteLine("This is a valid triangle.");
         if (A == B && B == C)
         {
             Console.WriteLine("Type: Equilateral");
         }
         else
         {
             if (A == B || B == C || A == C)
             {
                 Console.WriteLine("Type: Isosceles");
             }
             else
             {
                 Console.WriteLine("Type: Scalene");
             }
         }

     }
     else
     {
         Console.WriteLine("These sides do not form a valid triangle.");
     }*/
     ////////////////////////////////////////////////////////
     /*//TASK 14 (Online Store Checkout)
     Console.WriteLine("Online Store Checkout");
     // Ask user for product code
     Console.Write("Enter product code (1 = Headphones, 2 = Keyboard, 3 = Mouse): ");
     int product_code = int.Parse(Console.ReadLine());
     double unit_price;
     string product_name;
     switch (product_code)
     {
         case 1:
             product_name = "Headphones";
             unit_price = 8.500;
             break;
         case 2:
             product_name = "Keyboard";
             unit_price = 12.000;
             break;
         case 3:
             product_name = "Mouse";
             unit_price = 5.000;
             break;
         default:
             Console.WriteLine("Invalid product code");
             return;
         
     }
     // Ask user for quantity
     Console.Write("Enter quantity: ");
     int quantity = int.Parse(Console.ReadLine());
     // Ask user for coupon status
     Console.Write("Do you have a discount coupon? (yes/no): ");
     string coupon_response = Console.ReadLine();
     bool has_coupon = (coupon_response == "yes");
     // Calculate subtotal
     double subtotal = quantity * unit_price;
     //Apply discount if eligible
     double discount;
     if (has_coupon && subtotal > 20)
     {
         discount = subtotal * 0.10;
     }
     else
     {
         discount = 0;
     }
     // Amount after discount
     double after_discount = subtotal - discount;
     // Apply flat 5% tax on the discounted amount
     double tax = after_discount * 0.05;
     // Final total
     double total= after_discount + tax;
     // Print results
     Console.WriteLine($"Product: {product_name} ");
     Console.WriteLine($"Subtotal: {subtotal} OMR ");
     Console.WriteLine($"Discount: {discount} OMR");
     Console.WriteLine($"Tax: {tax} OMR ");
     Console.WriteLine($"Total: {total} OMR"); */
     ////////////////////////////////////////////////////////
     /*// TASK 15 (University Admission Decision) 
     Console.WriteLine("University Admission Decision Tool");
     // Ask user for program type
     Console.Write("Enter program type (S = Science, A = Arts): ");
     char program_type = char.Parse(Console.ReadLine());
     // Ask user for GPA
     Console.Write("Enter GPA (out of 4.0): ");
     double gpa = double.Parse(Console.ReadLine());
     // Ask user for exam score
     Console.Write("Enter entrance exam score (out of 100): ");
     double exam_score = double.Parse(Console.ReadLine());
     // Ask user for extracurricular achievement
     Console.Write("Do you have an extracurricular achievement? (yes/no): ");
     string extra_response = Console.ReadLine();
     bool has_extracurricular = (extra_response == "yes");
     string program_name;
     bool meets_requirements;
     // Determine requirements based on program type
     switch (program_type)
     {
         case 'S':
             program_name = "Science";
             meets_requirements = (gpa >= 3.0 && exam_score >= 75);
             break;
         case 'A':
             program_name = "Arts";
             meets_requirements = (gpa >= 2.5 && exam_score >= 60);
             break;
         default:
             Console.WriteLine("Invalid program type");
             return;
             
         
     }
     // Decide final admission result
     if (meets_requirements)
     {
         Console.WriteLine("Result: Admitted");
     }
     else
     {
         if (has_extracurricular)
         {
             Console.WriteLine("Result: Conditionally Admitted");
         }
         else
         {
             Console.WriteLine("Result: Not Admitted");
         }
     }
     Console.WriteLine($"Program:{program_name}");*/
     
     
     
     


      
      
      
      






}

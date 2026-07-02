namespace Task2;

class Program
{
    static void Main(string[] args)
    {
        /*//Task 1 (Countdown Timer)
        Console.Write("Enter a starting number: ");
        int start = int.Parse(Console.ReadLine());
        for (int i = start; i >= 1; i--)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine("Liftoff!"); */
        //////////////////////////////////////////////////////////////////////
        
       /* //Task 2 (Sum of Numbers 1 to N)
        Console.Write("Enter a positive whole number N:");
        int n = int.Parse(Console.ReadLine());
        int sum = 0;
        for (int i = 0; i <= n; i++)
        {
            sum += i;
        }
        Console.WriteLine($"The sum is: {sum}");*/
       //////////////////////////////////////////////////////////////////////
       
       /*//Task 3 (Multiplication Table)
       Console.Write("Enter a number: ");
       int num = int.Parse(Console.ReadLine());
       for (int i = 1; i <= 10; i++)
       {
           Console.WriteLine($"{i} * {num} = {num * i}");
       }*/
       //////////////////////////////////////////////////////////////////////
       
       /*//Task 4 (Password Retry)
       string validPassword = "Spark2026";
       string userInput = "";
       while (userInput != validPassword)
       {
           Console.Write("Enter the password: ");
           userInput = Console.ReadLine();
           if (userInput != validPassword)
           {
               Console.WriteLine("Incorrect password, please try again");
           }
       }
       Console.WriteLine("Access Granted");*/
       //////////////////////////////////////////////////////////////////////
       
       /*//Task 5 (Number Guessing Game)
       int secretNumber = 67;
       int guess;
       int attempts = 0;
       do
       {
           Console.Write("Enter your guess: ");
           guess = int.Parse(Console.ReadLine());
           attempts = attempts + 1;
           if (guess > secretNumber)
           {
               Console.WriteLine("Too high");
           }
           else if (guess < secretNumber)
           {
               Console.WriteLine("Too low");
           }
           else
           {
               Console.WriteLine($"Congrats! It took you {attempts} attempts");
           }
       }
       while (guess != secretNumber);*/
       //////////////////////////////////////////////////////////////////////
       
       /*//Task 6 (Safe Division Calculator)
       Console.Write("Enter the first number: ");
       string input1 = Console.ReadLine();

       Console.Write("Enter the second number: ");
       string input2 = Console.ReadLine();
       try
       {
           int num1 = int.Parse(input1);
           int num2 = int.Parse(input2);

           int result = num1 / num2;

           Console.WriteLine($"The result is {result}");
       }
       catch (DivideByZeroException)
       {
           Console.WriteLine("Error: You can't divide by zero!");
       }
       catch (FormatException)
       {
           Console.WriteLine("Error: Please enter valid whole numbers.");
       }*/
       //////////////////////////////////////////////////////////////////////
       
       /*// Task 7 ( Repeating Menu with Exit Option)
       bool running = true;
       while (running)
       {
           Console.WriteLine("\n===== MENU =====");
           Console.WriteLine("1. Say Hello");
           Console.WriteLine("2. Show Time-of-day Greeting");
           Console.WriteLine("3. Exit");
           Console.Write("Enter your choice: ");

           string input = Console.ReadLine();
           try
           {
               int choice = int.Parse(input);
               switch (choice)
               {
                   case 1:
                       Console.WriteLine("Hello!");
                       break;
                   case 2:
                       Console.WriteLine("Have a  nice day!");
                       break;
                   case 3:
                       Console.WriteLine("Goodbye!");
                       running = false;
                       break;
                   default:
                       Console.WriteLine("Please choose a valid option (1-3).");
                       break;
               }
           }
           catch (FormatException)
           {
               Console.WriteLine("Please choose a valid option (1-3) from the menu.");
           }
       }*/
       ///////////////////////////////////////////////////////////////////////
       
       /*//Task 8 (Sum of Even Numbers Only)
       Console.Write("Enter a positive whole number N: ");
       int n = int.Parse(Console.ReadLine());

       int sum = 0;

       for (int i = 1; i <= n; i++)
       {
           if (i % 2 == 0)
           {
               sum += i;
           }
       }

       Console.WriteLine($"The sum of even numbers is: {sum}");*/
       ///////////////////////////////////////////////////////////////////////
       
       //Task 9 (Validated Positive Number Input)
       int n = 0;
       bool validInput = false;

       do
       {
           Console.Write("Enter a positive whole number: ");
           string input = Console.ReadLine();

           try
           {
               n = int.Parse(input);

               if (n <= 0)
               {
                   Console.WriteLine("Please enter a number greater than zero.");
               }
               else
               {
                   validInput = true;
               }
           }
           catch (FormatException)
           {
               Console.WriteLine("Invalid input. Please enter a whole number.");
           }

       } while (!validInput);

       int sum = 0;

       for (int i = 1; i <= n; i++)
       {
           sum += i;
       }

       Console.WriteLine($"The sum from 1 to {n} is: {sum}");
       


    }
}

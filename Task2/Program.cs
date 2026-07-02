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
       
       //Task 5 (Number Guessing Game)
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
       while (guess != secretNumber);


    }
}
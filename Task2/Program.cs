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
       
       //Task 3 (Multiplication Table)
       Console.Write("Enter a number: ");
       int num = int.Parse(Console.ReadLine());
       for (int i = 1; i <= 10; i++)
       {
           Console.WriteLine($"{i} * {num} = {num * i}");
       }
       
    }
}
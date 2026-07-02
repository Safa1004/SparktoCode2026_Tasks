namespace Task2;

class Program
{
    static void Main(string[] args)
    {
        //Task 1 (Countdown Timer)
        Console.Write("Enter a starting number: ");
        int start = int.Parse(Console.ReadLine());
        for (int i = start; i >= 1; i--)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine("Liftoff!");
    }
}
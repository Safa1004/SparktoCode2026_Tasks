namespace Task3;

class Program
{
    static void Main(string[] args)
    {
        //TASK 1 (Absolute Difference)
        Console.Write("Enter the first number: ");
        double firstNumber = double.Parse(Console.ReadLine());
        Console.Write("Enter the second number: ");
        double secondNumber = double.Parse(Console.ReadLine());
        double result = firstNumber - secondNumber;
        double positiveDiffrence = Math.Abs(result);
        Console.WriteLine($"the positive diffrence is {positiveDiffrence}");

    }
}
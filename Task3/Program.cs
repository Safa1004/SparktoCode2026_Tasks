namespace Task3;

class Program
{
    static void Main(string[] args)
    {
       /* //TASK 1 (Absolute Difference)
        Console.Write("Enter the first number: ");
        double firstNumber = double.Parse(Console.ReadLine());
        Console.Write("Enter the second number: ");
        double secondNumber = double.Parse(Console.ReadLine());
        double result = firstNumber - secondNumber;
        double positiveDiffrence = Math.Abs(result);
        Console.WriteLine($"the positive diffrence is {positiveDiffrence}");*/
       ////////////////////////////////////////////////////////////////////////////
       
       //Task 2 (Power & Root Explorer)
       Console.Write("Enter a number: ");
       double num = double.Parse(Console.ReadLine());
       double sqr = Math.Pow(num, 2);
       double sqrRoot = Math.Sqrt(num);
       Console.WriteLine($"The square is: {sqr}");
       Console.WriteLine($"The square root is: {sqrRoot}");


    }
}
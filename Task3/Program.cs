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
       
       /* //Task 2 (Power & Root Explorer)
       Console.Write("Enter a number: ");
       double num = double.Parse(Console.ReadLine());
       double sqr = Math.Pow(num, 2);
       double sqrRoot = Math.Sqrt(num);
       Console.WriteLine($"The square is: {sqr}");
       Console.WriteLine($"The square root is: {sqrRoot}"); */
       ////////////////////////////////////////////////////////////////////////////
       
       /* // Task 3 ( Name Formatter)
       Console.Write("Please, Enter your full name: ");
       string fullName = Console.ReadLine();
       string upperFullName = fullName.ToUpper();
       string lowerFullName = fullName.ToLower();
       int fullNmaeLength = fullName.Length;
       Console.WriteLine($"Your full name in uppercase: {upperFullName}");
       Console.WriteLine($"Your full name in lowercase: {lowerFullName}");
       Console.WriteLine($"The number of characters in your full name is: {fullNmaeLength}");*/
       ////////////////////////////////////////////////////////////////////////////
       
       /* //Task 4 (Subscription End Date)
       Console.Write("Enter the number of trial days: ");
       int days = int.Parse(Console.ReadLine());
       DateTime endDate = DateTime.Today.AddDays(days);
       Console.WriteLine($"the end date of the trail is {endDate.ToString("dd/MM/yyyy")}"); */
       ////////////////////////////////////////////////////////////////////////////
       
       //Task (Grade Rounding System)
       Console.Write("Enter your raw exam score:");
       double examScore = double.Parse(Console.ReadLine());
       double roundedSxore = Math.Round(examScore, 0);
       Console.WriteLine($"Your rounded score is: {roundedSxore}");
       if (roundedSxore >= 60)
       {
           Console.WriteLine("Result: Pass");
       }
       else
       {
           Console.WriteLine("Result: Fail");
       }
       
       
       
       
       


    }
}
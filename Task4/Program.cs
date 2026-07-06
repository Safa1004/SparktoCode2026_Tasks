namespace Task4;

class Program
{
    /*//Task 1 ( Personalized Welcome Function)
    public static void PrintWelcome(string name)
    {
        Console.WriteLine($"Welcome balck! {name}");
        
    }*/
    //--------------------------------------------------------------
    //Task 2 ( Square Number Function)
    /*public static int Square(int number)
    {
        // Square means multiply a number by itself.
        return number * number;
    }*/
    //--------------------------------------------------------------
    //Task 3 (Celsius to Fahrenheit Function)
    /*public static double CelsiusToFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }*/
    //--------------------------------------------------------------
    //Task 4 (Fixed Menu Display Function)
    /*public static void DisplayMenu()
    {
        Console.WriteLine("1) Start");
        Console.WriteLine("2) Help");
        Console.WriteLine("3) Exit");
    } */
    //--------------------------------------------------------------
    //Task 5 (Even or Odd Function)
    /*public static bool IsEven(int number)
    {
        return number % 2 == 0;
    }*/
    //--------------------------------------------------------------
    //Task 6 (Rectangle Area & Perimeter Functions)
    /*public static double CalculateArea(double length, double width)
    {
        return length * width;
    }

    public static double CalculatePerimeter(double length, double width)
    {
        return 2 * (length + width);
    }*/
    //--------------------------------------------------------------
    //Task 7 (Grade Letter Function)
    public static string GetGradeLetter(int score)
    {
        if (score >= 90)
        {
            return "A";
        }
        else if (score >= 80)
        {
            return "B";
        }
        else if (score >= 70)
        {
            return "C";
        }
        else if (score >= 60)
        {
            return "D";
        }
        else
        {
            return "F";
        }
    }


    static void Main(string[] args)
    {
        /*//Task 1 ( Personalized Welcome Function)
        Console.Write("Enter your name: ");
        string userName = Console.ReadLine();
        PrintWelcome(userName);*/
        
        //--------------------------------------------------------------
        //Task 2 ( Square Number Function)
        /*Console.Write("Enter a number: ");
        int input = int.Parse(Console.ReadLine());
        int result = Square(input);
        Console.WriteLine($"The square of {input} is {result}.");*/
        
        //--------------------------------------------------------------
        //Task 3 (Celsius to Fahrenheit Function)
        /*Console.Write("Enter temperature in Celsius: ");
        double celsiusInput = double.Parse(Console.ReadLine());
        double fahrenheit = CelsiusToFahrenheit(celsiusInput);
        Console.WriteLine($"{celsiusInput} celsius is equal to {fahrenheit} fahrenheit.");*/
        
        //--------------------------------------------------------------
        //Task 4 (Fixed Menu Display Function)
        //DisplayMenu();
        
        //--------------------------------------------------------------
        //Task 5 (Even or Odd Function)
        /*Console.Write("Enter a number: ");
        int input = int.Parse(Console.ReadLine());
        bool result = IsEven(input);
        if (result)
        {
            Console.WriteLine("Even");
        }
        else
        {
            Console.WriteLine("Odd");
        }*/
        
        //--------------------------------------------------------------
        //Task 6 (Rectangle Area & Perimeter Functions)
        /*Console.WriteLine("Calculate Rectangle Area & Perimeterr \n");
        Console.Write("Enter length: ");
        double length = double.Parse(Console.ReadLine());

        Console.Write("Enter width: ");
        double width = double.Parse(Console.ReadLine());
        double area = CalculateArea(length, width);
        double perimeter = CalculatePerimeter(length, width);
        Console.WriteLine($"Area: {area}");
        Console.WriteLine($"Perimeter: {perimeter}");*/
        
        //--------------------------------------------------------------
        //Task 7 (Grade Letter Function)
        Console.Write("Enter your score: ");
        int score = int.Parse(Console.ReadLine());
        string grade = GetGradeLetter(score);
        Console.WriteLine($"Your grade is: {grade}");
        
        
        
        
        
        
    }
}
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
    /*public static string GetGradeLetter(int score)
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
    }*/
    //--------------------------------------------------------------
    //Task 8 (Countdown Function)
    /*public static void Countdown(int start)
    {
        for (int i = start; i >= 1; i--)
        {
            Console.WriteLine(i);
        }
    }*/
    //--------------------------------------------------------------
    //Task 9 (Overloaded Multiply Function)
    /* public static int Multiply(int a, int b)
     {
         return a * b;
     }

     public static double Multiply(double a, double b)
     {
         return a * b;
     }

     public static int Multiply(int a, int b, int c)
     {
         return a * b * c;
     }*/
    //--------------------------------------------------------------
    //Task 10 (Overloaded Area Calculator)
    /*public static double CalculateArea(double side)
    {
        return side * side;
    }
    public static double CalculateArea(double length, double width)
    {
        return length * width;
    }*/
    //--------------------------------------------------------------
    //Task 11 (Function-Based Calculator)
    public static double Add(double a, double b)
    {
        return a + b;
    }

    public static double Subtract(double a, double b)
    {
        return a - b;
    }

    public static double MultiplyNumbers(double a, double b)
    {
        return a * b;
    }

    public static double DivideNumbers(double a, double b)
    {
        try
        {
            if (b == 0)
            {
                throw new DivideByZeroException();
            }

            return a / b;
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Cannot divide by zero.");
            return 0; //so the function still gives back a valid number instead of letting the whole program crash.
        }
    }

    public static void DisplayResult(string operation, double result)
    {
        Console.WriteLine($"[{operation}] Result: {result}");
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
        /*Console.Write("Enter your score: ");
        int score = int.Parse(Console.ReadLine());
        string grade = GetGradeLetter(score);
        Console.WriteLine($"Your grade is: {grade}");*/

        //--------------------------------------------------------------
        //Task 8 (Countdown Function)
        /*Console.Write("Enter a starting number: ");
        int start = int.Parse(Console.ReadLine());

        Countdown(start);*/

        //--------------------------------------------------------------
        //Task 9 (Overloaded Multiply Function)
        /*int result1 = Multiply(6, 7);
        Console.WriteLine($"Multiply(int, int) = {result1}");

        double result2 = Multiply(6.5, 3.8);
        Console.WriteLine($"Multiply(double, double) = {result2}");

        int result3 = Multiply(5, 15, 25);
        Console.WriteLine($"Multiply(int, int, int) = {result3}");*/

        //--------------------------------------------------------------
        //Task 10 (Overloaded Area Calculator)
        /*Console.WriteLine("Area Calculator \n");
        Console.Write("Which shape do you want? (1 = Square, 2 = Rectangle): ");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                Console.Write("Enter side length: ");
                double side = double.Parse(Console.ReadLine());
                double squareArea = CalculateArea(side);
                Console.WriteLine($"Area of square: {squareArea}");
                break;
            case 2:
                Console.Write("Enter length: ");
                double length = double.Parse(Console.ReadLine());
                Console.Write("Enter width: ");
                double width = double.Parse(Console.ReadLine());
                double rectangleArea = CalculateArea(length, width);
                Console.WriteLine($"Area of rectangle: {rectangleArea}");
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }*/

        //--------------------------------------------------------------
        //Task 11 (Function-Based Calculator)
        bool keepGoing = true;

        while (keepGoing)
        {
            Console.WriteLine("\n--- Calculator Menu ---");
            Console.WriteLine("1) Add");
            Console.WriteLine("2) Subtract");
            Console.WriteLine("3) Multiply");
            Console.WriteLine("4) Divide");
            Console.WriteLine("5) Exit");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 5)
            {
                keepGoing = false;
                Console.WriteLine("Goodbye!");
                continue; //this skips the rest of the current loop iteration (like asking for numbers)
                //And jumps straight back up to check the while condition, which is now false, so the loop ends.
            }

            Console.Write("Enter first number: ");
            double num1 = double.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            double num2 = double.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    double addResult = Add(num1, num2);
                    DisplayResult("Addition", addResult);
                    break;
                case 2:
                    double subResult = Subtract(num1, num2);
                    DisplayResult("Subtraction", subResult);
                    break;
                case 3:
                    double mulResult = MultiplyNumbers(num1, num2);
                    DisplayResult("Multiplication", mulResult);
                    break;
                case 4:
                    double divResult = DivideNumbers(num1, num2);
                    DisplayResult("Division", divResult);
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }












    }
}

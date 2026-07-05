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
       
       /* //Task 5 (Grade Rounding System)
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
       }*/
       ////////////////////////////////////////////////////////////////////////////
       
       /*// Task 6 (Password Strength Checker)
       Console.Write("Please, enter your password to check its strength: ");
       string password = Console.ReadLine();
       bool checkLength = password.Length >= 8;
       bool forbiddinWord = password.ToLower().Contains("password");
       if (checkLength && !forbiddinWord)
       {
           Console.WriteLine("Strong password");
       }
       else
       {
           Console.WriteLine("Weak password");
           if (!checkLength)
           {
               Console.WriteLine("Reason: Password must be at least 8 characters long");
           }
           if (forbiddinWord) //Separate if (not else-if) so this still runs even if the one above already ran
           {
               Console.WriteLine("Reason: Password must not contain the word 'password'");
           }
       }*/
       ////////////////////////////////////////////////////////////////////////////
       
       /* //Task 7 (Clean Name Comparator)
       Console.Write("Enter your name: ");
       string name1 = Console.ReadLine();
       Console.Write("Enter your name again: ");
       string name2 = Console.ReadLine();
       string cleanedName1 = name1.Trim().ToUpper();
       string cleanedName2 = name2.Trim().ToUpper();
       if (cleanedName1 == cleanedName2)
       {
           Console.Write("Match");
       }
       else
       {
           Console.Write("No match");
       }*/
       ////////////////////////////////////////////////////////////////////////////
       
       /* //Task 8 Membership Expiry Checker
       Console.Write("Enter your membership start date (yyyy-MM-dd): ");
       string startDateInput = Console.ReadLine();
       Console.Write("Enter the number of valid membership days: ");
       int validDays = int.Parse(Console.ReadLine());
       try
       {
           DateTime startDate = DateTime.Parse(startDateInput);
           DateTime expiryDate = startDate.AddDays(validDays);
           if (expiryDate >= DateTime.Today)
           {
               Console.WriteLine("Membership status: Active");
           }
           else
           {
               Console.WriteLine("Membership status: Expired");
           }
           Console.WriteLine($"Expiry date: {expiryDate.ToString("yy-MM-dd")}");
           
       }
       catch (FormatException)
       {
           Console.WriteLine("That date doesn't look right. Please enter it like this: 2026-07-05");
       } */
       ////////////////////////////////////////////////////////////////////////////
       
       /* // Task 9 (Round Up / Round Down Explorer)
       Console.Write("Enter a decimal number: ");
       double num = double.Parse(Console.ReadLine());
       double nearest = Math.Round(num);
       double roundedUp = Math.Ceiling(num);
       double roundedDown = Math.Floor(num);
       Console.WriteLine($"Rounded to nearest: {nearest} ");
       Console.WriteLine($"Always rounded up: {roundedUp}");
       Console.WriteLine($"Always rounded down: {roundedDown}"); */
       ////////////////////////////////////////////////////////////////////////////
       
       /* // Task 10 (Word Position Finder)
       Console.Write("Enter a full sentence: ");
       string sentence = Console.ReadLine();

       Console.Write("Enter a word to search for: ");
       string word = Console.ReadLine();
       int firstPosition = sentence.IndexOf(word);
       int lastPosition = sentence.LastIndexOf(word);
       if (firstPosition == -1)
       {
           Console.WriteLine("Word not found in the sentence.");
       }
       else
       {
           Console.WriteLine($"First occurrence at position: {firstPosition}");
           Console.WriteLine($"Last occurrence at position: {lastPosition}");
       } */
       ////////////////////////////////////////////////////////////////////////////
       
       //Task 11 (One-Time Password (OTP) Generator)
       Random random = new Random();
       int otp = random.Next(1000, 10000); //// upper bound is exclusive, so 10000 gives max 9999
       Console.WriteLine($"Your OTP code is: {otp}");
       bool verified =  false;
       for (int attempt = 1; attempt <= 3; attempt++)
       {
           Console.WriteLine($"Enter the code attempt {attempt} out of 3");
           try
           {
               int enteredCode = int.Parse(Console.ReadLine());
               if (enteredCode == otp)
               {
                   Console.WriteLine("Verified");
                   verified = true;
                   break;
               }
               else
               {
                   Console.WriteLine("Incorrect code.");
               }
           }
           catch (FormatException)
           {
               Console.WriteLine("Invalid number, try again");
           }
       }

       if (!verified)
       {
           Console.WriteLine("Verification Failed");
       }
       
       
       












    }
}
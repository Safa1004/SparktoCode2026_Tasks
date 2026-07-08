namespace Task5;

class Program
{
    /*//Task 9 (Grade Analyzer with Functions)
    // takes a List of grades and returns the average as a double
    public static double CalculateAverage(List<int> grades) //takes in one parameter a List<int> called grades.
    {
        int sum = 0;
        // loop through the list and add up all the grades
        foreach (int grade in grades)
        {
            sum += grade;
        }
        double average = (double)sum / grades.Count; //so decimals aren't lost
        return average;
    }
    // takes a List of grades and returns the first one below 60
    public static int FindFirstFailing(List<int> grades) //takes in one parameter a List<int> called grades.
                                                         //So whoever calls this function has to hand it a list of grades.
    {
        //Find goes through the list and returns the first item that matches the condition
        int failingGrade = grades.Find(x => x < 60); //find gonna scan thru the list of grades
                                                     // about the condition is written in lambda expression style 
                                                     //x as a stand-in name for "each item in the list, one at a time
                                                     //So this reads as: "for each item x in the list, check if x is less than 60
                                                     
        return failingGrade;
    }*/
    //------------------------------------------------------------------------------------------------------------------
    //

    static void Main(string[] args)
    {
        //Task 1 (Fixed Grades Array)
        /*int [] grades = new int [5];
        // for loop to get input from the user and store each grade
        for (int i = 0 ; i < grades.Length ; i++)
        {
            Console.Write("Enter grade " + (i+1) + ": ");
            grades[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("\nThe grades you entered are:");
        // foreach loop to print every grade in the array
        foreach (int grade in grades)
        {
            Console.WriteLine(grade);
        }*/
        //////////////////////////////////////////////////////////////////////////////////

        //Task 2 (Dynamic To-Do List)
        /*// List to store to-do items, no fixed size needed (dynamic)
        List<String> tasks = new List<string>();
        // loop 5 times asking the user for a task each time
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Enter task " + (i + 1) + ": ");
            string task = Console.ReadLine();
            // add the entered task to the list by using .Add
            tasks.Add(task);
        }
        Console.WriteLine("\nYour To-Do List:");
        int number = 1; // used to number the tasks when printing
        // foreach loop to print every task in the list
        foreach (string task in tasks)
        {
            Console.WriteLine($"{number}. {task}");
            number++; // increase the number for the next task
        }*/
        //////////////////////////////////////////////////////////////////////////////////

        //Task 3 (Browsing History Stack)
        /*// stack to represent browser history (last page visited is on top (last in-first out)
        Stack<string> history = new Stack<string>();
        // ask user for 3 URLs and push each one onto the stack
        for (int i = 0; i < 3; i++)
        {
            Console.Write("Enter website URL " + (i + 1) + ": ");
            string url = Console.ReadLine();
            history.Push(url); //adss elements
        }
        Console.WriteLine("\nCurrent page: " + history.Peek()); //shows the 3rd URL (last one / in) (the one currently on top)
        // simulate pressing "back" once by popping the top page off the stack
        string poppedPage = history.Pop(); //you remove that current page, and whatever was pushed before it becomes the new top
        Console.WriteLine($"Going back from: {poppedPage}");
        // after popping, the new top of the stack is the page we land on
        Console.WriteLine("You are now on: " + history.Peek());*/
        //////////////////////////////////////////////////////////////////////////////////

        //Task 4 (Customer Service Queue)
        /*// queue to represent customers waiting in line (first in, first out)
        Queue<string> customerLine = new Queue<string>();
        // ask user for 3 customer names and enqueue each one
        for (int i = 0; i < 3; i++)
        {
            Console.Write("Enter customer name " + (i + 1) + ": ");
            string name = Console.ReadLine();

            customerLine.Enqueue(name); //adds elements
        }
        Console.WriteLine("\nCustomers currently in line: " + customerLine.Count);
        // serve the first customer by dequeuing them from the front of the line
        string servedCustomer = customerLine.Dequeue();
        //Dequeue() => removes the first item from the front of the queue and returns it to you at the same time.
        Console.WriteLine($"Now serving: {servedCustomer}");
        Console.WriteLine("Customers remaining in line: " + customerLine.Count);*/
        //////////////////////////////////////////////////////////////////////////////////

        //Task 5 (Array Grade Range)
        /*// array to store 5 grades
        int[] grades = new int[5];
        // loop to get the 5 grades from the user
        for (int i = 0 ; i <grades.Length ; i++)
        {
            Console.Write("Enter grade " + (i + 1) + ": ");
            grades[i] = int.Parse(Console.ReadLine());

        }
        // sort the array so lowest is at index 0 and highest is at the last index
        Array.Sort(grades);
        // loop through the sorted array to add up all the grades
        int sum = 0;
        for (int i = 0; i < grades.Length; i++)
        {
            sum += grades[i];
        }
        double average = (double)sum / grades.Length; // (double) so we don't lose decimals
        Console.WriteLine("\nLowest grade: " + grades[0]);
        Console.WriteLine("Highest grade: " + grades[grades.Length - 1]);
        Console.WriteLine("Average grade: " + average);*/
        //////////////////////////////////////////////////////////////////////////////////

        //Task 6 (Filtered Shopping List)
        /*// List to store shopping items
        List<string> shoppingList = new List<string>();
        Console.WriteLine("Enter items to add to your shopping list.");
        Console.WriteLine("Type 'done' when you're finished.\n");
        string item = ""; // will hold whatever the user types each time
        // while loop keeps asking for items until the user types "done"
        while (item != "done")
        {
            Console.Write("Enter item: ");
            item = Console.ReadLine();

            // only add it if it's not the word "done"
            if (item != "done")
            {
                shoppingList.Add(item); //add elements
            }
        }
        Console.Write("\nEnter the name of the item you want to remove: ");
        string itemToRemove = Console.ReadLine();
        //Remove takes out the first match it finds in the list
        shoppingList.Remove(itemToRemove);
        Console.WriteLine("\nFinal shopping list:");
        // foreach loop to print everything left in the list
        foreach (string i in shoppingList)
        {
            Console.WriteLine("- " + i);
        }*/
        //////////////////////////////////////////////////////////////////////////////////

        //Task 7 (High Score Podium)
        /*// List to store 5 game scores
        List<int> scores = new List<int>();

        // loop to get 5 scores from the user
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Enter score " + (i + 1) + ": ");
            int score = int.Parse(Console.ReadLine());

            scores.Add(score);
        }
        // sort puts scores in ascending order (lowest to highest) by default
        scores.Sort();
        // reverse flips it so highest is now first
        scores.Reverse();
        Console.WriteLine("\n--- Podium ---");
        Console.WriteLine("1st place: " + scores[0]);
        Console.WriteLine("2nd place: " + scores[1]);
        Console.WriteLine("3rd place: " + scores[2]);*/
        //////////////////////////////////////////////////////////////////////////////////

        //Task 8 (Undo Last Action)
        /* // stack to track actions done in the editor
         Stack<string> actions = new Stack<string>();
         Console.WriteLine("Enter your actions one by one.");
         Console.WriteLine("Type 'stop' when you're done.\n");
         string action = ""; // holds whatever the user types each time
         while (action != "stop")
         {
             Console.Write("Enter action: ");
             action = Console.ReadLine();
             if (action != "stop")
             {
                 actions.Push(action);
             }
         }

         Console.WriteLine("\n--- Undo x2 ---");
         // pop once to undo the most recent action
         string undo1 = actions.Pop();
         Console.WriteLine("Undo: " + undo1);
         // pop again to undo the next most recent action
         string undo2 = actions.Pop();
         Console.WriteLine("Undo: " + undo2);
         Console.WriteLine("\nRemaining actions on the stack:");
         // foreach to print whatever actions are left
         foreach (string a in actions)
         {
             Console.WriteLine($"- {a}");
         }*/
        //////////////////////////////////////////////////////////////////////////////////

        /*//Task 9 (Grade Analyzer with Functions)
        Console.Write("How many grades do you want to enter? ");
        int count = int.Parse(Console.ReadLine());
        List<int> grades = new List<int>();
        // loop 'count' times to get each grade from the user
        for (int i = 0; i < count; i++)
        {
            Console.Write("Enter grade " + (i + 1) + ": ");
            int grade = int.Parse(Console.ReadLine());
            grades.Add(grade);
        }

        double average = CalculateAverage(grades);
        int firstFailing = FindFirstFailing(grades);
        Console.WriteLine("\nAverage grade: " + average);
        //Find returns 0 for an int list when nothing matches, so we check for that
        if (firstFailing == 0)
        {
            Console.WriteLine("No failing grades found.");
        }
        else
        {
            Console.WriteLine("First failing grade: " + firstFailing);
        }*/
        //////////////////////////////////////////////////////////////////////////////////
        
        //
    











}
}
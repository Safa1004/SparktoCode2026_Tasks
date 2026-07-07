namespace Task5;

class Program
{
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
        // array to store 5 grades
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
        Console.WriteLine("Average grade: " + average);







    }
}
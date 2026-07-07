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
        // List to store to-do items, no fixed size needed (dynamic)
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
        }

    }
}
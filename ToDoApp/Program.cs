using System.ComponentModel;
using System.Text.Json;

class ToDoApp
{
    public static void Main()
    {
        int menuSelection;

        Console.WriteLine("-----------------------");
        Console.WriteLine("Welcome to ToDo App");
        Console.WriteLine("-----------------------");

        do
        {
            Console.WriteLine("");
            Console.WriteLine("0. Exit.");
            Console.WriteLine("1. Add to list.");
            Console.WriteLine("2. View all ToDos.");
            Console.WriteLine("3. View all pending ToDos.");
            Console.WriteLine("4. Mark as complete.");
            Console.WriteLine("5. Remove from list.");
            Console.WriteLine("");

            menuSelection = InputHandeling.MenuSelectionNumber(0, 6);

            switch (menuSelection)
            {
                case 0:
                    Console.WriteLine("Exiting..");
                    break;
                case 1:
                    Console.WriteLine("");
                    Console.WriteLine("Creating a new ToDo task ...");
                    Console.WriteLine("");
                    Action.AddToDo();
                    break;
                case 2:
                    Console.WriteLine("");
                    Console.WriteLine("Fetching all list...");
                    Console.WriteLine("");
                    Action.ViewAllToDo();
                    break;
                case 3:
                    Console.WriteLine("");
                    Console.WriteLine("Fetching all pending ToDos...");
                    Console.WriteLine("");
                    Action.ViewPending();
                    break;
                case 4:
                    Console.WriteLine("");
                    Console.WriteLine("Fetching all list...");
                    Console.WriteLine("");
                    Action.MarkComplete();
                    break;
                default:
                    Console.WriteLine("Not a valid Action or Yet to impliment.");
                    break;
            }

        } while (menuSelection != 0);
    }
}

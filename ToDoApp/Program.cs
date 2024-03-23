class ToDoApp
{
    public static void Main()
    {
        int menuSelection;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("-----------------------");
        Console.WriteLine("Welcome to ToDo App");
        Console.WriteLine("-----------------------");
        Console.ForegroundColor = ConsoleColor.White;


        do
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("");
            Console.WriteLine("0. Exit.");
            Console.WriteLine("1. Add to list.");
            Console.WriteLine("2. View all ToDos.");
            Console.WriteLine("3. View all pending ToDos.");
            Console.WriteLine("4. Mark as complete.");
            Console.WriteLine("5. Remove all completed todos.");
            Console.WriteLine("6. Remove all.");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;

            menuSelection = InputHandeling.MenuSelectionNumber(0, 6);

            switch (menuSelection)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Exiting..");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 1:
                    Console.WriteLine("");
                    Console.WriteLine("Creating a new ToDo task ...");
                    Console.WriteLine("");
                    Action.AddToDo();
                    GC.Collect();
                    break;
                case 2:
                    Console.WriteLine("");
                    Console.WriteLine("Fetching all list...");
                    Console.WriteLine("");
                    Action.ViewAllToDo();
                    GC.Collect();
                    break;
                case 3:
                    Console.WriteLine("");
                    Console.WriteLine("Fetching all pending ToDos...");
                    Console.WriteLine("");
                    Action.ViewPending();
                    GC.Collect();
                    break;
                case 4:
                    Console.WriteLine("");
                    Console.WriteLine("Fetching all list...");
                    Console.WriteLine("");
                    Action.MarkComplete();
                    GC.Collect();
                    break;
                case 5:
                    Console.WriteLine("");
                    Console.WriteLine("Removing all completed ToDos.");
                    Console.WriteLine("");
                    Action.RemoveCompleted();
                    GC.Collect();
                    break;
                case 6:
                    Console.WriteLine("");
                    Console.WriteLine("Deleting all item from list.");
                    Console.WriteLine("");
                    Action.RemoveAll();
                    break;
                default:
                    Console.WriteLine("Not a valid Action or Yet to impliment.");
                    break;
            }

        } while (menuSelection != 0);
    }
}

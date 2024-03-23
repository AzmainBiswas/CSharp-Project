using System.Text.Json;

class Action
{
    static readonly string jsonFilePath = @"todo.json";
    // Adding todo list
    public static void AddToDo()
    {
        int menuSelection;

        string? name;
        string? description;
        bool urgent;
        bool pending = true;
        DateTime creationTime = DateTime.Now;

        Console.WriteLine("Please enter the Name of your ToDo");
        Console.Write("=> ");
        name = Console.ReadLine();

        Console.WriteLine("Please enter the Description of your ToDo");
        Console.Write("=> ");
        description = Console.ReadLine();

        Console.WriteLine("Is Your Created Task is urgen?");
        Console.WriteLine("1. Yes\n2. No");
        menuSelection = InputHandeling.MenuSelectionNumber(1, 2);
        urgent = menuSelection switch
        {
            1 => true,
            2 => false,
            _ => false
        };

        ToDoJson? newToDo = new ToDoJson();
        newToDo.Name = name;
        newToDo.Description = description;
        newToDo.Urgent = urgent;
        newToDo.Pending = pending;
        newToDo.CreationTime = creationTime;

        // read from json data.
        string? todoJsonString = File.ReadAllText(jsonFilePath);
        List<ToDoJson>? todoListJsonData = JsonSerializer.Deserialize<List<ToDoJson>>(todoJsonString);

        // Check if todoListJsonData is null, and if so, initialize it with a new list
        if (todoListJsonData == null)
        {
            todoListJsonData = new List<ToDoJson>();
        }

        // added new item to json Object
        todoListJsonData.Add(newToDo);

        // Write to new json file
        string addedTodoJsonString = JsonSerializer.Serialize(todoListJsonData);
        File.WriteAllText(jsonFilePath, addedTodoJsonString);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("");
        Console.WriteLine("-----------------------------------------------------------");
        Console.WriteLine("Your task " + newToDo.Name + " Added.");
        Console.WriteLine("Added time: " + newToDo.CreationTime.ToString());
        Console.WriteLine("-----------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;

    }

    // viewing toDo list..
    public static void ViewAllToDo()
    {
        // read from json data
        string? todoJsonString = File.ReadAllText(jsonFilePath);
        List<ToDoJson>? toDoJsons = JsonSerializer.Deserialize<List<ToDoJson>>(todoJsonString);


        if (toDoJsons == null || toDoJsons.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("");
            Console.WriteLine("Your List is empty...");
            Console.WriteLine("Please add ToDo first.");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }

        Console.WriteLine("-----------------------------------------------------------");
        foreach (var toDo in toDoJsons)
        {
            Console.WriteLine("Name: " + toDo.Name);
            Console.WriteLine("Description: " + toDo.Description);
            Console.WriteLine("Urgent: " + toDo.Urgent);
            Console.WriteLine("Created at " + toDo.CreationTime.ToString());

            if (toDo.Pending) Console.WriteLine("Pending!!!");
            else Console.WriteLine("Completed ");
            Console.WriteLine("-----------------------------------------------------------");
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("");
        Console.WriteLine("-----------------------------------------------------------");
        Console.WriteLine("You have total " + toDoJsons.Count + " ToDos and " + toDoJsons.Count(x => x.Pending == false) + " completed ToDos.");
        Console.WriteLine("-----------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
    }

    // view all pending todo .. 
    public static void ViewPending()
    {
        int countPending = 0;
        int countUrgent = 0;

        // read from json data
        string? todoJsonString = File.ReadAllText(jsonFilePath);
        List<ToDoJson>? toDoJsons = JsonSerializer.Deserialize<List<ToDoJson>>(todoJsonString);

        if (toDoJsons == null || toDoJsons.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("");
            Console.WriteLine("Your List is empty...");
            Console.WriteLine("Please add ToDo first.");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }

        Console.WriteLine("-----------------------------------------------------------");
        foreach (var toDo in toDoJsons)
        {
            if (toDo.Pending)
            {
                Console.WriteLine("Name: " + toDo.Name);
                Console.WriteLine("Description: " + toDo.Description);
                Console.WriteLine("Urgent: " + toDo.Urgent);
                Console.WriteLine("Created at " + toDo.CreationTime.ToString());
                Console.WriteLine("");
                Console.WriteLine("-----------------------------------------------------------");

                if (toDo.Urgent)
                {
                    countUrgent++;
                }

                countPending++;
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("");
        Console.WriteLine("-----------------------------------------------------------");
        if (countPending == 0) Console.WriteLine("You have no pending work todo.");
        else if (countPending == 1) Console.WriteLine($"You have total {countPending} work pending and {countUrgent} urgent.");
        else Console.WriteLine($"You have total {countPending} works pending and out of them {countUrgent} are urgent.");
        Console.WriteLine("-----------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;

    }

    // mark as complete
    public static void MarkComplete()
    {
        int listIndex = 0;
        int countPending = 0;
        int menuSelection;

        // read from json file
        string? todoJsonString = File.ReadAllText(jsonFilePath);
        List<ToDoJson>? toDoJsons = JsonSerializer.Deserialize<List<ToDoJson>>(todoJsonString);

        if (toDoJsons == null || toDoJsons.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("");
            Console.WriteLine("Your List is empty...");
            Console.WriteLine("Please add ToDo first.");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }

        Console.WriteLine($"Index\tTask Name");

        for (int i = 0; i < toDoJsons.Count; i++)
        {
            if (toDoJsons[i].Pending)
            {
                Console.WriteLine($"{listIndex}\t{toDoJsons[i].Name}");
                countPending++;
            }
            listIndex++;
        }

        Console.WriteLine("-----------------------------------------------------------");

        if (countPending == 0)
        {
            Console.WriteLine("You have not work pending.");
            return;
        }

        menuSelection = InputHandeling.MenuSelectionNumber(0, toDoJsons.Count - 1);
        toDoJsons[menuSelection].Pending = false;

        // Write to new json file
        string? addedTodoJsonString = JsonSerializer.Serialize(toDoJsons);
        File.WriteAllText(jsonFilePath, addedTodoJsonString);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("-----------------------------------------------------------");
        Console.WriteLine($"{toDoJsons[menuSelection].Name} merked as complete.");
        Console.WriteLine("-----------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
    }

    // Remove all completed ToDos
    public static void RemoveCompleted()
    {
        // read from json file
        string? todoJsonString = File.ReadAllText(jsonFilePath);
        List<ToDoJson>? toDoJsons = JsonSerializer.Deserialize<List<ToDoJson>>(todoJsonString);

        if (toDoJsons == null || toDoJsons.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("");
            Console.WriteLine("Your List is empty...");
            Console.WriteLine("Please add ToDo first.");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }

        Console.Write("Are you sure? (y/n) ");
        string? conformation = Console.ReadLine();

        if (conformation == null)
        {
            Console.WriteLine("Action is canceled");
            return;
        }

        if (conformation.Trim().ToLower() != "y")
        {
            Console.WriteLine("Action is canceled");
            return;
        }

        // remove all completed task
        toDoJsons.RemoveAll(x => x.Pending == false);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("-----------------------------------------------------------");
        Console.WriteLine("All to completed ToDos has been removed.");
        Console.WriteLine("-----------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        // write to jason
        string? addedTodoJsonString = JsonSerializer.Serialize(toDoJsons);
        File.WriteAllText(jsonFilePath, addedTodoJsonString);
    }

    // remove all
    public static void RemoveAll()
    {
        // read from json file
        string? todoJsonString = File.ReadAllText(jsonFilePath);
        List<ToDoJson>? toDoJsons = JsonSerializer.Deserialize<List<ToDoJson>>(todoJsonString);

        if (toDoJsons == null || toDoJsons.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("");
            Console.WriteLine("Your List is empty...");
            Console.WriteLine("Please add ToDo first.");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }

        Console.Write("Are you sure? (y/n) ");
        string? conformation = Console.ReadLine();

        if (conformation == null)
        {
            Console.WriteLine("Action is canceled");
            return;
        }

        if (conformation.Trim().ToLower() != "y")
        {
            Console.WriteLine("Action is canceled");
            return;
        }

        // remove all task
        toDoJsons.Clear();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("-----------------------------------------------------------");
        Console.WriteLine("All items are removed...");
        Console.WriteLine("-----------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;

        // write to jason
        string? addedTodoJsonString = JsonSerializer.Serialize(toDoJsons);
        File.WriteAllText(jsonFilePath, addedTodoJsonString);

    }
}

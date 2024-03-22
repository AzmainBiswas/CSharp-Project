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

        Console.WriteLine("");
        Console.WriteLine("-----------------------------------------------------------");
        Console.WriteLine("Your task " + newToDo.Name + " Added.");
        Console.WriteLine("Added time: " + newToDo.CreationTime.ToString());
        Console.WriteLine("-----------------------------------------------------------");

        // free memory.
        todoJsonString = null;
        todoListJsonData = null;
        GC.Collect();
    }

    // viewing toDo list..

    public static void ViewAllToDo()
    {
        // read from json data
        string? todoJsonString = File.ReadAllText(jsonFilePath);
        List<ToDoJson>? toDoJsons = JsonSerializer.Deserialize<List<ToDoJson>>(todoJsonString);


        if (toDoJsons == null || toDoJsons.Count == 0)
        {
            Console.WriteLine("");
            Console.WriteLine("Your List is empty...");
            Console.WriteLine("Please add ToDo first.");
            Console.WriteLine("");
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
            Console.WriteLine("");

            Console.WriteLine("-----------------------------------------------------------");
        }

        //free memory
        todoJsonString = null;
        toDoJsons = null;
        GC.Collect();
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
            Console.WriteLine("");
            Console.WriteLine("Your List is empty...");
            Console.WriteLine("Please add ToDo first.");
            Console.WriteLine("");
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

        Console.WriteLine("");
        Console.WriteLine("-----------------------------------------------------------");
        if (countPending == 0) Console.WriteLine("You have no pending work todo.");
        else if (countPending == 1) Console.WriteLine($"You have total {countPending} work pending and {countUrgent} urgent.");
        else Console.WriteLine($"You have total {countPending} works pending and out of them {countUrgent} are urgent.");
        Console.WriteLine("-----------------------------------------------------------");

        //free memory
        todoJsonString = null;
        toDoJsons = null;
        GC.Collect();
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
            Console.WriteLine("");
            Console.WriteLine("Your List is empty...");
            Console.WriteLine("Please add ToDo first.");
            Console.WriteLine("");
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

        Console.WriteLine("-----------------------------------------------------------");
        Console.WriteLine($"{toDoJsons[menuSelection].Name} merked as complete.");
        Console.WriteLine("-----------------------------------------------------------");

        //free memory
        todoJsonString = null;
        toDoJsons = null;
        addedTodoJsonString = null;
        GC.Collect();
    }
}

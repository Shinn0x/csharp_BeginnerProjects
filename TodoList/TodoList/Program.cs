Console.WriteLine("Welcome to the do do list program.");

string actionInput;
List<string> taskList = new List<string>();

bool exit = false;

while (!exit)
{
    actionInput = PromptActionInput();
    switch (actionInput)
    {
        case "1":
            AddTaskToTheList(taskList);
            break;
        case "2":
            RemoveTaskFromTheList(taskList);
            break;
        case "3":
            ViewAllList(taskList);
            break;
        case "e":
            Console.WriteLine("Terminating the programn...");
            exit = true;
            break;
        case "_":
            Console.WriteLine("Please enter a valid input!");
            break;
    }
}

static string PromptActionInput()
{

    Console.WriteLine("\n What would you like to do?");
    Console.WriteLine("Enter 1 to add a task to the list.");
    Console.WriteLine("Enter 2 to remove a task from the list.");
    Console.WriteLine("Enter 3 to view the task list.");
    Console.WriteLine("Enter e to exit the program.");
    Console.Write(">> ");
    string input = Console.ReadLine();
    return input;
}

static void AddTaskToTheList(List<string> taskList)
{
    string newTask;
    Console.WriteLine("Please enter the name of the task to add to the list.\nBack(insert back).");
    Console.Write(">> ");
    newTask = Console.ReadLine();
    if (!newTask.ToLower().Equals("back"))
    {
        taskList.Add(newTask);
        ModifyWrite("Task added to the list!");
    }
}

static void RemoveTaskFromTheList(List<string> taskList)
{
    string inputStr;
    int removeTaskNum;
    int taskLength = taskList.Count;
    if(taskLength > 0) {
        Console.WriteLine("Your to do list:");
        foreach (var (task, index) in taskList.Select((value, i) => (value, i)))
        {
            Console.WriteLine($"{index}: {task}");
        }

    }else{
        Console.WriteLine("Your to do list has no task!");
    }
    Console.WriteLine("Enter the task number you want to remove.\nBack(insert back). ");
    Console.Write(">> ");
    inputStr = Console.ReadLine();
    if (!inputStr.ToLower().Equals("back"))
    {
        if (int.TryParse(inputStr, out removeTaskNum))
        {
            if (removeTaskNum >= taskLength || removeTaskNum < 0)
            {
                Console.WriteLine("Please enter a valid input!");
            }
            else
            {
                taskList.RemoveAt(removeTaskNum);
                ModifyWrite("Task successfully removed from the list!");
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid input!");
        }
    }
    
}

static void ViewAllList(List<string> taskList)
{
    ModifyWrite("Your TO-DO List");
    foreach (string task in taskList)
    {
        Console.WriteLine($"{task}");
    }
}

static void ModifyWrite(string prompt)
{
    Console.WriteLine("========================================================");
    Console.WriteLine(prompt);
    Console.WriteLine("========================================================");
}


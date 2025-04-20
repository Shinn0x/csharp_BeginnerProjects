static void main()
{
    Console.WriteLine("Shape Area Calculator");

    int opInput = 0;

    // Loop until user exits
    while (true)
    {
        // Prompt The Input
        GetOpInput(ref opInput);

        double? result = opInput switch
        {
            1 => CalculateTriangleArea(),
            2 => CalculateRectangleArea(),
            3 => CalculateCircleArea(),
            4 => ExitApplication(),
            _ => null
        };

        // Print the result

        Console.WriteLine("\n--------------------------------------------------");

        string shapeName = opInput switch
        {
            1 => "Triangle",
            2 => "Rectangle",
            3 => "Circle",
            _ => "Unknown Shape"
        };

        Console.WriteLine($"Area of {shapeName}: {result.Value:F2} square units");

        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("");

    }
}

// Function to get user input for numeric values
static double GetInput(string prompt)
{
    double input;
    while (true)
    {
        Console.Write(prompt);
        if (double.TryParse(Console.ReadLine(), out input))
        {
            return input;
        }
        else
        {
            Console.WriteLine("Please enter a valid input!");
        }
    }
}

// Function to calculate triangle area
static double CalculateTriangleArea()
{
    double baseOfT = GetInput("Enter the base of triangle: ");
    double heightOfT = GetInput("Enter the height of triangle: ");
    return 0.5 * (baseOfT * heightOfT);
}

// Function to calculate rectangle area
static double CalculateRectangleArea()
{
    double widthOfR = GetInput("Enter the width of rectangle: ");
    double heightOfR = GetInput("Enter the height of rectangle: ");
    return widthOfR * heightOfR;
}

// Function to calculate circle area
static double CalculateCircleArea()
{
    double radius = GetInput("Enter the radius of circle: ");
    return Math.PI * Math.Pow(radius, 2); 
}

// Function to handle exit
static double ExitApplication()
{
    Console.WriteLine("Terminating Shape Area Calculator...");
    Thread.Sleep(1000);
    Console.Beep();
    Environment.Exit(0);
    // just to manipulate return data( unreachable)
    return 0.0;
}

// Function to get user choice
static void GetOpInput(ref int opInput)
{
    while (true)
    {
        Console.WriteLine("Please choose the shape you want to calculate:");
        Console.WriteLine("1. Triangle");
        Console.WriteLine("2. Rectangle");
        Console.WriteLine("3. Circle");
        Console.WriteLine("4. Exit");
        Console.Write("Enter your choice (1-4): ");

        string? userInput = Console.ReadLine();

        if (int.TryParse(userInput, out int input) && input >= 1 && input <= 4)
        {
            opInput = input;
            return;
        }
        else
        {
            Console.WriteLine("Invalid input! Please enter a number between 1 and 4.");
        }
    }
}

// Start of the programn
main();

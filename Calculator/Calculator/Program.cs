Console.WriteLine("Welcome to my beginner C# Console Project - Calculator");

try
{
    // Declare variables to store user input and the result
    double num1;
    double num2;
    double result;
    string op;

    // Get numeric input from the user
    num1 = GetNumber("Enter your first number: ");
    num2 = GetNumber("Enter your second number: ");

    // Get the operation symbol from the user
    op = GetOperation();

    // Perform the calculation based on the operation using a switch expression
    result = op switch
    {
        "+" => num1 + num2,
        "-" => num1 - num2,
        "*" => num1 * num2,
        "/" => num2 != 0 ? num1 / num2 : throw new DivideByZeroException(),
        _ => throw new InvalidOperationException("Unknown operation"),
    };

    // Display the result
    Console.WriteLine("\n====================================");
    Console.WriteLine("Result: {0}", result);
    Console.WriteLine("====================================");
}
catch (DivideByZeroException)
{
    // Handle division by zero errors
    Console.WriteLine("A number cannot be divided by zero!");
}
catch (InvalidOperationException ex)
{
    // Handle invalid operation symbols
    Console.WriteLine(ex.Message);
}
catch (Exception)
{
    // Handle any other unexpected errors
    Console.WriteLine("An unexpected error occurred!");
}
finally
{
    // Pause the program until the user presses a key
    Console.ReadKey();
}

// Method to safely get a numeric input from the user
static double GetNumber(string prompt)
{
    double number;
    while (true)
    {
        Console.Write(prompt);
        if (double.TryParse(Console.ReadLine(), out number))
        {
            return number;
        }
        Console.WriteLine("Please enter a valid number.");
    }
}

// Method to get a valid operation symbol from the user
static string GetOperation()
{
    string[] validOps = { "+", "-", "*", "/" };
    string input;

    while (true)
    {
        Console.Write("Please enter an operation symbol (+, -, *, /): ");
        input = Console.ReadLine();

        if (validOps.Contains(input))
        {
            return input;
        }

        Console.WriteLine("Invalid operation. Please try again.");
    }
}
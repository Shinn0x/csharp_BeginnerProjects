string[] grid = Enumerable.Range(1, 9).Select(i => i.ToString()).ToArray();
bool isPlayer1Turn = true;
bool exit = false;

while (!exit)
{
    PrintGrid(grid);
    PromptUser(grid, ref isPlayer1Turn);
    CheckResult(grid, ref exit, isPlayer1Turn);
}

static void CheckResult(string[] grid, ref bool exit, bool isPlayer1Turn)
{
    if (CheckCol(grid) || CheckRow(grid) || CheckDiagonal(grid))
    {
        exit = true;
        string winner = !isPlayer1Turn ? "Player 1 Wins!" : "Player 2 Wins!";
        Console.WriteLine();
        Console.WriteLine($"{winner}");
        Console.WriteLine("Terminating the program...");
        Thread.Sleep(1000);
        Console.Beep();
        Environment.Exit(0);
    }
    else if (CheckDraw(grid))
    {
        exit = true;
        Console.WriteLine();
        Console.WriteLine("It's a Draw!");
        Console.WriteLine("Terminating the program...");
        Thread.Sleep(1000);
        Console.Beep();
        Environment.Exit(0);
    }
}


static bool CheckDraw(string[] grid)
{
    bool result = true;
    foreach(string g in grid)
    {
        bool isEqual = g == "X" || g == "O";
        result = result && isEqual;
    }
    return result;
}

static bool CheckRow(string[] grid)
{
    bool result = false;
    for(int i = 0; i < 3; i++)
    {
      bool row = grid[i*3] == grid[i * 3 + 1] && grid[i * 3 + 1] == grid[i * 3 + 2];
        result = result || row;
    }
    return result;
}

static bool CheckCol(string[] grid)
{
    bool result = false;
    for (int i = 0; i < 3; i++)
    {
        bool col = grid[i] == grid[i + 3] && grid[i + 3] == grid[i + 6];
        result = result || col;
    }
    return result;
}

static bool CheckDiagonal(string[] grid)
{
    bool result = false;
    for (int i = 0; i < 2; i++) {
    
        bool diagonalCheck = grid[i*3] == grid[i + 4] && grid[i + 4] == grid[9 - 1 - (2*i)];
        result = result || diagonalCheck;
    }
    return result;
}
static void PromptUser(string[] grid, ref bool isPlayer1Turn)
{
    Console.WriteLine();
    Console.WriteLine("==================================");
    Console.WriteLine(isPlayer1Turn ? "Player 1's Turn (X)" : "Player 2's Turn (O)");
    Console.Write("Choose a position (1-9): ");

    string choiceStr = Console.ReadLine();
    int choiceInt;
    if ((int.TryParse(choiceStr, out choiceInt)) && grid.Contains(choiceStr))
    {
        grid[choiceInt - 1] = isPlayer1Turn ? "X" : "O";
        isPlayer1Turn = !isPlayer1Turn;
    }
    else
    {
        Console.WriteLine("Invalid move! Please enter a number between 1 and 9 that hasn’t been taken.");
        Console.ReadKey();
    }
    Console.WriteLine("==================================");
    Console.WriteLine();
}

static void PrintGrid(string[] grid)
{
    Console.Clear();
    Console.WriteLine("======= TIC TAC TOE =======");
    Console.WriteLine();

    for (int i = 0; i < 3; i++)
    {
        Console.Write("  ");
        for (int j = 0; j < 3; j++)
        {
            Console.Write($" {grid[i * 3 + j]} ");
            if (j != 2)
            {
                Console.Write("|");
            }
        }
        Console.WriteLine();
        if (i != 2)
        {
            Console.WriteLine(" ---+---+---");
        }
    }

    Console.WriteLine();
}


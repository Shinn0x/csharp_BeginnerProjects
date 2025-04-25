using System;

const int Rows = 3;
const int Cols = 2;
const int AsciiStart = 65;
const int TotalMatchesRequired = (Rows * Cols) / 2;

char[] grid = new char[Rows * Cols];
string[] playingGrid = Enumerable.Range(1, Rows * Cols).Select(i => i.ToString()).ToArray();
Random random = new Random();
bool exit = false;
int match = 0;

InitializeGrid(grid, random);

while (!(exit && match == TotalMatchesRequired))
{
    ShowPlayingGrid(playingGrid);
    PromptUser(playingGrid, grid, ref match, ref exit);

    if (match == TotalMatchesRequired)
    {
        Console.WriteLine("Congratulations! You matched all!");
    }

    if (exit)
    {
        Console.WriteLine("Terminating the program...");
        Thread.Sleep(1000);
        Console.Beep();
        Environment.Exit(0);
    }
}

static void InitializeGrid(char[] grid, Random random)
{
    for (int i = 0; i < grid.Length; i++)
    {
        grid[i] = Convert.ToChar(AsciiStart + (i / 2));
    }
    Shuffle(grid, random);
}

static void Shuffle<T>(T[] array, Random rand)
{
    for (int i = array.Length - 1; i > 0; i--)
    {
        int j = rand.Next(i + 1);
        (array[i], array[j]) = (array[j], array[i]);
    }
}

static void ShowPlayingGrid(string[] playingGrid)
{
    Console.WriteLine("+---+---+");
    for (int i = 0; i < playingGrid.Length; i++)
    {
        Console.Write($"| {playingGrid[i]} ");
        if ((i + 1) % Cols == 0)
        {
            Console.WriteLine("|\n+---+---+");
        }
    }
}

static void PromptUser(string[] playingGrid, char[] grid, ref int match, ref bool exit)
{
    int firstIndex = GetCardIndex("Please select your first card: ", playingGrid.Length, ref exit, playingGrid);
    if (exit) return;

    string originalFirst = playingGrid[firstIndex];
    playingGrid[firstIndex] = grid[firstIndex].ToString();
    ShowPlayingGrid(playingGrid);

    int secondIndex = GetCardIndex("Please select your second card: ", playingGrid.Length, ref exit, playingGrid);
    if (exit) return;

    string originalSecond = playingGrid[secondIndex];
    playingGrid[secondIndex] = grid[secondIndex].ToString();
    ShowPlayingGrid(playingGrid);

    if (grid[firstIndex] == grid[secondIndex])
    {
        match++;
        Console.WriteLine($"Great! You found {match} match(es).");
    }
    else
    {
        Console.WriteLine("Oops! Not a match.");
        playingGrid[firstIndex] = originalFirst;
        playingGrid[secondIndex] = originalSecond;
    }

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
    Console.Clear();
}

static int GetCardIndex(string prompt, int max, ref bool exit, string[] playingGrid)
{
    while (true)
    {
        Console.Write(prompt);
        string input = Console.ReadLine();

        if (input.ToLower() == "exit")
        {
            exit = true;
            return -1;
        }

        if (int.TryParse(input, out int index) && index >= 1 && index <= max)
        {
            int result = index - 1;
            int resultValueCheckStrToInt;
            if (!int.TryParse(playingGrid[result],out resultValueCheckStrToInt))
            {
                Console.WriteLine("Please enter a valid card number that hasn't been conveyed yet.");
            }
            else
            {
                return result;
            }
        }

        Console.WriteLine("Invalid input. Please enter a valid card number.");
    }
}

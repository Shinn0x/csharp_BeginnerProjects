Console.WriteLine("Welcome to my C# beginner project - Dice Game");

try
{
    // Initialize scores for both user and AI
    int userResult = 0;
    int aiResult = 0;
    int matches = 1;

    // Create a single instance of Random
    Random random = new Random();

    // Loop for 10 rounds
    while (matches <= 10)
    {
        Console.WriteLine($"Round {matches}: Press any key to roll the dice.");
        Console.ReadKey();

        // Call the roll method to simulate dice rolls and update scores
        roll(ref userResult, ref aiResult, random);
        matches++;

        Console.WriteLine("=========================");
        Console.WriteLine($"Your Score: {userResult}, AI Score: {aiResult}\n");
    }
   
    Console.WriteLine("=== Game Over ===");

    if (userResult > aiResult)
    {
        Console.WriteLine("Yay! You win...");
    }
    else if (aiResult > userResult)
    {
        Console.WriteLine("Try Again! You lose...");
    }
    else
    {
        Console.WriteLine("Oh! It was a draw...");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
finally
{
    Console.WriteLine("Press any key to exit.");
    Console.ReadKey();
}


// Method to simulate dice rolls and update scores
static void roll(ref int userResult, ref int aiResult, Random random)
{
    // Generate random dice values from 1 to 6
    int userDR = random.Next(1, 7);
    int aiDR = random.Next(1, 7);

    // Display rolled values
    Console.WriteLine($"You rolled: {userDR}");
    Console.WriteLine($"AI rolled: {aiDR}");

    // Compare rolls and update the score accordingly
    if (userDR > aiDR)
    {
        userResult++;
        Console.WriteLine("You win!");
    }
    else if (aiDR > userDR)
    {
        aiResult++;
        Console.WriteLine("AI wins!");
    }
    else
    {
        Console.WriteLine("It's a draw!");
    }
}

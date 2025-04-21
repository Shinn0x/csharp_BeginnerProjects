int playerHP = 40;
int enemyHP = 20;
int healAmount = 5;

Random random = new Random();

try
{
    while (playerHP > 0 && enemyHP > 0)
    {
        showCurrentHPs(playerHP, enemyHP);
        playerTurn(ref playerHP, ref enemyHP, healAmount);

        // End early if enemy is defeated
        if (enemyHP <= 0)
        {
            Console.WriteLine("\nYou defeated the enemy! Victory!");
            Console.ReadKey();
            break;
        }

        enemyTurn(ref playerHP, ref enemyHP, healAmount, random);

        // End early if player is defeated
        if (playerHP <= 0)
        {
            Console.WriteLine("\nYou were defeated by the enemy. Game Over.");
            break;
        }

        Console.Write("\nPress Enter to continue to the next round, or type 'exit' to quit: ");
        string nextOrExitOp = Console.ReadLine()?.Trim().ToLower();

        if (nextOrExitOp == "exit")
        {
            Console.WriteLine("Exiting the game... Goodbye!");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }

        Console.Clear();


    }
}
catch (Exception e)
{
    Console.WriteLine(e);
}
finally
{
    Console.Beep();
}


static void playerTurn(ref int playerHP, ref int enemyHP, int healAmount)
{
    int playerAttack = 5;
    bool validAction = false;

    while (!validAction)
    {
        Console.Write("\nChoose action - a for Attack, h for Heal: ");
        string actionInput = Console.ReadLine()?.Trim().ToLower();

        switch (actionInput)
        {
            case "a":
                enemyHP -= playerAttack;
                Console.WriteLine($"You attacked the enemy! Enemy HP is now {enemyHP}");
                validAction = true;
                break;
            case "h":
                playerHP += healAmount;
                Console.WriteLine($"You healed yourself! Your HP is now {playerHP}");
                validAction = true;
                break;
            default:
                Console.WriteLine("Invalid action. Please try again.");
                break;
        }
    }
}

static void enemyTurn(ref int playerHP, ref int enemyHP, int healAmount, Random random)
{
    int enemyAttack = 7;
    string[] actions = { "a", "h" };
    string action = actions[random.Next(0, 2)];

    Console.WriteLine("\nEnemy's turn:");

    switch (action)
    {
        case "a":
            playerHP -= enemyAttack;
            Console.WriteLine($"Enemy attacked you! Your HP is now {playerHP}");
            break;
        case "h":
            enemyHP += healAmount;
            Console.WriteLine($"Enemy healed itself! Enemy HP is now {enemyHP}");
            break;
    }
}

static void showCurrentHPs(int playerHP, int enemyHP)
{
    Console.WriteLine($"\n==== Current Status ====");
    Console.WriteLine($"Player HP: {playerHP}");
    Console.WriteLine($"Enemy  HP: {enemyHP}");
    Console.WriteLine("========================");
}

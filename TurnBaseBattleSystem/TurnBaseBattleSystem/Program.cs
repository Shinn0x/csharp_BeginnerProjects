using TurnBaseBattleSystem;
try
{
    Random random = new Random();
    Unit player = new Unit(100, 20, 12, "Player");
    Unit enemy = new Unit(75, 10, 7, "Enemy Mage");
    bool exit = false;
    Console.WriteLine("Ready for it! \n");
    ShowStatus(player, enemy);

    while ((player.CurrentHp > 0 && enemy.CurrentHp > 0) && !exit)
    {
        if (PlayerTurn(player, enemy,ref exit))
        {
            if (enemy.CurrentHp > 0)
            {
                EnemyTurn(enemy, player, random);
            }

            ShowStatus(player, enemy);
        }
    }

    if (!exit)
    {
        // Outcome message
        if (player.CurrentHp > 0)
        {
            Console.WriteLine("\nYou win! 🎉");
        }
        else
        {
            Console.WriteLine("\nYou lost... Better luck next time!");
        }
    }
    else
    {
        Console.WriteLine("Terminating the program...");
        Thread.Sleep(1000);
        Console.Beep();
        Environment.Exit(0);
    }
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}
finally
{
    Console.ReadKey();
}



bool PlayerTurn(Unit player, Unit enemy, ref bool exit)
    {
        Console.Write("Player Turn! What will you do? >> ");
        string choose = Console.ReadLine();

        if (!string.IsNullOrEmpty(choose.Trim()))
        {
            if (choose.Equals("a"))
            {
                player.Attack(enemy);
                return true;
            }
            else if (choose.Equals("h"))
            {
                player.Heal();
                return true;
        }
            else if (choose.ToLower().Equals("exit"))
        {
            exit = true;
            return true;
        }
            else
        {
            Console.WriteLine("Wtf bro");
            return false;
        }
        }
        else
        {
            Console.WriteLine("Please enter a valid input!");
            return false;
        }
    }

static void EnemyTurn(Unit enemy, Unit player, Random random)
{
    bool willAttack = random.Next(2) == 0;

    if (willAttack)
    {
        enemy.Attack(player);
    }
    else
    {
        enemy.Heal();
    }
}


static void ShowStatus(Unit player, Unit enemy)
{
    Console.WriteLine("=============================================");
    Console.WriteLine(player.UnitName + ": " + player.CurrentHp + " HP || " + enemy.UnitName + ": " + enemy.CurrentHp + " HP ");
    Console.WriteLine("=============================================");
}
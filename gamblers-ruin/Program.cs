using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamblers_ruin
/*
In Gambler’s ruin the player starts by specifying an initial pot of cash they are
going to play with and a target amount of money they hope to win. Each round two
dice are thrown. If the number is < 6 then the player wins €1 and it is added to
their total funds. If the number is >=6 they lose, and their cash pot is reduced by €1.
After each round the code should check to see if the player's current pot of cash is
equal to their target amount. If so, they have won the game and can choose to quit
or play again. If at any point the player's pot of cash reaches €0 then they lose the
game.

After each game ends (player has lost all their money or won), the code should ask
the player if they want to play again.
*/

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=======================\n==  GAMBLER'S RUIN  ==\n=======================\n");
            int playerPot = askInitialPot();
            int target = askTarget(playerPot);

            while (playerPot < target && playerPot > 0)
            {
                Console.WriteLine("Let's ROLL THE DICE!");
                int sumDiceRolls = rollDice() + rollDice();
                Console.WriteLine($"Result: {sumDiceRolls}");
                if (sumDiceRolls < 6)
                {
                    Console.WriteLine("You win this roll!");
                    playerPot++;
                } else
                {
                    Console.WriteLine("You lose this roll!");
                    playerPot--;
                }
                Console.WriteLine($"You have {playerPot} in the pot; target is {target}.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }

            if (playerPot == 0)
            {
                Console.WriteLine("Better luck next time...");
            } else
            {
                Console.WriteLine("You've reached your target. Now get out of my face.");
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static int rollDice()
        {
            return new Random().Next(1, 7);
        }

        private static int askTarget(int playerPot)
        {
            int target = 0;

            Console.Write("Grrreat! And how much do you want to walk away with? ");
            do
            {
                String userInput = Console.ReadLine();
                if (int.TryParse(userInput, out target))
                {
                    if (target <= playerPot)
                    {
                        Console.WriteLine("Target should be higher than your pot!\nTry again:");
                    }
                }
                else { Console.WriteLine("That doesn't look like a number!\nTry again:"); }
            } while (target <= playerPot);

            return target;
        }

        private static int askInitialPot()
        {
            int pot = 0;

            Console.Write("Welcome, gambler! How much do you want to bet? ");
            do
            {
                String userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int num))
                {
                    if (num > 0)
                    {
                        pot = num;
                    }
                    else
                    {
                        Console.WriteLine("Initial pot must be greater than 0!\nTry again: ");
                    }

                }
                else
                {
                    Console.WriteLine("That doesn't look like a number!\nTry again: ");
                }
            } while (pot <= 0);

            return pot;
        }
    }
}

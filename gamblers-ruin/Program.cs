using System;

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
        static void Main()
        {
            Console.WriteLine("=======================\n==  GAMBLER'S RUIN  ==\n=======================\n");

            // Ask player how much to bet and what their target is
            int playerPot = AskInitialPot();
            int target = AskTarget(playerPot);

            // Start main game loop
            while (playerPot < target && playerPot > 0)
            {
                Console.WriteLine("Let's ROLL THE DICE!");
                var rnd = new Random();
                int sumDiceRolls = rnd.Next(1, 7) + rnd.Next(1, 7);
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

        private static int AskInitialPot()
        {
            return AskInt("Welcome, gambler! How much do you want to bet? ", 1);
        }

        private static int AskTarget(int playerPot)
        {
            return AskInt("Grrreat! And how much do you want to walk away with? ", playerPot+1);
        }
 
        private static int AskInt(String prompt, int minimum)
        {
            int result;

            Console.Write(prompt);
            do
            {
                String userInput = Console.ReadLine();
                if (!int.TryParse(userInput, out result) | result < minimum)
                {
                    Console.Write($"Please enter a NUMBER equal to or greater than {minimum}!\nTry again: ");
                }
            } while (result < minimum);

            return result;
        }
   }
}

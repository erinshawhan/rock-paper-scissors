using System;
using System.Collections.Generic;

namespace FinalProject
{
    public static class GamePlay
    {
        public static void round(Player player, List<Player> playerList)
        {
            while(true){
                int round = player.calculateTotal() + 1;
                Console.WriteLine($"\nRound {round}\n\n\t1. Rock\n\t2. Paper\n\t3. Scissors\n\nWhat will it be?");
                string playerChoice = Console.ReadLine();
                if (playerChoice != "1" && playerChoice != "2" && playerChoice != "3"){
                    Console.WriteLine("\nInvalid input. Please enter 1, 2, or 3.");
                    continue;
                }

                Dictionary<string, string> dict = new Dictionary<string, string>(){
                    {"1", "Rock"},
                    {"2", "Paper"},
                    {"3", "Scissors"}
                };
                
                Random rnd = new Random();
                string computerChoice = (rnd.Next(1, 4)).ToString();

                if (playerChoice.Equals(computerChoice)){
                    Console.WriteLine($"\nYou chose {dict[playerChoice]}. The computer chose {dict[computerChoice]}. You tie!");
                    player.playerTies();
                }else if ((playerChoice == "1" && computerChoice == "3") || (playerChoice == "2" && computerChoice == "1") || (playerChoice == "3" && computerChoice == "2")){
                    Console.WriteLine($"\nYou chose {dict[playerChoice]}. The computer chose {dict[computerChoice]}. You win!");
                    player.playerWins();
                }else{
                    Console.WriteLine($"\nYou chose {dict[playerChoice]}. The computer chose {dict[computerChoice]}. You lose!");
                    player.playerLoses();
                }

                Menus.secondMenu(player, playerList);
            }
        }
    }
}
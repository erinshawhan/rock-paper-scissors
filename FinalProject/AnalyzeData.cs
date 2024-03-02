using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject
{
    public static class AnaylzeData
    {
        public static void GeneratePlayerStats(Player player, List<Player> playerlist){
            Console.WriteLine($"\n{player.Name}, here are your game play statistics...");
            Console.WriteLine($"Wins: {player.Wins}\nLosses: {player.Losses}\nTies: {player.Ties}\n\nWin/Loss Ratio: {player.winLossRatio():N2}");
            Menus.secondMenu(player, playerlist);
        }
        public static void GenerateLeaderboard(Player p, List<Player> playerList){
            string leaderboard = "";

            if(playerList.Count() < 1){
                leaderboard += "No data available. \n";
                Console.WriteLine(leaderboard);
            }

            leaderboard += "\nGlobal Game Statistics\n----------------------";

            //top 10 winning players
            var alphabeticalPlayers = from player in playerList orderby player.Name ascending select player;
            var top10Winners = from player in alphabeticalPlayers orderby player.Wins descending select player;
            leaderboard += "\n----------------------\nTop 10 Winning Players\n----------------------\n";
            int count = 0;
            foreach(var winner in top10Winners){
                count ++;
                leaderboard += $"{winner.Name}: {winner.Wins} wins\n";
                if (count == 10){
                    break;
                }
            }

            //most games played
            var mostGamesPlayed = from player in alphabeticalPlayers orderby player.calculateTotal() descending select player;
            leaderboard += "\n----------------------\nMost Games Played\n----------------------\n";
            count = 0;
            foreach(var player in mostGamesPlayed){
                count ++;
                leaderboard += $"{player.Name}: {player.calculateTotal()} games played\n";
                if (count == 5){
                    break;
                }
            }

            //overall win/loss ratio
            var overallWinLossRatio = Convert.ToSingle((from player in playerList select player.Wins).Sum()) / Convert.ToSingle((from player in playerList select player.Losses).Sum());
            leaderboard += $"\n----------------------\nWin/Loss Ratio: {overallWinLossRatio:N2}\n----------------------\n";

            //total games played
            var totalGamesPlayed = (from player in playerList select player.calculateTotal()).Sum();
            leaderboard += $"\n----------------------\nTotal Games Played: {totalGamesPlayed}\n----------------------";

            Console.WriteLine(leaderboard);

            Menus.secondMenu(p, playerList);
        }
    }
}
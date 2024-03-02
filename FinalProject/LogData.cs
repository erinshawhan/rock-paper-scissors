using System;
using System.IO;
using System.Collections.Generic;

namespace FinalProject
{
    public static class LogData
    {
        public static void Log(Player player, List<Player> playerList, string playerType)
        {
            try{
                using(var writer = new StreamWriter("player_log.csv")){
                    foreach(var p in playerList){
                        writer.Write($"{p.Name},{p.Wins},{p.Losses},{p.Ties}\n");
                    }
                    if (playerType == "newPlayer"){
                        writer.Write($"{player.Name},{player.Wins},{player.Losses},{player.Ties}");
                    }
                }
            }catch(Exception err){
                Console.WriteLine($"There was an error writing to the player log: {err.Message}");
            }
        }
    }
}
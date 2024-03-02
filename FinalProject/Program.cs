using System;
using System.Collections.Generic;

namespace FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rock, Paper, Scissors!");
            
            List<Player> playerList = null;
            try{
                playerList = PlayerLoader.loadPlayers("player_log.csv");
            }catch(Exception err){
                Console.WriteLine(err.Message);
                Environment.Exit(1);
            }

            Menus.mainMenu(playerList);
        }
    }
}

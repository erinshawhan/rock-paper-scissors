using System;
using System.Collections.Generic;

namespace FinalProject
{
    public static class Menus
    {
        public static void mainMenu(List<Player> playerList)
        {
            while (true){
                Console.WriteLine("\n\t1. Start New Game\n\t2. Load Game\n\t3. Quit");
                Console.WriteLine("\nEnter choice:");
                string choice = Console.ReadLine();
                if (choice == "1"){
                    startNewGame(playerList);
                }else if (choice == "2"){
                    loadGame(playerList);
                }else if (choice == "3"){
                    Console.WriteLine("Goodbye!");
                    break;
                }else{
                    Console.WriteLine("\nInvalid input. You must enter 1, 2, or 3.");
                    continue;
                }
            }
        }
        static void startNewGame(List<Player> playerList)
        {
            while (true){
                Console.WriteLine("\nWhat is your name?");
                string name = Console.ReadLine();
                Player foundPlayer = null;
                foreach(var p in playerList){
                    if (p.Name == name){
                        foundPlayer = p;
                        Console.WriteLine("\nThere is already a game saved under that name. Please enter another name.");
                        continue;
                    }else{
                        continue;
                    }
                }
                if (foundPlayer == null){
                    Player player = new Player(name, 0, 0, 0);
                    LogData.Log(player, playerList, "newPlayer");
                    Console.WriteLine($"\nHello {name}. Let's play!");
                    GamePlay.round(player, playerList);
                }
            }
        }
        static void loadGame(List<Player> playerList)
        {
            while (true){
                Console.WriteLine("\nWhat is your name?");
                string name = Console.ReadLine();
                Player foundPlayer = null;
                foreach(var player in playerList){
                    if(player.Name == name){
                        foundPlayer = player;
                        Console.WriteLine($"\nWelcome back {name}. Let's play!");
                        GamePlay.round(foundPlayer, playerList);
                    }else{
                        continue;
                    }
                }
                if (foundPlayer == null){
                    Console.WriteLine($"\n{name}, your game could not be found.\n");
                    mainMenu(playerList);
                }
            }
        }
        public static void secondMenu(Player player, List<Player> playerList){
            while(true){
                Console.WriteLine("\nWhat would you like to do?\n");
                Console.WriteLine("\n\t1. Play Again\n\t2. View Player Statistics\n\t3. View Leaderboard\n\t4. Quit");
                string choice = Console.ReadLine();
                if (choice == "1"){
                    GamePlay.round(player, playerList);
                }else if (choice == "2"){
                    AnaylzeData.GeneratePlayerStats(player, playerList);
                }else if (choice == "3"){
                    AnaylzeData.GenerateLeaderboard(player, playerList);
                }else if (choice == "4"){
                    try{
                        Player foundPlayer = null;
                        foreach(var p in playerList){
                            if(p.Name == player.Name){
                                foundPlayer = player;
                                LogData.Log(foundPlayer, playerList, "returningPlayer");
                            }else{
                                continue;
                            }
                        }
                        if (foundPlayer == null){
                            LogData.Log(player, playerList, "newPlayer");
                        }
                        Console.WriteLine($"\n{player.Name}, your game has been saved.");
                    }catch (Exception err){
                        Console.WriteLine($"\nSorry {player.Name}, the game could not be saved.\n{err.Message}");
                    }finally{
                        Environment.Exit(1);
                    }
                }else{
                    Console.WriteLine("\nInvalid input. Please enter 1, 2, 3, or 4.");
                    continue;
                }
            }
        }
    }
}
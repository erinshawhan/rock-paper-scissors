using System;
using System.Collections.Generic;
using System.IO;

namespace FinalProject
{
    public class PlayerLoader
    {
        public static List<Player> loadPlayers(string filePath){
            List<Player> playerList = new List<Player>();

            try{
                using(var playerReader = new StreamReader(filePath)){
                    int lineNumber = 0;
                    int piecesOfData = 4;

                    while(!playerReader.EndOfStream){
                        var line = playerReader.ReadLine();
                        lineNumber ++;
                        var values = line.Split(",");

                        if(values.Length != piecesOfData){
                            throw new Exception($"Row {lineNumber} contains {values.Length} values. It should contain {piecesOfData}.");
                        }

                        try{
                            string name = values[0];
                            int wins = Int32.Parse(values[1]);
                            int losses = Int32.Parse(values[2]);
                            int ties = Int32.Parse(values[3]);
                            Player player = new Player(name, wins, losses, ties);
                            playerList.Add(player);
                        }catch(FormatException err){
                            throw new Exception($"Row {lineNumber} contains invalid data. ({err.Message})");
                        }
                    }
                }
            }catch(Exception err){
                throw new Exception($"Unable to load data from {filePath}. ({err.Message})");
            }
            return playerList;
        }
    }
}
using System;

namespace FinalProject
{
    public class Player
    {
        //attributes
        public string Name {get;}
        public int Wins {get; set;}
        public int Losses {get; set;}
        public int Ties {get; set;}
        
        //constructor
        public Player(string name, int wins, int losses, int ties){
            Name = name;
            Wins = wins;
            Losses = losses;
            Ties = ties;
        }
        public void playerWins(){
            Wins ++;
        }
        public void playerLoses(){
            Losses ++;
        }
        public void playerTies(){
            Ties ++;
        }
        public int calculateTotal(){
            int total = Wins + Losses + Ties;
            return total;
        }

        public float winLossRatio(){
            float ratio = Convert.ToSingle(Wins)/Convert.ToSingle(Losses);
            return ratio;
        }
    }
}
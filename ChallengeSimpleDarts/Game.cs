using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Darts;

namespace ChallengeSimpleDarts
{
    public class Game
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public string Winner { get; set; }
        public Random Random = new Random();

        public Game(string player1Name, string player2Name)
        {
            Player1 = new Player();
            Player1.Name = player1Name;
            Player2 = new Player();
            Player2.Name = player2Name;


        }

        public void GameStart()
        {
            while(Player1.Score < 300 && Player2.Score < 300)
            {
                PlayRound(Player1);
                PlayRound(Player2);
            }

            DetermineWinner();
        }

        private void PlayRound(Player player)
        {
            for(int i = 0; i < 3; i++)
            {
                Dart dart = new Dart(Random);
                dart.Throw();
                player.Score += dart.Score;
            }
            
        }

        private void DetermineWinner()
        {
            if (Player1.Score > Player2.Score)
                Winner = Player1.Name;
            else
                Winner = Player2.Name;
        }
    }
}
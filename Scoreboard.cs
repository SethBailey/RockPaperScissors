using System;

namespace TextGame
{
    class Scoreboard
    {
        static int player1Score = 0;
        static int player2Score = 0;

        public void Displayscorecard( string player1Name, string player2Name )
        {
            Console.WriteLine(player1Name + "score: " + player1Score);
            Console.WriteLine(player2Name + "score: " + player2Score);
        }

        internal void UpdateResult(Result result)
        {
            switch(result)
            {
                case Result.Win : player1Score++; break;
                case Result.Lose : player2Score++; break;
                case Result.Draw : break;
            }
        }
    };

}

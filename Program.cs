using System;

namespace TextGame
{
    class Start
    {
        
        const int Rock = 1;
        const int Paper =2;
        const int Scissors = 3;
        static int player1Score = 0;
        static int player2Score = 0;


        //This is where your program starts
        static void Main(string[] args)
        {
            isSoloGame = IsSoloPlayer();
            GetPlayerNames();
            PlayRockPaperScissors();
        }

        private static void GetPlayerNames()
        {
            Player1 = GetPlayerName();
            if (!isSoloGame)
            {
                Player2 = GetPlayerName();
            }
        }

        private static string GetPlayerName()
        {
            Console.Write("What is your name? : ");
            return Console.ReadLine();
        }

        static bool isSoloGame = true;
        static string Player1 = "Player1";
        static string Player2 = "Computer";

        private static void PlayRockPaperScissors()
        {
            int player2Pick = 0;
            int player1Pick = 0;
            
            if ( isSoloGame )
            {
                player1Pick = PlayerPickAWeapon(Player1);
                player2Pick = ComputerPickAWeapon();
            }
            else
            {
                player1Pick = PlayerPickAWeapon(Player1);
                player2Pick = PlayerPickAWeapon(Player2); 
            }
            
            DisplayPick(Player1, player1Pick);
            DisplayPick(Player2, player2Pick);
            
            DisplayWinner(player1Pick, player2Pick);
            Displayscorecard();
            PlayAgain();
        }

        private static bool IsSoloPlayer()
        {
            Console.Write("Do you want to play solo? (y/n) :");
            var choice = Console.ReadLine();
            if (choice == "y")
            {
                return true;
            }
            return false;
        }

        private static void Displayscorecard()
        {
            Console.WriteLine(Player1 + "score: " + player1Score);
            Console.WriteLine(Player2 + "score: " + player2Score);
        }

        private static void PlayAgain()
        {
            Console.Write("Continue? (y,n) ");
            var playAgain = Console.ReadLine();
            if (playAgain == "y")
            {
                Console.Clear();
                PlayRockPaperScissors();
            }
            else if (playAgain == "n")
            {
                Console.WriteLine("Bye bye");
            }
            else 
            {
               Console.WriteLine("I don't get it try again: "); 
               PlayAgain();
            }
        }




        private static void DisplayWinner(int player1Pick, int player2Pick)
        {
            ShowResult(player1Pick, player2Pick);
        }

        const int Draw = 1;
        const int Win = 2;
        const int Lose = 3;
        private static void ShowResult(int player1, int player2)
        {
            var result = GetGameResult(player1, player2);
            DrawResultToScreen(result);
        }

        private static void DrawResultToScreen(int result)
        {
            if (result == Draw)
            {
                Console.WriteLine("Draw ");
                return;
            }

            if (result == Win)
            {
                player1Score++;
                Console.WriteLine(Player1 + " Win! ");
                return;
            }

            player2Score++;
            Console.WriteLine(Player2 + " Win! ");
        }

        //This tells us the result from player1's perspective
        private static int GetGameResult(int player1, int player2)
        {   
            //Draw
            if (player2 == player1)
            {
                return Draw;
            }

            //Player Win
            if ( (player1 == Paper    && player2 == Rock)  ||
                 (player1 == Scissors && player2 == Paper) ||
                 (player1 == Rock     && player2 == Scissors))
            { 
                return Win;
            }

            //Player Lose
            return Lose;
        }

        private static void DisplayPick(string player, int pick)
        {
            Console.Write(player + " chose : ");
            if (pick == Rock)
            {
                Console.WriteLine("rock");
            }
            else if (pick == Paper)
            {
                Console.WriteLine("paper");
            }
            else if (pick == Scissors)
            {
                Console.WriteLine("scissors");
            }
        }

        private static int PlayerPickAWeapon(string playerName)
        {
            Console.Write( playerName + " Pick a weapon (r,p,s) : ");
            var input = Console.ReadKey(true);
            Console.WriteLine();
            if (input.Key == ConsoleKey.R)
            {
                return Rock;
            }
            if (input.Key == ConsoleKey.P)
            {
                return Paper;
            }
            if (input.Key == ConsoleKey.S)
            {
               return Scissors; 
            }

            Console.WriteLine(playerName + " picked the wrong letter...try again");
            return PlayerPickAWeapon(playerName);
        }
          
       
        private static int ComputerPickAWeapon()
        {
            var x = new Random();
            return x.Next(1,3);
        }


    }

}

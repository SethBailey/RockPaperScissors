using System;

namespace TextGame
{
    class Start
    {
        
        const int Rock = 1;
        const int Paper =2;
        const int Scissors = 3;
        static int player1 = 0;
        static int player2 = 0;


        //This is where your program starts
        static void Main(string[] args)
        {
            PlayRockPaperScissors();
        }

        private static void PlayRockPaperScissors()
        {
            int player2Pick = 0;
            int player1Pick = 0;

            if ( IsSoloPlayer() )
            {
                player1Pick = PlayerPickAWeapon("Player1");
                player2Pick = ComputerPickAWeapon();
                DisplaysComputerPick(player2Pick);
            }
            else
            {
                player1Pick = PlayerPickAWeapon("Player1");
                player2Pick = PlayerPickAWeapon("Player2"); 
            }
            
            
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
            Console.WriteLine("player1 score: " + player1);
            Console.WriteLine("player2 score: " + player2);
        }

        private static void PlayAgain()
        {
            Console.Write("Continue? (y,n) ");
            var playAgain = Console.ReadLine();
            if (playAgain == "y")
            {
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
        private static void ShowResult(int computerPick, int playerPick)
        {
            var result = GetGameResult(playerPick, computerPick);
            DrawResultToScreen(result);
        }

        private static void DrawResultToScreen(int result)
        {
            if (result == Draw)
            {
                Console.WriteLine(" draw ");
                return;
            }

            //Player Win
            if (result == Win)
            {
                player1++;
                Console.WriteLine(" Win! ");
                return;
            }

            //Player Lose
            player2++;
            Console.WriteLine(" Lose ");
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
            if ((player1 == Paper && player2 == Rock) ||
                 (player1 == Scissors && player2 == Paper) ||
                 (player1 == Paper && player2 == Scissors))
            { 
                return Win;
            }

            //Player Lose
            return Lose;
        }

        private static void DisplaysComputerPick(int computerPick)
        {
            Console.Write("Player2 chose : ");
            if (computerPick == Rock)
            {
                Console.WriteLine("rock");
            }
            else if (computerPick == Paper)
            {
                Console.WriteLine("paper");
            }
            else if (computerPick == Scissors)
            {
                Console.WriteLine("scissors");
            }
        }

        private static int PlayerPickAWeapon(string playerName)
        {
            Console.Write( playerName + " Pick a weapon (r,p,s) : ");
            var input = Console.ReadLine();
            if (input == "r")
            {
                return Rock;
            }
            if (input == "p")
            {
                return Paper;
            }
            if (input == "s")
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

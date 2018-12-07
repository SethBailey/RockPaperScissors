using System;

namespace TextGame
{
    class Start
    {
        
        const int Rock = 1;
        const int Paper =2;
        const int Scissors = 3;
        static int playerscore = 0;
        static int computerscore = 0;


        //This is where your program starts
        static void Main(string[] args)
        {
            PlayRockPaperScissors();
        }

        private static void PlayRockPaperScissors()
        {
            int computerPick = ComputerPickAWeapon();
            int playerPick = PlayerPickAWeapon();
            DisplayWinner(computerPick, playerPick);
            Displayscorecard();
            PlayAgain();
        }

        private static void Displayscorecard()
        {
            Console.WriteLine("player score: " + playerscore);
            Console.WriteLine("computer score: " + computerscore);
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




        private static void DisplayWinner(int computerPick, int playerPick)
        {
            DisplaysComputerPick(computerPick);
            ShowResult(computerPick, playerPick);
        }

        private static void ShowResult(int computerPick, int playerPick)
        {
            //Draw
            if (computerPick == playerPick)
            {
                Console.WriteLine(" draw ");
                return;
            }

            //Player Win
            if ( (playerPick == Paper && computerPick == Rock  ) ||
                 (playerPick == Scissors  && computerPick == Paper ) ||
                 (playerPick == Paper && computerPick == Scissors ) )
            {
                playerscore++;
                Console.WriteLine(" Win! ");
                return;
            }
            
            //Player Lose
            computerscore++;
            Console.WriteLine(" Lose ");          
        }

        private static void DisplaysComputerPick(int computerPick)
        {
            Console.Write("Computer chose : ");
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

        private static int PlayerPickAWeapon()
        {
            Console.Write("Pick a weapon (r,p,s) : ");
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

            Console.WriteLine("You picked the wrong letter...try again");
            return PlayerPickAWeapon();
        }
          
       
        private static int ComputerPickAWeapon()
        {
            var x = new Random();
            return x.Next(1,3);
        }


    }

}

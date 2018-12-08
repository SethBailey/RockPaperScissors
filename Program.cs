using System;

namespace TextGame
{
    class Start
    {
        
        enum Weapon {
            Rock,
            Paper,
            Scissors
        };

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
            Player1Name = GetPlayerName();
            if (!isSoloGame)
            {
                Player2Name = GetPlayerName();
            }
        }

        private static string GetPlayerName()
        {
            Console.Write("What is your name? : ");
            return Console.ReadLine();
        }

        static bool isSoloGame = true;
        static string Player1Name = "Player1";
        static string Player2Name = "Computer";

        private static void PlayRockPaperScissors()
        {
            Weapon player2Pick;
            Weapon player1Pick;
            
            if ( isSoloGame )
            {
                player1Pick = PlayerPickAWeapon(Player1Name);
                player2Pick = ComputerPickAWeapon();
            }
            else
            {
                player1Pick = PlayerPickAWeapon(Player1Name);
                player2Pick = PlayerPickAWeapon(Player2Name); 
            }
            
            DisplayPick(Player1Name, player1Pick);
            DisplayPick(Player2Name, player2Pick);
            
            ShowResult(player1Pick, player2Pick);
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
            Console.WriteLine(Player1Name + "score: " + player1Score);
            Console.WriteLine(Player2Name + "score: " + player2Score);
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

        enum Result{

         Draw,
         Win,
         Lose 

        }
        private static void ShowResult(Weapon player1, Weapon player2)
        {
            var result = GetGameResult(player1, player2);
            DrawResultToScreen(result);
        }

        private static void DrawResultToScreen(Result result)
        {
            if (result == Result.Draw)
            {
                Console.WriteLine("Draw ");
                return;
            }

            if (result == Result.Win)
            {
                player1Score++;
                Console.WriteLine(Player1Name + " Win! ");
                return;
            }

            player2Score++;
            Console.WriteLine(Player2Name + " Win! ");
        }

        //This tells us the result from player1's perspective
        private static Result GetGameResult(Weapon player1, Weapon player2)
        {   
            //Draw
            if (player2 == player1)
            {
                return Result.Draw;
            }

            //Player Win
            if ( (player1 == Weapon.Paper    && player2 == Weapon.Rock)  ||
                 (player1 == Weapon.Scissors && player2 == Weapon.Paper) ||
                 (player1 == Weapon.Rock     && player2 == Weapon.Scissors))
            { 
                return Result.Win;
            }

            //Player Lose
            return Result.Lose;
        }

        private static void DisplayPick(string player, Weapon pick)
        {
            Console.Write(player + " chose : ");
            switch (pick)
            {
                case Weapon.Rock: Console.WriteLine("rock"); break;
                case Weapon.Paper: Console.WriteLine("paper"); break; 
                case Weapon.Scissors: Console.WriteLine("scissors"); break;
            }
        }

        private static Weapon PlayerPickAWeapon(string playerName)
        {
            Console.Write( playerName + " Pick a weapon (r,p,s) : ");
            var input = Console.ReadKey(true);
            Console.WriteLine();
            switch ( input.Key )
            {
                case ConsoleKey.R : return Weapon.Rock;
                case ConsoleKey.P : return Weapon.Paper;
                case ConsoleKey.S : return Weapon.Scissors;
                default:           
                    Console.WriteLine(playerName + " picked the wrong letter...try again");
                    return PlayerPickAWeapon(playerName);
            }
        }
          
       
        private static Weapon ComputerPickAWeapon()
        {
            var x = new Random();
            var randomNumber =  x.Next(1,3);
            switch(randomNumber)
            {
                case 1 : return Weapon.Rock;
                case 2 : return Weapon.Paper;
                case 3 : return Weapon.Scissors;

                //have to return something to make the compiler happy
                //this code will NEVER execute!
                default : return Weapon.Scissors;
            }
        }


    }

}

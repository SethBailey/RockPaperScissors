using System;

namespace TextGame
{
    enum Result{

         Draw,
         Win,
         Lose 
    };

    public enum Weapon {
            Rock,
            Paper,
            Scissors
    };

    class Start
    {        
        static Scoreboard scoreboard = new Scoreboard();
        static RockPaperScissorsLogic logic = new RockPaperScissorsLogic();

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
            scoreboard.Displayscorecard(Player1Name, Player2Name);
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

        private static void ShowResult(Weapon player1, Weapon player2)
        {
            var result = logic.GetGameResult(player1, player2);
            scoreboard.UpdateResult(result);
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
                Console.WriteLine(Player1Name + " Win! ");
                return;
            }
            Console.WriteLine(Player2Name + " Win! ");
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
           return logic.RandomlyPickAWeapon();
        }


    }

}

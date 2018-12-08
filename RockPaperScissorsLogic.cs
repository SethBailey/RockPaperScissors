using System;

namespace TextGame
{
    class RockPaperScissorsLogic
    {
        //This tells us the result from player1's perspective
        public Result GetGameResult(Weapon player1, Weapon player2)
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

         public Weapon RandomlyPickAWeapon()
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
    };

}

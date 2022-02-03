using System;

namespace Tamagochi
{
    public class Player
    {
        private int money = 0;

        private Random generator = new Random();


//
        public void Money()
        {
            int m = generator.Next(1, 5);


            money += m;

        }
    }
}
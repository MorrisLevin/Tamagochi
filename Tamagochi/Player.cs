using System;

namespace Tamagochi
{
    public class Player
    {
        private int money = 0;

        private Random generator = new Random();




        //Mängd pengar som spelare får. Om spelaren arbterar så tjänar dem mellan 1-5 kr.
        public void Money()
        {
            int m = generator.Next(1, 5);


            money += m;

        }

        //Här kollan spelaren deras mängd pengar.
        public void CheckMoney()
        {
            Console.WriteLine($"Money: {money}");
        }
        //Spelaren betalar pengar när PayMoney används.
        public void PayMoney()
        {
            money -= 1;

        }
        //Avgör om spelaren har kvar pengar.
        public bool HasMoneyLeft()
        {
            if (money > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
using System;

namespace Tamagochi
{
    public class PersonalGucci : Tamagucci
    {

        private Random generator = new Random();

        int xp = 0;
        int level = 1;

        public void LevelUp()
        {
            int x = generator.Next(1, 3);


            xp += x;

            level = 1 + xp / 10;
        }

        public void PrintLevel()
        {


            int l = level;



            Console.WriteLine($"Level: {level}");

        }


    }
}
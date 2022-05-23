using System;

namespace Tamagochi
{
    public class Dummy
    {
        int hp = 100000;


        public void TakeDamage(int amount)
        {

            hp -= amount;


            Console.WriteLine($" Dummy hp: {hp}");

        }

    }
}
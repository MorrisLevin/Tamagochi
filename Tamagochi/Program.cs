using System;

namespace Tamagochi
{
    class Program
    {
        static void Main(string[] args)
        {
            Tamagucci tama = new Tamagucci();

            string answer = "";

            Console.WriteLine("Name your Tamagochi: ");

            tama.name = Console.ReadLine();

            while (tama.GetAlive() == true)
            {


                Console.WriteLine("Do you want to 1. Teach your Tamagochi a new word? 2. Say hi to your Tomochi? 3. Feed your Tamagochi? 4. Do nothing?  ");

                answer = Console.ReadLine();

                if (answer == "1")
                {

                    Console.WriteLine("What new word would you like to teach your Tamagochi?");

                    string w = Console.ReadLine();

                    tama.Teach(w);

                }
                else if (answer == "2")
                {

                    Console.WriteLine("You said hi to your Tamagochi. Tamagochi says: ");

                    tama.Hi();

                }
                else if (answer == "3")
                {

                    tama.Feed();

                    Console.WriteLine("You fed your tamagochi. ");

                }
                else if (answer == "4")
                {

                    tama.Tick();

                    Console.WriteLine("You did...nothing");

                }

                Console.WriteLine("Press Enter to continue");

                Console.ReadLine();

                Console.Clear();



            }

            Console.WriteLine("Your Tamagochi has unfortunetly died. Better luck next time.");

        }
    }
}

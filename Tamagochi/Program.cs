using System.Collections.Generic;
using System.Linq;
using System;

namespace Tamagochi
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tamagucci> tamaguccis = new List<Tamagucci>();

            tamaguccis.Add(new Tamagucci());

            string answer = "";




            int i = 0;



            while (tamaguccis[i].GetAlive() == true)
            {

                DateTime start = DateTime.Now;

                Console.WriteLine($"Do you want to 1. Teach {tamaguccis[i].name} a new word? 2. Say hi to {tamaguccis[i].name}? 3. Feed {tamaguccis[i].name}? 4. Do nothing?  5. Make a new tomagotchi? 6. Switch your tamagotchi?");

                answer = Console.ReadLine();

                if (answer == "1")
                {

                    Console.WriteLine($"What new word would you like to teach {tamaguccis[i].name}?");

                    string w = Console.ReadLine();

                    tamaguccis[i].Teach(w);

                }
                else if (answer == "2")
                {

                    Console.WriteLine($"You said hi to {tamaguccis[i].name}. {tamaguccis[i].name} says: ");

                    tamaguccis[i].Hi();

                }
                else if (answer == "3")
                {

                    tamaguccis[i].Feed();

                    Console.WriteLine($"You fed {tamaguccis[i].name}. ");

                }
                else if (answer == "4")
                {

                    tamaguccis[i].Tick();

                    Console.WriteLine("You did...nothing");

                }
                else if (answer == "5")
                {
                    tamaguccis.Add(new Tamagucci());
                }
                else if (answer == "6")
                {
                    Console.WriteLine("Write down the name of the tamagothi you want to choose.");
                    string choice = Console.ReadLine();
                    bool validAnswer = tamaguccis.Any(t => t.name == choice);

                    i = tamaguccis.FindIndex(0, t => t.name == choice);
                    if (validAnswer == false)
                    {
                        Console.WriteLine("That is not a Tamagothi.");

                    }
                }

                DateTime end = DateTime.Now;

                TimeSpan span = end - start;


                for (int h = 0; h < span.Seconds / 10; h++)
                {
                    tamaguccis[h].Tick();

                }




                Console.WriteLine("Press Enter to continue");

                Console.ReadLine();

                Console.Clear();




            }

            Console.WriteLine($"{tamaguccis[i].name} has unfortunetly died. Better luck next time.");
            Console.WriteLine("Press Enter to quit");
            Console.ReadLine();

        }
    }
}

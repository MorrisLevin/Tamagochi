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
            Player player = new Player();
            Tamagucci pgucci = tamaguccis[0];

            string answer = "";

            Dummy dumdum = new Dummy();


            int i = 0;




            //Menas isAlive är sant så spelas loopen om och om igen.
            //Hela denna klassmetod gör allting i mitt spel, mer eller mindre. Detta är ett stort problem, eftersom det är mer effektivt och stabilt om klassmetoder gör endast en enstaka uppgift. Programmet skulle kunna förbättras genom att skriva om koden i Program.cs, och skapa flera olika klassmetoder som gör samma jobb som hela klassmetoder under
            while (pgucci.GetAlive() == true)
            {
                //Mäter tiden från när loopen börjar/börjar om igen. Implimenterar tid som en faktor i detta spel.
                DateTime start = DateTime.Now;
                //Hela denna klassmetod baseras på dessa val, då spelares kan bestämma vad deras Tamagutchi gör.
                Console.WriteLine($"Do you want to 1. Teach {pgucci.name} a new word? 2. Say hi to {pgucci.name}? 3. Feed {pgucci.name}? 4. Do nothing?  5. Make a new tomagotchi? 6. Switch your tamagotchi? 7. Work and earn money? 8. Check {pgucci.name}'s level? 9. Attack the dummy? 10. Try digging for treasure?");

                answer = Console.ReadLine();

                if (answer == "1")
                {

                    //Om spelaren har mindre money än 1, så kan man inte avsluta den action som man vill.
                    if (player.HasMoneyLeft() == true)
                    {




                        //Lär ut en tamagochi en string som läggs in i en list.
                        Console.WriteLine($"What new word would you like to teach {pgucci.name}?");

                        string w = Console.ReadLine();

                        pgucci.Teach(w);

                        player.PayMoney();
                    }
                    else
                    {
                        Console.WriteLine("You have no money to do that task. You need to work to get money");
                    }

                }
                else if (answer == "2")
                {

                    if (player.HasMoneyLeft() == true)
                    {
                        //Säger hej till tamagochin, och tamagochin tar ut en string från listan och svarar med det ordet. Om den inte lärt sig ett ord, så blir det "Hello".
                        Console.WriteLine($"You said hi to {pgucci.name}. {pgucci.name} says: ");

                        pgucci.Hi();

                        player.PayMoney();

                    }
                    else
                    {
                        Console.WriteLine("You have no money to do that task. You need to work to get money");
                    }

                }
                else if (answer == "3")
                {
                    if (player.HasMoneyLeft() == true)
                    {
                        //Höher tamagochin's feed-meter.
                        pgucci.Feed();

                        Console.WriteLine($"You fed {pgucci.name}. ");
                        player.PayMoney();
                    }
                    else
                    {
                        Console.WriteLine("You have no money to do that task. You need to work to get money");
                    }

                }
                else if (answer == "4")
                {
                    //Inget händer. 
                    pgucci.Tick();

                    Console.WriteLine("You did...nothing");
                    //Gör så att spelaren kan skapa en ny tamagochi, och lägger den i en list.
                }
                else if (answer == "5")
                {
                    if (player.HasMoneyLeft() == true)
                    {
                        tamaguccis.Add(new Tamagucci());
                        player.PayMoney();
                    }
                    else
                    {
                        Console.WriteLine("You have no money to do that task. You need to work to get money");
                    }
                }

                else if (answer == "6")
                {
                    Console.WriteLine("Write down the name of the tamagothi you want to choose.");



                    //Spelaren skriver ner namnet på Tamagochin som dem vill spela med. Om svaret är validAnswer, alltså namnet dem skriver passar med en av tamagotchin i listan, så byts tamagotchin ut.
                    string choice = Console.ReadLine();

                    i = tamaguccis.FindIndex(0, t => t.name == choice);

                    try
                    {
                        pgucci = tamaguccis[i];
                    }
                    catch
                    {
                        Console.WriteLine("That is not a tamagotchi");
                    }





                }
                else if (answer == "7")
                {
                    //Kollar spelarens pengar.
                    player.Money();
                    player.CheckMoney();
                }
                else if (answer == "8")
                {
                    if (player.HasMoneyLeft() == true)
                    {
                        //Kollar ens tamagochis level.
                        pgucci.PrintLevel();
                        player.PayMoney();
                    }
                    else
                    {
                        Console.WriteLine("You have no money to do that task. You need to work to get money");
                    }
                }


                else if (answer == "9")
                {
                    if (player.HasMoneyLeft() == true && pgucci.w != null)
                    {
                        dumdum.TakeDamage(pgucci.w.damage);
                        player.PayMoney();
                    }
                    else
                    {
                        Console.WriteLine($"You either don't have money, or {pgucci.name} does not have a weapon yet. Earn money, or level up {pgucci.name}. ");
                    }
                }
                else if (answer == "10")
                {
                    if (player.HasMoneyLeft() == true && pgucci.s != null)
                    {
                        pgucci.Dig();
                        player.PayMoney();
                    }
                    else
                    {
                        Console.WriteLine($"You either don't have money, or {pgucci.name} does not have a  yet. Earn money, or level up {pgucci.name}. ");
                    }
                }


                else
                {
                    Console.WriteLine("That is not a valid answer. Please press one of the required numbers.");
                }




                //Byter den nuvarande tiden till tiden då man har avslutat en action. Använder funktionen datetime.
                DateTime end = DateTime.Now;
                //Mäter tiden mellan när man avslutat sin senaste action med en ny action.
                TimeSpan span = end - start;

                //Mäter timespan seconds. Om det är delbart med 10, så läggs en extra tick till. Om det är mellan 10-19, så blir det en extra tick, och mellan 20-29 så blir det 2 extra ticks, osv. Detta är pga att det är en int.
                for (int h = 0; h < span.Seconds / 10; h++)
                {
                    pgucci.Tick();

                }

                pgucci.LevelUp();



                //Startar om loopen och clearar all text.
                Console.WriteLine("Press Enter to continue");

                Console.ReadLine();

                Console.Clear();




            }
            //Om isAlive är false så avslutas loopen och samtidigt programmet.
            Console.WriteLine($"{pgucci.name} has unfortunetly died. Better luck next time.");
            Console.WriteLine("Press Enter to quit");
            Console.ReadLine();

        }
    }
}


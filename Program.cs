using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace Vårat_spel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool PlayAgain = true;

            while (PlayAgain)
            {
                int level1 = Level1();
                int level2 = Level2(level1);
                int level3 = Level3(level2);

                Console.WriteLine("Vill du spela igen? Ja/Nej");
                string inmatning = Console.ReadLine();
            
                if (inmatning == "Ja" || inmatning == "ja")
                {
                    Console.Clear();
                   PlayAgain = true;
                    
                }
                else if (inmatning == "Nej" || inmatning == "nej")
                {
                    Console.Clear();
                    Console.WriteLine("Tack för att du spelade!");
                    break;
                    Environment.Exit(0); // Stänger av programmet om användaren väljer "nej"
                }
                else continue; // Om användaren ger en felaktig inmatning, fortsätt att fråga tills en giltig inmatning ges
            }

        }
        static int Level1()
        {
            Console.WriteLine("Välkommen till Labyrinten! Du måste ta dig ut genom att välja rätt väg. ");
            Console.WriteLine("Du måste nu välja om du vill gå höger eller vänster.");
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("Välj [1] för att gå höger\nVälj [2] för att gå vänster.");
            
            int userChoice = int.Parse(Console.ReadLine());
            if(userChoice == 1)
            {
                Console.Clear();
                Console.WriteLine("Du stöter på en stor farlig anaconda, spring tillbaka så fort du kan!");

                return Level1();
            }
            else if(userChoice == 2)
            {
                Console.Clear();
                Console.WriteLine("Titta! Du hittar en liten korg med mat så att du orkar fortsätta hela vägen.\nDu kan nu fortsätta vidare.");

                return 2;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Du måste ange [1] eller [2]");

                return Level1();
                
            }
        }

        static int Level2(int latestChoice)
        {
            Console.WriteLine("Till vänster om dig så hör du en dam som ropar, rakt fram ser du en stege\n" +
                "och till höger om dig ser du ett ljus.");
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("Vilken väg vill du ta?");

            Console.WriteLine("Välj [1] för att gå vänster");
            Console.WriteLine("Välj [2] för att gå rakt fram");
            Console.WriteLine("Välj [3] för att gå höger");
            int way = int.Parse(Console.ReadLine());


            switch (way)
            {

                case 1:

                    Console.WriteLine("Du valde att gå till vänster. Här sitter Hilma som säger sig vara en spådam\n" +
                        "och säger att hon kan trolla dig ut ur labyrinten. Vill du att hon ska göra det? Ja/Nej");
                    string myAnswer = Console.ReadLine();
                    if (myAnswer == "ja" || myAnswer == "Ja")
                    {
                        Console.Clear();
                        Console.WriteLine("Spådamen Hilma har lurat dig. Hon skickade tillbaka dig till början..");
                        return Level1(); 

                    }
                    else if (myAnswer == "nej" || myAnswer == "Nej")
                    {
                        Console.Clear();
                        Console.WriteLine("Du kommer inte förbi spådamen Hilma och får gå tillbaka och välja en annan väg");
                        return Level2(way); //// lägg till return 
                    }
                    else
                    {
                        Console.WriteLine("Du måste skriva ja eller nej");
                        return Level2(way);
                        ///lägg till return laevel2(latestChoice);
                    }

                case 2:
                    Console.Clear();
                    Console.WriteLine("Ajaj, stegen är trasig och du kommer inte vidare. Gå tillbaka.");
                    return Level2(way);
                case 3:
                    Console.Clear();
                    Console.WriteLine("Här ligger en ficklampa! Perfekt så att du kanske hittar fler ledtrådar ut ur labyrinten.");
                    return 3; ////lagt till return
                    
                default:
                    Console.WriteLine("Du måste ange [1], [2] eller [3]");
                    return Level2(way);
                }
            }

        static int Level3(int latestChoice)
        {
            Console.Clear();
            Console.WriteLine("När du lyser på marken så ser du en inristad karta som kan hjälpa dig vidare.\n" +
                "Kartan visar att det finns två vägar som tar dig ut, på båda vägarna visas en varning\n" +
                "men inte vad det kan vara..\n" +
                "Du måste nu välja om du vill gå höger eller vänster och själv upptäcka vilka hinder som kan finnas");
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("Välj [1] för att gå till höger\n" +
                "Välj [2] för att gå till vänster");


            int userChoice = int.Parse(Console.ReadLine());

            switch (userChoice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Du valde att gå till höger och faller ner i en grop. Det finns nu två alternativ,\n" +
                            "nere i gropen hittar du både en spade och virke med spik. Vill du bygga en stege för att ta dig\n" +
                            "upp och välja den andra vägen eller vill du använda spaden för att gräva en tunnel?");
                    Console.WriteLine("------------------------------------------------------------------------------------");
                    Console.WriteLine("Välj [1] för att bygga en stege.\nVälj [2] för att gräva en tunnel.");

                    int choiceInLevel3 = int.Parse(Console.ReadLine());

                    switch (choiceInLevel3)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Du valde att bygga en stege och kan nu ta den andra vägen");
                            return Level3(userChoice);
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Du valde att gräva en tunnel och nu har du hittat vägen ur labyrinten.\n" +
                                "Bra jobbat!");
                            return 3;
                        default:
                            Console.WriteLine("Du måste ange [1) eller [2]");
                            return Level3(userChoice);
                    }
                case 2:
                    Console.Clear();
                    Console.WriteLine("Du valde att gå till vänster och möts av en tiger och blir uppäten.\nDu har tyvärr förlorat spelet.");
                    return 3;

                default:
                    Console.WriteLine("Du måste ange [1] eller [2]");
                    return Level3(userChoice);
            }
        }
    }
}
using System;
using System.Collections.Generic;

namespace MinGolfSpel
{
    class Program
    {
        static void Main(string[] args)
        {
            string JaNej;
            bool boll = true;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("¤¤¤¤¤¤¤¤¤¤ Välkommen i min Golf spel ¤¤¤¤¤¤¤¤¤¤");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" Vill Du spela?   J/N: ");
            JaNej = Console.ReadLine();

            if (JaNej.Equals("j"))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Du går på kursen\n" +
                    "1- Det är 320 meter till koppen\n" +
                    "2- Du har 5 gungor för att komma till det\n" +
                    "3- Om du någonsin kommer längre bort från koppen när du började,\n" +
                    "4- Du kommer att avsluta denna kursen.");
                Loop();
            }
            else
            {
                boll = false;
            }


        }

        static int Loop()
        {
            int loopNumber = 0;

            string JaNej = Console.ReadLine();
            bool boll = true;
            double distanceToHole = 320;
            double distanceRemaining = distanceToHole;
            List<double> swings = new List<double>();

            do
            {
                double angle = Angle();
                double velocity = Velosity();
                double ballDistance = CalcDis(angle, velocity);
                distanceRemaining = distanceRemaining - ballDistance;
                distanceRemaining = Math.Abs(distanceRemaining);
                distanceRemaining = Math.Round(distanceRemaining, 1);
                swings.Add(distanceRemaining);

                Console.WriteLine("Dina gungor: " + swings.Count);


                if (distanceRemaining <= 0.1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Vänster avstånd till koppen: " + distanceRemaining);
                    Console.WriteLine("Din avstånd är : " + ballDistance + "\n¤¤¤¤ Grattis Du vann! ¤¤¤¤\n");

                    boll = false;
                }
                else if (distanceRemaining > distanceToHole)
                {
                    Console.WriteLine("Till lång Spel Över\n");
                    boll = false;
                }
                else if (swings.Count > 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Din avstånd är: " + ballDistance);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Vänster avstånd till koppen: " + distanceRemaining);
                    Console.WriteLine("Förlåt du har inte mer gungor \n");
                    boll = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Din avstånd är : " + ballDistance);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Vänster avstånd till koppen : " + distanceRemaining);
                }
            }
            while (boll);

            PrintList(swings);
            Console.Write("Vill du spela igen? Skriv j/n: \n");
            JaNej = Console.ReadLine();
            Console.WriteLine("Avstånd till koppen är 320 meters");
            boll = false;
            if (JaNej.Equals("j"))
            {

                Loop();
            }

            boll = false;
            if (JaNej.Equals("n"))
            {
                JaNej = Console.ReadLine();
                Console.WriteLine("Tack för att du har spelat hejdå");
            }

            return loopNumber;

        }
        static void PrintList(List<double> swings)
        {
            Console.WriteLine("¤¤¤¤¤¤¤(Historia)¤¤¤¤¤¤¤");

            foreach (double item in swings)
            {
                Console.WriteLine("Din gungor : " + item);

            }
        }
        static double Angle()
        {

            bool stay = true;
            int creativeNumber = 0;

            do
            {
                try
                {
                    Console.Write("\n Ingångsvinkel: ");
                    double angle = Convert.ToDouble(Console.ReadLine());

                    if (angle < 0.1 || angle > 89.9)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Vinkeln måste ligga inom 0,1 till 89,9, försök igen.");
                    }
                    else
                    {
                        return angle;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Inte rätt nummer");
                    Console.WriteLine();
                }
            }
            while (stay);
            return creativeNumber;

        }
        static double Velosity()
        {
            bool stay = true;
            int creativeNumber = 0;

            do
            {
                try
                {
                    Console.Write("Ingångsvinkel: ");
                    double velocity = Convert.ToDouble(Console.ReadLine());

                    if (velocity < 0.1 || velocity > 100)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Hastigheten måste vara inom 0,1 till 100, försök igen.");
                    }
                    else
                    {
                        return velocity;
                    }
                }
                catch (FormatException)
                {

                    Console.WriteLine("Inte rätt nummer");
                    Console.WriteLine();
                }
            }
            while (stay);
            return creativeNumber;
        }
        static double CalcDis(double angle, double velocity)
        {
            double GRAVITY = 9.8;


            return Math.Round(Math.Pow(velocity, 2) / GRAVITY * Math.Sin(2 * (Math.PI / 180) * angle));
        }
    }
}
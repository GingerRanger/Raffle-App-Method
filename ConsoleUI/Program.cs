using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        private static Dictionary<int, string> guests = new Dictionary<int, string>();
        private static Dictionary<int, string> death = new Dictionary<int, string>()
        {
            {1,"Gunshot"}, {2, "Stabbing"}, {3, "Decapitation"}, {4, "A Grandfather Clock"}, {5, "Being doused in gasoline and set on fire"}, {6, "Cannibalization"},
            {7, "A fatal pant zipper malfunction" }
        };
        private static int min = 1000;
        private static int max = 9999;
        private static int raffleNumber;
        private static Random _rdm = new Random();

        static string GetUserInput(string message)
            {
            Console.Write(message);
            string guest = Console.ReadLine();
            return guest;
            }
        static int GenerateRandomNumber( int min , int max)
        {
            return _rdm.Next(min, max);
        }
        static void GetUserInfo()
        {
            string otherGuest;
            do
            {
                string name = GetUserInput("Enter a name to be entered into the sacrificial raffle!!!  ");
               raffleNumber = GenerateRandomNumber(min, max);
               guests.Add(raffleNumber, name);
                otherGuest = GetUserInput("Would you like to offer another sacrifice?  ").ToLower();
              
            } while (otherGuest == "yes");
           // PrintGuestsName();
         
           

        }
        static void PrintGuestsName()
        {
            foreach(var i in guests)
            {
                Console.WriteLine(i);
            }
        }
        public static int GetRaffleNumber(Dictionary<int, string> people)
        {
            List<int> raffleNumber = people.Keys.ToList();
            int i = _rdm.Next(raffleNumber.Count);
            int winnerNumber = raffleNumber[i];
            return winnerNumber;
        }
        static void PrintWinner()
        {
            int winnerNumber = GetRaffleNumber(guests);
            string winnerName = guests[winnerNumber] ;
            Console.WriteLine($"Congratulations {winnerName}!!\n With the #{winnerNumber} you're our next sacrifice!");
        }
        public static int GetDeath(Dictionary<int, string> people)
        {
            List<int> raffleNumber = people.Keys.ToList();
            int i = _rdm.Next(raffleNumber.Count);
            int winnerNumber = raffleNumber[i];
            return winnerNumber;
        }
        static void PrintDeath()
        {
            int winnerNumber = GetDeath(death);
            string winnerName = death[winnerNumber];
            Console.WriteLine($"You were killed by, {winnerName}!!");
        }

        static void Main(string[] args)
        {
            string playAgain;
            do
            {
                Console.WriteLine("Welcome to the Party!!");
                GetUserInfo();
                MultiLineAnimation();
                PrintGuestsName();
                PrintWinner();
                PrintDeath();
                playAgain = GetUserInput("Would you like to play a game?  ").ToLower();

            } while (playAgain == "yes");

            
            Console.ReadLine();




        }

        //Start writing your code here







        static void MultiLineAnimation() // Credit: https://www.michalbialecki.com/2018/05/25/how-to-make-you-console-app-look-cool/
        {
            var counter = 0;
            for (int i = 0; i < 30; i++)
            {
                Console.Clear();

                switch (counter % 4)
                {
                    case 0:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    │││ \\   ║");
                            Console.WriteLine("         ║    │││  O  ║");
                            Console.WriteLine("         ║    OOO     ║");
                            break;
                        };
                    case 1:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                    case 2:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║   / │││    ║");
                            Console.WriteLine("         ║  O  │││    ║");
                            Console.WriteLine("         ║     OOO    ║");
                            break;
                        };
                    case 3:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                }

                counter++;
                Thread.Sleep(200);
            }
        }
    }
}

/* Author: Christoffer Wiik
 * E-mail: Coffa19@hotmail.com
 * Ltu-mail: chrwii-3@student.ltu.se
 * Kurskod: L0002B
 * Uppgift: 2
 */




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppdrag2
{
    class Sellers
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string District { get; set; }
        public int Sold { get; set; }
        public string[] Employes { get; set; }
        public static Sellers GetSeller()
        {
            return new Sellers()
            {
                Name = Console.ReadLine(),
                Id = Console.ReadLine(),
                District = Console.ReadLine(),
                Sold = int.Parse(Console.ReadLine())
            };
        }
        public int NrSellers { get; set; }
        public static void Menu()
        {
            string[] MenuOptions = new string[] { "Inmatningar", "Utskrift", "Avsluta" };       //Dom olika valens namn i menyn
            int MenuSelected = 0;
            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;

                if (MenuSelected == 0)                                  //Dom olika valen 1-3
                {
                    Console.WriteLine("**********************************");
                    Console.WriteLine(MenuOptions[0] + "    <------¤¤¤");
                    Console.WriteLine(MenuOptions[1]);
                    Console.WriteLine(MenuOptions[2]);
                    Console.WriteLine("**********************************");
                }
                else if (MenuSelected == 1)
                {
                    Console.WriteLine("**********************************");
                    Console.WriteLine(MenuOptions[0]);
                    Console.WriteLine(MenuOptions[1] + "    <------¤¤¤");
                    Console.WriteLine(MenuOptions[2]);
                    Console.WriteLine("**********************************");
                }
                else if (MenuSelected == 2)
                {
                    Console.WriteLine("**********************************");
                    Console.WriteLine(MenuOptions[0]);
                    Console.WriteLine(MenuOptions[1]);
                    Console.WriteLine(MenuOptions[2] + "    <------¤¤¤");
                    Console.WriteLine("**********************************");
                }
                var KeyPressed = Console.ReadKey();
                if (KeyPressed.Key == ConsoleKey.DownArrow && MenuSelected != MenuOptions.Length - 1)           //kod som gör att man kan röra sig med upp och ner pilen på tangentbordet
                {
                    MenuSelected++;
                }
                else if (KeyPressed.Key == ConsoleKey.UpArrow && MenuSelected >= 1)
                {
                    MenuSelected--;
                }
                else if (KeyPressed.Key == ConsoleKey.Enter)
                {
                    switch (MenuSelected)
                    {
                        case 0:
                            AddEmploye() ;  //skickas vidare till metod för inmatning
                            break;
                        case 1:
                            Print();    //skickas vidare till metod för utskrift
                            break;
                        case 2:
                            Exit();     //Metod för att avsluta
                            break;
                    }
                }
            }
        }
        public void AddEmploye()
        {

            int Lvl1, Lvl2, Lvl3, Lvl4;
            int[] soldLvl = new int[] { Lvl1 = 0, Lvl2 = 0, Lvl3 = 0, Lvl4 = 0 };

            var Employes = new Sellers[NrSellers];
            for (int i = 0; i < NrSellers - 1; i++)
            {
                var Employe = new Sellers();

                Console.WriteLine("Säljare" + i);
                Console.WriteLine("Skriv in Namn: ");
                Employe.Name = Console.ReadLine();

                Console.WriteLine("Skriv in person nr: ");
                Employe.Id = Console.ReadLine();

                Console.WriteLine("Skriv in distrikt: ");
                Employe.District = Console.ReadLine();

                Console.WriteLine("Skriv in antal sålda artiklar: ");
                Employe.Sold = int.Parse(Console.ReadLine());

                Employes[i] = GetSeller();
                if (Employe.Sold >= 0 && Employe.Sold <= 50)
                {
                    soldLvl[Lvl1] ++;
                    Console.WriteLine("Antal försäljare i nivå 1: " + Lvl1);
                }
                else if (Employe.Sold > 50 && Employe.Sold <= 99)
                {
                    soldLvl[Lvl2] ++;
                    Console.WriteLine("Antal försäljare i nivå 2: " + Lvl2);
                }
                else if (Employe.Sold > 99 && Employe.Sold <= 199)
                {
                    soldLvl[Lvl3] ++;
                    Console.WriteLine("Antal försäljare i nivå 3: " + Lvl3);
                }
                else if (Employe.Sold > 199)
                {
                    soldLvl[Lvl4] ++;
                    Console.WriteLine("Antal försäljare i nivå 4:" + Lvl4);
                }
                else
                {
                    Console.WriteLine("Inga försäljnings uppgifter");
                }
            }
            return;
        }
        public void Print()
        {
            for (int i = 0; i < Employes.Length; i++)
            {
                Console.WriteLine("Säljare: " + i);
                Console.WriteLine(Employes[i]);
            }
        }
        public static void Exit()
        {
            Console.WriteLine("Du har valt att avsluta.");
            Console.ReadKey();
            Environment.Exit(0);
        }
        private static void Sorting()
        {
            
        }
    }
    class Program
    {
        public static void Main(string[] args)     //Start metoden
        {
            Console.WriteLine("Skriv in antal anställda:");
            int NrSellers = int.Parse(Console.ReadLine());

            Sellers[] Employes = new Sellers[NrSellers];
            Sellers.Menu();
        }
    }
}

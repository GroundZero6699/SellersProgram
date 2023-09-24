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
        public Sellers()
        {
            Name = Name;
            Id = Id;
            District = District;
            Sold = Sold;
        }
        public int NrSellers { get; set; }
        public void Menu()
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
                            AddEmploye(" ");  //skickas vidare till metod för inmatning
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
        public string AddEmploye(string n)
        {
            Console.WriteLine("Skriv in antal anställda:");
            int NrSellers = int.Parse(Console.ReadLine());
            
            Sellers[] Employes = new Sellers[NrSellers];
            int Lvl1, Lvl2, Lvl3, Lvl4;
            int[] soldLvl = new int[] { Lvl1 = 0, Lvl2 = 0, Lvl3 = 0, Lvl4 = 0 };
            
            Sellers employe = new Sellers();
            for (int i = 0; i < Employes.Length; i++)
            {
                Console.Clear();
                Console.WriteLine("Skriv in Namn: ");
                employe.Name = Console.ReadLine();

                Console.WriteLine("Skriv in person nr: ");
                employe.Id = Console.ReadLine();

                Console.WriteLine("Skriv in distrikt: ");
                employe.District = Console.ReadLine();

                Console.WriteLine("Skriv in antal sålda artiklar: ");
                employe.Sold = int.Parse(Console.ReadLine());
                
                if (Sold >= 0 && Sold <= 50)
                {
                    soldLvl[Lvl1]++;
                    Console.WriteLine("Antal försäljare i nivå 1: " + Lvl1);
                }
                else if (Sold > 50 && Sold <= 99)
                {
                    soldLvl[Lvl2]++;
                    Console.WriteLine("Antal försäljare i nivå 2: " + Lvl2);
                }
                else if (Sold > 99 && Sold <= 199)
                {
                    soldLvl[Lvl3]++;
                    Console.WriteLine("Antal försäljare i nivå 3: " + Lvl3);
                }
                else if (Sold > 199)
                {
                    soldLvl[Lvl4]++;
                    Console.WriteLine("Antal försäljare i nivå 4:" + Lvl4);
                }
                else
                {
                    Console.WriteLine("Inga försäljnings uppgifter");
                }
            }
            

            for (int i = 0; i < Employes.Length; i++)
            {
                Console.WriteLine("Säljare: " + i);
                Console.WriteLine(employes);
            }
            Console.ReadKey();
            return n;
        }
        public void Print()
        {
            bool sort;
            string s = " ";
            do
            {
                sort = false;
                for (int i = 0; i < Employes.Length; i++)
                {
                    for (int j = 0; j < Employes.Length - 1; j++)
                    {
                        if (string.Compare(Employes[i], Employes[j + 1]) < 0)
                        {
                            s = Employes[i];
                            Employes[i] = Employes[j + 1];
                            Employes[j + 1] = s;
                            sort = true;
                        }
                    }
                }
            }
            while (sort);
            
            for (int i = 0; i < Employes.Length; i++)
            {
                Console.WriteLine("Säljare: " + i);
                Console.WriteLine(Employes[i]);
            }
            Console.ReadKey();
        }
        public static void Exit()
        {
            Console.WriteLine("Du har valt att avsluta.");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
    class Program
    {
        public static void Main(string[] args)     //Start metoden
        {
            
            Sellers s = new Sellers();
           
           
            s.Menu();
        }
    }
}


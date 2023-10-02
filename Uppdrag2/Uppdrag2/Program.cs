/* Author: Christoffer Wiik
 * E-mail: Coffa19@hotmail.com
 * Ltu-mail: chrwii-3@student.ltu.se
 * Kurskod: L0002B
 * Uppgift: 2
 */




using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppdrag2
{
    class Menu
    {
        private static Sellers[] Employes { get; set; }
        public static void MyMenu()
        {
            try
            {
                Console.WriteLine("Ange antal anställda.");
                int nrOfSellers = int.Parse(Console.ReadLine());
                Employes = new Sellers[nrOfSellers];
            }
            catch
            {
                Console.WriteLine("Ange antal säljare TACK!");
            }
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
                            for (int i = 0; i < Employes.Length; i++)
                            {
                                Employes[i] = AddEmploye();  //skickas vidare till metod för inmatning
                            }
                            break;
                        case 1:
                            Print();    //skickas vidare till metod för utskrift
                            break;
                        case 3:
                            Exit();     //Metod för att avsluta
                            break;
                    }
                }
            }
        }
        private static Sellers AddEmploye()
        {
            Sellers employes = new Sellers();
            Console.WriteLine("*****************************************");
            Console.WriteLine();
            Console.WriteLine("Skriv in Namn: ");
            Console.WriteLine();
            Console.WriteLine("*****************************************");
            employes.Name = Console.ReadLine();

            Console.WriteLine("*****************************************");
            Console.WriteLine();
            Console.WriteLine("Skriv in person nr: ");
            Console.WriteLine();
            Console.WriteLine("*****************************************");
            employes.Id = Console.ReadLine();

            Console.WriteLine("*****************************************");
            Console.WriteLine();
            Console.WriteLine("Skriv in distrikt: ");
            Console.WriteLine();
            Console.WriteLine("*****************************************");
            employes.District = Console.ReadLine();

            Console.WriteLine("*****************************************");
            Console.WriteLine();
            Console.WriteLine("Skriv in antal sålda artiklar: ");
            Console.WriteLine();
            Console.WriteLine("*****************************************");
            employes.Sold = int.Parse(Console.ReadLine());
            
            employes.Lvl = SoldLvl(employes);
            Console.Clear();
            return employes;
        }
        private static void Sorting()
        {
            bool notSorted = true;
            int theEnd = Employes.Length - 1;

            while (notSorted)
            {
                notSorted = false;
                for (int i = 0; i < theEnd; i++)
                {
                    if (Employes[i].Sold > Employes[i + 1].Sold)
                    {
                        Jump(Employes, i, i + 1);
                        notSorted = true;
                    }
                }
                theEnd--;
            }
            
        }
        private static void Jump(Sellers[] array, int emp, int amp)
        {
            Sellers e = array[emp];
            array[emp] = array[amp];
            array[amp] = e;
        } 
        private static void Print()
        {
            Sorting();
            for (int i = 0; i < Employes.Length; i++)
            {
                Console.WriteLine("***************************************************");
                Console.WriteLine();
                Console.WriteLine(Employes[i] + "\n");
                Console.WriteLine();
                Console.WriteLine("***************************************************");
            }
            foreach (Sellers employes in Employes)
            { 
                Console.WriteLine(employes.Lvl + " Säljare");
            }

            Console.ReadKey();
        }
        private static string SoldLvl(Sellers employes)
        {
            int Lvl1 = 0, Lvl2 = 0, Lvl3 = 0, Lvl4 = 0, Lvl0 = 0;
            for (int i = 0; i < Employes.Length; i++)
            {
                if (employes.Sold >= 0 && employes.Sold <= 50)
                {
                    Lvl1++;
                }
                else if (employes.Sold > 50 && employes.Sold <= 99)
                {
                    Lvl2++;
                }
                else if (employes.Sold > 99 && employes.Sold <= 199)
                {
                    Lvl3++;
                }
                else if (employes.Sold > 199)
                {
                    Lvl4++;
                }
                else
                {
                    Lvl0++;
                }
            }
            if (Lvl1 != 0)
            {
                return "Antal säljare på nivå 1: " + Lvl1;
            }
            else if (Lvl2 != 0)
            {
                return "Antal säljare på nivå 2: " + Lvl2;
            }
            else if (Lvl3 != 0)
            {
                return "Antal säljare på nivå 3: " + Lvl3;
            }
            else if (Lvl4 != 0)
            {
                return "Antal säljare på nivå 4: " + Lvl4;
            }
            else
            {
                return "Antal säljare utan försäljnings uppgifter: " + Lvl0;
            }
        }
        private static void Exit()
        {
            Console.WriteLine("Du har valt att avsluta.");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
    class Sellers
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string District { get; set; }
        public int Sold { get; set; }
        public string Lvl { get; set; }
        public Sellers(string Name, string Id, string District, int Sold, string Lvl)
        {
            Name = Name;
            Id = Id;
            District = District;
            Sold = Sold;
            Lvl = Lvl;
        }
        public Sellers()
        {

        }
        public override string ToString()
        {
            string person = Name + "\n" + Id + "\n" + District + "\n" + Sold;
            return person;
        }

    }
    class Program
    {
        public static void Main(string[] args)     //Start metoden
        {
            Menu.MyMenu();
        }
    }
}

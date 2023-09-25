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
        public override string ToString()
        {
            string person = Name + "\n" + Id + "\n" + District + "\n" + Sold;
            return person;
        }
        public Sellers(string Name, string Id, string District, int Sold)
        {
            Name = Name;
            Id = Id;
            District = District;
            Sold = Sold;
        }
        public Sellers()
        {

        }
        
    }
    class Program
    {
        public int[] soldLvl { get; set; }
        public string[] employes { get; set; }
        public static void Main(string[] args)     //Start metoden
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
                            AddEmploye("a", "b", "c", 1);  //skickas vidare till metod för inmatning
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
        public static string AddEmploye(string Name, string Id, string District, int Sold)
        {
            int Lvl1, Lvl2, Lvl3, Lvl4;
            int[] soldLvl = new int[] { Lvl1 = 0, Lvl2 = 0, Lvl3 = 0, Lvl4 = 0 };
            Console.WriteLine("Skriv in antal anställda:");
            int NrSellers = int.Parse(Console.ReadLine());
            string[] employes = new string[NrSellers];

            Sellers person = new Sellers();
            for (int i = 0; i < NrSellers; i++)
            {
                
                Console.Clear();
                Console.WriteLine("*********************************************************");
                Console.WriteLine();
                Console.WriteLine("Skriv in Namn: ");
                person.Name = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("*********************************************************");
                Console.WriteLine();

                Console.WriteLine("*********************************************************");
                Console.WriteLine();
                Console.WriteLine("Skriv in person nr: ");
                person.Id = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("*********************************************************");
                Console.WriteLine();

                Console.WriteLine("*********************************************************");
                Console.WriteLine();
                Console.WriteLine("Skriv in distrikt: ");
                person.District = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("*********************************************************");
                Console.WriteLine();

                Console.WriteLine("*********************************************************");
                Console.WriteLine();
                Console.WriteLine("Skriv in antal sålda artiklar: ");
                person.Sold = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("*********************************************************");
                if (Sold >= 0 && Sold <= 50)
                {
                    soldLvl[Lvl1]++;
                }
                else if (Sold > 50 && Sold <= 99)
                {
                    soldLvl[Lvl2]++;
                }
                else if (Sold >= 100 && Sold <= 199)
                {
                    soldLvl[Lvl3]++;
                }
                else
                {
                    soldLvl[Lvl4]++;
                }
                employes[i] = person.ToString();
            }
            return person.ToString();
        }
        public string Print(string person)
        {
            
            int s = 1;
            Sorting(employes);
            foreach (var item in employes)
            {
                Console.WriteLine("*********************************************************");
                Console.WriteLine();
                Console.WriteLine("Säljare: " + s++);
                Console.WriteLine(item.ToString());
                Console.WriteLine(soldLvl);
                Console.WriteLine();
                Console.WriteLine("*********************************************************");
                Console.ReadKey();
            }
            return person;
        }
        public string Sorting(string[] employes)
        {
            string sorted_arr = employes.ToString();
            bool sort;
            string s = " ";
            do
            {
                sort = false;
                for (int i = 0; i < employes.Length; i++)
                {
                    for (int j = 0; j < employes.Length - 1; j++)
                    {
                        if (string.Compare(employes[i], employes[j + 1]) < 0)
                        {
                            s = employes[i];
                            employes[i] = employes[j + 1];
                            employes[j + 1] = s;
                            sort = true;
                        }
                    }
                }
            }
            while (sort);
            return employes[1];
        }
        public static void Exit()
        {
            Console.WriteLine("Du har valt att avsluta.");
            Console.ReadKey();
            Environment.Exit(0);
        }
        
    }
}

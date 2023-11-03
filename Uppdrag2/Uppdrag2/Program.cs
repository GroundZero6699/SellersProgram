/* Author: Christoffer Wiik
 * E-mail: Coffa19@hotmail.com
 * Ltu-mail: chrwii-3@student.ltu.se
 * Kurskod: L0002B
 * Uppgift: 2
 */




using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

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
                Console.WriteLine("Ange antal säljare tack!");
                Console.ReadKey();
            }
            string[] MenuOptions = new string[] { "Lägg till säljare", "Sammanställning", "Avsluta" };       //Dom olika valens namn i menyn
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
                                Employes[i] = AddEmploye();  //skickas vidare till metod för inmatning av försäljare
                            }
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
        private static Sellers AddEmploye()             //Metod för att lägga till nya försäljare.
        {
            Sellers employes = new Sellers();
            try
            {
                
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
            }
            catch
            {
                Console.WriteLine("Nu blev det galet! Kontrollera uppgifterna och prova igen.");                      // Felmeddelande om man inte använder sig av siffror vid inmatning av sålda artiklar i .Sold 
                Console.ReadKey();
            }
            
            if (employes.Sold >= 0 && employes.Sold <= 50)                      // Tilldelning av nivå vid inmatning av försäljarens information.
            {
                employes.Lvl = 1;
            }
            else if (employes.Sold > 50 && employes.Sold <= 99)
            {
                employes.Lvl = 2;
            }
            else if (employes.Sold > 99 && employes.Sold <= 199)
            {
                employes.Lvl = 3;
            }
            else if (employes.Sold > 199)
            {
                employes.Lvl = 4;
            }
            else
            {
                employes.Lvl = 5;
            }

            Console.Clear();
            return employes;
        }
        private static void Sorting()                       // Sorterings metoden
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
        private static void Jump(Sellers[] array, int emp, int amp)                 // Förflyttning i arrayen vid sortering.
        {
            Sellers e = array[emp];
            array[emp] = array[amp];
            array[amp] = e;
        } 
        private static void Print()
        {
            Sorting();                      // Till sorterings metoden.

            Dictionary<int, int> levelCounts = SoldLvl();                   // Hämta räknarvärdet av försäljnings nivån 

            Console.Clear();
            StreamWriter file = new StreamWriter("Bonus.txt");
            var groupedEmployees = Employes.GroupBy(e => e.Lvl).OrderBy(g => g.Key);

            foreach (var group in groupedEmployees)
            {
                Console.WriteLine("************************************************************************************");      // Gruppera och utskrift till konsol.
                Console.WriteLine("Nivå: " + group.Key + " * ");
                Console.WriteLine("*********");
                file.WriteLine("************************************************************************************");      // Gruppera och utskrift till fil "Bonus.txt"
                file.WriteLine("Nivå: " + group.Key + " * ");
                file.WriteLine("*********");
                foreach (var employee in group)
                {
                    Console.Write("{0,-20}\t{1,-15}\t{2,-15}\t{3,-15}\n", "Namn", "Personnr", "Distrikt", "Sålda artiklar");
                    Console.WriteLine("------------------------------------------------------------------------------------");
                    Console.Write("{0,-20}\t{1,-15}\t{2,-15}\t{3,-15}\n", employee.Name, employee.Id, employee.District, employee.Sold); // Skriva till konsolen.
                    Console.WriteLine("------------------------------------------------------------------------------------");
                    file.Write("{0,-20}\t{1,-15}\t{2,-15}\t{3,-15}\n", "Namn", "Personnr", "Distrikt", "Sålda artiklar");
                    file.WriteLine("------------------------------------------------------------------------------------");
                    file.Write("{0,-20}\t{1,-15}\t{2,-15}\t{3,-15}\n", employee.Name, employee.Id, employee.District, employee.Sold); // Skriva till filen "Bonus.txt"
                    file.WriteLine("------------------------------------------------------------------------------------");
                }
                Console.WriteLine("Antal säljare på nivå " + group.Key + ": " + levelCounts[group.Key]);
                Console.WriteLine("************************************************************************************");
                file.WriteLine("Antal säljare på nivå " + group.Key + ": " + levelCounts[group.Key]);
                file.WriteLine("************************************************************************************");
            }
            file.Close();
            Console.ReadKey();
        }
        private static Dictionary<int, int> SoldLvl()
        {
            Dictionary<int, int> levelCounts = new Dictionary<int, int>() { { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 } };

            for (int i = 0; i < Employes.Length; i++)           // Nivå räknare för varje gång det läggs till ny anställd.
            {
                levelCounts[Employes[i].Lvl]++;
            }

            return levelCounts;
        }
        private static void Exit()
        {
            Console.WriteLine("Du har valt att avsluta.");              // Metod för att avsluta
            Console.ReadKey();
            Environment.Exit(0);                // Program slut
        }
    }
    class Sellers                   // Egen klass för att skapa nya anställda.
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string District { get; set; }
        public int Sold { get; set; }
        public int Lvl { get; set; }
        public Sellers(string Name, string Id, string District, int Sold, int Lvl)
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
    }
    class Program
    {
        public static void Main(string[] args)     //Start metoden
        {
            Menu.MyMenu();          //Skickas till menyn.
        }
    }
}

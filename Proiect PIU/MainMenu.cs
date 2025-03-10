using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Targ_Auto;

namespace Proiect_PIU
{
    static class MainMenu
    {
        static void Main(string[] args)
        {
            /*
            Vanzator vanzator = new Vanzator("Ilisescu"," Adrian", "Str. Unirii, bl. 4, ap.10", 0723456789,"ilici75@gmail.com",50421);
            vanzator.Display();
            Console.WriteLine("");
            Cumparator cumparator = new Cumparator("Vasilescu", "Gheorghe", "Str. Mihai Viteazu, bl. 2, ap. 5", 0723456789, "vasilescu33@gmail.com", 30421);
            cumparator.Display();
            Console.WriteLine("");
            Tranzactie tranzactie = new Tranzactie(234543, 2000, cumparator, vanzator, "24.02.2025");
            tranzactie.Display();
            Console.WriteLine("");
            Masina masina = new Masina(vanzator.get_nume()+' '+vanzator.get_prenume(), cumparator.get_nume() + ' ' + cumparator.get_prenume(), "Opel", "Astra G Caravan", 2002, "alb", new string[] { "aer conditionat", "Nu bate", "Nu troncane" }, tranzactie.get_suma());
            masina.Display();
            Console.WriteLine("");*/
            Vanzator vanzator = null;
            Cumparator cumparator = null;
            Tranzactie tranzactie = null;
            Masina masina = null;
            Registru registru = new Registru();

            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Meniu principal:");
                Console.WriteLine("1. Adauga o masina în registru");
                Console.WriteLine("2. Afiaeaza registrul");
                Console.WriteLine("3. Cautare masina dupa marca");
                Console.WriteLine("4. Iesire");
                Console.Write("Alege o optiune (1-4): ");

                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        

                        Citire();

                        Console.WriteLine("Datele au fost adaugate cu succes!");
                        Console.ReadLine();
                        break;

                    case "2":
                        registru.AfiseazaRegistru();
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.WriteLine("Introduceti marca pentru cautare:");
                        string marcaCautata = Console.ReadLine();
                        registru.CautaMasinaDupaMarca(marcaCautata);
                        Console.ReadLine();
                        break;

                    case "4":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Optiune invalida!");
                        Console.ReadLine();
                        break;


                }
            }
            void Citire()
            {
                vanzator = new Vanzator();
                Console.WriteLine("Vanzator:");
                vanzator.Read();
                cumparator = new Cumparator();
                Console.WriteLine("Cumparator:");
                cumparator.Read();
                
                tranzactie = new Tranzactie(cumparator, vanzator);
                Console.WriteLine("Masina:");
                masina = new Masina(vanzator.get_nume()+" "+vanzator.get_prenume(), cumparator.get_nume() + " " + cumparator.get_prenume());
                
                
                masina.Read();
                Console.WriteLine("Tranzactie:");
                tranzactie.Read();

                registru.AdaugaMasina(masina);
            }

        }
    }
}
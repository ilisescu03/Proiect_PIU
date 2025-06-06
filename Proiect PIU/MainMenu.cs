﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Targ_Auto;
using System.Configuration;

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
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            Vanzator vanzator = null;
            Cumparator cumparator = null;
            Tranzactie tranzactie = null;
            Masina masina = null;
            Registru registru = new Registru();
            RegistruFisier registruFisier = new RegistruFisier("registru.txt");
            registru.AdauagaMasini(registruFisier.GetMasini());
            Vanzatori vanzatori = new Vanzatori();
   
            vanzatori.LoadFromFile("vanzatori.txt");
            bool running = true;
            while (running)
            {

                Console.Clear();
                Console.WriteLine("Meniu principal:");
                Console.WriteLine("1. Adauga o masina in registru si un vanzator in baza de date vanzatori");
                Console.WriteLine("2. Afiseaza registrul");
                Console.WriteLine("3. Cautare masina dupa marca");
                Console.WriteLine("4. Cautare vanzator dupa nume");
                Console.WriteLine("5. Afiseaza vanzatori");
                Console.WriteLine("6. Salveaza datele");
                Console.WriteLine("7. Iesire");
                Console.Write("Alege o optiune (1-7): ");

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
                        Console.WriteLine("Introduceti numele vanzatorului pentru cautare:");
                        string numeCautat = Console.ReadLine();
                        vanzatori.CautaVanzatorDupaNume(numeCautat);
                        Console.ReadLine();
                        break;

                    case "5":
                        vanzatori.AfiseazaVanzatori();
                        Console.ReadLine();
                        break;

                    case "6":
                        // Save data to files
                        
                        vanzatori.SaveToFile("vanzatori.txt");
                        Console.WriteLine("Datele au fost salvate cu succes!");
                        Console.ReadLine();
                        break;

                    case "7":
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

               // tranzactie = new Tranzactie(cumparator, vanzator);
                Console.WriteLine("Masina:");
                masina = new Masina(vanzator.get_nume() + " " + vanzator.get_prenume(), cumparator.get_nume() + " " + cumparator.get_prenume());

                masina.Read();
                Console.WriteLine("Tranzactie:");
                tranzactie.Read();

                registru.AdaugaMasina(masina);
                registruFisier.AdaugaMasina(masina);
                registru.AdaugaTranzactie(tranzactie);
                vanzatori.AdaugaVanzator(vanzator);
            }
        }
    }
}
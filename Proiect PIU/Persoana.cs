using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PIU
{
    public class Persoana
    {

        protected string nume;
        protected string prenume;
        protected string adresa;
        protected int telefon;
        protected string email;
        public Persoana()
        {

        }
        public Persoana(string _nume, string _prenume, string _adresa, int _telefon, string _email)
        {
            nume = _nume;
            prenume = _prenume;
            adresa = _adresa;
            telefon = _telefon;
            email = _email;
        }
        public virtual void Display()
        {
            Console.WriteLine("Nume: " + nume);
            Console.WriteLine("Prenume: " + prenume);
            Console.WriteLine("Adresa: " + adresa);
            Console.WriteLine("Telefon: " + telefon);
            Console.WriteLine("Email: " + email);
        }
        public void set_nume(string _nume)
        {
            nume = _nume;
        }
        public void set_prenume(string _prenume)
        {
            prenume = _prenume;
        }
        public string get_nume()
        {
            return nume;
        }

        public string get_prenume()
        {
            return prenume;
        }
        public string get_adresa()
        {
            return adresa;
        }
        public int get_telefon()
        {
            return telefon;
        }
        public string get_email()
        {
            return email;
        }
        public virtual void Read()
        {
            Console.WriteLine("Introdu numele:");
            nume = Console.ReadLine();

            Console.WriteLine("Introdu prenumele:");
            prenume = Console.ReadLine();

            Console.WriteLine("Introdu adresa:");
            adresa = Console.ReadLine();

            Console.WriteLine("Introdu numarul de telefon:");
            while (!int.TryParse(Console.ReadLine(), out telefon))
            {
                Console.WriteLine("Număr de telefon invalid! Introdu un numar valid:");
            }

            Console.WriteLine("Introdu email-ul:");
            email = Console.ReadLine();
        }
    }
}

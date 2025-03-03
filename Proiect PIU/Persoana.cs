using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PIU
{
    class Persoana
    {

        protected string nume;
        protected string prenume;
        protected string adresa;
        protected int telefon;
        protected string email;
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
        public string get_nume()
        {
            return nume;
        }

        public string get_prenume()
        {
            return prenume;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PIU
{
    class Vanzator : Persoana
    {
        int codVanzator;
        public Vanzator() { }
        
        public Vanzator(string _nume, string _prenume, string _adresa, int _telefon, string _email, int codVanzator) : base(_nume, _prenume, _adresa, _telefon, _email)
        {
            this.codVanzator = codVanzator;
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine("Cod vanzator: " + codVanzator);
        }
        public override void Read()
        {
            base.Read();
            Console.WriteLine("Introdu codul vanzator:");
            codVanzator = int.Parse(Console.ReadLine());
        }
    }
}

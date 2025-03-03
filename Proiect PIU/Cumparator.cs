using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PIU
{
    class Cumparator : Persoana
    {
        int codCumparator;
        public Cumparator(string _nume, string _prenume, string _adresa, int _telefon, string _email, int codCumparator) : base(_nume, _prenume, _adresa, _telefon, _email)
        {
            this.codCumparator = codCumparator;
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine("Cod cumparator: " + codCumparator);
        }
    }
}

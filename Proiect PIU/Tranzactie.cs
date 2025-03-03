using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PIU
{
    class Tranzactie
    {
        int codTranzactie;
        float suma;
        Cumparator cumparator;
        Vanzator vanzator;
        string dataTranzactie;
        public Tranzactie(int _codTranzactie, float _suma, Cumparator _cumparator, Vanzator _vanzator, string _dataTranzactie)
        {
            this.codTranzactie = _codTranzactie;
            this.suma = _suma;
            this.cumparator = _cumparator;
            this.vanzator = _vanzator;
            this.dataTranzactie = _dataTranzactie;
        }
        public void Display()
        {
            Console.WriteLine("Tranzactie incheiata intre:");
            cumparator.Display();
            vanzator.Display();
            Console.WriteLine("Suma: " + suma);
            Console.WriteLine("Data tranzactie: " + dataTranzactie);

        }
        public string get_dataTranzactie()
        {
            return dataTranzactie;
        }
        public float get_suma()
        {
            return suma;
        }
    }
}

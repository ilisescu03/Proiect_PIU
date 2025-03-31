using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PIU
{
    public class Tranzactie
    {
        int codTranzactie;
        float suma;
        Cumparator cumparator;
        Vanzator vanzator;
        string dataTranzactie;
        public Tranzactie(Cumparator _cumparator, Vanzator _vanzator)
        {
            cumparator = _cumparator;
            vanzator = _vanzator;
        }
        public Tranzactie()
        {

        }
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
            Console.WriteLine("{0} {1} si {2} {3}", cumparator.get_nume(), cumparator.get_prenume(), vanzator.get_nume(), vanzator.get_prenume());
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
        public void Read()
        {
            Console.WriteLine("Introdu codul tranzactiei:");
            codTranzactie = int.Parse(Console.ReadLine());

            Console.WriteLine("Introdu suma tranzactiei:");
            suma = float.Parse(Console.ReadLine());

            Console.WriteLine("Introdu data tranzactiei (format: dd-MM-yyyy):");
            dataTranzactie = Console.ReadLine();
        }

        public string Serialize()
        {
            return $"Tranzactie:{codTranzactie}|{suma}|{cumparator.get_nume()}|{cumparator.get_prenume()}|{vanzator.get_nume()}|{vanzator.get_prenume()}|{dataTranzactie}";
        }

        public static Tranzactie Deserialize(string data)
        {
            var parts = data.Split('|');
            if (parts.Length == 7)
            {
                var cumparator = new Cumparator();
                cumparator.set_nume(parts[2]);
                cumparator.set_prenume(parts[3]);

                var vanzator = new Vanzator();
                vanzator.set_nume(parts[4]);
                vanzator.set_prenume(parts[5]);

                return new Tranzactie(
                    int.Parse(parts[0].Split(':')[1]),
                    float.Parse(parts[1]),
                    cumparator,
                    vanzator,
                    parts[6]
                );
            }
            throw new FormatException("Invalid data format");

        }
    }
}

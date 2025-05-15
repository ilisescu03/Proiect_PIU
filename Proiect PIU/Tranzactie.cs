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
        string cumparator;
        string vanzator;
        string masina;
        string dataTranzactie;
        public Tranzactie(string _cumparator, string _vanzator)
        {
            cumparator = _cumparator;
            vanzator = _vanzator;
        }
        public Tranzactie()
        {

        }
        public Tranzactie(string numeFisier)
        {
            string[] date = numeFisier.Split(';');
            if (date.Length != 6) return;
            codTranzactie = Int32.Parse(date[0]);
            suma = float.Parse(date[1]);
            cumparator = date[2];
            vanzator = date[3];
            masina = date[5];
            dataTranzactie = date[4];

        }
        public Tranzactie(int _codTranzactie, float _suma, string _cumparator, string _vanzator, string _dataTranzactie, string masina)
        {
            this.codTranzactie = _codTranzactie;
            this.suma = _suma;
            this.cumparator = _cumparator;
            this.vanzator = _vanzator;
            this.dataTranzactie = _dataTranzactie;
            this.masina = masina;

        }
        public void Display()
        {
            Console.WriteLine("Tranzactie incheiata intre:");
            Console.WriteLine("{0} si {1}", cumparator, vanzator);
            Console.WriteLine("Suma: " + suma);
            Console.WriteLine("Data tranzactie: " + dataTranzactie);

        }
        public int getCod()
        {
            return codTranzactie;
        }
        public string get_dataTranzactie()
        {
            return dataTranzactie;
        }
        public string get_Cumparator()
        {
            return cumparator;
        }
        public string get_Masina()
        {
            return masina;
        }
        public string get_Vanzator()
        { return vanzator;}
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
            return $"{codTranzactie}|{suma}|{cumparator}|{vanzator}|{dataTranzactie}|{masina}";
        }

        public static Tranzactie Deserialize(string data)
        {
            var parts = data.Split('|');
            Tranzactie tranzactie = new Tranzactie(Int32.Parse(parts[0]), float.Parse(parts[1]), parts[2], parts[3], parts[4], parts[5]);
            if (parts.Length == 6)
            {
                return tranzactie;

            }
            throw new FormatException("Invalid data format");

        }
        public string ConversieLaSir_PentruFisier()
        {
            return $"{codTranzactie};{suma};{cumparator};{vanzator};{dataTranzactie};{masina}";
        }
    }
}

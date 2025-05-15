using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PIU
{
    public class Cumparator : Persoana
    {
        int codCumparator;
        public Cumparator() { }
        public Cumparator(string numeFisier)
        {
            string[] date = numeFisier.Split(';');
            if (date.Length != 6) return;
            codCumparator = Int32.Parse(date[0]);
            nume = date[1];
            prenume = date[2];
            adresa = date[3];
            telefon = int.Parse(date[4]);
            email = date[5];

        }
        public Cumparator(string _nume, string _prenume, string _adresa, int _telefon, string _email, int codCumparator) : base(_nume, _prenume, _adresa, _telefon, _email)
        {
            this.codCumparator = codCumparator;
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine("Cod cumparator: " + codCumparator);
        }
        public override void Read()
        {
            base.Read();
            Console.WriteLine("Introdu codul cumparator:");
            codCumparator = int.Parse(Console.ReadLine());
        }
        public string Serialize()
        {
            return $"{nume}|{prenume}|{adresa}|{telefon}|{email}|{codCumparator}";
        }

        public static Cumparator Deserialize(string data)
        {
            var parts = data.Split('|');
            if (parts.Length == 6)
            {
                return new Cumparator(
                    parts[0],
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]),
                    parts[4],
                    int.Parse(parts[5])
                );
            }
            throw new FormatException("Invalid data format");
        }
        public string ConversieLaSir_PentruFisier()
        {
            return $"{codCumparator};{nume};{prenume};{adresa};{telefon};{email}";
        }
        public int getCodCumparator()
        {
            return codCumparator;
        }
    }
}

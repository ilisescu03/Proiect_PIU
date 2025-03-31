using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Targ_Auto;

namespace Proiect_PIU
{
    public class Registru
    {
        private List<Masina> masini;
        private List<Tranzactie> tranzactii;

        public Registru()
        {
            masini = new List<Masina>();
            tranzactii = new List<Tranzactie>();
        }

        public void AdaugaMasina(Masina masina)
        {
            masini.Add(masina);
        }
        public void AdaugaTranzactie(Tranzactie tranzactie)
        {
            tranzactii.Add(tranzactie);
        }
        public void AfiseazaRegistru()
        {
            foreach (var masina in masini)
            {
                masina.Display();
                Console.WriteLine();
            }
            foreach (var tranzactie in tranzactii)
            {
                tranzactie.Display();
                Console.WriteLine();
            }
        }

        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var masina in masini)
                {
                    writer.WriteLine(masina.Serialize());
                }
                foreach (var tranzactie in tranzactii)
                {
                    writer.WriteLine(tranzactie.Serialize());
                }
            }
        }
        public List<Masina> GetRegistru()
        {
            return masini;
        }
        public void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            masini.Clear();
            tranzactii.Clear();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("Masina:"))
                    {
                        Masina masina = Masina.Deserialize(line);
                        masini.Add(masina);
                    }
                    else if (line.StartsWith("Tranzactie:"))
                    {
                        Tranzactie tranzactie = Tranzactie.Deserialize(line);
                        tranzactii.Add(tranzactie);
                    }
                }
            }
        }
        public void CautaMasinaDupaMarca(string marcaCautata)
        {
            var masiniGasite = masini.Where(m => m.GetMarca().ToLower() == marcaCautata.ToLower()).ToList();
            if (masiniGasite.Count > 0)
            {
                foreach (var masina in masiniGasite)
                {
                    masina.Display();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Nu s-au gasit masini cu marca " + marcaCautata);
            }
        }
    }
}

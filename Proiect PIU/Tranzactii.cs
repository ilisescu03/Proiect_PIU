using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics.Eventing.Reader;

namespace Proiect_PIU
{
    public class Tranzactii
    {
        private List<Tranzactie> tranzactii;

        public Tranzactii()
        {
            tranzactii = new List<Tranzactie>();
        }
        public void AdaugaTranzactie(Tranzactie tranzactie)
        {
            tranzactii.Add(tranzactie);
        }
        public void AfiseazaTranzactii()
        {
            foreach(var tranzactie in tranzactii)
            {
                tranzactie.Display();
                Console.WriteLine();
            }
        }
        public void CautaTranzactieDupaCod(int cod)
        {
            var tranzactiiGasite=tranzactii.Where(t=> t.getCod()==cod).ToList();
            if(tranzactiiGasite.Count() > 0 )
            {
                foreach(Tranzactie t in tranzactiiGasite)
                {
                    t.Display();
                    Console.WriteLine();
                }
                
            }
            else { Console.WriteLine("Nu s-au gasit!\n"); }
        }
        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var tranzactie in tranzactii)
                {
                    writer.WriteLine(tranzactie.Serialize());
                }
            }
        }

        public void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            tranzactii.Clear();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Tranzactie tranzactie = Tranzactie.Deserialize(line);
                    tranzactii.Add(tranzactie);
                }
            }
        }
    }
}

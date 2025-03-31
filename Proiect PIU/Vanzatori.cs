using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PIU
{
    class Vanzatori
    {
        private List<Vanzator> listaVanzatori;

        public Vanzatori()
        {
            listaVanzatori = new List<Vanzator>();
        }

        public void AdaugaVanzator(Vanzator vanzator)
        {
            listaVanzatori.Add(vanzator);
        }

        public void AfiseazaVanzatori()
        {
            foreach (var vanzator in listaVanzatori)
            {
                vanzator.Display();
                Console.WriteLine();
            }
        }

        public void CautaVanzatorDupaNume(string numeCautat)
        {
            var vanzatoriGasiti = listaVanzatori.Where(v => v.get_nume().ToLower() == numeCautat.ToLower()).ToList();
            if (vanzatoriGasiti.Count > 0)
            {
                foreach (var vanzator in vanzatoriGasiti)
                {
                    vanzator.Display();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Nu s-au gasit vanzatori cu numele " + numeCautat);
            }
        }
        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var vanzator in listaVanzatori)
                {
                    writer.WriteLine(vanzator.Serialize());
                }
            }
        }

        public void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            listaVanzatori.Clear();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Vanzator vanzator = Vanzator.Deserialize(line);
                    listaVanzatori.Add(vanzator);
                }
            }
        }
    }
}

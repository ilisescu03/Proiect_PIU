using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PIU
{
    class Cumparatori
    {
        private List<Cumparator> listaCumparatori;
        public Cumparatori()
        {
            listaCumparatori = new List<Cumparator>();
        }
        public void AdaugaCumparator(Cumparator cumparator)
        {
            listaCumparatori.Add(cumparator);
        }
        public void AfiseazaCumparatori()
        {
            foreach (Cumparator cumparator in listaCumparatori)
            {
                cumparator.Display();
                Console.WriteLine();
            }
        }
        public void CautaCumparatorDupaNume(string numeCautat)
        {
            var cumparatoriGasiti = listaCumparatori.Where(c => c.get_nume().ToLower() == numeCautat.ToLower()).ToList();
            if (cumparatoriGasiti.Count > 0)
            {
                foreach (var cumparator in cumparatoriGasiti)
                {
                    cumparator.Display();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Nu s-au gasit cumparatori cu numele " + numeCautat);
            }
        }
        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var cumparator in listaCumparatori)
                {
                    writer.WriteLine(cumparator.Serialize());
                }
            }
        }

        public void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            listaCumparatori.Clear();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Cumparator cumparator = Cumparator.Deserialize(line);
                    listaCumparatori.Add(cumparator);
                }
            }
        }

    }
}

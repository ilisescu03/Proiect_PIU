using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PIU
{
    public class CumparatoriFisier
    {
        private string numeFisier;
        public CumparatoriFisier(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }
        public void AdaugaCumparator(Cumparator cumparator)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(cumparator.ConversieLaSir_PentruFisier());
            }
        }
        public List<Cumparator> GetCumparatori()
        {
            List<Cumparator> cumparatori = new List<Cumparator>();
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    cumparatori.Add(new Cumparator(linieFisier));
                }
            }
            return cumparatori;
        }
        public void StergeTotDinFisier()
        {
            using (StreamWriter sw = new StreamWriter(numeFisier, false))
            {
                // Nu scriem nimic => fișierul va fi golit
            }
        }
    }
}

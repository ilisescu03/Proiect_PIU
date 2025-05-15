using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PIU
{
    public class TranzactiiFisier
    {
        private string numeFisier;
        public TranzactiiFisier(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }
        public void AdaugaTranzactie(Tranzactie tranzactie)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(tranzactie.ConversieLaSir_PentruFisier());
            }
        }
        public List<Tranzactie> GetTranzactii()
        {
            List<Tranzactie> tranzactiiLista = new List<Tranzactie>();
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    tranzactiiLista.Add(new Tranzactie(linieFisier));
                }
            }
            return tranzactiiLista;
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

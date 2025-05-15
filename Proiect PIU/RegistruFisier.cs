using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Targ_Auto;

namespace Proiect_PIU
{
    
    public class RegistruFisier
    {
        private string numeFisier;
        public RegistruFisier(string numeFisier)
        {

            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }
        public void AdaugaMasina(Masina masina)
        {
            
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(masina.ConversieLaSir_PentruFisier());
            }
        }
        
        public List<Masina> GetMasini()
        {
            List<Masina> masini = new List<Masina>();
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    masini.Add(new Masina(linieFisier));
                }
            }
            return masini;
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

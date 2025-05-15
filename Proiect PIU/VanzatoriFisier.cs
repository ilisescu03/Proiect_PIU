using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Targ_Auto;

namespace Proiect_PIU
{
    
    public class VanzatoriFisier
    {
        private string numeFisier;
        public VanzatoriFisier(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }
        public void AdaugaVanzator(Vanzator vanzator)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(vanzator.ConversieLaSir_PentruFisier());
            }
        }
        public List<Vanzator> GetVanzatori()
        {
            List<Vanzator> vanzatori = new List<Vanzator>();
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    vanzatori.Add(new Vanzator(linieFisier));
                }
            }
            return vanzatori;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Targ_Auto;

namespace Proiect_PIU
{
    class Registru
    {
        private List<Masina> masini;

        public Registru()
        {
            masini = new List<Masina>();
        }

        public void AdaugaMasina(Masina masina)
        {
            masini.Add(masina);
        }

        public void AfiseazaRegistru()
        {
            foreach (var masina in masini)
            {
                masina.Display();
                Console.WriteLine();
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

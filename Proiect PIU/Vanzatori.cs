using System;
using System.Collections.Generic;
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
    }
}

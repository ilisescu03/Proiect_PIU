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
        private string numeFisier;
        public Registru()
        {
            masini = new List<Masina>();
            tranzactii = new List<Tranzactie>();
        }
        public void AdauagaMasini(List<Masina>masini)
        {
            this.masini = masini;
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

        
        public List<Masina> GetRegistru()
        {
            return masini;
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

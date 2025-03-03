using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Targ_Auto
{
    class Masina
    {
        string numeVanzator;
        string numeCumparator;
        string marca;
        string model;
        int anFabricatie;
        string culoare;
        string[] optiuni;
        int ziTranzactie;
        int lunaTranzactie;
        int anTranzactie;
        string dataTranzactie;
        float pret;

        public Masina(string _numeVanzator, string _numeCumparator, string _marca, string _model, int _anFabricatie, string _culoare, string[] _optiuni, string _dataTranzactie, float _pret)
        {
            numeVanzator = _numeVanzator;
            numeCumparator = _numeCumparator;
            marca = _marca;
            model = _model;
            anFabricatie = _anFabricatie;
            culoare = _culoare;
            optiuni = _optiuni;
            dataTranzactie = _dataTranzactie;
            pret = _pret;

            var sep = dataTranzactie.Split('.');
            if (sep.Length == 3)
            {
                ziTranzactie = int.Parse(sep[0]);
                lunaTranzactie = int.Parse(sep[1]);
                anTranzactie = int.Parse(sep[2]);
            }
            else
            {
                ziTranzactie = 0;
                lunaTranzactie = 0;
                anTranzactie = 0;
                Console.Write("Extragerea datei tranzactie a esuat!");
            }
        }
        public void Display()
        {
            Console.WriteLine("Nume vanzator: " + numeVanzator);
            Console.WriteLine("Nume cumparator: " + numeCumparator);
            Console.WriteLine("Marca: " + marca);
            Console.WriteLine("Model: " + model);
            Console.WriteLine("An fabricatie: " + anFabricatie);
            Console.WriteLine("Culoare: " + culoare);
            Console.WriteLine("Optiuni: ");
            foreach (var optiune in optiuni)
            {
                Console.WriteLine(optiune);
            }
            Console.WriteLine("Data tranzactie: " + dataTranzactie);
            Console.WriteLine("Pret: " + pret);
        }
    }
}

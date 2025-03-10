using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Targ_Auto
{
    class Masina
    {
        static int ID=0;
        string numeVanzator;
        string numeCumparator;
        string marca;
        string model;
        int anFabricatie;
        string culoare;
        string[] optiuni;
        float pret;
        public Masina()
        {
            ID++;
        }
        public Masina(string _numeVanzator, string _numeCumparator)
        {
            numeVanzator = _numeVanzator;
            numeCumparator = _numeCumparator;
            ID++;
        }
        public Masina(string _numeVanzator, string _numeCumparator, string _marca, string _model, int _anFabricatie, string _culoare, string[] _optiuni, float _pret)
        {
            numeVanzator = _numeVanzator;
            numeCumparator = _numeCumparator;
            marca = _marca;
            model = _model;
            anFabricatie = _anFabricatie;
            culoare = _culoare;
            optiuni = _optiuni;
           
            pret = _pret;
            ID++;
            
        }
        public void Display()
        {
            Console.WriteLine("ID: " + ID);
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
            Console.WriteLine("Pret: " + pret);
        }
        public void Read()
        {
            Console.WriteLine("Marca:");
            marca=Console.ReadLine();
            Console.WriteLine("Model:");
            model = Console.ReadLine();
            Console.WriteLine("An fabricatie:");
            anFabricatie = int.Parse(Console.ReadLine());
            Console.WriteLine("Culoare:");
            culoare = Console.ReadLine();
            Console.WriteLine("Nr optiuni:");
            int n= int.Parse(Console.ReadLine());
            Console.WriteLine("Optiunile:");
            optiuni = new string[n];
            for (int i=0;i<n;i++)
            {
                optiuni[i] = Console.ReadLine();
            }
            Console.WriteLine("Pret:");
            pret = float.Parse(Console.ReadLine());
        }
        public string GetMarca()
        {
            return marca;
        }
    }
}

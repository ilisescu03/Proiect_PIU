using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Targ_Auto
{
    public enum Culoare
    {
        Rosu,
        Alb,
        Negru,
        Albastru,
        Verde,
        Galben,
        Gri,
        Maro,
        Mov,
        Roz
    }
    
    public class Masina
    {
        static int ID=0;
        string numeVanzator;
        string numeCumparator;
        string marca;
        string model;
        int anFabricatie;
        Culoare culoare;
        ArrayList optiuni;
        float pret;
        public Masina()
        {
            ID++;
            optiuni = new ArrayList();
        }
        public Masina(string numeFisier)
        {
            string[] date = numeFisier.Split(';');
            if (date.Length != 8) return;
            numeVanzator = date[0];
            numeCumparator = date[1];
            marca = date[2];
            model = date[3];
            anFabricatie = int.Parse(date[4]);
            culoare = (Culoare)Enum.Parse(typeof(Culoare), date[5], true);
            optiuni = new ArrayList(date[6].Split(',').Select(o => o.Trim()).ToList());

            pret = float.Parse(date[7]);
        }
        public Masina(string _numeVanzator, string _numeCumparator)
        {
            numeVanzator = _numeVanzator;
            numeCumparator = _numeCumparator;
            optiuni = new ArrayList();
            ID++;
        }
        public Masina(string _numeVanzator, string _numeCumparator, string _marca, string _model, int _anFabricatie, Culoare _culoare, ArrayList _optiuni, float _pret)
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
            Console.WriteLine("Optiuni: " + string.Join(", ", optiuni.Cast<string>()));

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
            culoare = (Culoare)Enum.Parse(typeof(Culoare), Console.ReadLine(), true);
            Console.WriteLine("Optiunile:");
            optiuni = new ArrayList(Console.ReadLine().Split(',').Select(o => o.Trim()).ToList());


            Console.WriteLine("Pret:");
            pret = float.Parse(Console.ReadLine());
        }
        public string GetMarca()
        {
            return marca;
        }
        public string GetModel()
        {
            return model;
        }
        public Culoare GetCuloare()
        {
            return culoare;
        }
        public int GetAnFabricatie()
        {
            return anFabricatie;
        }
        public float GetPret()
        {
            return pret;
        }
        public ArrayList GetOptiuni()
        {
            return optiuni;
        }
        public string ConversieLaSir_PentruFisier()
        {
            return $"{numeVanzator};{numeCumparator};{marca};{model};{anFabricatie};{culoare};{string.Join(",", optiuni.Cast<string>())};{pret}";
        }
    }
}

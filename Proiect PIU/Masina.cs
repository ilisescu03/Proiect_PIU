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
        int ID;
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
            
            optiuni = new ArrayList();
        }
        public Masina(string numeFisier)
        {
            string[] date = numeFisier.Split(';');
            if (date.Length != 9) return;
            ID = Int32.Parse(date[0]);
            numeVanzator = date[1];
            numeCumparator = date[2];
            marca = date[3];
            model = date[4];
            anFabricatie = int.Parse(date[5]);
            culoare = (Culoare)Enum.Parse(typeof(Culoare), date[6], true);
            optiuni = new ArrayList(date[7].Split(',').Select(o => o.Trim()).ToList());

            pret = float.Parse(date[8]);
        }
        public Masina(string _numeVanzator, string _numeCumparator)
        {
            numeVanzator = _numeVanzator;
            numeCumparator = _numeCumparator;
            optiuni = new ArrayList();
         
        }
        public Masina(int _ID, string _numeVanzator, string _numeCumparator, string _marca, string _model, int _anFabricatie, Culoare _culoare, ArrayList _optiuni, float _pret)
        {
            ID = _ID;
            numeVanzator = _numeVanzator;
            numeCumparator = _numeCumparator;
            marca = _marca;
            model = _model;
            anFabricatie = _anFabricatie;
            culoare = _culoare;
            optiuni = _optiuni;
           
            pret = _pret;
          
            
        }
        public string Serialize()
        {
            return $"{ID}|{numeVanzator}|{numeCumparator}|{marca}|{model}|{anFabricatie}|{culoare}|{string.Join(",", optiuni.Cast<string>())}|{pret}";
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
        public int GetID()
        {
            return ID;
        }
        public ArrayList GetOptiuni()
        {
            return optiuni;
        }
        public void SetVanzator(string text)
        {
            numeVanzator = text;
        }
        public void SetCumparator(string text)
        {
            numeCumparator = text;
        }
        public string GetVanzator()
        {
            return numeVanzator;
        }
        public string GetCumparator()
        {
            return numeCumparator;
        }
        public string Print()
        {
            return $"ID: {ID}\n Vanzator: {numeVanzator}\n Cumparator: {numeCumparator}\n Marca: {marca}\n Model: {model}\n An: {anFabricatie}\n Culoare: {culoare}\n Optiuni: {string.Join(", ", optiuni.Cast<string>())}, Pret: {pret}";
        }
        public string ConversieLaSir_PentruFisier()
        {
            return $"{ID};{numeVanzator};{numeCumparator};{marca};{model};{anFabricatie};{culoare};{string.Join(",", optiuni.Cast<string>())};{pret}";
        }
    }
}

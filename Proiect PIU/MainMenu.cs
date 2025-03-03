using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Targ_Auto;

namespace Proiect_PIU
{
    static class MainMenu
    {
        static void Main(string[] args)
        {
            Vanzator vanzator = new Vanzator("Ilisescu"," Adrian", "Str. Unirii, bl. 4, ap.10", 0723456789,"ilici75@gmail.com",50421);
            vanzator.Display();
            Console.WriteLine("");
            Cumparator cumparator = new Cumparator("Vasilescu", "Gheorghe", "Str. Mihai Viteazu, bl. 2, ap. 5", 0723456789, "vasilescu33@gmail.com", 30421);
            cumparator.Display();
            Console.WriteLine("");
            Tranzactie tranzactie = new Tranzactie(234543, 2000, cumparator, vanzator, "24.02.2025");
            tranzactie.Display();
            Console.WriteLine("");
            Masina masina = new Masina(vanzator.get_nume()+' '+vanzator.get_prenume(), cumparator.get_nume() + ' ' + cumparator.get_prenume(), "Opel", "Astra G Caravan", 2002, "alb", new string[] { "aer conditionat", "Nu bate", "Nu troncane" }, tranzactie.get_dataTranzactie(), tranzactie.get_suma());
            masina.Display();
            Console.WriteLine("");

        }
    }
}

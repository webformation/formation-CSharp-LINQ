using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            String nomCherche=null;
            var Liste = from p in dc.Person
                        where p.FirstName == nomCherche
                        select new { p.FirstName, p.LastName };
         nomCherche = "Martin";
           foreach (var x in Liste)
            {
                Console.WriteLine(String.Format("{0} {1}", x.FirstName, x.LastName)); 
            }
            var nb = Liste.Count();
            Console.WriteLine(String.Format("Il y a {0} {1}",nb, nomCherche));
            var Decompte = from p in dc.Person
                           group p by p.FirstName into Prenom
                           where Prenom.Count() < 10
                           orderby Prenom.Count()
                           select Prenom;
            Console.WriteLine("------------ Prenoms avec moins de 10 occurences --------------");
            foreach (var g in Decompte)
            {
                Console.WriteLine(g.Key + " " + g.Count());
            }
        }

    }
}

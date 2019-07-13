using System;
using System.Collections.Generic;
using System.Linq;

namespace memoire
{
    class Program
    {
        static void Main(string[] args)
        {
          List<String> annuaire = new List<String>() { "Décembre", "Novembre" };
            annuaire.Add("Janvier");
            annuaire.Add("Février");
            annuaire.Add("Mars");
            var sousliste = annuaire.Select(x => x);
            foreach (var x in sousliste)
            {
                Console.WriteLine(x);
            }
            List<Personne> annuaire2 = new List<Personne>() {
                new Personne("Jean"),
                new Personne("Marie")
            };
             var sousliste2 = annuaire2.Select(x => x.nom).Last();
            var sousliste3 = from p in annuaire2
                             select new { p.nom,p.prenom};
           sousliste3 = annuaire2.Select(x => new { x.nom, x.prenom });


        valretour retour(Personne p)
            {
            valretour v = new valretour();
            v.nom = p.nom;
            v.prenom = p.prenom;
                return v; 
            }
            var sousliste4 = annuaire2.Select(retour);
            
            int age = 20;
            foreach (var x in sousliste4)
            {
                Console.WriteLine(x.nom);
            };
        }
    }
    class Personne
    {
        public string nom;
        public string prenom= "";
        public int age = 20;
        public Personne(String nom) { this.nom = nom; }
    }
    class valretour
    {
        public String nom;
        public String prenom;
    }
}

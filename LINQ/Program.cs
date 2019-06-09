using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static String répertoire = ".";
        static String filtre = "*";
        static void Main(string[] args)
        {
            var fichiers = from f in Directory.GetFiles(répertoire, filtre, SearchOption.AllDirectories)
                           select f;
            foreach (var f in fichiers) Console.WriteLine(f);
            Console.WriteLine("-------------- Filtre .exe ----------------");
            filtre = "*.exe";
            fichiers = from f in Directory.GetFiles(répertoire, filtre, SearchOption.AllDirectories)
                      select f;
            foreach (var f in fichiers) Console.WriteLine(f);
        }

    }
}

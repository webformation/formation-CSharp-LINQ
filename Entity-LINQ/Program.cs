using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            ADVENTUREWORKS2012Entities e1 = new ADVENTUREWORKS2012Entities();
            var Liste = from p in e1.Person
                        where p.FirstName == "Martin"
                        select new { p.FirstName, p.LastName };
            foreach (var x in Liste)
            {
                Console.WriteLine(String.Format("{0} {1}", x.FirstName, x.LastName));
            }
        }
    }
}

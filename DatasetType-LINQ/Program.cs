using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            NORTHWNDDataSetTableAdapters.EmployeesTableAdapter ta = new NORTHWNDDataSetTableAdapters.EmployeesTableAdapter();
            NORTHWNDDataSet ds = new NORTHWNDDataSet();
            NORTHWNDDataSet.EmployeesDataTable dt = new NORTHWNDDataSet.EmployeesDataTable();
            ta.Fill(dt);

            var q1 = from emp in dt
                    where emp.FirstName.StartsWith("M")
                    select new { nom = emp.LastName }; 
            foreach (var s in q1)
            {
                Console.WriteLine(s.nom);
            }
            SalarieDataContext db = new SalarieDataContext();

            var q2 = from emp in db.Employees
                     where emp.FirstName.StartsWith("M")
                     select emp;
            foreach (var s in q2)
            {
                Console.WriteLine(s.FirstName);
            }
            var q3 = from emp in db.Employees
                     select new XElement("Employe",
                         new XElement("Nom",emp.LastName),
                         new XElement("Prénom",emp.FirstName),
                         new XElement("DateNaissance",emp.BirthDate));
            XElement racine = new XElement("Employes", q3);
            Console.WriteLine(racine.ToString());

            var q4 = from emp in racine.Elements("Employe")
                     where emp.Element("Prénom").Value.StartsWith("N")
                     select emp.Element("Nom").Value;
            foreach (var s in q4)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }
    }
}

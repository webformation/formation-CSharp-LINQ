

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

delegate bool Requete(string s);

namespace IntroductionLINQ_objet
{
    public partial class Form1 : Form
    {
        String répertoire = ".";
        String filtre = "*";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            var fichiers = from f in Directory.GetFiles(répertoire, filtre, SearchOption.AllDirectories)
                           select f ;
            foreach (string f in fichiers) {
                listView1.Items.Add(f);
            }
            label1.Text = "Nombre de fichiers " + fichiers.Count().ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var fichiers = from f in Directory.GetFiles(répertoire, filtre, SearchOption.AllDirectories)
                           where f.Contains("exe")
                           select f;
            listView1.Clear();
            foreach (string f in fichiers)
            {
                listView1.Items.Add(f);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {           
            if (checkBox2.Checked)
            {            
                var fichiers = Directory.GetFiles(répertoire, filtre, SearchOption.AllDirectories)
                    .Where(f => f.Contains("exe"));
                listView1.initialise(fichiers.ToList());
            }
            else {
                var fichiers = from f in Directory.GetFiles(répertoire, filtre, SearchOption.AllDirectories)
                               select f;
                listView1.initialise(fichiers.ToList());
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fichiers = from f in Directory.GetFiles(répertoire, filtre, SearchOption.AllDirectories)
                           orderby f descending
                           select f;
            listView1.initialise(fichiers.ToList());
        }

    }
    static class extension
    {
        static public void initialise(this ListView lv, List<string> ls)
        {
            lv.Clear();
            foreach (string f in ls)
            {
                lv.Items.Add(f);
            }
        }
    }
}

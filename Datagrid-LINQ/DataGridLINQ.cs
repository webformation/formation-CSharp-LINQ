using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataGridLINQ
{
    public partial class Feuille : Form
    {
        EmployeeDataContext EmpDC = new EmployeeDataContext();

        public Feuille()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var q = from emp in EmpDC.Employees
                    select emp;
            textBox2.Text = q.ToString();
            employeeBindingSource.DataSource = q;
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmpDC.SubmitChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var q = from emp in EmpDC.Employees
                    where emp.Nom.StartsWith(textBox1.Text)
                    select emp;
            textBox2.Text = q.ToString();
            employeeBindingSource.DataSource = q;
            dataGridView1.Refresh();

            var q1 = from emp in EmpDC.Employees
                    select emp;
            var q2 = from s in q1
                     where s.Nom.StartsWith(textBox1.Text)
                    select s;
            textBox3.Text = q2.ToString();

        }


    }
}

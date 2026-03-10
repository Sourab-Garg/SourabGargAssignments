using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private DataClasses1DataContext db;
        public Form1()
        {
            InitializeComponent();
            db = new DataClasses1DataContext();
        }
        private void LoadEmployees()
        {
            //dataGridView1.DataSource = db.Employees.ToList();
            dataGridView1.DataSource = db.sp_GetEmployees().ToList(); 
        }
        private void ClearFields()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        private void RefreshDataContext()
        {
            db?.Dispose();
            db = new DataClasses1DataContext();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Name is required");
                return;
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Dept is required");
                return;
            }
            var emp = new Employee
            {
                Name = textBox2.Text,
                Department = textBox3.Text,
                Salary = decimal.TryParse(textBox4.Text, out var s) ? s : 0
            };
            db.Employees.InsertOnSubmit(emp);
            db.SubmitChanges();
            RefreshDataContext();
            LoadEmployees();
            ClearFields();
        }

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (dataGridView1.CurrentRow == null) return;
        //    var emp = dataGridView1.CurrentRow.DataBoundItem as Employee;
        //    if (emp == null) return;
        //    textBox1.Text = emp.Id.ToString();
        //    textBox2.Text = emp.Name.ToString();
        //    textBox3.Text = emp.Department.ToString();
        //    textBox4.Text = emp.Salary.ToString();

        //}
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!int.TryParse(dataGridView1.CurrentRow?.Cells[0].Value?.ToString(), out var id))
                return;

            var result = db.sp_GetEmployeeById(id);   
            var emp = result.FirstOrDefault();
            if (emp != null)
            {
                textBox1.Text = emp.Id.ToString(); 
                textBox2.Text = emp.Name;
                textBox3.Text = emp.Department;
                textBox4.Text = emp.Salary.ToString();
            }
            else
            {
                ClearFields();  
            }
        }

        private void button3_Click(object sender, EventArgs e) 
        {
            if (!int.TryParse(textBox1.Text, out var id))
            {
                MessageBox.Show("select and employee to update");
                return;
            }

            var emp = db.Employees.SingleOrDefault(x => x.Id == id);
            if (emp == null)
            {
                MessageBox.Show("Employee not found");
                return;
            }
            emp.Name = textBox2.Text;
            emp.Department = textBox3.Text;
            emp.Salary = decimal.TryParse(textBox4.Text, out var s) ? s : emp.Salary;

            db.SubmitChanges(); 
            LoadEmployees();
            ClearFields();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out var id))
            {
                MessageBox.Show("select and employee to update");
                return;
            }
            var emp = db.Employees.SingleOrDefault(x => x.Id == id);
            if (emp == null)
            {
                MessageBox.Show("Employee not found");
                return;
            }

            if (MessageBox.Show("delete this employee?", "confirm",MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                db.Employees.DeleteOnSubmit(emp);
                db.SubmitChanges();
                LoadEmployees();
                ClearFields();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
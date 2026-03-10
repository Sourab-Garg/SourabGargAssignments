namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class Employee
        {
            int sal;
            int bonus;

            public void totalSalary(int sal1, int bonus1)
            {
                sal = sal1;
                bonus = bonus1;
                int total = sal + bonus;
                MessageBox.Show($"Total Salary is {total}");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.totalSalary(Convert.ToInt32(textBox1.Text),
                Convert.ToInt32(textBox2.Text));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

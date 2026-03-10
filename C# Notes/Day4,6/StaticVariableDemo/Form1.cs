namespace StaticVariableDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class JointAccount
        {
            static int bal = 10000;
            public void withDraw(int amt)
            {
                bal -= amt;
                MessageBox.Show($"Renaming balance: {bal}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JointAccount account = new JointAccount();
            account.withDraw(Convert.ToInt32(textBox1.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JointAccount account = new JointAccount();
            account.withDraw(Convert.ToInt32(textBox1.Text));

        }

    }
}

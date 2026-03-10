namespace ExceptionDemoW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class SBIBankException : ApplicationException
        {
            public SBIBankException(string message) : base(message)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(textBox1.Text);
                int b = Convert.ToInt32(textBox2.Text);
                int c = a / b;
                textBox3.Text = c.ToString();
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show("Dont give zero as divisor: " + ex.Message);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Dont enter chars and specical keywords:" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some other exception occured: " + ex.Message);
            }
            finally
            {
                MessageBox.Show("I am still alive..");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int age = Convert.ToInt32(textBox4.Text);
                if(age < 18)
                {
                    throw new SBIBankException("Age is less than 18.");
                   }
                else
                {
                    MessageBox.Show("click this link to open an account :\"+\"https://www.icicibank.com/\"");
                }
            }
            catch (SBIBankException exx)
            {
                MessageBox.Show($"{exx.Message}");
            }
        }
    }
}

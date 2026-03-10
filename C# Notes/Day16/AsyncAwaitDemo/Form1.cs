namespace AsyncAwaitDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Before Delay";
            //Thread.Sleep(1000);
            await Task.Delay(5000);
            label2.Text = "After Delay";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = "Button 2 Clicked";
        }
    }
}

namespace InheritanceDemoDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //global section area
        class Father
        {
            public void maruthicar()
            {
                MessageBox.Show(" Maruthi Car");
            }
        }
        class Son : Father
        {
            public void BMWCar()
            {
                MessageBox.Show(" BMW Car");
            }
        }
        class GrandSon : Son
        {
            public void AudiCar()
            {
                MessageBox.Show(" Audi Car");
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            GrandSon obj1 = new GrandSon();
            obj1.maruthicar();
            obj1.BMWCar();
            obj1.AudiCar();
        }
    }
}

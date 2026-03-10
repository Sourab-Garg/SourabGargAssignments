namespace GarbageCollectorDemoW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class A
        {
            public A()
            {
                MessageBox.Show("Creating A");
            }
            ~A()
            {

                for (int i = 0; i < 1000; i++) ;

                Console.WriteLine("Destroying A");
                MessageBox.Show("destroying A");
            }
        }
        class B : A
        {
            public B()
            {
                MessageBox.Show("Creating B");
            }
            ~B()
            {
                for (int i = 0; i < 1000; i++) ;
                Console.WriteLine("Destroying B");
                MessageBox.Show("destroying B");
            }
        }
        class C : B
        {
            public C()
            {
                MessageBox.Show("Creating C");
            }
            ~C()
            {
                for (int i = 0; i < 1000; i++) ;

                Console.WriteLine("Destroying C");
                MessageBox.Show("destroying C");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CreateObject();

            GC.Collect();

            GC.WaitForPendingFinalizers();
        }

        private void CreateObject()
        {
            C cc = new C();
        }
    }
}

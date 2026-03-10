namespace GarbageCollectorDemo2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class GarbageCollection : IDisposable
        {
            public void dosomething()
            {
                MessageBox.Show("performing usual tasks");
            }

            public void Dispose()
            { 
                GC.SuppressFinalize(this);
                MessageBox.Show("disposing object via Dispose()");
            }

            ~GarbageCollection()
            { 
                MessageBox.Show("destroying object via Finalizer/Destructor");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            GarbageCollection obj1 = new GarbageCollection();
            obj1.dosomething();
            obj1.Dispose(); 


            CreateTemporaryObject();


            MessageBox.Show("Starting GC Collection...");

            GC.Collect(); 
            GC.WaitForPendingFinalizers();  
            GC.Collect(); 

            MessageBox.Show("GC operations complete.");
        }

        private void CreateTemporaryObject()
        {
            GarbageCollection obj2 = new GarbageCollection();
            obj2.dosomething();
        }
    }
}
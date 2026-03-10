namespace AbstractClassDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public abstract class Polygon2
        {
            public abstract void area(int side);
        }
        public abstract class Polygon
        {
            public void testfunction()
            {
                MessageBox.Show("***************************");
            }
            public abstract void area(int x, int y);

        }

        class Triangle : Polygon
        {
            public override void area(int x, int y)
            {
                MessageBox.Show($"The area of triangle is {0.5 * x * y}");
            }
        }
        class square : Polygon2
        {
            public override void area(int side)
            {
                MessageBox.Show($"The area of square is {side * side}");
            }
        }
        interface A
        {
            void area(int s);
            //int a;//not possible 
            //  public int age { set; get; } properties can be defined 


        }
        interface B : A
        {
            void area(int x, int y);
        }

        //class newshape : Polygon, polygon2
        //{
        //    public override void area(int x, int y)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
        class Rectangle : Polygon
        {
            public override void area(int x, int y)
            {
                MessageBox.Show($"The area of rectangle is {x * y}");
            }
        }

        class newshape : B
        {
            public void area(int s)
            {
                MessageBox.Show($"The area of new shape when single paramter :{s * s}");
            }

            public void area(int x, int y)
            {
                MessageBox.Show($"The area of new shape when two paramter :{x * y}");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Polygon obj;//=new Polygon() not possible becasue partial methods are there 
                        //so i am taking only referecne it is a car without petrol 

            obj = new Triangle();
            obj.area(12, 4);
            obj = new Rectangle();
            obj.area(12, 5);
            obj.testfunction();
            Polygon2 obj2;
            obj2 = new square();
            obj2.area(4);
            A aobj;
            B bobj;
            aobj = new newshape();
            aobj.area(12);
            bobj = new newshape();
            bobj.area(12, 5);


        }
    }
}
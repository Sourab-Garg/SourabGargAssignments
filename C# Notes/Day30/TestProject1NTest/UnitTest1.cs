using AirthmeticOpsAndAnother;

namespace TestProject1NTest
{
    [TestFixture]
    public class Tests
    {
        Calculate cal = null;
        [SetUp]
        public void Setup()
        {
            cal = new Calculate();
        }

        [Test]

        [TestCase(15, 20, 35)]
        [TestCase(20, 20, 40)]

        public void Addition(int x, int y, int expected)
        {
            //arrange 
            int actual;
            //int expected = 40;
            //act 
            actual = cal.Addition(x, y);
            //assert
            Assert.AreEqual(expected, actual);
            Assert.Pass();
        }
        [TestCase(20, 15)]
        [TestCase(20, 20)]

        public void Substraction(int x, int y)
        {
            //arrange 
            int actual;
            int expected = 0;
            //act 
            actual = cal.substract(x, y);
            //assert
            Assert.AreEqual(expected, actual);
            Assert.Pass();
        }

    }
}
using Baitapn17;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N17.NunitTest
{
    [TestFixture]
    public class Bai2Test
    {
        private Bai2 _b2;
        [SetUp]
        public void SetUp()
        {
            int[] numbers = { 10, 3, 7, 5 };
            _b2 = new Bai2(numbers);
        }
        [Test]
        [TestCase(1, 2, 3)]
        [TestCase(1, 2, 3, 4)]
        [TestCase(1, 2, 3, 4)]
        public void Khonghople(int a, int b, int c, int d = 0)
        {
            Assert.Throws<ArgumentException>(() => new Bai2(new int[] { a, b, c, d }));
        }

      
        [Test]
        [TestCase(10, 3, 7, 5, ExpectedResult = 7)] 
        [TestCase(5, 5, 5, 5, ExpectedResult = 0)]   
        [TestCase(-1, -3, -2, -4, ExpectedResult = 3)] 
        [TestCase(-1, 2, 3, -4, ExpectedResult = 7)]  
        [TestCase(1000, 5000, 3000, 2000, ExpectedResult = 4000)] 
        [TestCase(1, 2, 3, 4, ExpectedResult = 3)]      
        [TestCase(0, 2, 4, 6, ExpectedResult = 6)]    
        public int Hople(int a, int b, int c, int d)
        {
            return _b2.HieuCuaMang();
        }
    }
}

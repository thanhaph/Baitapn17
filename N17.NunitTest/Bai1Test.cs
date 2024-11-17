using Baitapn17;

namespace N17.NunitTest
{
    [TestFixture]
    public class Tests
    {
        private Bai1 _b1;
        [SetUp]
        public void Setup()
        {
        _b1 = new Bai1();
        }

        [Test]
        
        [TestCase(new int[] { 0, 4, 5, 6, 18, 10, 9, 21, 25, 40 }, ExpectedResult = new int[] { 0, 4, 6, 18, 10, 40 })]
        [TestCase(new int[] { 1, 3, 5, 7, 9 }, ExpectedResult = new int[] { })]
        [TestCase(new int[] { }, ExpectedResult = new int[] { })]
        [TestCase(new int[] { -2, -4, -6 }, ExpectedResult = new int[] { -2, -4, -6 })]
        [TestCase(new int[] { -1, -3, -5 }, ExpectedResult = new int[] { })]
        [TestCase(new int[] { 0, 2, 4, 6, 8, 10 }, ExpectedResult = new int[] { 0, 2, 4, 6, 8, 10 })]
        public int[] GetEvenNumbers_ValidInput(int[] numbers)
        {
            return _b1.GetSochiahetcho2(numbers).ToArray();
        }
    }
}
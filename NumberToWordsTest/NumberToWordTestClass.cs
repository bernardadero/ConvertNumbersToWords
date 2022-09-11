using NUnit.Framework;
using Exercise01;
using System.Numerics;

namespace NumberToWordsUnitTests
{
    public class NumberToWordTestClass
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

        }
        [Test]
        public void Test_Negatives()
        {
            // arrange
            int number = -1;
            string expected = "negative one";

            // act
            string actual = number.ToWords();

            // assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test_Integer_Zero()
        {
            // arrange
            int number = 0;
            string expected = "zero";

            // act
            string actual = number.ToWords();

            // assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test_Tens_12()
        {
            // arrange
            int number = 12;
            string expected = "twelve";

            // act
            string actual = number.ToWords();

            // assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test_Thousands_1001()
        {
            // arrange
            int number = 1001;
            string expected = "one thousand and one";

            // act
            string actual = number.ToWords();

            // assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test_BigNumber()
        {
            // arrange
            BigInteger number = BigInteger.Parse("1000000000");
            string expected = "one billion";

            // act
            string actual = number.ToWords();

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
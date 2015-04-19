using System;
using NUnit.Framework;

namespace CodeKata.Test
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void AddEmptyString()
        {
            var result = Calculator.Add("");
            Assert.AreEqual(0, result);
        }

        [TestCase("1", 1)]
        [TestCase("2", 2)]
        public void AddOneNumberString(string numbers, int expected)
        {
            int result = Calculator.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestCase("1,2", 3)]
        [TestCase("2,2", 4)]
        public void AddTwoNumberString_ReturnSum(string numbers, int expected)
        {
            int result = Calculator.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestCase("1,2,3", 6)]
        public void AddMultiple_ReturnSum(string numbers, int expected)
        {
            int result = Calculator.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_NoNumberStringWithDelimeter_ReturnZero()
        {
            int result = Calculator.Add("//,\n");
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Add_OneNumberStringWithDelimeterLine_ReturnNumber()
        {
            int result = Calculator.Add("//,\n1");

            Assert.AreEqual(1,result);
        }

        [Test]
        public void AddTwoNumberWithAlternativeDelimeter_ReturnSum()
        {
            int result = Calculator.Add("//,\n1,2");
            Assert.AreEqual(3, result);
            Console.Write(result);
        }

        [Test]
        public void Add_IgnoredThousand_ReturnNumber()
        {
            int result = Calculator.Add("2+1001");
            
            Assert.AreEqual(2, result);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using IntegrationTesting;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Test_CalculateVar1_NormalValues()
        {
            float a = 10;
            float b = 2;
            float c = 6;

            Calculator calculator = new Calculator(a, b);

            Assert.AreEqual(a, calculator.GetA());
            Assert.AreEqual(b, calculator.GetB());
            Assert.AreEqual(c, calculator.CalculateVar1());
        }

        [TestMethod]
        public void Test_CalculateVar1_ZeroValues()
        {
            float a = 0;
            float b = 0;
            float c = 0;

            Calculator calculator = new Calculator(a, b);

            Assert.AreEqual(a, calculator.GetA());
            Assert.AreEqual(b, calculator.GetB());
            Assert.AreEqual(c, calculator.CalculateVar1());
        }

        [TestMethod]
        public void Test_CalculateVar1_NegativeValues()
        {
            float a = -5;
            float b = 3;
            float c = -14;

            Calculator calculator = new Calculator(a, b);

            Assert.AreEqual(a, calculator.GetA());
            Assert.AreEqual(b, calculator.GetB());
            Assert.AreEqual(c, calculator.CalculateVar1());
        }

        [TestMethod]
        public void Test_CalculateVar1_NormalValues_SetNewA()
        {
            float a = 10;
            float b = 13;
            float c = -155;

            Calculator calculator = new Calculator(a, b);

            calculator.SetA(14);

            Assert.AreEqual(b, calculator.GetB());
            Assert.AreEqual(c, calculator.CalculateVar1());
        }



        [TestMethod]
        public void Test_CalculateVar8_NormalValues()
        {
            float a = 8;
            float b = 3;
            float c = 40;

            Calculator calculator = new Calculator(a, b);

            Assert.AreEqual(a, calculator.GetA());
            Assert.AreEqual(b, calculator.GetB());
            Assert.AreEqual(c, calculator.CalculateVar8());
        }

        [TestMethod]
        public void Test_CalculateVar8_ZeroValues()
        {
            float a = 0;
            float b = 0;
            float c = 0;

            Calculator calculator = new Calculator(a, b);

            Assert.AreEqual(a, calculator.GetA());
            Assert.AreEqual(b, calculator.GetB());
            Assert.AreEqual(c, calculator.CalculateVar8());
        }

        [TestMethod]
        public void Test_CalculateVar8_NegaiveValues()
        {
            float a = -3;
            float b = 3;
            float c = -15;

            Calculator calculator = new Calculator(a, b);

            Assert.AreEqual(a, calculator.GetA());
            Assert.AreEqual(b, calculator.GetB());
            Assert.AreEqual(c, calculator.CalculateVar8());
        }
    }
}

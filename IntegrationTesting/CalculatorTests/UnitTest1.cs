using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using IntegrationTesting;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        [DataTestMethod]
        [DataRow(10, 2)]
        [DataRow(0, 0)]
        [DataRow(-5, 3)]
        public void Test_ComputeC_WithDifferentValues(float a, float b)
        {
            Calculator calculator = new Calculator(a, b);
            Assert.AreEqual(a, calculator.GetA());
            Assert.AreEqual(b, calculator.GetB());

            var expectedResult = a - Math.Pow(b, 2);
            var actualResult = calculator.Calculate();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [DataTestMethod]
        [DataRow(5, 9)]
        [DataRow(0, 7)]
        [DataRow(2, -4)]
        public void Test_ComputeC_WithErrorValues(float a, float b)
        {
            Calculator calculator = new Calculator(a, b);
            Assert.AreEqual(a, calculator.GetA());
            Assert.AreEqual(b, calculator.GetB());

            calculator.SetB(b + 2);

            var expectedResult = a - Math.Pow(b, 2);
            var actualResult = calculator.Calculate();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}

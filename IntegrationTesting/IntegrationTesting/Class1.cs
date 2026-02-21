using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTesting
{
    public class Calculator
    {
        private float a, b;

        public Calculator(float initA, float initB)
        {
            this.a = initA;
            this.b = initB;
        }

        public double CalculateVar1()
        {
            return a - Math.Pow(b, 2);
        }

        public double CalculateVar8()
        {
            return (a * (Math.Pow(b, 2) + 16)) / 5;
        }

        public void SetA(float value)
        {
            a = value;
        }

        public void SetB(float value)
        {
            b = value;
        }

        public float GetA()
        {
            return a;
        }

        public float GetB()
        {
            return b;
        }
    }
}

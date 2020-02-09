using System;
using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.SUM
{
    public static class SumSolution
    {
        public static int Sum(int x, int y)
        {
            if (x < 0 || x > 100)
            {
                throw new ArgumentException("Please make sure x is between 0 and 100");
            }

            if (y < 0 || y > 100)
            {
                throw new ArgumentException("Please make sure y is between 0 and 100");
            }

            return x + y;
        }
    }
}




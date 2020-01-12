using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace ProjectEulerTests
{
    public class Euler002Iterative
    {
        private readonly ITestOutputHelper output;

        public Euler002Iterative(ITestOutputHelper output)
        {
            this.output = output;
        }
        private static Dictionary<long, long> calculatedFibonacciNumbers = new Dictionary<long, long>()
        {
            [0] = 0,
            [1] = 1,
            [2] = 1
        };

        [Theory]
        [InlineData(10, 10)]
        [InlineData(400, 188)]
        [InlineData(4000000, 4613732)]
        [InlineData(3, 2)]
        [InlineData(11, 10)]
        [InlineData(12, 10)]
        public void SumEvenFibonacciNumbers(long upTo, long expected)
        {
            long n = 0;
            long x = 0;
            long actual = 0;
            while ((x = GetNthFibonacciNumber(n)) < upTo)
            {
                if (x % 2 == 0)
                {
                    actual += x;
                }
                n++;
            }

            Assert.Equal(expected, actual);
        }

        private static long GetNthFibonacciNumber(long n)
        {
            if (calculatedFibonacciNumbers.ContainsKey(n))
            {
                return calculatedFibonacciNumbers[n];
            }
            else
            {
                var f = calculatedFibonacciNumbers[n - 1] + calculatedFibonacciNumbers[n - 2];
                calculatedFibonacciNumbers[n] = f;
                return f;
            }
        }

    }
}
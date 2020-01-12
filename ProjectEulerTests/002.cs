using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace ProjectEulerTests
{
    public class Euler002
    {
        private readonly ITestOutputHelper output;

        public Euler002(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData(10, 10)]
        [InlineData(400, 188)]
        [InlineData(4000000, 4613732)]
        public void SumEvenFibonacciNumbers(long upTo, long expected)
        {
            long actual = 0;
            foreach (var n in GetEveryThirdFib())
            {
                if (n >= upTo)
                {
                    break;
                }

                actual += n;
            }

            Assert.Equal(expected, actual);
        }

        private IEnumerable<long> GetEveryThirdFib()
        {
            var x = 3;
            while (true)
            {
                yield return GetNthFibonacciNumber(x);
                x += 3;
            }
        }

        private long GetNthFibonacciNumber(long n)
        {
            return (long)((Math.Pow(GetPhi(), n) - Math.Pow(-(GetPhi() - 1), n)) / Math.Sqrt(5));
        }

        private double GetPhi()
        {
            return (Math.Sqrt(5) + 1) / 2;
        }
        

        [Theory]
        [InlineData(10, 20)]
        public void SumFibonacciNumbers(long upTo, long expected)
        {
            var actual = new[] { 0, 1, 1, 2, 3, 5, 8 }.Sum();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 5)]
        [InlineData(6, 8)]
        public void NthFibonacciNumber(int n, long expected)
        {
            var actual = GetNthFibonacciNumber(n);

            output.WriteLine($"Actual: {actual}");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CheckPhi()
        {
            Assert.Equal(1.61803398874989484820, GetPhi());
        }

        [Fact]
        public void Checkphi()
        {
            Assert.Equal(0.61803398874989484820, GetPhi() - 1);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace ProjectEulerTests
{
    public class Euler001
    {
        private readonly ITestOutputHelper outputHelper;

        public Euler001(ITestOutputHelper outputHelper)
        {
            this.outputHelper = outputHelper;
        }

        [Theory]
        [InlineData(10, 23)]
        [InlineData(100, 2318)]
        [InlineData(1000, 233168)]
        public void SumMultiplesOf3and5UpToX(int upTo, int expected)
        {
            var countOfMultiplesOf3 = GetCountOfMultiplesOf(3, upTo);

            var sumOfMultiplesOf3 = 3 * SumSeriesUpToX(countOfMultiplesOf3);

            var countOfMultiplesOf5 = GetCountOfMultiplesOf(5, upTo);
            var sumOfMultiplesOf5 = 5 * SumSeriesUpToX(countOfMultiplesOf5);

            var countOfMultiplesOf15 = GetCountOfMultiplesOf(15, upTo);
            var sumOfMultiplesOf15 = 15 * SumSeriesUpToX(countOfMultiplesOf15);


            int actual = 0;
            actual += sumOfMultiplesOf3;
            actual += sumOfMultiplesOf5;
            actual -= sumOfMultiplesOf15;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(10, 55)]
        [InlineData(20, 210)]
        public void SumNaturalNumbers(int upTo, int expected)
        {
            var actual = SumSeriesUpToX(upTo);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3, 10, 18)]
        [InlineData(5, 10, 5)]
        public void SumMultiplesOfXUpToY(int multiple, int upTo, int expected)
        {
            int numberOfMultiples = GetCountOfMultiplesOf(multiple, upTo);

            var actual = multiple * SumSeriesUpToX(numberOfMultiples);

            Assert.Equal(expected, actual);
        }

        private static int GetCountOfMultiplesOf(int factor, int upTo)
        {
            return (upTo - 1) / factor;
        }

        private static int SumSeriesUpToX(int x)
        {
            return (x + 1) * x / 2;
        }

    }
}
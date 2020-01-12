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
        [InlineData(2, 0)]
        [InlineData(10, 23)]
        [InlineData(9, 14)]
        [InlineData(100, 2318)]
        [InlineData(1000, 233168)]
        public void SumMultiplesOf3and5UpToX(long upTo, int expected)
        {
            var countOfMultiplesOf3 = GetCountOfMultiplesOf(3, upTo);

            var sumOfMultiplesOf3 = 3 * SumSeriesUpToX(countOfMultiplesOf3);

            var countOfMultiplesOf5 = GetCountOfMultiplesOf(5, upTo);
            var sumOfMultiplesOf5 = 5 * SumSeriesUpToX(countOfMultiplesOf5);

            var countOfMultiplesOf15 = GetCountOfMultiplesOf(15, upTo);
            var sumOfMultiplesOf15 = 15 * SumSeriesUpToX(countOfMultiplesOf15);

            long actual = 0;
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
            var numberOfMultiples = GetCountOfMultiplesOf(multiple, upTo);

            var actual = multiple * SumSeriesUpToX(numberOfMultiples);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(9, 3, 2)]
        [InlineData(10, 3, 3)]
        public void CountMulitplesOf(int upTo, int multiple, int expected)
        {
            var actual = GetCountOfMultiplesOf(multiple, upTo);
            Assert.Equal(expected, actual);
        }

        private static long GetCountOfMultiplesOf(int factor, long upTo)
        {
            return (upTo - 1) / factor;
        }

        private static long SumSeriesUpToX(long x)
        {
            return (x + 1) * x / 2;
        }

    }
}
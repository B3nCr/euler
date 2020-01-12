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
        [InlineData(2, 10, 100, 23, 2318)]
        public void TestName(int cases, params int[] input)
        {
            var inputs = GetInputs(cases, input);
            var expectations = GetExpectations(cases, input);

            outputHelper.WriteLine(string.Join(",", inputs));

            var actual = new List<int>();

            foreach (int testcase in inputs.Select(x => x ))
            {
                int tally = 0;

                for (int i = 1; i < testcase; i++)
                {
                    if (i % 3 == 0 || i % 5 == 0)
                    {
                        tally += i;
                    }
                }

                actual.Add(tally);
            }

            Assert.Equal(expectations, actual);
        }

        private List<int> GetExpectations(int cases, int[] input)
        {
            return new List<int>(input.Skip(cases).Take(cases));
        }

        private List<int> GetInputs(int cases, int[] input)
        {
            return new List<int>(input.Take(cases));
        }
    }
}
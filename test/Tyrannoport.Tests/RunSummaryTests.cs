using System.Linq;
using Tyrannoport.Models;
using Xunit;

namespace Tyrannoport.Tests
{
    public sealed class RunSummaryTests
    {
        [Fact]
        public void SummaryWithoutTestsHasCorrectOutcome()
        {
        //Given
            var summary = new RunSummary(Enumerable.Empty<TestOutcome>());
        
        //When
            var outcome = summary.OverallOutcome;
        
        //Then
            Assert.Equal(TestOutcome.Passed, outcome);
        }

        [Theory]
        [InlineData(new [] { TestOutcome.Passed }, TestOutcome.Passed)]
        [InlineData(new [] { TestOutcome.Failed }, TestOutcome.Failed)]
        [InlineData(new [] { TestOutcome.NotExecuted }, TestOutcome.NotExecuted)]
        [InlineData(new [] { TestOutcome.Other }, TestOutcome.Other)]
        [InlineData(new [] { TestOutcome.Passed, TestOutcome.Other }, TestOutcome.Other)]
        [InlineData(new [] { TestOutcome.Passed, TestOutcome.Failed }, TestOutcome.Failed)]
        [InlineData(new [] { TestOutcome.Passed, TestOutcome.NotExecuted, TestOutcome.Failed }, TestOutcome.Failed)]
        [InlineData(new [] { TestOutcome.Passed, TestOutcome.NotExecuted }, TestOutcome.NotExecuted)]
        public void SummaryAggregatesOutcomes(TestOutcome[] given, TestOutcome expected)
        {
            var summary = new RunSummary(given);
            Assert.Equal(expected, summary.OverallOutcome);
        }
    }
}
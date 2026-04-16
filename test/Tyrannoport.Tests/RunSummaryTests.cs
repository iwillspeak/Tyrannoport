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

        [Fact]
        public void ExcludeSkippedFromPassRateCalculatesPercentageWithoutSkipped()
        {
        //Given
            var outcomes = new[]
            {
                TestOutcome.Passed,
                TestOutcome.Passed,
                TestOutcome.NotExecuted,
                TestOutcome.NotExecuted,
            };

        //When
            var summary = new RunSummary(outcomes, excludeSkippedFromPassRate: true);

        //Then
            Assert.Equal(4, summary.TotalTests);
            Assert.Equal(2, summary.Passed);
            Assert.Equal(2, summary.Skipped);
            Assert.Equal(100.0, summary.PassPercentage, 2);
        }

        [Fact]
        public void DefaultPassRateIncludesSkipped()
        {
        //Given
            var outcomes = new[]
            {
                TestOutcome.Passed,
                TestOutcome.Passed,
                TestOutcome.NotExecuted,
                TestOutcome.NotExecuted,
            };

        //When
            var summary = new RunSummary(outcomes);

        //Then
            Assert.Equal(4, summary.TotalTests);
            Assert.Equal(2, summary.Passed);
            Assert.Equal(2, summary.Skipped);
            Assert.Equal(50.0, summary.PassPercentage, 2);
        }

        [Fact]
        public void ExcludeSkippedSkippedPercentageStillUsesTotalTests()
        {
        //Given
            var outcomes = new[]
            {
                TestOutcome.Passed,
                TestOutcome.Passed,
                TestOutcome.NotExecuted,
                TestOutcome.NotExecuted,
            };

        //When
            var summary = new RunSummary(outcomes, excludeSkippedFromPassRate: true);

        //Then
            Assert.Equal(50.0, summary.SkippedPercentage, 2);
        }

        [Fact]
        public void ExcludeSkippedAllSkippedReturnsZeroPercentages()
        {
        //Given
            var outcomes = new[]
            {
                TestOutcome.NotExecuted,
                TestOutcome.NotExecuted,
            };

        //When
            var summary = new RunSummary(outcomes, excludeSkippedFromPassRate: true);

        //Then
            Assert.Equal(0.0, summary.PassPercentage, 2);
            Assert.Equal(0.0, summary.FailedPercentage, 2);
            Assert.Equal(0.0, summary.OtherPercentage, 2);
        }
    }
}
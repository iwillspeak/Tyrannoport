using System;
using Tyrannoport.Trx.Models;
using Xunit;

namespace Tyrannoport.Tests
{
    public sealed class ReportContextTests
    {
        private readonly TestRun _run;

        public ReportContextTests()
        {
            _run = new TestRun
            {
                Times = new Times
                {
                    Creation = "2021-07-15T18:47:19.5612408+01:00",
                    Queuing = "2021-07-15T18:47:19.5612409+01:00",
                    Start = "2021-07-15T18:47:18.5970852+01:00",
                    Finish = "2021-07-15T18:47:19.5688108+01:00",
                },
                ResultSummary = new ResultSummary
                {

                    Counters = new Counters
                    {
                        Total = 9,
                        Executed = 8,
                        Passed = 3,
                        Failed = 2,
                        Error = 1,
                        Timeout = 0,
                        Aborted = 1,
                        Inconclusive = 1,
                        PassedButRunAborted = 0,
                        NotRunnable = 0,
                        NotExecuted = 1,
                        Disconnected = 0,
                        Warning = 0,
                        Completed = 0,
                        InProgress = 0,
                        Pending = 0,
                    }
                }
            };
        }
        
        [Fact]
        public void ExposesTestTimingsWithDeltas()
        {
        
        //When
            var report = new ReportContext(_run);

        //Then
            Assert.Equal(new DateTimeOffset(637619716395612408, new TimeSpan(1, 0, 0)), report.Timings.Creation);
            Assert.Equal(new DateTimeOffset(637619716395612409, new TimeSpan(1, 0, 0)), report.Timings.Queuing);
            Assert.Equal(new DateTimeOffset(637619716385970852, new TimeSpan(1, 0, 0)), report.Timings.Start);
            Assert.Equal(new DateTimeOffset(637619716395688108, new TimeSpan(1, 0, 0)), report.Timings.Finish);
            

            Assert.Equal(TimeSpan.Parse("00:00:00.9717256"), report.Timings.Duration);
        }

        [Fact]
        public void RunSummaryhasCorrectCounts()
        {

        //When

            var report = new ReportContext(_run);
        
        //Then
            Assert.Equal(9, report.Summary.TotalTests);
            Assert.Equal(3, report.Summary.Passed);
            Assert.Equal(3, report.Summary.Failed);
            Assert.Equal(1, report.Summary.Skipped);
            Assert.Equal(2, report.Summary.Other);
            Assert.Equal(33.33, report.Summary.PassPercentage, 2);
            Assert.Equal(33.33, report.Summary.FailedPercentage, 2);
            Assert.Equal(11.11, report.Summary.SkippedPercentage, 2);
            Assert.Equal(22.22, report.Summary.OtherPercentage, 2);
        }
    }   
}
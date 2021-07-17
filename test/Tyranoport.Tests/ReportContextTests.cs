using System;
using Tyranoport.Trx.Models;
using Xunit;

namespace Tyranoport.Tests
{
    public sealed class ReportContextTests
    {
        [Fact]
        public void ExposesTestTimingsWithDeltas()
        {
        //Given
            var run = new TestRun
            {
                Times = new Times
                {
                    Creation = "2021-07-15T18:47:19.5612408+01:00",
                    Queuing = "2021-07-15T18:47:19.5612409+01:00",
                    Start = "2021-07-15T18:47:18.5970852+01:00",
                    Finish = "2021-07-15T18:47:19.5688108+01:00",
                }
            };
        
        //When
            var report = new ReportContext(run);

        //Then
            Assert.Equal(new DateTimeOffset(637619716395612408, new TimeSpan(1, 0, 0)), report.Timings.Creation);
            Assert.Equal(new DateTimeOffset(637619716395612409, new TimeSpan(1, 0, 0)), report.Timings.Queuing);
            Assert.Equal(new DateTimeOffset(637619716385970852, new TimeSpan(1, 0, 0)), report.Timings.Start);
            Assert.Equal(new DateTimeOffset(637619716395688108, new TimeSpan(1, 0, 0)), report.Timings.Finish);
            

            Assert.Equal(TimeSpan.Parse("00:00:00.9717256"), report.Timings.Duration);
        }
    }   
}
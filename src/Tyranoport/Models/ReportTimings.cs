using System;
using DotLiquid;
using Tyranoport.Trx.Models;

namespace Tyranoport.Models
{
    internal class ReportTimings : Drop
    {
        public ReportTimings(Times times)
        {
            Creation = DateTimeOffset.Parse(times.Creation);
            Queuing = DateTimeOffset.Parse(times.Queuing);
            Start = DateTimeOffset.Parse(times.Start);
            Finish = DateTimeOffset.Parse(times.Finish);
        }

        public DateTimeOffset Creation { get; }
        public DateTimeOffset Queuing { get; }
        public DateTimeOffset Start { get; }
        public DateTimeOffset Finish { get; }
        public TimeSpan Duration => Finish - Start;
    }
}
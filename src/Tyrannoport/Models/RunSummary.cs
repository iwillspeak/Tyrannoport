using System.Collections.Generic;
using DotLiquid;
using Tyrannoport.Trx.Models;

namespace Tyrannoport.Models
{
    internal class RunSummary : Drop
    {
        private ResultSummary _summary;

        public RunSummary(ResultSummary resultSummary)
        {
            _summary = resultSummary;
        }

        public int TotalTests => _summary.Counters.Total;

        public int Passed => _summary.Counters.Passed;
        public int Failed => _summary.Counters.Failed + _summary.Counters.Error;
        public int Skipped => _summary.Counters.Total - _summary.Counters.Executed;
        public int Other => _summary.Counters.Aborted + _summary.Counters.Inconclusive + _summary.Counters.NotRunnable + _summary.Counters.Timeout;

        public double PassPercentage => ((double)Passed / TotalTests) * 100;
        public double FailedPercentage => ((double)Failed / TotalTests) * 100;
        public double SkippedPercentage => ((double)Skipped / TotalTests) * 100;
        public double OtherPercentage => ((double)Other / TotalTests) * 100;
    }
}
using System.Collections.Generic;
using DotLiquid;
using Tyrannoport.Trx.Models;

namespace Tyrannoport.Models
{
    internal class RunSummary : Drop
    {
        public RunSummary(ResultSummary summary)
        {
            TotalTests = summary.Counters.Total; 
            Passed = summary.Counters.Passed;
            Failed = summary.Counters.Failed + summary.Counters.Error;
            Skipped = summary.Counters.Total - summary.Counters.Executed;
            Other = summary.Counters.Aborted + summary.Counters.Inconclusive + summary.Counters.NotRunnable + summary.Counters.Timeout;
        }

        public RunSummary(IEnumerable<TestOutcome> outcomes)
        {
            foreach (var outcome in outcomes)
            {
                TotalTests++;
                switch (outcome)
                {
                case TestOutcome.Passed:
                    Passed++;
                    break;

                case TestOutcome.NotExecuted:
                    Skipped++;
                    break;

                case TestOutcome.Failed:
                    Failed++;
                    break;

                default:
                    Other++;
                    break;
                }
            }
        }

        public int TotalTests { get; }
        public int Passed { get; }
        public int Failed { get; }
        public int Skipped { get; }
        public int Other { get; }

        public double PassPercentage => ((double)Passed / TotalTests) * 100;
        public double FailedPercentage => ((double)Failed / TotalTests) * 100;
        public double SkippedPercentage => ((double)Skipped / TotalTests) * 100;
        public double OtherPercentage => ((double)Other / TotalTests) * 100;

        public TestOutcome OverallOutcome
        {
            get
            {
                if (Failed > 0)
                {
                    return TestOutcome.Failed;
                }
                else if (Skipped > 0)
                {
                    return TestOutcome.NotExecuted;
                }
                else if (Other > 0)
                {
                    return TestOutcome.Other;
                }
                return TestOutcome.Passed;
            }
        }
    }
}
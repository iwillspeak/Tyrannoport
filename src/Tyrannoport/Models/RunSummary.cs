using System.Collections.Generic;
using DotLiquid;
using Tyrannoport.Trx.Models;

namespace Tyrannoport.Models
{
    internal class RunSummary : Drop
    {
        private readonly bool _excludeSkippedFromPassRate;

        public RunSummary(ResultSummary summary, bool excludeSkippedFromPassRate = false)
        {
            _excludeSkippedFromPassRate = excludeSkippedFromPassRate;
            TotalTests = summary.Counters.Total; 
            Passed = summary.Counters.Passed;
            Failed = summary.Counters.Failed + summary.Counters.Error;
            Skipped = summary.Counters.Total - summary.Counters.Executed;
            Other = summary.Counters.Aborted + summary.Counters.Inconclusive + summary.Counters.NotRunnable + summary.Counters.Timeout;
        }

        public RunSummary(IEnumerable<TestOutcome> outcomes, bool excludeSkippedFromPassRate = false)
        {
            _excludeSkippedFromPassRate = excludeSkippedFromPassRate;
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

        private int EffectiveTotalTests => _excludeSkippedFromPassRate ? (TotalTests - Skipped) : TotalTests;

        public double PassPercentage => EffectiveTotalTests == 0 ? 0.0 : ((double)Passed / EffectiveTotalTests) * 100;
        public double FailedPercentage => EffectiveTotalTests == 0 ? 0.0 : ((double)Failed / EffectiveTotalTests) * 100;
        public double SkippedPercentage => TotalTests == 0 ? 0.0 : ((double)Skipped / TotalTests) * 100;
        public double OtherPercentage => EffectiveTotalTests == 0 ? 0.0 : ((double)Other / EffectiveTotalTests) * 100;

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
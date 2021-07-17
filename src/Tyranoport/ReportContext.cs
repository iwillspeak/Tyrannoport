using Tyranoport.Models;
using Tyranoport.Trx.Models;

namespace Tyranoport
{
    /// <summary>
    ///   Wrapper around a Trx <see cref="Trx.Models.TestRun" /> to provide
    ///   cached and efficient access to the underlying test data for our views.
    /// </summary>
    internal sealed class ReportContext
    {
        public ReportContext(TestRun testRun)
        {
            Timings = new ReportTimings(testRun.Times);
            Summary = new RunSummary(testRun.ResultSummary);
        }

        public ReportTimings Timings { get; }

        public RunSummary Summary { get; }
    }
}
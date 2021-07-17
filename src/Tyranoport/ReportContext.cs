using System;
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
        }

        public ReportTimings Timings { get; }
    }
}
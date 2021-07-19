using System.Collections.Generic;
using System.Linq;
using Tyrannoport.Models;
using Tyrannoport.Trx.Models;

namespace Tyrannoport
{
    /// <summary>
    ///   Wrapper around a Trx <see cref="Trx.Models.TestRun" /> to provide
    ///   cached and efficient access to the underlying test data for our views.
    /// </summary>
    internal sealed class ReportContext
    {
        private readonly IDictionary<string, UnitTestResult> _executions;
        private readonly ILookup<string, UnitTest>? _testsByClass;

        public ReportContext(TestRun testRun)
        {
            Timings = new ReportTimings(testRun.Times);
            Summary = new RunSummary(testRun.ResultSummary);
            Title = testRun.Name ?? "Unit Tests";
            Output = new GlobalOutput(testRun.ResultSummary);

            _executions = testRun.Results?.UnitTestResult?.ToDictionary(x => x.ExecutionId) ??
                new Dictionary<string, UnitTestResult>();
            _testsByClass = testRun.TestDefinitions?.UnitTest?.ToLookup(x => x.TestMethod.ClassName);
        }

        public ReportTimings Timings { get; }

        public RunSummary Summary { get; }

        public string Title { get; }
        public GlobalOutput Output { get; }

        public IEnumerable<TestGrouping> TestGroups => _testsByClass
            ?.Select(g => new TestGrouping(g.Key, g.Select(t => new Test(t, _executions[t.Execution.Id])))) ??
            Enumerable.Empty<TestGrouping>(); 
    }
}
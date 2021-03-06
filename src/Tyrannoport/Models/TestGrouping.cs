using System.Collections.Generic;
using System.Linq;
using DotLiquid;
using Tyrannoport.Models;

namespace Tyrannoport.Models
{
    internal class TestGrouping : Drop
    {
        public TestGrouping(string key, IEnumerable<Test> tests)
        {
            Key = key;
            Tests = tests.ToArray();
            Summary = new RunSummary(Tests.Select(t => t.Outcome));
        }

        public string Key { get; }

        public string Slug => $"{Key}.html";
        
        public IReadOnlyCollection<Test> Tests { get; }

        public RunSummary Summary { get; }
    }
}
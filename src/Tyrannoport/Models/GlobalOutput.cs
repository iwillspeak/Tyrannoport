using System.Collections.Generic;
using DotLiquid;
using Tyrannoport.Trx.Models;

namespace Tyrannoport.Models
{
    internal class GlobalOutput : Drop
    {
        private ResultSummary _resultSummary;

        public GlobalOutput(ResultSummary resultSummary)
        {
            _resultSummary = resultSummary;
            var messages = new List<SummaryMessage>();
            if (resultSummary.RunInfos?.RunInfo != null)
            {
                foreach (var run in resultSummary.RunInfos.RunInfo)
                {
                    messages.Add(new SummaryMessage(run));
                }
            }
            Messages = messages;
        }

        public string? StdOut => _resultSummary?.Output?.StdOut;

        public IReadOnlyCollection<SummaryMessage> Messages { get; } 
    }
}
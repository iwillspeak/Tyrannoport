using System;
using DotLiquid;
using Tyrannoport.Trx.Models;

namespace Tyrannoport.Models
{
    internal class SummaryMessage : Drop
    {
        private readonly RunInfo _run;

        public SummaryMessage(RunInfo run)
        {
            _run = run;
        }

        public string Type => _run.Outcome;

        public string Content => _run.Text;

        public DateTimeOffset Timestamp => DateTimeOffset.Parse(_run.Timestamp);

        public string Computer => _run.ComputerName;
    }
}
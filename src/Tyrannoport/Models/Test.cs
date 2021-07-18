using System;
using DotLiquid;
using Tyrannoport.Trx.Models;

namespace Tyrannoport.Models
{
    internal class Test : Drop
    {
        private readonly UnitTest _test;
        private readonly UnitTestResult _result;

        public Test(UnitTest test, UnitTestResult unitTestResult)
        {
            _test = test;
            _result = unitTestResult;
            if (_result.Output?.ErrorInfo != null)
            {
                Error = new TestError(_result.Output.ErrorInfo);
            }
        }

        public string Slug => _test.Id;

        public string Name => _test.Name;

        public string MethodName => _test.TestMethod.Name;

        public string ClassName => _test.TestMethod.ClassName;

        public string ComputerName => _result.ComputerName;

        public DateTimeOffset Start => DateTimeOffset.Parse(_result.StartTime);

        public DateTimeOffset End => DateTimeOffset.Parse(_result.EndTime);

        public string TestType => _result.TestType;

        public string Adapter => _test.TestMethod.AdapterTypeName;

        public string CodeBase => _test.TestMethod.CodeBase;

        public TimeSpan Duration => TimeSpan.Parse(_result.Duration);

        public string Outcome => _result.Outcome;

        public string? Output => _result.Output?.StdOut;

        public TestError? Error { get; }
    }
}
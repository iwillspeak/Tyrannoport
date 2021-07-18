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
        }

        public string Slug => _test.Id;

        public string Name => _test.Name;

        public string MethodName => _test.TestMethod.Name;

        public string ClassName => _test.TestMethod.ClassName;

        public string Outcome => _result.Outcome;
    }
}
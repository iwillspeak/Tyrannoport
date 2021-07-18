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
    }
}
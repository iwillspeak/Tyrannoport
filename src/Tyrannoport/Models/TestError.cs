using DotLiquid;
using Tyrannoport.Trx.Models;

namespace Tyrannoport.Models
{
    internal class TestError : Drop
    {
        private readonly ErrorInfo _errorInfo;

        public TestError(ErrorInfo errorInfo)
        {
            _errorInfo = errorInfo;
        }

        public string Message => _errorInfo.Message;

        public string? StackTrace => _errorInfo.StackTrace;
    }
}
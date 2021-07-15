using System;
using Xunit;

namespace Tyranoport.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Console.WriteLine("Stuff");
        }

        [Fact]
        public void TesFailtName()
        {
            Assert.Equal(1, 100);
        }
    }
}

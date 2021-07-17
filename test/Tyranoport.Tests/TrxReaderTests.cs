using System;
using System.Collections.Generic;
using System.IO;
using Tyranoport.Trx;
using Xunit;

namespace Tyranoport.Tests
{
    public class TrxReaderTests
    {
        [Theory]
        [MemberData(nameof(AllTrxFixtures))]
        public void ReadExampleFixtures(string path)
        {
        //When
            var testResult = TrxReader.LoadPath(path);
        
        //Then
            Assert.NotNull(testResult);
        }

        public static IEnumerable<object[]> AllTrxFixtures()
        {
            foreach (var file in Directory.GetFiles("fixture_data", "*.trx"))
            {
                yield return new object[] { file };
            }
        }
    }
}

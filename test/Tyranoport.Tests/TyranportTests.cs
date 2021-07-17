using System;
using System.IO;
using System.Linq;
using Xunit;

namespace Tyranoport.Tests
{
    public sealed class TyranoportTests
    {
        [Fact]
        public void ReportWithoutTestsThrows()
        {
        // When
            var argException = Assert.ThrowsAny<ArgumentException>(() =>
            {
                new Tyranoport(Enumerable.Empty<string>());
            });

        // Then
            Assert.Equal("paths", argException.ParamName);
        }

        [Fact]
        public void ReportWithInvalidPathsThrows()
        {
        //When
            var ex = Assert.ThrowsAny<FileNotFoundException>(() =>
            {
                new Tyranoport(new [] { 
                    "invalid_path.trx"
                });
            });
        
        //Then
           var fileName = Path.GetFileName(ex.FileName);
           Assert.Equal("invalid_path.trx", fileName); 
        }
    }
}
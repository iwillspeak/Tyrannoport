using System.IO;
using Xunit;

namespace Tyrannoport.Tests
{
    public sealed class ScopedOutputProviderTests
    {
        [Fact]
        public void ScopedProviderAddsBasePath()
        {
        //Given
            var innerProvider = new TestOutputProvider();
            var scoped = new ScopedOutputProvider(innerProvider, "test/path");
        
        //When
            using (var stream = scoped.OpenPath("some/test/path"))
            using (var sw = new StreamWriter(stream))
            {
                sw.WriteAsync("<test content>");
            }
        
        //Then
            Assert.Collection(innerProvider.Outputs,
                x => {
                    Assert.Equal("test/path/some/test/path", x.Key);
                    Assert.Equal("<test content>", x.Value);
                });
        }
    }
}
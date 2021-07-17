using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DotLiquid;
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

        [Fact]
        public async Task TestRender()
        {
        //Given
            var report = new Tyranoport(
                new TestTemplateRepository
                {
                    ["overview"] = Template.Parse("{{ summary.pass_percentage | round: 2 }}%")
                },
                new [] { Path.Join("fixture_data", "SimpleExample.trx") }
            );
            var testOutput = new TestOutputProvider();

        //When
            await report.RenderAsync(testOutput);
        
        //Then
            Assert.Collection(testOutput.Outputs,
                x =>
                {
                    Assert.Equal("SimpleExample.html", Path.GetFileName(x.Key));
                    Assert.Equal("50%", x.Value);
                });
        }
    }
}
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DotLiquid;
using Xunit;

namespace Tyrannoport.Tests
{
    public sealed class TyrannoportTests
    {
        [Fact]
        public void ReportWithoutTestsThrows()
        {
        // When
            var argException = Assert.ThrowsAny<ArgumentException>(() =>
            {
                new Tyrannoport(Enumerable.Empty<string>());
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
                new Tyrannoport(new [] { 
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
            var templateRepo = 
                new TestTemplateRepository
                {
                    ["overview"] = Template.Parse("{{ summary.pass_percentage | round: 2 }}%"),
                    ["class_details"] = Template.Parse("{{ class }}|{{ tests.size }}"),
                    ["output"] = Template.Parse("{{ output.messages.size }}|{{output.std_out.size}}"),
                };
            templateRepo.AddAsset("test/asset.js", "const foo = 'a-string';");
            var report = new Tyrannoport(
                templateRepo,
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
                },
                x =>
                {
                    Assert.Equal("SimpleExample_output.html", Path.GetFileName(x.Key));
                    Assert.Equal("1|656", x.Value);
                },
                x =>
                {
                    Assert.Equal("Tyrannoport.Tests.UnitTest1.html", Path.GetFileName(x.Key));
                    Assert.Equal("Tyrannoport.Tests.UnitTest1|2", x.Value);
                },
                x =>
                {
                    Assert.Equal("fixture_data/test/asset.js", x.Key);
                    Assert.Equal("const foo = 'a-string';", x.Value);
                });
        }
    }
}
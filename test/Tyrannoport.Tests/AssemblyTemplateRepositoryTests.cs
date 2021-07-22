using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tyrannoport.Tests
{
    public sealed class AssemblyTemplateRepositoryTests
    {
        [Fact]
        public async Task LoadWithInvalidTemplateNameThrowsException()
        {
        //Given
            var repo = new AssemblyTemplateRepository();
        
        //When
            var argEx = await Assert.ThrowsAnyAsync<ArgumentException>(() =>
                repo.LoadAsync("invalid_template_name"));
        
        //Then
            Assert.Equal("name", argEx.ParamName);
        }

        [Theory]
        [InlineData("overview")]
        [InlineData("class_details")]
        [InlineData("output")]
        public async Task LoadKnownTemplatesSucceeds(string name)
        {
        //Given
            var repo = new AssemblyTemplateRepository();

        //When
            var template = await repo.LoadAsync(name);
        
        //Then
            Assert.NotNull(template);
        }

        [Fact]
        public async Task DeploysExpectedAssets()
        {
        //Given
            var outputProvider = new TestOutputProvider();
            var repo = new AssemblyTemplateRepository();

        //When
            await repo.DeployAssetsAsync(outputProvider);
        
        //Then
            Assert.Collection(outputProvider.Outputs.OrderBy(o => o.Key),
                x => Assert.Equal("js/dark_mode.js", x.Key),
                x => Assert.Equal("js/grid_filter.js", x.Key));
        }
    }
}
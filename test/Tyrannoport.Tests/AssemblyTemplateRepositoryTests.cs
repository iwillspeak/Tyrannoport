using System;
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
        public async Task LoadKnownTemplatesSucceeds(string name)
        {
        //Given
            var repo = new AssemblyTemplateRepository();

        //When
            var template = await repo.LoadAsync(name);
        
        //Then
            Assert.NotNull(template);
        }
    }
}
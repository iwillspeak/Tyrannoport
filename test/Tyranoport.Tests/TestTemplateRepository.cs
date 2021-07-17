using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DotLiquid;

namespace Tyranoport.Tests
{
    internal sealed class TestTemplateRepository : ITemplateRepository
    {
        private readonly IDictionary<string, Template> _templates =
            new Dictionary<string, Template>();

        public void Add(string key, Template value) => _templates[key] = value;

        public Template this[string index]
        {
            get => _templates[index];
            set => Add(index, value);
        } 

        public Task<Template> LoadAsync(string name)
        {
            if (_templates.TryGetValue(name, out var template))
            {
                return Task.FromResult(template);
            }
            return Task.FromException<Template>(
                new FileNotFoundException($"Could not find file {name}", name));
        }
    }
}
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DotLiquid;

namespace Tyrannoport.Tests
{
    internal sealed class TestTemplateRepository : ITemplateRepository
    {
        private readonly IDictionary<string, Template> _templates =
            new Dictionary<string, Template>();

        private readonly IDictionary<string, string> _assets =
            new Dictionary<string, string>();

        public void Add(string key, Template value) => _templates[key] = value;

        public void AddAsset(string path, string asset) => _assets[path] = asset;

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

        public async Task DeployAssetsAsync(IOutputStreamProvider output)
        {
            foreach (var (path, asset) in _assets)
            {
                using var outputStream = output.OpenPath(path);
                using var sw = new StreamWriter(outputStream);
                await sw.WriteAsync(asset);
            }
        }
    }
}
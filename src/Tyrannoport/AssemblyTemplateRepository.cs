using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using DotLiquid;
using DotLiquid.FileSystems;

namespace Tyrannoport
{
    internal class AssemblyTemplateRepository : ITemplateRepository
    {
        private readonly Assembly _assembly;
        private readonly string _templateBasePath;
        private readonly EmbeddedFileSystem _fileSystem;

        public AssemblyTemplateRepository()
            : this(typeof(AssemblyTemplateRepository).Assembly)
        {}

        protected AssemblyTemplateRepository(Assembly assembly)
        {
            _assembly = assembly;
            _templateBasePath = $"{_assembly.GetName().Name}.templates";
            _fileSystem = new EmbeddedFileSystem(assembly, _templateBasePath);
        }

        public async Task DeployAssetsAsync(IOutputStreamProvider output)
        {
            var assetBasePath = $"{_assembly.GetName().Name}.assets.";
            foreach (var resource in _assembly.GetManifestResourceNames())
            {
                if (resource.StartsWith(assetBasePath))
                {
                    var assetExtension = Path.GetExtension(resource);
                    var assetPath = resource.Substring(assetBasePath.Length, resource.Length - assetBasePath.Length - assetExtension.Length);
                    assetPath = assetPath.Replace('.', Path.DirectorySeparatorChar);
                    assetPath = $"{assetPath}{assetExtension}";
                    using var resourceStream =_assembly.GetManifestResourceStream(resource)!;
                    using var assetStream = output.OpenPath(assetPath);
                    await resourceStream.CopyToAsync(assetStream);
                }
            }
        }

        public async Task<Template> LoadAsync(string name)
        {
            var resource = _assembly.GetManifestResourceStream(
                    $"{_templateBasePath}.{name}.liquid") ??
                throw new ArgumentException($"Invalid template name {name}", nameof(name));

            using var templateStream = new StreamReader(resource);
            var template = Template.Parse(await templateStream.ReadToEndAsync());

            template.Registers["file_system"] = _fileSystem;

            return template;
        }
    }
}
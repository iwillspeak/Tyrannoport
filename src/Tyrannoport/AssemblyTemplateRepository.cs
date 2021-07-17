using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using DotLiquid;

namespace Tyrannoport
{
    internal class AssemblyTemplateRepository : ITemplateRepository
    {
        private readonly Assembly _assembly;

        public AssemblyTemplateRepository()
            : this(typeof(AssemblyTemplateRepository).Assembly)
        {}

        protected AssemblyTemplateRepository(Assembly assembly)
        {
            _assembly = assembly;
        }

        public async Task<Template> LoadAsync(string name)
        {
            var resource = _assembly.GetManifestResourceStream(
                $"{_assembly.GetName().Name}.templates.{name}.liquid") ??
                throw new ArgumentException($"Invalid template name {name}", nameof(name));
            using var templateStream = new StreamReader(resource);
            return Template.Parse(await templateStream.ReadToEndAsync());
        }
    }
}
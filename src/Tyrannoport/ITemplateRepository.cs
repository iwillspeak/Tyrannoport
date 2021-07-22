using System.Threading.Tasks;
using DotLiquid;

namespace Tyrannoport
{
    /// <summary>Interface for loading parsed DotLiquid templates</summary>
    public interface ITemplateRepository
    {
        /// <summary>Load a named template</summary>
        /// <param name="name">The template name to load</param>
        Task<Template> LoadAsync(string name);

        /// <summary>Deploy any global assets required by the templates</summary>
        /// <param name="output">The output provider to write to</param>
        Task DeployAssetsAsync(IOutputStreamProvider output);
    }
}
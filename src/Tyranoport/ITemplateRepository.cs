using System.Threading.Tasks;
using DotLiquid;

namespace Tyranoport
{
    /// <summary>Interface for loading parsed DotLiquid templates</summary>
    public interface ITemplateRepository
    {
        /// <summary>Load a named template</summary>
        /// <param name="name">The template name to load</param>
        Task<Template> LoadAsync(string name);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tyranoport.Trx;
using Tyranoport.Trx.Models;

namespace Tyranoport
{
    /// <summary>
    ///   Tyranoport Workspace
    ///   <para>
    ///     This is the main entry point to report rendering. It is responsible
    ///     for holding the loaded TRX data, and traversing it to render the
    ///     report.
    ///   </para>
    /// </summary>
    public sealed class Tyranoport
    {
        private readonly IReadOnlyCollection<TestRun> _reports;

        /// <summary>Create a new Tyranport for the given paths.</summary>
        /// <param name="paths">
        ///  The paths to one or more TRX files to generate the report from.
        /// </param>
        public Tyranoport(IEnumerable<string> paths)
            : this(new AssemblyTemplateRepository(), paths)
        {
        }

        /// <summary>Create a new Tyranport for the given paths with custom resolvers.</summary>
        /// <param name="paths">
        ///   The paths to one or more TRX files to generate the report from.
        /// </param>
        /// <param name="templateRepository">
        ///   The repository to use for loading templates.
        /// </param> 
        public Tyranoport(ITemplateRepository templateRepository, IEnumerable<string> paths)
        {
            _reports = paths.Any() ?
                paths.Select(TrxReader.LoadPath).ToArray() :
                throw new ArgumentException("One or more paths are required", nameof(paths));
        }

        /// <summary>Render the report to chosen output path</summary>
        public Task RenderAsync()
        {
            // using var output = File.OpenWrite(outputPath);

            // template.Render(output, new RenderParameters(CultureInfo.InvariantCulture)
            // {
            //     LocalVariables = Hash.FromAnonymousObject(report),
            // });
            return Task.CompletedTask;
        }
    }
}
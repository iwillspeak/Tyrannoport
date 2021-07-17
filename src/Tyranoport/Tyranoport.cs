using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DotLiquid;
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
        private readonly IReadOnlyDictionary<string, TestRun> _runs;
        private readonly ITemplateRepository _templateRepository;

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
            _runs = paths.Any() ?
                paths.ToDictionary(p => p, TrxReader.LoadPath) :
                throw new ArgumentException("One or more paths are required", nameof(paths));
            _templateRepository = templateRepository;
        }

        /// <summary>Render the report to chosen output path</summary>
        public async Task RenderAsync()
        {
            foreach (var (path, run) in _runs)
            {
                var context = new ReportContext(run);
                await RenderRunAsync(path, context);
            }
        }

        private async Task RenderRunAsync(string path, ReportContext report)
        {
            // TODO: we should have the option to change the output location
            //       from the CLI.
            var overviewPath = Path.ChangeExtension(path, "html");
            using var output = File.OpenWrite(overviewPath);

            var template = await _templateRepository.LoadAsync("overview");

            template.Render(output, new RenderParameters(CultureInfo.InvariantCulture)
            {
                LocalVariables = Hash.FromAnonymousObject(new {
                    Timings = report.Timings,
                }),
            });
        }
    }
}
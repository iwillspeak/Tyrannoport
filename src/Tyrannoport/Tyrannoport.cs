using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DotLiquid;
using Tyrannoport.Trx;
using Tyrannoport.Trx.Models;

namespace Tyrannoport
{
    /// <summary>
    ///   Tyrannoport Workspace
    ///   <para>
    ///     This is the main entry point to report rendering. It is responsible
    ///     for holding the loaded TRX data, and traversing it to render the
    ///     report.
    ///   </para>
    /// </summary>
    public sealed class Tyrannoport
    {
        private readonly IReadOnlyDictionary<string, TestRun> _runs;
        private readonly ITemplateRepository _templateRepository;

        /// <summary>Create a new Tyranport for the given paths.</summary>
        /// <param name="paths">
        ///  The paths to one or more TRX files to generate the report from.
        /// </param>
        public Tyrannoport(IEnumerable<string> paths)
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
        public Tyrannoport(ITemplateRepository templateRepository, IEnumerable<string> paths)
        {
            _runs = paths.Any() ?
                paths.ToDictionary(p => p, TrxReader.LoadPath) :
                throw new ArgumentException("One or more paths are required", nameof(paths));
            _templateRepository = templateRepository;
        }

        /// <summary>Render the report the filesystem output.</summary>
        public Task RenderAsync() =>
            RenderAsync(new FileSystemOutputProvider());

        /// <summary>Render the report to chosen output</summary>
        /// <param name="outputProvider">The output provider to render to</param>
        public async Task RenderAsync(IOutputStreamProvider outputProvider)
        {
            foreach (var (path, run) in _runs)
            {
                var context = new ReportContext(run);
                await RenderOverviewAsync(path, context, outputProvider);
            }
        }

        private async Task RenderOverviewAsync(
            string path,
            ReportContext report,
            IOutputStreamProvider outputProvider)
        {
            // TODO: we should have the option to change the output location
            //       from the CLI.
            var overviewPath = Path.ChangeExtension(path, "html");

            using (var output = outputProvider.OpenPath(overviewPath))
            {
                var overviewTemplate = await _templateRepository.LoadAsync("overview");
                overviewTemplate.Render(output, new RenderParameters(CultureInfo.CurrentCulture)
                {
                    LocalVariables = Hash.FromAnonymousObject(new {
                        Timings = report.Timings,
                        Summary = report.Summary,
                        Tests = report.TestGroups,
                    }),
                });
            }

            var detailsTemplate = await _templateRepository.LoadAsync("class_details");
            foreach (var group in report.TestGroups)
            {
                using var output = outputProvider.OpenPath(
                    Path.Join(Path.GetDirectoryName(overviewPath), group.Slug));
                detailsTemplate.Render(output, new RenderParameters(CultureInfo.CurrentCulture)
                {
                    LocalVariables = Hash.FromAnonymousObject(new {
                        Class = group.Key,
                        Tests = group.Tests,
                    }),
                });
            }
        }
    }
}
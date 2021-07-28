using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Tyrannoport
{
    /// <summary>Tool runner for the Tyrannoport tool</summary>
    public sealed class TyrannoportRunner : Tool<TyrannoportSettings>
    {
        /// <summary>Create a new instance of the tool runner</summary>
        public TyrannoportRunner(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <summary>Run the tool against a single file path</summary>
        /// <param name="trxPath">The path to the input TRX file</param>
        /// <param name="settings">Tool settings for this operation</param>
        public void Run(FilePath trxPath, TyrannoportSettings settings)
        {
            Run(settings, GetArguments(trxPath));
        }

        private ProcessArgumentBuilder GetArguments(FilePath trxPath) =>
            new ProcessArgumentBuilder()
                .AppendQuoted(trxPath.FullPath);

        /// <summary>Returns an enumerator that yields the known tool names</summary>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            yield return "tyrannoport";
            yield return "tyrannoport.exe";
        }

        /// <summary>Returns the tyrannoport tool name</summary>
        protected override string GetToolName()
        {
            return "Tyrannoport";
        }
    }
}
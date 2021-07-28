using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;

namespace Cake.Tyrannoport
{
    /// <summary>Extension methods for calling Tyrannoport from Cake builds</summary>
    public static class TyrannoportCakeExtension
    {
        /// <summary>Generate a Tyrannoport report for each TRX file in
        /// <paramref ref="trxPaths" /></summary>
        /// <param name="context">The cake context for this method</param>
        /// <param name="trxPath">The TRX file path to generate a report for</param>
        [CakeMethodAlias]
        public static void Tyrannoport(this ICakeContext context, FilePath trxPath)
        {   
            Tyrannoport(context, trxPath, new TyrannoportSettings());
        }

        /// <summary>Generate a Tyrannoport report for each TRX file in
        /// <paramref ref="trxPaths" /></summary>
        /// <param name="context">The cake context for this method</param>
        /// <param name="trxPath">The TRX file path to generate a report for</param>
        /// <param name="settings">Tool settings for this operation</param>
        [CakeMethodAlias]
        public static void Tyrannoport(
            this ICakeContext context,
            FilePath trxPath,
            TyrannoportSettings settings)
        {   
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var runner = new TyrannoportRunner(
                context.FileSystem,
                context.Environment,
                context.ProcessRunner,
                context.Tools);
            runner.Run(trxPath, settings);
        }
    }
}
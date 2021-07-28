using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Tyrannoport
{
    /// <summary>Extension methods for calling Tyrannoport from Cake builds</summary>
    public static class TyrannoportCakeExtension
    {
        /// <summary>Generate a Tyrannoport report for each TRX file in
        /// <paramref ref="trxPaths" /></summary>
        /// <param name="context">The cake context for this method</param>
        /// <param name="trxPaths">The TRX file paths to generate reports for</param>
        [CakeMethodAlias]
        public static void Tyrannoport(this ICakeContext context, params string[] trxPaths)
        {
            var t = Task.Run(() => TyrannoportAsync(context, trxPaths));
            t.GetAwaiter().GetResult();
        }

        /// <summary>Generate a Tyrannoport report for each TRX file in
        /// <paramref ref="trxPaths" /></summary>
        /// <param name="context">The cake context for this method</param>
        /// <param name="trxPaths">The TRX file paths to generate reports for</param>
        [CakeMethodAlias]
        public static async Task TyrannoportAsync(this ICakeContext context, params string[] trxPaths)
        {
            await new global::Tyrannoport.Tyrannoport(trxPaths).RenderAsync();
        }
    }
}
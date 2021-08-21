using System.Reflection;

namespace Tyrannoport
{
    internal sealed class Version
    {
        public static string VersionString
        {
            get
            {
                var assm = Assembly.GetExecutingAssembly();
                var versionAttr = assm.GetCustomAttribute<AssemblyInformationalVersionAttribute>();

                if (versionAttr != null)
                {
                    return versionAttr.InformationalVersion;
                }

                return assm.GetName().Version!.ToString();
            }
        }
    }
}

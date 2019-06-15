using Contracts;
using System.ComponentModel.Composition;

namespace AppUtilImp_2
{
    // så klasserne bruger samme IAppUtil så man ikke instantierer flere forskellige
    [Export(typeof(IAppUtil))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class AppUtilImp : IAppUtil
    {
        public  string Name { get; set; }
        public string GetName()
        {
            return Name;
        }

        public string MyAddString(string str1, string str2)
        {
            return str1 + str2;
        }
    }
}

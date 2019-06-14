using Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUtilImp_1
{
    // så klasserne bruger samme IAppUtil så man ikke instantierer flere forskellige
    [Export(typeof(IAppUtil))]
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

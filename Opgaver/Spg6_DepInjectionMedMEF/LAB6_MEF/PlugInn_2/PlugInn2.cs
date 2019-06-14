using Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugInn_2
{
    // Implementes på en lidt anden måde så den
    // importerer IAppUtil som en property så den ikke behøver init IAppUtil
    [Export(typeof(IDllContract))]
    public class PlugInn2 : IDllContract
    {
        IAppUtil appUtil;

        public void Init(IAppUtil util)
        {
           appUtil = util;
        }

        public bool Run()
        {
            Console.WriteLine($"Hey man {appUtil.GetName()}, lets also print some strings.. {appUtil.MyAddString("hey ", "you..")}");
            return true;
        }

        public void TearDown()
        {
            appUtil = null;
        }
    }
}

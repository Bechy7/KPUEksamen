using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace PlugInn_1
{

    [Export(typeof(IDllContract))]
    public class PlugInn1 : IDllContract
    {
        IAppUtil appUtil;

        public void Init(IAppUtil util)
        {
            appUtil = util;
        }

        public bool Run()
        {
            Console.WriteLine($"Hey man {appUtil.GetName()}");
            return true;
        }

        public void TearDown()
        {
            appUtil = null;
        }
    }
}

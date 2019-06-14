﻿using Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugInn_2_v2
{
    [Export(typeof(IDllContract))]
    public class PlugInn2 : IDllContract
    {
        [Import(typeof(IAppUtil))]
        IAppUtil appUtil;

        public void Init(IAppUtil util)
        {
            //  appUtil = util;
        }

        public bool Run()
        {
            Console.WriteLine($"Hey man {appUtil.GetName()} from v2 dll 2!" +
                              $", lets also print some strings.. {appUtil.MyAddString("hey ", "you..")}");
            return true;
        }

        public void TearDown()
        {
            appUtil = null;
        }
    }
}

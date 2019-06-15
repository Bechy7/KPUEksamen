using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.ComponentModel.Composition.Registration;

namespace AppUtilImp_1
{
    class Program
    {
        // can use Lazy<IDllContracts, IMetaData> hvor metaData er funktioner i IDllContract
        // Dvs init, run, teardown
        [ImportMany(typeof(IDllContract))]
        public IEnumerable<IDllContract> PlugInns { get; set; }

        [Import(typeof(IAppUtil))]
        private AppUtilImp Util { get; set; }

        static void Main()
        {

            Program program = new Program();
            program.Compose();
            // Does not need to be instantiated, MEF does this under property injection
            //program.Util = new AppUtilImp();
            program.Run();
        }

        private void Run()
        {
            Console.Write("Enter your name: ");
            Util.Name = Console.ReadLine();

            // Init

            // not needed anymore

            foreach (var plugInn in PlugInns)
            {
                plugInn.Init(Util);
            }

            foreach (var plugInn in PlugInns)
            {
                plugInn.Run();
            }

            foreach (var plugInn in PlugInns)
            {
                plugInn.TearDown();
            }
        }

        private void Compose()
        {
            var catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new DirectoryCatalog(@".\Extensions"));

            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));

            // Make an instance of a CompositionContainer and give it a reference to the AggregateCatalog
            var container = new CompositionContainer(catalog, CompositionOptions.DisableSilentRejection);
            // Finally call composeparts to connect the Import with Export.
            container.ComposeParts(this);
        }
    }
}

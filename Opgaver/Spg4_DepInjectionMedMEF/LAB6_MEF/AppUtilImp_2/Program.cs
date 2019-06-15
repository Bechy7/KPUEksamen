using Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Registration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppUtilImp_2
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
            //var conventions = new RegistrationBuilder();

            //conventions.ForTypesDerivedFrom<IDllContract>()
            //    .Export();

            //conventions.ForType<AppUtilImp>().ImportProperty(x => x);

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

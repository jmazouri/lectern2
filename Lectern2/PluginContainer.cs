using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Registration;
using System.Reflection;
using Lectern2.Bridges;
using Lectern2.Configuration;
using Lectern2.Plugins;

namespace Lectern2
{
    public class PluginContainer
    {
        public static string PluginDirectory
        {
            get { return "../../../Plugins"; }
        }

        private static CompositionContainer _iocContainer;

        public static CompositionContainer Container
        {
            get
            {
                if (_iocContainer != null) return _iocContainer;

                var registration = new RegistrationBuilder();

                registration.ForTypesDerivedFrom<ILecternPlugin>()
                    .ImportProperty<ILecternBridge>(d => d.Bridge)
                    .Export<ILecternPlugin>();

                DirectoryCatalog dircat = new DirectoryCatalog(PluginDirectory, registration);
                AssemblyCatalog asscat = new AssemblyCatalog(Assembly.GetCallingAssembly());
                AggregateCatalog catalog = new AggregateCatalog(dircat, asscat);
                

                _iocContainer = new CompositionContainer(catalog);

                return _iocContainer;
            }
        }

        /*
        private static IKernel _kernel;

        

        public static IKernel Kernel
        {
            get
            {
                if (_kernel == null)
                {
                    _kernel = new StandardKernel();

                    if (!Directory.Exists(PluginDirectory))
                    {
                        Directory.CreateDirectory(PluginDirectory);
                    }


                    _kernel.Bind(d =>
                    {
                        d.FromAssembliesInPath(PluginDirectory)
                            .IncludingNonePublicTypes()
                            .SelectAllClasses()
                            .InheritedFrom<ILecternPlugin>()
                            .BindAllInterfaces()
                            .Configure(c => c.InSingletonScope());
                    });
                }

                return _kernel;
            }
        }
        */
    }
}

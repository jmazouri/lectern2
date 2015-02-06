using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition.Registration;
using System.Linq;
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

                registration.ForTypesDerivedFrom<ILecternBridge>()
                    .SetCreationPolicy(CreationPolicy.Shared)
                    .Export<ILecternBridge>();

                registration.ForTypesDerivedFrom<ILecternPlugin>()
                    .Export<ILecternPlugin>()
                    .SetCreationPolicy(CreationPolicy.Shared)
                    .ImportProperties(d => d.PropertyType.IsAssignableFrom(typeof (ILecternBridge)));
                    
                DirectoryCatalog dircat = new DirectoryCatalog(PluginDirectory, registration);

                var assemblyCatalogs = new List<ComposablePartCatalog>();

                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    if (assembly.FullName.ToLowerInvariant().Contains("lectern"))
                    {
                        assemblyCatalogs.Add(new AssemblyCatalog(assembly, registration));
                    }
                }

                assemblyCatalogs.Add(dircat);

                AggregateCatalog catalog = new AggregateCatalog(assemblyCatalogs);

                _iocContainer = new CompositionContainer(catalog);
                _iocContainer.ComposeParts();

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

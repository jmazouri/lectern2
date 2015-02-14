using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition.Registration;
using System.Linq;
using System.Reflection;
using Lectern2.Configuration;
using Lectern2.Interfaces;
using Lectern2.Plugins;
using LoggingExtensions.Logging;

namespace Lectern2
{
    //One lectern to rule them all, one lectern to find them. One lectern to bring them all and in the container bind them.
    public static class GlobalContainer
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

                registration.ForTypesDerivedFrom<LecternConfiguration>()
                    .SelectConstructor(ctor=>ctor.FirstOrDefault(d=>d.IsPrivate))
                    .SetCreationPolicy(CreationPolicy.Shared)
                    .Export<LecternConfiguration>();

                registration.ForType<DefaultPluginManager>()
                    .SetCreationPolicy(CreationPolicy.Shared)
                    .Export<IPluginManager>();

                registration.ForTypesDerivedFrom<ILecternBridge>()
                    .SetCreationPolicy(CreationPolicy.Shared)
                    .Export<ILecternBridge>()
                    .ImportProperties(d => d.PropertyType.IsAssignableFrom(typeof(LecternConfiguration)) | d.PropertyType.IsAssignableFrom(typeof(IPluginManager)));

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
                        "GlobalContainer".Log().Info("Added assembly {0}", assembly.FullName);
                    }
                }

                assemblyCatalogs.Add(dircat);

                AggregateCatalog catalog = new AggregateCatalog(assemblyCatalogs);

                _iocContainer = new CompositionContainer(catalog, CompositionOptions.DisableSilentRejection | CompositionOptions.IsThreadSafe);
                _iocContainer.ComposeParts();

                return _iocContainer;
            }
        }
    }
}

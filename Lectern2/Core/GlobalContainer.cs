using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition.Registration;
using System.IO;
using System.Linq;
using System.Reflection;
using Lectern2.Configuration;
using Lectern2.Interfaces;

namespace Lectern2.Core
{
    public static class GlobalContainer
    {
        private static readonly string Base = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string PluginDirectory = Path.Combine(Base, @"Lectern\Plugins");
        private static readonly string ConfigDirectory = Path.Combine(Base, @"Lectern\Config");
        private static readonly string BridgeDirectory = Path.Combine(Base, @"Lectern\Bridges");

        private static CompositionContainer _iocContainer;

        public static CompositionContainer Container
        {
            get
            {
                if (_iocContainer != null) return _iocContainer;

                Directory.CreateDirectory(PluginDirectory);
                Directory.CreateDirectory(ConfigDirectory);
                Directory.CreateDirectory(BridgeDirectory);

                var configRegistration = new RegistrationBuilder();
                configRegistration.ForTypesDerivedFrom<LecternConfiguration>()
                    .SelectConstructor(ctor=>ctor.FirstOrDefault(d=>d.IsPrivate))
                    .SetCreationPolicy(CreationPolicy.Shared)
                    .Export<LecternConfiguration>();

                var bridgeRegistration = new RegistrationBuilder();
                bridgeRegistration.ForTypesDerivedFrom<ILecternBridge>()
                    .SetCreationPolicy(CreationPolicy.Shared)
                    .Export<ILecternBridge>();

                var pluginRegistration = new RegistrationBuilder();
                pluginRegistration.ForTypesDerivedFrom<ILecternPlugin>()
                    .SetCreationPolicy(CreationPolicy.Shared)
                    .Export<ILecternPlugin>();

                var assemblyCatalogs = new List<ComposablePartCatalog>
                {
                    new DirectoryCatalog(ConfigDirectory, configRegistration),
                    new DirectoryCatalog(BridgeDirectory, bridgeRegistration),
                    new DirectoryCatalog(PluginDirectory, pluginRegistration)
                };

                var aggregateCatalog = new AggregateCatalog(assemblyCatalogs);

                _iocContainer = new CompositionContainer(aggregateCatalog, CompositionOptions.DisableSilentRejection | CompositionOptions.IsThreadSafe);
                _iocContainer.ComposeParts();

                return _iocContainer;
            }
        }
    }
}

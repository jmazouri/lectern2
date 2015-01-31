using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lectern2.Bridges;
using Lectern2.Plugins;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Conventions.BindingGenerators;
using Ninject.Modules;
using Ninject.Syntax;

namespace Lectern2
{
    public class PluginContainer
    {
        private static IKernel _kernel;

        public static string PluginDirectory
        {
            get { return "../../../Plugins"; }
        }

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
    }
}

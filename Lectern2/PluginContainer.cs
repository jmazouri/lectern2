using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lectern2.Plugins;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Conventions.BindingGenerators;
using Ninject.Syntax;

namespace Lectern2
{

    public class PluginContainer
    {
        private static IKernel _kernel;

        public static IKernel Kernel
        {
            get
            {
                if (_kernel != null) return _kernel;

                _kernel = new StandardKernel();

                if (!Directory.Exists("../../../Plugins"))
                {
                    Directory.CreateDirectory("../../../Plugins");
                }

                _kernel.Bind(d =>
                {
                    d.FromAssembliesInPath("../../../Plugins")
                        .SelectAllClasses().InheritedFrom<ILecternPlugin>()
                        .BindAllInterfaces()
                        .Configure(c => c.InSingletonScope());
                });

                return _kernel;
            }
        }
    }
}

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
        private class PluginBindingGenerator : IBindingGenerator
        {
            private readonly Type pluginInterfaceType = typeof(ILecternPlugin);

            public IEnumerable<IBindingWhenInNamedWithOrOnSyntax<object>> CreateBindings(Type type, IBindingRoot bindingRoot)
            {
                if (type == null)
                {
                    throw new ArgumentNullException("type");
                }

                if (bindingRoot == null)
                {
                    throw new ArgumentNullException("bindingRoot");
                }

                if (type.IsInterface || type.IsAbstract)
                {
                    return Enumerable.Empty<IBindingWhenInNamedWithOrOnSyntax<object>>();
                }

                if (!pluginInterfaceType.IsAssignableFrom(type))
                {
                    return Enumerable.Empty<IBindingWhenInNamedWithOrOnSyntax<object>>();
                }

                return new[] { bindingRoot.Bind(type.BaseType).To(type) };
            }
        }

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

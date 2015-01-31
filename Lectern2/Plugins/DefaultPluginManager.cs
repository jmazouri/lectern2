using System.IO;
using Ninject;
using Ninject.Extensions.Conventions;

namespace Lectern2.Plugins
{
    public class DefaultPluginManager
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            if (!Directory.Exists("Plugins"))
            {
                Directory.CreateDirectory("Plugins");
            }

            kernel.Bind(d =>
            {
                d.FromAssembliesInPath("Plugins")
                    .SelectAllClasses()
                    .InheritedFrom<ILecternPlugin>()
                    .BindAllInterfaces()
                    .Configure(c => c.InSingletonScope());
            });

            return kernel;
        }
    }
}

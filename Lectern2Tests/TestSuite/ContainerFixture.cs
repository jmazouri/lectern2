using System;
using System.Collections.Generic;
using System.Text;
using Lectern2.Core;
using Lectern2.Interfaces;
using Lectern2.Util;
using LoggingExtensions.Logging;
using LoggingExtensions.NLog;
using Xunit;

namespace Lectern2Tests.TestSuite
{
    public class ContainerFixture
    {
        public ContainerFixture()
        {
            Log.InitializeWith<NLogLog>();
            GlobalContainer.AddPreemptiveAssembly(GetType().Assembly);

            var container = GlobalContainer.Container;
            
            var stringBuilder = new StringBuilder()
                .AppendLine()
                .AppendLine("Loaded Test Bridges: ")
                .AppendLine(PrintExportNames(container.GetExports<ILecternBridge>()))
                .AppendLine("Loaded Test Plugins: ")
                .AppendLine(PrintExportNames(container.GetExports<ILecternPlugin>()));
            
            this.Log().Debug(stringBuilder.ToString);
        }

        private static string PrintExportNames<T>(IEnumerable<Lazy<T>> exportLazies)
        {
            var exportTypeSet = new Stack<Type>();
            foreach (var exportLazy in exportLazies)
            {
                exportTypeSet.Push(exportLazy.Value.GetType());
            }
            return JsonUtil.ToJson(exportTypeSet, false);
        }
    }

    [CollectionDefinition("LecternTestSuite")]
    public class DatabaseCollection : ICollectionFixture<ContainerFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}

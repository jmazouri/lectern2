using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Reflection;
using Lectern2.Configuration;
using Lectern2.Interfaces;
using Lectern2.Messages;

namespace Lectern2.Core
{
    public class Lectern
    {
        public LecternConfiguration Configuration;
        private readonly FileVersionInfo _versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
        public readonly Mediator Mediator;

        public Lectern(LecternConfiguration overrideConfiguration = null, ISet<ILecternBridge> additionalBridges = null, ISet<ILecternPlugin> additionalPlugins = null)
        {
#if DEBUG
            NLog.LogManager.ThrowExceptions = true;
#endif
            LoggingExtensions.Logging.Log.InitializeWith<LoggingExtensions.NLog.NLogLog>();

            if (additionalBridges != null)
            {
                foreach (var additionalBridge in additionalBridges)
                {
                    GlobalContainer.Container.ComposeExportedValue(additionalBridge);
                }
            }
            if (additionalPlugins != null)
            {
                foreach (var additionalPlugin in additionalPlugins)
                {
                    GlobalContainer.Container.ComposeExportedValue(additionalPlugin);
                }
            }

            Mediator = new Mediator();

            Mediator.BroadcastMessage(new LecternMessage(String.Format("Lectern (Version {0}) loaded!", _versionInfo.ProductVersion)));
        }
    }
}

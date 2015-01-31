using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lectern2.Configuration
{
    public interface IConfiguration<T>
    {
        string Name { get; }
        string ConfigPath { get; }
        T Load();
        void Save();
    }
}

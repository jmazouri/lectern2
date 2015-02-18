using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lectern2.Attributes
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class ApiVersionAttribute : Attribute
    {
        public string ApiVersion = "";

        public ApiVersionAttribute(string apiVersion)
        {
            ApiVersion = apiVersion;
        }
    }
}

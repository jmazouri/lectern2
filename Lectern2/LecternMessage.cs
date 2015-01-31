using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Lectern2.Bridges;
using Newtonsoft.Json;

namespace Lectern2
{
    public class LecternMessage
    {
        [JsonIgnore]
        private ILecternBridge lecternBridge;

        public string MessageBody { get; set; }

        public LecternMessage(string message, ILecternBridge bridge)
        {
            MessageBody = message;
            lecternBridge = bridge;

            ParseArguments();
        }

        private void ParseArguments()
        {
            if (MessageBody == null || MessageBody.Length >= lecternBridge.Configuration.SimplePluginPrefix.Length)
            {
                Arguments = new List<string>();
            }

            Regex rx = new Regex(@"(?<="")[^""]+(?="")|[^\s""]\S*");
            List<string> arguments = new List<string>();

            for (var match = rx.Match(MessageBody); match.Success; match = match.NextMatch())
            {
                arguments.Add(match.Value.Trim());
            }

            Arguments = arguments.Skip(1).ToList();
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public List<string> Arguments { get; set; }
    }
}

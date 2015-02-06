using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            if (MessageBody == null)
            {
                Arguments = new List<string>();
            }

            Regex rx = new Regex(@"(?<="")[^""]+(?="")|[^\s""]\S*");
            List<string> arguments = new List<string>();

            for (var match = rx.Match(MessageBody); match.Success; match = match.NextMatch())
            {
                arguments.Add(match.Value.Trim());
            }

            if (arguments.FirstOrDefault() == lecternBridge.Configuration.SimplePluginPrefix)
            {
                Arguments = arguments.Skip(1).ToList();
            }
            else
            {
                Arguments = arguments.ToList();
            }
        }

        public string ToJson(bool indented = true)
        {
            return JsonConvert.SerializeObject(this, (indented ? Formatting.Indented : Formatting.None));
        }

        public List<string> Arguments { get; set; }
    }
}

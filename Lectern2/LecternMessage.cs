using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Lectern2.Configuration;
using Lectern2.Interfaces;
using Newtonsoft.Json;
using NLog;

namespace Lectern2
{
    public class LecternMessage
    {
        private Logger _logger = LogManager.GetCurrentClassLogger();
        public string MessageBody { get; set; }
        private static Regex ArgumentRegex;

        public LecternMessage(string message)
        {
            MessageBody = message;

            if (ArgumentRegex == null)
            {
                _logger.Warn("The regex for LecternMessages wasn't compiled! This will reduce performance.");
                ArgumentRegex = new Regex(@"(?<="")[^""]+(?="")|[^\s""]\S*");
            }

            ParseArguments();
        }

        public static void LoadRegex()
        {
            ArgumentRegex = new Regex(@"(?<="")[^""]+(?="")|[^\s""]\S*", RegexOptions.Compiled);
        }

        private void ParseArguments()
        {

            if (MessageBody == null)
            {
                Arguments = new List<string>();
                return;
            }

            List<string> arguments = new List<string>();

            for (var match = ArgumentRegex.Match(MessageBody); match.Success; match = match.NextMatch())
            {
                arguments.Add(match.Value.Trim());
            }

            if (arguments.FirstOrDefault() == LecternConfiguration.Instance.SimplePluginPrefix)
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

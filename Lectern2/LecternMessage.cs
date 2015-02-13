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
        private readonly LecternConfiguration _configuration;

        private string _messageBody = null;

        public string MessageBody
        {
            get
            {
                return _messageBody;
            }
            set
            {
                _messageBody = value;
                ParseArguments();
            }
        }

        private static Regex _argumentRegex;

        public List<string> Arguments { get; set; }

        public LecternMessage(string message, LecternConfiguration config = null)
        {
            _configuration = config ?? JsonConfiguration.Load<LecternConfiguration>();

            //If for some reason the regex isn't compiled, do it
            if (_argumentRegex == null)
            {
                this.Log().Warn("The regex for LecternMessages wasn't compiled! Doing it now, hold on...");
                LoadRegex();
            }

            MessageBody = message;
        }

        public static void LoadRegex()
        {
            _argumentRegex = new Regex(@"(?<="")[^""]+(?="")|[^\s""]\S*", RegexOptions.Compiled);
        }

        private void ParseArguments()
        {
            string prefix = _configuration.CommandPrefix;

            if (MessageBody == null)
            {
                Arguments = new List<string>();
                return;
            }

            string tempBody = MessageBody;
            if (tempBody.Length >= prefix.Length)
            {
                if (tempBody.StartsWith(prefix))
                {
                    tempBody = tempBody.Substring(prefix.Length, tempBody.Length - prefix.Length);
                }
            }

            Arguments.Clear();

            for (var match = _argumentRegex.Match(tempBody); match.Success; match = match.NextMatch())
            {
                Arguments.Add(match.Value.Trim());
            }
        }

        public string ToJson(bool indented = true)
        {
            return JsonConvert.SerializeObject(this, (indented ? Formatting.Indented : Formatting.None));
        }
    }
}

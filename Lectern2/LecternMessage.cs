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

        public LecternMessage(string message)
        {
            MessageBody = message;

            //If for some reason the regex isn't compiled, just use the slow version
            if (_argumentRegex == null)
            {
                this.Log().Warn("The regex for LecternMessages wasn't compiled! This will reduce performance.");
                _argumentRegex = new Regex(@"(?<="")[^""]+(?="")|[^\s""]\S*");
            }
        }

        public static void LoadRegex()
        {
            _argumentRegex = new Regex(@"(?<="")[^""]+(?="")|[^\s""]\S*", RegexOptions.Compiled);
        }

        private void ParseArguments()
        {
            if (MessageBody == null)
            {
                Arguments = new List<string>();
                return;
            }

            string tempBody = MessageBody;

            if (tempBody.FirstOrDefault() == '/')
            {
                tempBody = tempBody.Substring(1, tempBody.Length - 1);
            }

            List<string> arguments = new List<string>();

            for (var match = _argumentRegex.Match(tempBody); match.Success; match = match.NextMatch())
            {
                arguments.Add(match.Value.Trim());
            }

            Arguments = arguments;
        }

        public string ToJson(bool indented = true)
        {
            return JsonConvert.SerializeObject(this, (indented ? Formatting.Indented : Formatting.None));
        }
    }
}

using System.Collections.Generic;
using System.Text.RegularExpressions;
using Lectern2.Configuration;

namespace Lectern2.Messages
{
    public class LecternMessage
    {
        public enum Scope
        {
            Log,
            System,
            Error,
            Chat
        }

        private readonly LecternConfiguration _configuration;

        private string _messageBody;

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

        public Scope MessageScope { get; private set; }

        private static Regex _argumentRegex;

        public readonly List<string> Arguments = new List<string>();

        public LecternMessage(string message, LecternConfiguration config = null, Scope scope = Scope.Chat)
        {
            _configuration = config ?? JsonConfigParser.Load<LecternConfiguration>();

            //If for some reason the regex isn't compiled, do it
            if (_argumentRegex == null)
            {
                this.Log().Warn("The regex for LecternMessages wasn't compiled! Doing it now, hold on...");
                LoadRegex();
            }

            MessageBody = message;
            MessageScope = scope;
        }

        public static void LoadRegex()
        {
            _argumentRegex = new Regex(@"(?<="")[^""]+(?="")|[^\s""]\S*", RegexOptions.Compiled);
        }

        private void ParseArguments()
        {
            Arguments.Clear();

            if (MessageBody == null) return;

            string prefix = _configuration.CommandPrefix;
            string tempBody = MessageBody;

            if (tempBody.Length >= prefix.Length)
            {
                if (tempBody.StartsWith(prefix))
                {
                    tempBody = tempBody.Substring(prefix.Length, tempBody.Length - prefix.Length);
                }
            }


            for (var match = _argumentRegex.Match(tempBody); match.Success; match = match.NextMatch())
            {
                Arguments.Add(match.Value.Trim());
            }
        }

        public static implicit operator LecternMessage(string input)
        {
            return new LecternMessage(input);
        }
    }
}

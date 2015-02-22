using System;
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
        public string Command { get; private set; }

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
            Command = "";

            if (MessageBody == null) return;

            string prefix = _configuration.CommandPrefix;
            string tempBody = MessageBody;

            if (tempBody.Length < prefix.Length || !tempBody.StartsWith(prefix)) return;

            var commandEnd = tempBody.IndexOf(" ", StringComparison.Ordinal);
            if (commandEnd == -1)
            {
                commandEnd = tempBody.Length;
            }

            Command = tempBody.Substring(prefix.Length, commandEnd - prefix.Length);
            tempBody = tempBody.Substring(prefix.Length + Command.Length, tempBody.Length - (prefix.Length + Command.Length));

            for (var match = _argumentRegex.Match(tempBody); match.Success; match = match.NextMatch())
            {
                Arguments.Add(match.Value.Trim());
            }
        }

        public bool IsCommand()
        {
            return Command != "";
        }

        public static implicit operator LecternMessage(string input)
        {
            return new LecternMessage(input);
        }
    }
}

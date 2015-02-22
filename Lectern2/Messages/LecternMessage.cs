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

        public bool IsCommand
        {
            get { return Command != ""; }
        }

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
            var prefix = _configuration.CommandPrefix;

            if (MessageBody.Length < prefix.Length || !MessageBody.StartsWith(prefix)) return;
            var tempBody = MessageBody.Substring(prefix.Length, MessageBody.Length - prefix.Length);

            for (var match = _argumentRegex.Match(tempBody); match.Success; match = match.NextMatch())
            {
                if (Command.Length > 0)
                {
                    Arguments.Add(match.Value.Trim());
                }
                else
                {
                    Command = match.Value.Trim();
                }
            }
        }

        public static implicit operator LecternMessage(string input)
        {
            return new LecternMessage(input);
        }

        public static implicit operator String(LecternMessage input)
        {
            return input.MessageBody;
        }
    }
}

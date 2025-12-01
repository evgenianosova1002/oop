using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework8
{

    // Порушено принцип Single Responsibility
    // EmailSender і відправляє лист, і вирішує, як вести лог (через Console).

    class Email
    {
        public string Theme { get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
    }

    interface ILogger
    {
        void Log(string message);
    }

    class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    class EmailSender
    {
        private readonly ILogger _logger;

        public EmailSender(ILogger logger)
        {
            _logger = logger;
        }

        public void Send(Email email)
        {
            // ... sending ...
            _logger.Log($"Email from '{email.From}' to '{email.To}' with theme '{email.Theme}' was sent");
        }
    }
}

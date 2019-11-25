using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class NotificationHandler : INotificationHandler
    {
        private readonly IList<string> _messages;
        public NotificationHandler()
        {
            _messages = new List<string>();
        }
        public string Messages
            => string.Join(Environment.NewLine, _messages);

        public bool HasNotification => _messages.Any();

        public NotificationHandler AddNotification(string notification)
        {
            _messages.Add(notification);
            return this;
        }
    }
}

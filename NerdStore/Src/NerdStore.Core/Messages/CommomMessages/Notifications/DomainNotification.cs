using MediatR;
using System;
using System.Text;

namespace NerdStore.Core.Messages.CommomMessages.Notifications
{
    public class DomainNotification : Message, INotification
    {
        public DateTime TimeStamp { get; private set; }
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }
        public DomainNotification(string key, string value)
        {
            TimeStamp = DateTime.Now;
            DomainNotificationId = Guid.NewGuid();
            Key = key;
            Value = value;
            Version = 1;
        }

    }
}

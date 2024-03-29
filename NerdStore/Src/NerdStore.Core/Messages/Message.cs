﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Core.Messages
{
    public abstract partial class Message
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }
        protected  Message()
        {
            MessageType = GetType().Name;
        }
    }
}

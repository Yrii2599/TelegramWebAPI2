using System;
using System.Collections.Generic;
using ModelsLayer;

namespace AbstractionsLayer
{
    public interface IMessageData
    {
        IEnumerable<Message> Get();
        IEnumerable<Message> Get(Func<Message, bool> predicate);
        Message GetById(int messageId);
        Message Add(Message messageData);
        Message Edit(int messageId, Message messageData);
        bool Remove(int messageId);
    }
}

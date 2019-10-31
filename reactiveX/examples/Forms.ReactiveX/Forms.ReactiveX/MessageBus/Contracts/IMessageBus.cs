using System;

namespace Forms.ReactiveX.MessageBus.Contracts {
    public interface IMessageBus : IDisposable {
        IObservable<MessageBase> Listen(MessageBase message);
        void Send(MessageBase message);
    }
}
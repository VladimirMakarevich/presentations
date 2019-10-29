using System;

namespace Forms.ReactiveX.MessageBus.Contracts {
    public interface IMessageBus : IDisposable {
        IObservable<IMessage> Listen(IMessage message);
        void Send(IMessage message);
    }
}
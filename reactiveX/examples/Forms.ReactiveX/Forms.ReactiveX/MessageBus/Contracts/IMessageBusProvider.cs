using Forms.ReactiveX.MessageBus.Types;
using System;

namespace Forms.ReactiveX.MessageBus.Contracts {
    public interface IMessageBusProvider {
        MessageScope Scope { get; }

        IObservable<T> Listen<T>();

        void Send<T>(T message);
    }
}
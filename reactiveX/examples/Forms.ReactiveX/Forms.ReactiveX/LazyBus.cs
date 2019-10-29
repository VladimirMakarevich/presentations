using Forms.ReactiveX.MessageBus.Contracts;
using System;

namespace Forms.ReactiveX
{
    public static class Ioc {
        public static IMessageBus GetBus() {
            return new MessageBus.MessageBus();
        }
    }

    public sealed class LazyBus {
        public IMessageBus Bus { get; }

        private static readonly Lazy<LazyBus> Instance =
            new Lazy<LazyBus>(
                () => new LazyBus());

        LazyBus() {
            Bus = new MessageBus.MessageBus();
        }

        public static LazyBus GetInstance => Instance.Value;
    }
}
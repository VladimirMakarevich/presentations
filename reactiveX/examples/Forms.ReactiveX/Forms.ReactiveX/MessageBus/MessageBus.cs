using Forms.ReactiveX.MessageBus.Contracts;
using Forms.ReactiveX.MessageBus.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Forms.ReactiveX.MessageBus {
    public class MessageBus : IMessageBus {
        #region [obsolute]

        public MessageBus(IEnumerable<IMessageBusProvider> providers) {
            _providers = providers;
        }

        private IEnumerable<IMessageBusProvider> _providers;

        protected IEnumerable<IMessageBusProvider> Providers {
            get {
                _providers = _providers ?? Enumerable.Empty<IMessageBusProvider>();
                return _providers;
            }
        }

        public IObservable<T> Listen<T>(MessageScope scope) {
            return Observable.Merge(
                Providers.Where(p => (p.Scope & scope) == scope).Select(p => p.Listen<T>()));
        }

        public void Send<T>(T message, MessageScope scope) {
            Providers.Where(p => (p.Scope & scope) == scope)
                .ToList()
                .ForEach(p => p.Send(message));
        }

        #endregion

        public MessageBus() {
        }

        private readonly Subject<IMessage> _baseChannel = new Subject<IMessage>();

        private readonly BehaviorSubject<IMessage> _stackChannel = new BehaviorSubject<IMessage>(null);

        public void Send(IMessage message) {
            if (message.Type == ChannelType.Base) {
                _baseChannel.OnNext(message);
            }
            else if (message.Type == ChannelType.Stack) {
                _stackChannel.OnNext(message);
            }
            else {
                throw new NotSupportedException();
            }
        }

        public IObservable<IMessage> Listen(IMessage message) {
            IObservable<IMessage> observable;
            if (message.Type == ChannelType.Base) {
                observable = _baseChannel.AsObservable();
            }
            else if (message.Type == ChannelType.Stack) {
                observable = _stackChannel.AsObservable();
            }
            else {
                throw new NotSupportedException();
            }

            return observable;
        }

        public void Dispose() {
            _baseChannel?.Dispose();
            _stackChannel?.Dispose();
        }
    }
}
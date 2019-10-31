using Forms.ReactiveX.MessageBus.Contracts;
using Forms.ReactiveX.MessageBus.Types;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Forms.ReactiveX.MessageBus
{
    public class MessageBus : IMessageBus {
        public MessageBus() {
        }

        private readonly Subject<MessageBase> _baseChannel = new Subject<MessageBase>();

        private readonly BehaviorSubject<MessageBase> _stackChannel = new BehaviorSubject<MessageBase>(null);

        public void Send(MessageBase message) {
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

        public IObservable<MessageBase> Listen(MessageBase message) {
            IObservable<MessageBase> observable;
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
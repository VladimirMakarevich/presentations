using Forms.ReactiveX.MessageBus.Types;

namespace Forms.ReactiveX.MessageBus.Contracts {
    public abstract class MessageBase {
        public abstract string Name { get; }
        public abstract ChannelType Type { get; }
    }
}
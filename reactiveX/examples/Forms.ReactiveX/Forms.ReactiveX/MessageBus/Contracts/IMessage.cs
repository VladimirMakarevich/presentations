using Forms.ReactiveX.MessageBus.Types;

namespace Forms.ReactiveX.MessageBus.Contracts {
    public interface IMessage {
        string Name { get; }
        ChannelType Type { get; }
        T Data<T>();
    }
}
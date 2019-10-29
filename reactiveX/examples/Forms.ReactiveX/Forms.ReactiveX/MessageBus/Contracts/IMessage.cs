using Forms.ReactiveX.MessageBus.Types;

namespace Forms.ReactiveX.MessageBus.Contracts {
    public interface IMessage {
        string Name { get; }
        ChannelType Type { get; }
        dynamic GetData();
        void SetData(dynamic data);
    }
}
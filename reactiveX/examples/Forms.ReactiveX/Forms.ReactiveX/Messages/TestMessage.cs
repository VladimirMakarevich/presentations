using Forms.ReactiveX.MessageBus.Contracts;
using Forms.ReactiveX.MessageBus.Types;

namespace Forms.ReactiveX.Messages
{
    public class TestMessage : IMessage {
        public string Name => "Test Message";
        public ChannelType Type => ChannelType.Stack;

        public dynamic Data;
        public dynamic GetData() {
            return Data;
        }
        public void SetData(dynamic data) {
            Data = data;
        }
    }
}
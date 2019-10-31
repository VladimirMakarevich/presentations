using Forms.ReactiveX.MessageBus.Contracts;
using Forms.ReactiveX.MessageBus.Types;

namespace Forms.ReactiveX.Messages {
    public class TestMessage<T> : MessageBase {
        public override string Name => "Test Message";
        public override ChannelType Type => ChannelType.Stack;

        public T Data;

        public TestMessage(T data) {
            Data = data;
        }

        public TestMessage() {
        }
    }
}
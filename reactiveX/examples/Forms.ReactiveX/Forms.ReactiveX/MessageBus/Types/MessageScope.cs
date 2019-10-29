using System;

namespace Forms.ReactiveX.MessageBus.Types {
    [Flags]
    public enum MessageScope {
        Unknown = 0,
        Local = 1,
        Global = 2
    }
}
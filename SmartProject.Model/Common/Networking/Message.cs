using System;
using System.Collections.Generic;
using System.Text;

namespace SmartProject.Model.Common.Networking
{
    public enum MessageType
    {
        Text,
        MethodInvocation,
        ConnectionEvent,
        MethodReturnValue
    }

    public class Message
    {
        public MessageType MessageType { get; set; }
        public string Data { get; set; }
    }
}

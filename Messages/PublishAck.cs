using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenNETCF.MQTT
{
    internal class PublishAck:Message
    {
        public PublishAck()
            : base(MessageType.PublishAck, QoS.FireAndForget, false, false)
        {
            FixedHeader.RemainingLength = 2;
            // NOTE: Disconnect has no variable header and no payload
        }
        public override byte[] Payload
        {
            get { return null; }
        }
    }
}

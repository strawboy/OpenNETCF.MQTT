﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenNETCF.MQTT
{
    internal class Subscribe : Message
    {
        private VariableHeader<MessageIDHeaderData> m_header;
        private Subscription[] m_subscriptions;

        public Subscribe(Subscription[] subscriptions, ushort messageID)
            : base(MessageType.Subscribe, QoS.AcknowledgeDelivery, false, false)
        {
            Validate
                .Begin()
                .IsNotNull(subscriptions)

                .IsGreaterThanOrEqualTo(subscriptions.Length,1)
                .Check();

            m_header = new VariableHeader<MessageIDHeaderData>();
            m_header.HeaderData.MessageID = messageID;
            VariableHeader = m_header;

            m_subscriptions = subscriptions;
        }

        public override byte[] Payload
        {
            get 
            {
                var data = new List<byte>(m_subscriptions.Length * 3);

                foreach (var s in m_subscriptions)
                {
                    data.AddRange(s.Serialize());
                }

                return data.ToArray();
            }
        }
    }
}

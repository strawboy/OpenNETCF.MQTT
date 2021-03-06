﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace OpenNETCF.MQTT
{
    public class MQTTString
    {
        public string Value { get; set; }
        public static implicit operator string(MQTTString s)
        {
            return s.Value;
        }

        public static implicit operator MQTTString (string s)
        {
            return new MQTTString() { Value = s };
        }

        public override string ToString()
        {
            return Value;
        }

        public byte[] Serialize()
        {
            var data = new List<byte>(Value.Length + 2);

            // to big-endian
            data.AddRange(BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)Value.Length)));
            data.AddRange(Encoding.UTF8.GetBytes(Value));

            return data.ToArray();
        }
    }
}

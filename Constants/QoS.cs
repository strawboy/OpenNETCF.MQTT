using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenNETCF.MQTT
{
    public enum QoS
    {
        /// <summary>
        /// //至多一次 发完即丢弃 
        /// </summary>
        FireAndForget = 0,

        /// <summary>
        /// //至少一次 需要确认回复 
        /// </summary>
        AcknowledgeDelivery = 1,

        /// <summary>
        /// //只有一次 需要确认回复  
        /// </summary>
        AssureDelivery = 2,

        /// <summary>
        ///  待用，保留位置 
        /// </summary>
        Reserved = 3
    }
}

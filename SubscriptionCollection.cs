using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace OpenNETCF.MQTT
{
    public class SubscriptionCollection : IEnumerable<Subscription>
    {
        private Dictionary<string, Subscription> m_subscriptions = new Dictionary<string, Subscription>();

   
        //public event EventHandler<GenericEventArgs<Subscription>> SubscriptionAdded;
        //public event EventHandler<GenericEventArgs<tring>> SubscriptionRemoved;

        public event EventHandler<GenericEventArgs<List<Subscription>>> SubscriptionAdded;
        public event EventHandler<GenericEventArgs<List<string>>> SubscriptionRemoved;

        public int Count
        {
            get { return m_subscriptions.Count; }
        }

        public Subscription this[int index]
        {
            get { return m_subscriptions.Values.ToList()[index]; }
        }

        public Subscription this[string topic]
        {
            get { return m_subscriptions[topic]; }
        }

        //public Subscription Add(string topic, QoS qos)
        //{
        //    var s = new Subscription(topic, qos);
        //    Add(s);
        //    return s;
        //}

        //
        //public Subscription Add(Dictionary<string, QoS> subscriptions)
        //{
        //    var s = new Subscription(topic, qos);
        //    Add(s);
        //    return s;
        //}

        public void Add(Dictionary<string, QoS> subscriptions)
        {
            List<Subscription> subscribeList = new List<Subscription>();
            foreach (KeyValuePair<string, QoS> keyValuePair in subscriptions)
            {
                // TODO: validate uniqueness of topic?
                if (!m_subscriptions.ContainsKey(keyValuePair.Key))
                {
                    Subscription subscription = new Subscription(keyValuePair.Key,keyValuePair.Value);
                    m_subscriptions.Add(keyValuePair.Key , subscription);
                    subscribeList.Add(subscription);
                }
            }
            if (SubscriptionAdded != null) SubscriptionAdded(this, new GenericEventArgs<List<Subscription>>(subscribeList));
        }

        //public void Add(Subscription subscription)
        //{
        //    // TODO: validate uniqueness of topic?
        //    if (!m_subscriptions.ContainsKey(subscription.TopicName))
        //    {
        //        m_subscriptions.Add(subscription.TopicName, subscription);
        //    }
        //    if(SubscriptionAdded != null) SubscriptionAdded(this, new GenericEventArgs<Subscription>(subscription));
        //}

        //public void Remove(Subscription subscription)
        //{
        //    Remove(subscription.TopicName);
        //}

        public void Remove(List<string> topicList)
        {
            foreach (string topic in topicList)
            {
                m_subscriptions.Remove(topic);
            }
            if(SubscriptionRemoved != null) SubscriptionRemoved(this, new GenericEventArgs<List<string>>(topicList));
        }

        public IEnumerator<Subscription> GetEnumerator()
        {
            return m_subscriptions.Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    //public class Subscription
    //{
    //    public Subscription(string topic)
    //        : this(topic, QoS.FireAndForget)
    //    {
    //    }

    //    public Subscription(string topic, QoS qos)
    //    {
    //        Validate
    //            .Begin()
    //            .IsNotNullOrEmpty(topic)
    //            .Check();

    //        Topic = topic;
    //        QoS = qos;
    //    }

    //    public readonly string Topic { get; set; }
    //    public readonly QoS QoS { get; set; }
    //}
}

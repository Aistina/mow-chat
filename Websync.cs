using System;
using FM.WebSync;
using MowChat.Data;
using RestSharp;
using RestSharp.Deserializers;

namespace MowChat
{
    public class Websync
    {
        /// <summary>
        /// The websync server
        /// </summary>
        private const string WebsyncUrl = "http://igmchatlx.isotx.com/websync.ashx";

        /// <summary>
        /// The WebSync connection.
        /// </summary>
        private Client _client;

        private static Websync _instance;
        public static Websync Instance
        {
            get { return _instance ?? (_instance = new Websync()); }
        }

        public Websync()
        {
            ConnectToWebsync();
        }

        private void ConnectToWebsync()
        {
            _client = new Client(WebsyncUrl);
            _client.Connect();
        }

        public void Subscribe(string channelName, Action<WebsyncMessage> callback)
        {
            _client.Subscribe(
                new SubscribeArgs(channelName)
                {
                    OnReceive = data =>
                    {
                        // Abuse RestSharp to deserialize JSON for us.
                        var response = new RestResponse<WebsyncMessage> { Content = data.DataJson };
                        var message = new JsonDeserializer().Deserialize<WebsyncMessage>(response);

                        callback(message);
                    }
                });
        }
    }
}

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

        /// <summary>
        /// The instance of WebSync manager singleton.
        /// </summary>
        private static Websync _instance;

        /// <summary>
        /// The instance of WebSync manager singleton.
        /// </summary>
        public static Websync Instance
        {
            get { return _instance ?? (_instance = new Websync()); }
        }

		/// <summary>
		/// Whether the WebSync manager singleton exists.
		/// </summary>
	    public static bool HasInstance
	    {
			get { return _instance != null; }
	    }

	    /// <summary>
        /// Constructor.
        /// </summary>
        private Websync()
        {
            ConnectToWebsync();
        }
        
        /// <summary>
        /// Connect to the WebSync server.
        /// </summary>
        private void ConnectToWebsync()
        {
            _client = new Client(WebsyncUrl);
	        _client.Connect(new ConnectArgs
		        {
			        OnSuccess = data => Logger.Print("Connected to WebSync."),
		        });
        }

		/// <summary>
		/// Disconnect from WebSync.
		/// </summary>
		public void DisconnectFromWebsync()
		{
			if (!_client.IsConnected) return;

			_client.Disconnect();
			_instance = null;
		}

        /// <summary>
        /// Subscribe to a WebSync channel.
        /// </summary>
        /// <param name="channelName">The name of the channel to subscribe to.</param>
        /// <param name="callback">The function to call when a message is received.</param>
        public void Subscribe(string channelName, Action<WebsyncMessage> callback)
        {
            _client.Subscribe(
                new SubscribeArgs(channelName)
                {
                    OnReceive = data =>
                    {
						Logger.Print("Received from WebSync, " + data.DataJson);

                        var wrapped = FromJson<WrappedWebsyncMessage>(data.DataJson);
                        var message = FromJson<WebsyncMessage>(string.Join("", wrapped.m_dataJson));

                        callback(message);
                    }
                });
        }

        /// <summary>
        /// Deserialize a JSON string to an object of type T.
        /// </summary>
        /// <typeparam name="T">The expected object type.</typeparam>
        /// <param name="json">The JSON string.</param>
        /// <returns>An instance of T.</returns>
        private static T FromJson<T>(string json)
        {
            // Abuse RestSharp to deserialize JSON for us.
            var response = new RestResponse<T> { Content = json };
            return new JsonDeserializer().Deserialize<T>(response);
        }
    }
}

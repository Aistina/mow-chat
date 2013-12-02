using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MetroFramework.Controls;
using MowChat.Data;

namespace MowChat
{
	public partial class ChatControl : MetroUserControl
	{
	    private ChatChannel Channel { get; set; }

		public ChatControl(ChatChannel channel)
		{
			InitializeComponent();

			Channel = channel;
            
			// Anchor (grow) in all directions
		    Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

			// Get some chat history
			API.Instance.Get<ChatMessageList>(OnHistoryReceived, string.Format("chat/messages/{0}", Channel.Id));

            // Receive messages from WebSync
            Websync.Instance.Subscribe(channel.WebsyncChannel, OnMessageReceived);

            // Events for sending chat message
		    sendButton.Click += (sender, args) => SendMessage();
		    chatText.KeyPress += (sender, args) =>
		    {
		        if (args.KeyChar != (char) Keys.Enter) return;

                // Send the message
		        SendMessage();

		        // Prevent default handling of input
		        args.Handled = true;
		    };
		}

        private void SendMessage()
        {
            var text = chatText.Text;
            chatText.Text = "";

            // No callback needed since we'll receive the message via WebSync.
            API.Instance.Post<ChatMessage>(null, string.Format("chat/channels/{0}", Channel.Id), new Dictionary<string, string>
            {
                { "message", text }
            });
        }

	    private void OnMessageReceived(WebsyncMessage obj)
	    {
	        if (obj == null || obj.Type != "message" || obj.ChatMessages == null)
	            return;

	        Invoke((MethodInvoker) delegate
            {
                foreach (var message in obj.ChatMessages)
                    AddMessage(message);
	        });
	    }

	    private void OnHistoryReceived(ChatMessageList list)
		{
		    Invoke((MethodInvoker) delegate
		    {
                // Oldest is at the top oops
		        list.Records.Reverse();

		        foreach (var message in list.Records)
		            AddMessage(message);
		    });
		}

	    private void AddMessage(ChatMessage message)
		{
		    messagesContainer.Text += string.Format("{3}[{0}] {1}: {2}",
		        message.Date, message.Character.Name, message.Message, 
                messagesContainer.Text.Length > 0 ? Environment.NewLine : "");

            // Scroll to end
		    messagesContainer.Select(messagesContainer.Text.Length, 0);
            messagesContainer.ScrollToCaret();
		}
	}
}

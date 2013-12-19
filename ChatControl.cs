using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Controls;
using MowChat.Data;

namespace MowChat
{
	public sealed partial class ChatControl : MetroUserControl
	{
	    private ChatChannel Channel { get; set; }
		private int UnreadCount { get; set; }

		public MetroTabPage TabPage { get; set; }

		private MetroTabControl _tabControl;

		public MetroTabControl TabControl
		{
			get { return _tabControl; }
			set
			{
				_tabControl = value;

				// Reset unread counter when opening the tab
				value.SelectedIndexChanged += delegate
					{
						if (TabControl.SelectedTab == TabPage)
							ResetUnreadCounter();
					};
			}
		}

		private static readonly Color[] FactionColors = new[]
			{
				Color.FromArgb(0x999bc3), // 1 = Alliance
				Color.FromArgb(0x8ba477), // 2 = Junta
				Color.FromArgb(0xa5a4a4), // 3 = Empire
				Color.FromArgb(0x60bbce), // 4 = Republic
				Color.FromArgb(0xe06666), // 5 = Union
				Color.FromArgb(0xca9e37) // 6 = Warlords
			};

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
				// Add messages to text box
                foreach (var message in obj.ChatMessages)
                    AddMessage(message);

				// If tab is not active, show unread indicator
	            if (TabControl.SelectedTab != TabPage)
		            IncreaseUnreadCounter();
            });
	    }

		private void IncreaseUnreadCounter()
		{
			TabPage.Text = string.Format("{0} ({1})", Channel.Name, ++UnreadCount);
		}

		private void ResetUnreadCounter()
		{
			UnreadCount = 0;

			TabPage.Text = Channel.Name;
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

		private Color GetFactionColor(Character character)
		{
			if (character.FactionId >= 1 && character.FactionId <= 6)
				return FactionColors[character.FactionId - 1];

			return Color.Black;
		}

	    private void AddMessage(ChatMessage message)
		{
		    if (messagesContainer.Text.Length > 0)
				messagesContainer.AppendText(Environment.NewLine);

			// Add message's sender to player store
			PlayerStore.Instance.StorePlayer(message.Character);

			// If the chat message mentions the selected character, highlight the line
		    var highlighted = false;
		    var oldBackColor = messagesContainer.SelectionBackColor;
			if (message.Message.Contains(API.Instance.CurrentUser.SelectedCharacter.Name))
			{
				highlighted = true;
				messagesContainer.SelectionBackColor = Color.LightGray;
			}

			// Add the timestamp and sender.
			var oldColor = messagesContainer.SelectionColor;
			messagesContainer.AppendText(message.Date + " ");
			messagesContainer.SelectionColor = GetFactionColor(message.Character);
			messagesContainer.SelectionFont = new Font(messagesContainer.Font, FontStyle.Bold);
			messagesContainer.AppendText("[" + message.Character.Name + "]");
		    messagesContainer.SelectionFont = messagesContainer.Font;
			messagesContainer.SelectionColor = oldColor;
		    messagesContainer.AppendText(" ");
			
			// Loop over the sections of the text.
			var sections = PlayerStore.Instance.FindPlayerReferences(message.Message);
			foreach (var section in sections)
			{
				if (section.Character != null)
				{
					messagesContainer.SelectionColor = GetFactionColor(section.Character);
					messagesContainer.SelectionFont = new Font(messagesContainer.Font, FontStyle.Bold);
				}

				messagesContainer.AppendText(section.Text);
				messagesContainer.SelectionColor = oldColor;
				messagesContainer.SelectionFont = messagesContainer.Font;
			}

			// Reset back color
		    if (highlighted)
				messagesContainer.SelectionBackColor = oldBackColor;

            // Scroll to end
		    messagesContainer.Select(messagesContainer.Text.Length, 0);
            messagesContainer.ScrollToCaret();
		}
	}
}

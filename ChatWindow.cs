using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;
using MowChat.Data;

namespace MowChat
{
	public partial class ChatWindow : MetroForm
	{
		public Dictionary<ChatChannel, MetroTabPage> ChannelTabs { get; set; }

		public ChatWindow()
		{
			ChannelTabs = new Dictionary<ChatChannel, MetroTabPage>();

			InitializeComponent();
		}

		public void SetChatChannels(ChatChannelList list)
		{
			for (var i = 0; i < list.Records.Count; i++)
			{
				var channel = list.Records[i];
				if (ChannelTabs.ContainsKey(channel))
				{
					// Nothing to do
					continue;
				}

				// Create the tab page that will hold the chat
				var newTab = new MetroTabPage
				{
					CustomBackground = false,
					HorizontalScrollbar = false,
					HorizontalScrollbarBarColor = true,
					HorizontalScrollbarHighlightOnWheel = false,
					HorizontalScrollbarSize = 10,
					Location = new System.Drawing.Point(4, 35),
					Name = string.Format("chatTab{0}", i),
					Size = new System.Drawing.Size(589, 341),
					Style = MetroFramework.MetroColorStyle.Blue,
					StyleManager = null,
					TabIndex = i,
					Text = channel.Name,
					Theme = MetroFramework.MetroThemeStyle.Light,
					VerticalScrollbar = false,
					VerticalScrollbarBarColor = true,
					VerticalScrollbarHighlightOnWheel = false,
					VerticalScrollbarSize = 10,
				};

				// Add our custom chat control
				var chatControl = new ChatControl(channel);

				// Add to tab page
				newTab.Controls.Add(chatControl);

				ChannelTabs[channel] = newTab;
			}

			// We re-add all tabs to get the order right
			chatTabs.Controls.Clear();
			foreach (var kvp in ChannelTabs.OrderBy(kvp => kvp.Key.Id))
				chatTabs.Controls.Add(kvp.Value);
		}
	}
}

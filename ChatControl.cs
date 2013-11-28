using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MowChat.Data;

namespace MowChat
{
	public partial class ChatControl : MetroUserControl
	{
		public ChatChannel Channel { get; set; }

		public ChatControl(ChatChannel channel)
		{
			InitializeComponent();

			Channel = channel;

			// Anchor (grow) in all directions
			Anchor = (System.Windows.Forms.AnchorStyles)
				(System.Windows.Forms.AnchorStyles.Top | 
				 System.Windows.Forms.AnchorStyles.Bottom |
				 System.Windows.Forms.AnchorStyles.Left |
				 System.Windows.Forms.AnchorStyles.Right);

			// Get some chat history
			API.Instance.Get<ChatMessageList>(OnHistoryReceived, string.Format("chat/channels/{0}/history", Channel.Id));
		}

		private void OnHistoryReceived(ChatMessageList list)
		{
			foreach (var message in list.Records)
				AddMessage(message);
		}

		public void AddMessage(ChatMessage message)
		{
		}
	}
}

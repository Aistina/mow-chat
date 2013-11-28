using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MowChat.Data
{
	public class ChatChannelList : ResultList<ChatChannel>
	{
	}

	public class ChatChannel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public string TypeId { get; set; }
		public DateTime Created { get; set; }
		public int Active { get; set; }
		public string WebsyncChannel { get; set; }
	}
}

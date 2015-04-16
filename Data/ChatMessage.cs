using System;

namespace MowChat.Data
{
	public class ChatMessageList : ResultList<ChatMessage>
	{
	}

	public class ChatMessage : IHasCharacterData
	{
	    public int Id { get; set; }
	    public string Message { get; set; }
	    public DateTime Date { get; set; }
		public string UserCharacterName { get; set; }
        public int? UserCharacterTier { get; set; }

		public string Name { get { return UserCharacterName; } }

		// For backwards compatibility.
		public Character Character { get; set; }
	}
}

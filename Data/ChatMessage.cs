using System;

namespace MowChat.Data
{
	public class ChatMessageList : ResultList<ChatMessage>
	{
	}

	public class ChatMessage
	{
	    public int Id { get; set; }
	    public string Message { get; set; }
	    public DateTime Date { get; set; }
	    public Character Character { get; set; }
	}
}

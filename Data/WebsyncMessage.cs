using System.Collections.Generic;

namespace MowChat.Data
{
    public class WebsyncMessage
    {
        public string Type { get; set; }
        public List<ChatMessage> ChatMessages { get; set; }
    }
}

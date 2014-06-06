using System.Collections.Generic;

namespace MowChat.Data
{
    public class WrappedWebsyncMessage
    {
        // ReSharper disable once InconsistentNaming
        public string[] m_dataJson { get; set; }
    }

    public class WebsyncMessage
    {
        public string Type { get; set; }
        public List<ChatMessage> ChatMessages { get; set; }
    }
}

using System.Collections.Generic;

namespace MowChat.Data
{
    public class WrappedWebsyncMessage
    {
        // ReSharper disable once InconsistentNaming
        public int m_version { get; set; }
        // ReSharper disable once InconsistentNaming
        public string[] m_dataJson { get; set; }
        // ReSharper disable once InconsistentNaming
        public string m_dataJsonS { get; set; }
    }

    public class WebsyncMessage
    {
        public string Type { get; set; }
        public List<ChatMessage> ChatMessages { get; set; }
    }
}

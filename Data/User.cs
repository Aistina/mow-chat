using System.Collections.Generic;

namespace MowChat.Data
{
	public class User
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public int Admin { get; set; }
		public List<Character> Characters { get; set; }
	}
}

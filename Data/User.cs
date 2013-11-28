using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MowChat.Data
{
	class User
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public int Admin { get; set; }
		public List<Character> Characters { get; set; }
	}
}

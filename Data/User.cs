namespace MowChat.Data
{
	public class User
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public bool Admin { get; set; }
		public Character Character { get; set; }
	}
}

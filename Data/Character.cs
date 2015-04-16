namespace MowChat.Data
{
	public class Character : IHasCharacterData
	{
		public int Id { get; set; }
        public string Name { get; set; }
        public int? UserCharacterTier { get; set; }
	}
}

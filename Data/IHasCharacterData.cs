namespace MowChat.Data
{
	public interface IHasCharacterData
	{
        string Name { get; }
        int? UserCharacterTier { get; }
	}
}

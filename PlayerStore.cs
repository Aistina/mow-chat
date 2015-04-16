using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MowChat.Data;

namespace MowChat
{
	public class PlayerStore
	{
		/// <summary>
		/// A section of a message, optionally mentioning a character name.
		/// </summary>
		public class MessageSection
		{
			public string Text { get; private set; }
			public IHasCharacterData CharacterMention { get; private set; }

			public MessageSection(string text, IHasCharacterData character = null)
			{
				Text = text;
				CharacterMention = character;
			}
		}

		/// <summary>
		/// The instance of the API singleton.
		/// </summary>
		private static PlayerStore _instance;

		/// <summary>
		/// The instance of the API singleton.
		/// </summary>
		public static PlayerStore Instance
		{
			get { return _instance ?? (_instance = new PlayerStore()); }
		}

		/// <summary>
		/// Dictionary of all seen users.
		/// </summary>
		private Dictionary<string, IHasCharacterData> Characters { get; set; }

		/// <summary>
		/// A regex pattern to match any known player name.
		/// </summary>
		private string Pattern { get; set; }

		/// <summary>
		/// Constructor.
		/// </summary>
		private PlayerStore()
		{
			Characters = new Dictionary<string, IHasCharacterData>();
		}

		/// <summary>
		/// Add a character to the player store.
		/// </summary>
		/// <param name="c">The character to add.</param>
		public void StorePlayer(IHasCharacterData c)
		{
			if (c.Name == null)
			{
				var cm = c as ChatMessage;
				if (cm != null && cm.Character != null)
					StorePlayer(cm.Character);

				return;
			}

			var lowerName = c.Name.ToLowerInvariant();
			if (Characters.ContainsKey(lowerName)) return;

			Characters.Add(lowerName, c);
			Pattern = null;
		}

		/// <summary>
		/// Check if a piece of text mentions the currently selected character.
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <returns>True if the text contains the name of the current character.</returns>
		public static bool TextContainsMe(string text)
		{
			return Regex.IsMatch(text, API.Instance.CurrentUser.Character.Name, RegexOptions.IgnoreCase);
		}

		/// <summary>
		/// Find all references to a player in a piece of text, and return the text split up in
		/// sections of non-mentions and mentions.
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <returns>A list of text sections.</returns>
		public IEnumerable<MessageSection> FindPlayerReferences(string text)
		{
			var pattern = CompilePattern();
			var matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);
			var result = new List<MessageSection>();

			// Extract each match from the text
			foreach (Match match in matches)
			{
				// Find part in text before mention
				var index = text.IndexOf(match.Value, StringComparison.Ordinal);
				if (index > 0)
				{
					result.Add(new MessageSection(text.Substring(0, index)));
				}

				// Add the character mention to the result and continue after that
			    var lowerMatch = match.Value.ToLowerInvariant();
				var character = Characters.ContainsKey(lowerMatch) ? Characters[lowerMatch] : null;

				result.Add(new MessageSection(text.Substring(index, match.Value.Length), character));
				text = text.Substring(index + match.Value.Length);
			}

			// Always add the remainder
			if (text.Length > 0)
				result.Add(new MessageSection(text));

			return result;
		}

		/// <summary>
		/// Create a regex pattern to match any registered player name.
		/// </summary>
		/// <returns>A regex pattern.</returns>
		private string CompilePattern()
		{
			if (string.IsNullOrEmpty(Pattern))
				Pattern = "(" + string.Join("|", Characters.Keys) + ")";

			return Pattern;
		}
	}
}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace ktsu.io.EmojiHelper;

public static class EmojiHelper
{
	private static Dictionary<Codepoint, string> EmojiNames { get; } = new();

	static EmojiHelper()
	{
		string textData = File.ReadAllText("emoji-zwj-sequences.txt");
		string[] lines = textData.Split('\n');
		foreach (string line in lines)
		{
			if (line.StartsWith('#'))
			{
				continue;
			}

			string[] parts = line.Split(';');
			if (parts.Length < 2)
			{
				continue;
			}

			string codepoint = parts[0].Trim();
			string cldrName = parts[2].Trim();
			EmojiNames.Add(new Codepoint(codepoint), cldrName);
		}
	}

	public static string GetEmojiName(string codepoint) => GetEmojiName(new Codepoint(codepoint));
	public static string GetEmojiName(Codepoint codepoint) =>
		EmojiNames.TryGetValue(codepoint, out string? name) ? name : "Unknown";
}

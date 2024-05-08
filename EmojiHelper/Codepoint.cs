#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace EmojiHelper;

public class Codepoint
{
	private readonly string code;

	public Codepoint(string codepoint)
	{
		// remove any charachters that are not hex digits by replacing them with spaces
		string hexDigits = new(codepoint.Select(c => Uri.IsHexDigit(c) ? c : ' ').ToArray());
		// remove repeated spaces
		string[] segments = hexDigits.Split(' ', StringSplitOptions.RemoveEmptyEntries);
		// join the segments with a space
		code = string.Join(" ", segments).ToUpperInvariant();
	}

	public override bool Equals(object? obj) =>
		obj is Codepoint other && code == other.code;

	public override int GetHashCode() => code.GetHashCode(StringComparison.Ordinal);

	public override string ToString() => code;
}

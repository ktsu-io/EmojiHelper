namespace EmojiHelper
{
	public class Codepoint
	{
		private readonly string _code;

		public Codepoint(string codepoint)
		{
			// remove any charachters that are not hex digits by replacing them with spaces
			string hexDigits = new(codepoint.Select(c => Uri.IsHexDigit(c) ? c : ' ').ToArray());
			// remove repeated spaces
			string[] segments = hexDigits.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			// join the segments with a space
			_code = string.Join(" ", segments).ToUpperInvariant();
		}

		public override bool Equals(object? obj)
		{
			if (obj is Codepoint other)
			{
				return _code == other._code;
			}

			return false;
		}

		public override int GetHashCode()
		{
			return _code.GetHashCode();
		}

		public override string ToString()
		{
			return _code;
		}
	}
}

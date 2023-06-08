using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// A "glob" is a string matching pattern. It is similar to the
/// matches available in the file system (*.cs, for example). The Glob
/// class implements this string matching.
/// </summary>
/// <remarks>Glob supports the following metacharacters:
///     * - match zero or more characters
///     ? - match any one character
/// [abc] - match one character if it's in the characters inside the brackets.
/// All other characters in the glob are literals.
/// </remarks>
public class Glob
{
	private readonly Regex pattern;

	/// <summary>
	/// Constructs a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.Glob" /> instance that matches the given pattern.
	/// </summary>
	/// <remarks>
	/// The pattern match is case sensitive by default.
	/// </remarks>
	/// <param name="pattern">Pattern to use. See <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.Glob" /> summary for
	/// details of the pattern.</param>
	public Glob(string pattern)
		: this(pattern, caseSensitive: true)
	{
	}

	/// <summary>
	/// Constructs a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.Glob" /> instance that matches the given pattern.
	/// </summary>
	/// <param name="pattern">The pattern to use. See <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.Glob" /> summary for
	/// details of the patterns supported.</param>
	/// <param name="caseSensitive">If true, perform a case sensitive match. 
	/// If false, perform a case insensitive comparison.</param>
	public Glob(string pattern, bool caseSensitive)
	{
		this.pattern = GlobPatternToRegex(pattern, caseSensitive);
	}

	/// <summary>
	/// Checks to see if the given string matches the pattern.
	/// </summary>
	/// <param name="s">String to check.</param>
	/// <returns>True if it matches, false if it doesn't.</returns>
	public bool IsMatch(string s)
	{
		return pattern.IsMatch(s);
	}

	private static Regex GlobPatternToRegex(string pattern, bool caseSensitive)
	{
		StringBuilder stringBuilder = new StringBuilder(pattern);
		string[] array = new string[9] { "\\", ".", "$", "^", "{", "(", "|", ")", "+" };
		string[] array2 = array;
		foreach (string text in array2)
		{
			stringBuilder.Replace(text, "\\" + text);
		}
		stringBuilder.Replace("*", ".*");
		stringBuilder.Replace("?", ".");
		stringBuilder.Insert(0, "^");
		stringBuilder.Append("$");
		RegexOptions options = ((!caseSensitive) ? RegexOptions.IgnoreCase : RegexOptions.None);
		return new Regex(stringBuilder.ToString(), options);
	}
}

namespace Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

/// <summary>
/// Class that tracks the current input state of the parser.
/// </summary>
internal class InputStream
{
	private readonly string input;

	private int currentPosition;

	public bool AtEnd => currentPosition == input.Length;

	public char CurrentChar => input[currentPosition];

	public int CurrentPosition => currentPosition;

	public InputStream(string input)
	{
		this.input = input ?? string.Empty;
	}

	public void Consume(int numChars)
	{
		currentPosition = Clamp(currentPosition + numChars);
	}

	public void BackupTo(int bookmark)
	{
		currentPosition = Clamp(bookmark);
	}

	private int Clamp(int newPosition)
	{
		if (newPosition < 0)
		{
			newPosition = 0;
		}
		if (newPosition > input.Length)
		{
			newPosition = input.Length;
		}
		return newPosition;
	}
}

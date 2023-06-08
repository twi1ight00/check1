namespace System.Linq.Dynamic;

/// <summary>
/// ParseException
/// </summary>
public sealed class ParseException : Exception
{
	private int position;

	/// <summary>
	/// Position
	/// </summary>
	public int Position => position;

	/// <summary>
	/// ParseException
	/// </summary>
	/// <param name="message"></param>
	/// <param name="position"></param>
	public ParseException(string message, int position)
		: base(message)
	{
		this.position = position;
	}

	/// <summary>
	/// ToString
	/// </summary>
	/// <returns></returns>
	public override string ToString()
	{
		return $"{Message} (at index {position})";
	}
}

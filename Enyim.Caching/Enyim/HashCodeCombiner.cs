namespace Enyim;

/// <summary>
/// Combines multiple hash codes into one.
/// </summary>
public class HashCodeCombiner
{
	private int currentHash;

	public int CurrentHash => currentHash;

	public HashCodeCombiner()
		: this(5381)
	{
	}

	public HashCodeCombiner(int initialValue)
	{
		currentHash = initialValue;
	}

	public static int Combine(int code1, int code2)
	{
		return ((code1 << 5) + code1) ^ code2;
	}

	public void Add(int value)
	{
		currentHash = Combine(currentHash, value);
	}

	public static int Combine(int code1, int code2, int code3)
	{
		return Combine(Combine(code1, code2), code3);
	}

	public static int Combine(int code1, int code2, int code3, int code4)
	{
		return Combine(Combine(code1, code2), Combine(code3, code4));
	}
}

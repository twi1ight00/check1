namespace ns181;

internal class Class4955 : Class4943
{
	protected char char_0;

	internal bool bool_0;

	public Class4955(int blockProgressionOffset, int bidiLevel, char space, bool adjustable)
		: base(blockProgressionOffset, bidiLevel)
	{
		char_0 = space;
		bool_0 = adjustable;
	}

	public string method_51()
	{
		return char_0.ToString();
	}

	public bool method_52()
	{
		return bool_0;
	}
}

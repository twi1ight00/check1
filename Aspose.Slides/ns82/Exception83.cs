namespace ns82;

internal class Exception83 : Exception77
{
	private int int_4;

	public int Expecting
	{
		get
		{
			return int_4;
		}
		set
		{
			int_4 = value;
		}
	}

	public Exception83()
	{
	}

	public Exception83(int expecting, Interface388 input)
		: base(input)
	{
		int_4 = expecting;
	}

	public override string ToString()
	{
		return "MismatchedTokenException(" + UnexpectedType + "!=" + int_4 + ")";
	}
}

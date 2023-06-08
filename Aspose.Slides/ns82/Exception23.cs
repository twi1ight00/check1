namespace ns82;

internal class Exception23 : Exception17
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

	public Exception23()
	{
	}

	public Exception23(int expecting, Interface107 input)
		: base(input)
	{
		int_4 = expecting;
	}

	public override string ToString()
	{
		return "MismatchedTokenException(" + UnexpectedType + "!=" + int_4 + ")";
	}
}

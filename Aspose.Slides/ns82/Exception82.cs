namespace ns82;

internal class Exception82 : Exception77
{
	private int int_4;

	private int int_5;

	public int A
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

	public int B
	{
		get
		{
			return int_5;
		}
		set
		{
			int_5 = value;
		}
	}

	public Exception82()
	{
	}

	public Exception82(int a, int b, Interface388 input)
		: base(input)
	{
		int_4 = a;
		int_5 = b;
	}

	public override string ToString()
	{
		return "MismatchedNotSetException(" + UnexpectedType + " not in [" + int_4 + "," + int_5 + "])";
	}
}

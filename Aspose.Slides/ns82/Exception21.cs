namespace ns82;

internal class Exception21 : Exception20
{
	public Exception21()
	{
	}

	public Exception21(Class4391 expecting, Interface107 input)
		: base(expecting, input)
	{
	}

	public override string ToString()
	{
		return string.Concat("MismatchedNotSetException(", UnexpectedType, "!=", class4391_0, ")");
	}
}

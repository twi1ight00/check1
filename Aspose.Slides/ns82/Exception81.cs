namespace ns82;

internal class Exception81 : Exception80
{
	public Exception81()
	{
	}

	public Exception81(Class7332 expecting, Interface388 input)
		: base(expecting, input)
	{
	}

	public override string ToString()
	{
		return string.Concat("MismatchedNotSetException(", UnexpectedType, "!=", class7332_0, ")");
	}
}

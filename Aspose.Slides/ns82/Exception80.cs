namespace ns82;

internal class Exception80 : Exception77
{
	public Class7332 class7332_0;

	public Exception80()
	{
	}

	public Exception80(Class7332 expecting, Interface388 input)
		: base(input)
	{
		class7332_0 = expecting;
	}

	public override string ToString()
	{
		return string.Concat("MismatchedSetException(", UnexpectedType, "!=", class7332_0, ")");
	}
}

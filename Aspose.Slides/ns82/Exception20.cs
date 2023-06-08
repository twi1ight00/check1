namespace ns82;

internal class Exception20 : Exception17
{
	public Class4391 class4391_0;

	public Exception20()
	{
	}

	public Exception20(Class4391 expecting, Interface107 input)
		: base(input)
	{
		class4391_0 = expecting;
	}

	public override string ToString()
	{
		return string.Concat("MismatchedSetException(", UnexpectedType, "!=", class4391_0, ")");
	}
}

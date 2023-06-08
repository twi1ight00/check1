namespace ns82;

internal class Exception25 : Exception23
{
	public Interface86 UnexpectedToken => interface86_0;

	public Exception25()
	{
	}

	public Exception25(int expecting, Interface107 input)
		: base(expecting, input)
	{
	}

	public override string ToString()
	{
		string text = ", expected " + base.Expecting;
		if (base.Expecting == 0)
		{
			text = string.Empty;
		}
		if (interface86_0 == null)
		{
			return "UnwantedTokenException(found=" + text + ")";
		}
		return "UnwantedTokenException(found=" + interface86_0.Text + text + ")";
	}
}

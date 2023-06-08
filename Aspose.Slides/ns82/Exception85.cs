namespace ns82;

internal class Exception85 : Exception83
{
	public Interface392 UnexpectedToken => interface392_0;

	public Exception85()
	{
	}

	public Exception85(int expecting, Interface388 input)
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
		if (interface392_0 == null)
		{
			return "UnwantedTokenException(found=" + text + ")";
		}
		return "UnwantedTokenException(found=" + interface392_0.Text + text + ")";
	}
}

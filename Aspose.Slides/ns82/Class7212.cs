using ns83;

namespace ns82;

internal class Class7212 : Class7211
{
	public Interface388 interface388_0;

	public Interface392 interface392_1;

	public Interface392 interface392_2;

	public Exception77 exception77_0;

	public override bool IsNil => false;

	public override int Type => 0;

	public override string Text
	{
		get
		{
			string text = null;
			if (interface392_1 != null)
			{
				int tokenIndex = interface392_1.TokenIndex;
				int num = interface392_2.TokenIndex;
				if (interface392_2.Type == Class7346.int_7)
				{
					num = ((Interface393)interface388_0).imethod_7();
				}
				return ((Interface393)interface388_0).ToString(tokenIndex, num);
			}
			if (interface392_1 is Interface386)
			{
				return ((Interface389)interface388_0).ToString(interface392_1, interface392_2);
			}
			return "<unknown>";
		}
	}

	public Class7212(Interface393 input, Interface392 start, Interface392 stop, Exception77 e)
	{
		if (stop == null || (stop.TokenIndex < start.TokenIndex && stop.Type != Class7346.int_7))
		{
			stop = start;
		}
		interface388_0 = input;
		interface392_1 = start;
		interface392_2 = stop;
		exception77_0 = e;
	}

	public override string ToString()
	{
		if (exception77_0 is Exception84)
		{
			return "<missing type: " + ((Exception84)exception77_0).MissingType + ">";
		}
		if (exception77_0 is Exception85)
		{
			return string.Concat("<extraneous: ", ((Exception85)exception77_0).UnexpectedToken, ", resync=", Text, ">");
		}
		if (exception77_0 is Exception83)
		{
			return string.Concat("<mismatched token: ", exception77_0.Token, ", resync=", Text, ">");
		}
		if (exception77_0 is Exception87)
		{
			return string.Concat("<unexpected: ", exception77_0.Token, ", resync=", Text, ">");
		}
		return "<error: " + Text + ">";
	}
}

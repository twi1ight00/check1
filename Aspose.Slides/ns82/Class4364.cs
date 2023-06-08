using ns83;

namespace ns82;

internal class Class4364 : Class4363
{
	public Interface107 interface107_0;

	public Interface86 interface86_1;

	public Interface86 interface86_2;

	public Exception17 exception17_0;

	public override bool IsNil => false;

	public override int Type => 0;

	public override string Text
	{
		get
		{
			string text = null;
			if (interface86_1 != null)
			{
				int tokenIndex = interface86_1.TokenIndex;
				int num = interface86_2.TokenIndex;
				if (interface86_2.Type == Class4398.int_7)
				{
					num = ((Interface111)interface107_0).imethod_7();
				}
				return ((Interface111)interface107_0).ToString(tokenIndex, num);
			}
			if (interface86_1 is Interface105)
			{
				return ((Interface108)interface107_0).ToString(interface86_1, interface86_2);
			}
			return "<unknown>";
		}
	}

	public Class4364(Interface111 input, Interface86 start, Interface86 stop, Exception17 e)
	{
		if (stop == null || (stop.TokenIndex < start.TokenIndex && stop.Type != Class4398.int_7))
		{
			stop = start;
		}
		interface107_0 = input;
		interface86_1 = start;
		interface86_2 = stop;
		exception17_0 = e;
	}

	public override string ToString()
	{
		if (exception17_0 is Exception24)
		{
			return "<missing type: " + ((Exception24)exception17_0).MissingType + ">";
		}
		if (exception17_0 is Exception25)
		{
			return string.Concat("<extraneous: ", ((Exception25)exception17_0).UnexpectedToken, ", resync=", Text, ">");
		}
		if (exception17_0 is Exception23)
		{
			return string.Concat("<mismatched token: ", exception17_0.Token, ", resync=", Text, ">");
		}
		if (exception17_0 is Exception27)
		{
			return string.Concat("<unexpected: ", exception17_0.Token, ", resync=", Text, ">");
		}
		return "<error: " + Text + ">";
	}
}

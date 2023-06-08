using System;

namespace ns171;

internal class Class5657 : Class5656
{
	private bool bool_0 = true;

	private char char_0;

	public Class5657(char c)
	{
		char_0 = c;
	}

	public override bool imethod_0()
	{
		return bool_0;
	}

	public override char vmethod_0()
	{
		if (!bool_0)
		{
			throw new InvalidOperationException();
		}
		bool_0 = false;
		return char_0;
	}
}

using System;

namespace ns256;

internal class Class6373 : Interface289
{
	private Interface290 interface290_0;

	private string string_0;

	public string X => string_0;

	public Class6373(string[] formulaParts, Interface290 callback)
	{
		if (formulaParts.Length < 2)
		{
			throw new ArgumentOutOfRangeException("formulaParts", "Wrong number of formula parts.");
		}
		string_0 = formulaParts[1];
		interface290_0 = callback;
	}

	public double imethod_0(Interface288 guideValueProvider)
	{
		double x = Class6369.smethod_0(X, guideValueProvider);
		return interface290_0.imethod_0(x);
	}
}

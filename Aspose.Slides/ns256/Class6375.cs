using System;

namespace ns256;

internal class Class6375 : Interface289
{
	private Interface292 interface292_0;

	private string string_0;

	private string string_1;

	public string X => string_0;

	public string Y => string_1;

	public Class6375(string[] formulaParts, Interface292 callback)
	{
		if (formulaParts.Length < 3)
		{
			throw new ArgumentOutOfRangeException("formulaParts", "Wrong number of formula parts.");
		}
		string_0 = formulaParts[1];
		string_1 = formulaParts[2];
		interface292_0 = callback;
	}

	public double imethod_0(Interface288 guideValueProvider)
	{
		double x = Class6369.smethod_0(X, guideValueProvider);
		double y = Class6369.smethod_0(Y, guideValueProvider);
		return interface292_0.imethod_0(x, y);
	}
}

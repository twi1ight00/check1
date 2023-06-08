using System;

namespace ns256;

internal class Class6374 : Interface289
{
	private Interface291 interface291_0;

	private string string_0;

	private string string_1;

	private string string_2;

	public string X => string_0;

	public string Y => string_1;

	public string Z => string_2;

	public Class6374(string[] formulaParts, Interface291 callback)
	{
		if (formulaParts.Length < 4)
		{
			throw new ArgumentOutOfRangeException("formulaParts", "Wrong number of formula parts.");
		}
		string_0 = formulaParts[1];
		string_1 = formulaParts[2];
		string_2 = formulaParts[3];
		interface291_0 = callback;
	}

	public double imethod_0(Interface288 guideValueProvider)
	{
		double x = Class6369.smethod_0(X, guideValueProvider);
		double y = Class6369.smethod_0(Y, guideValueProvider);
		double z = Class6369.smethod_0(Z, guideValueProvider);
		return interface291_0.imethod_0(x, y, z);
	}
}

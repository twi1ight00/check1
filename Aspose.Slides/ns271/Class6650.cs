using System;
using System.Drawing;
using ns218;
using ns224;

namespace ns271;

internal abstract class Class6650
{
	public Class6730 method_0(string familyName, FontStyle style, string altFamilyName)
	{
		Class6730 @class = vmethod_0(familyName, style);
		if (@class == null && Class5964.smethod_20(altFamilyName))
		{
			@class = vmethod_0(altFamilyName, style);
		}
		if (@class == null)
		{
			@class = vmethod_1(style);
		}
		if (@class == null)
		{
			@class = vmethod_2();
		}
		if (@class == null)
		{
			throw new InvalidOperationException("Cannot find any fonts installed on the system.");
		}
		return @class;
	}

	public Class5999 method_1(string familyName, float sizePoints, FontStyle style)
	{
		return method_3(familyName, sizePoints, style, null);
	}

	public Class5999 method_2(string familyName, float sizePoints, FontStyle style, Enum748 fontCapitals)
	{
		return method_4(familyName, sizePoints, style, null, fontCapitals);
	}

	public Class5999 method_3(string familyName, float sizePoints, FontStyle style, string altFamilyName)
	{
		return new Class5999(sizePoints, style, method_0(familyName, style, altFamilyName));
	}

	public Class5999 method_4(string familyName, float sizePoints, FontStyle style, string altFamilyName, Enum748 fontCapitals)
	{
		return new Class5999(sizePoints, style, method_0(familyName, style, altFamilyName), fontCapitals);
	}

	public abstract Class6730 vmethod_0(string familyName, FontStyle style);

	internal abstract Class6730 vmethod_1(FontStyle style);

	internal abstract Class6730 vmethod_2();
}

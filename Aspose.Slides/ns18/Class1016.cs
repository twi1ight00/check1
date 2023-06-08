using System;
using Aspose.Slides;
using ns56;

namespace ns18;

internal class Class1016
{
	public static object smethod_0(Class2272 valElementData)
	{
		switch (valElementData.Value.Name)
		{
		case "clrVal":
		{
			Class1814 colorElementData = (Class1814)valElementData.Value.Object;
			IColorFormat colorFormat = new ColorFormat(null);
			Class930.smethod_0(colorFormat, colorElementData);
			return colorFormat;
		}
		case "boolVal":
		{
			Class2271 class4 = (Class2271)valElementData.Value.Object;
			return class4.Val;
		}
		case "fltVal":
		{
			Class2273 class3 = (Class2273)valElementData.Value.Object;
			return class3.Val;
		}
		case "intVal":
		{
			Class2274 class2 = (Class2274)valElementData.Value.Object;
			return class2.Val;
		}
		default:
			throw new Exception();
		case "strVal":
		{
			Class2275 @class = (Class2275)valElementData.Value.Object;
			return @class.Val;
		}
		}
	}

	public static void smethod_1(object value, Class2272 valElementData)
	{
		if (value is string)
		{
			Class2275 @class = (Class2275)valElementData.delegate2773_0("strVal").Object;
			@class.Val = (string)value;
			return;
		}
		if (value is int)
		{
			Class2274 class2 = (Class2274)valElementData.delegate2773_0("intVal").Object;
			class2.Val = (int)value;
			return;
		}
		if (value is float)
		{
			Class2273 class3 = (Class2273)valElementData.delegate2773_0("fltVal").Object;
			class3.Val = (float)value;
			return;
		}
		if (value is bool)
		{
			Class2271 class4 = (Class2271)valElementData.delegate2773_0("boolVal").Object;
			class4.Val = (bool)value;
			return;
		}
		if (!(value is IColorFormat))
		{
			throw new Exception();
		}
		Class1814 colorElementData = (Class1814)valElementData.delegate2773_0("clrVal").Object;
		Class930.smethod_3((IColorFormat)value, colorElementData);
	}
}

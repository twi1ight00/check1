using System.Collections.Generic;
using ns218;
using ns250;
using ns251;
using ns252;
using ns261;

namespace ns248;

internal class Class6271 : Interface264
{
	private Class5944 class5944_0;

	public Interface274 imethod_0(Class5944 reader)
	{
		class5944_0 = reader;
		string localName = class5944_0.LocalName;
		Interface274 result = null;
		while (class5944_0.method_0(localName))
		{
			switch (class5944_0.LocalName)
			{
			case "hslClr":
			case "prstClr":
			case "schemeClr":
			case "scrgbClr":
			case "srgbClr":
			case "sysClr":
			{
				Interface274 @interface = imethod_1(class5944_0);
				if (@interface != null)
				{
					result = @interface;
				}
				break;
			}
			default:
				class5944_0.method_2();
				break;
			}
		}
		return result;
	}

	public Interface274 imethod_1(Class5944 reader)
	{
		class5944_0 = reader;
		return reader.LocalName switch
		{
			"hslClr" => method_9(), 
			"prstClr" => method_8(), 
			"schemeClr" => method_7(), 
			"scrgbClr" => method_6(), 
			"srgbClr" => method_5(), 
			"sysClr" => method_0(), 
			_ => null, 
		};
	}

	private Class6284 method_0()
	{
		Class6291 @class = new Class6291();
		@class.Value = class5944_0.method_4("val", string.Empty);
		@class.LastColor = class5944_0.method_4("lastClr", string.Empty);
		@class.ColorModifiers = method_1();
		return @class;
	}

	private List<Interface275> method_1()
	{
		List<Interface275> list = new List<Interface275>();
		string localName = class5944_0.LocalName;
		while (class5944_0.method_0(localName))
		{
			switch (class5944_0.LocalName)
			{
			case "alpha":
				list.Add(method_2(new Class6294()));
				break;
			case "alphaMod":
				list.Add(method_2(new Class6295()));
				break;
			case "alphaOff":
				list.Add(method_2(new Class6296()));
				break;
			case "blue":
				list.Add(method_2(new Class6297()));
				break;
			case "blueMod":
				list.Add(method_2(new Class6298()));
				break;
			case "blueOff":
				list.Add(method_2(new Class6299()));
				break;
			case "comp":
				list.Add(new Class6315());
				break;
			case "gamma":
				list.Add(new Class6316());
				break;
			case "gray":
				list.Add(new Class6317());
				break;
			case "green":
				list.Add(method_2(new Class6300()));
				break;
			case "greenMod":
				list.Add(method_2(new Class6301()));
				break;
			case "greenOff":
				list.Add(method_2(new Class6302()));
				break;
			case "hue":
				method_4(list);
				break;
			case "hueMod":
				list.Add(method_2(new Class6303()));
				break;
			case "hueOff":
				method_3(list);
				break;
			case "inv":
				list.Add(new Class6320());
				break;
			case "invGamma":
				list.Add(new Class6321());
				break;
			case "lum":
				list.Add(method_2(new Class6304()));
				break;
			case "lumMod":
				list.Add(method_2(new Class6305()));
				break;
			case "lumOff":
				list.Add(method_2(new Class6306()));
				break;
			case "red":
				list.Add(method_2(new Class6307()));
				break;
			case "redMod":
				list.Add(method_2(new Class6308()));
				break;
			case "redOff":
				list.Add(method_2(new Class6309()));
				break;
			case "sat":
				list.Add(method_2(new Class6310()));
				break;
			case "satMod":
				list.Add(method_2(new Class6311()));
				break;
			case "satOff":
				list.Add(method_2(new Class6312()));
				break;
			case "shade":
				list.Add(method_2(new Class6313()));
				break;
			case "tint":
				list.Add(method_2(new Class6314()));
				break;
			default:
				class5944_0.method_2();
				break;
			}
		}
		return list;
	}

	private Class6293 method_2(Class6293 modifier)
	{
		modifier.Value = new Class6329(class5944_0.method_6("val", 0.0));
		return modifier;
	}

	private void method_3(List<Interface275> colorModifiers)
	{
		Class6319 @class = new Class6319();
		@class.Value = new Class6323(class5944_0.method_6("val", 0.0));
		colorModifiers.Add(@class);
	}

	private void method_4(List<Interface275> colorModifiers)
	{
		Class6318 @class = new Class6318();
		@class.Value = new Class6323(class5944_0.method_6("val", 0.0));
		colorModifiers.Add(@class);
	}

	private Class6284 method_5()
	{
		Class6285 @class = new Class6285();
		@class.Value = class5944_0.method_4("val", string.Empty);
		@class.ColorModifiers = method_1();
		return @class;
	}

	private Class6284 method_6()
	{
		Class6287 @class = new Class6287();
		@class.R = new Class6331(class5944_0.method_4("r", string.Empty));
		@class.G = new Class6331(class5944_0.method_4("g", string.Empty));
		@class.B = new Class6331(class5944_0.method_4("b", string.Empty));
		@class.ColorModifiers = method_1();
		return @class;
	}

	private Interface274 method_7()
	{
		string text = class5944_0.method_4("val", string.Empty);
		if (text == "phClr")
		{
			Class6288 @class = new Class6288();
			@class.ColorModifiers = method_1();
			return @class;
		}
		Class6290 class2 = new Class6290();
		class2.Value = Class6421.smethod_0(text);
		class2.ColorModifiers = method_1();
		return class2;
	}

	private Class6284 method_8()
	{
		Class6289 @class = new Class6289();
		@class.Value = class5944_0.method_4("val", string.Empty);
		@class.ColorModifiers = method_1();
		return @class;
	}

	private Class6284 method_9()
	{
		Class6286 @class = new Class6286();
		@class.Hue = new Class6323(class5944_0.method_5("hue", 0));
		@class.Luminance = new Class6331(class5944_0.method_4("lum", string.Empty));
		@class.Saturation = new Class6331(class5944_0.method_4("sat", string.Empty));
		@class.ColorModifiers = method_1();
		return @class;
	}
}

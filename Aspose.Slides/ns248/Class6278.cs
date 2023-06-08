using ns218;
using ns252;
using ns258;

namespace ns248;

internal class Class6278 : Interface268
{
	private Interface266 interface266_0;

	private Class5944 class5944_0;

	public Interface266 FillBuilder
	{
		get
		{
			if (interface266_0 == null)
			{
				interface266_0 = new Class6274();
			}
			return interface266_0;
		}
		set
		{
			interface266_0 = value;
		}
	}

	public Class6400 imethod_0(Class5944 reader)
	{
		if (reader.LocalName != "ln")
		{
			return null;
		}
		class5944_0 = reader;
		Class6400 @class = new Class6400();
		method_7(@class);
		method_0(@class);
		return @class;
	}

	private void method_0(Class6400 outline)
	{
		while (class5944_0.method_0("ln"))
		{
			switch (class5944_0.LocalName)
			{
			case "gradFill":
			case "pattFill":
			case "noFill":
			case "solidFill":
				outline.Fill = FillBuilder.imethod_0(class5944_0);
				break;
			case "prstDash":
				outline.Dash = method_4();
				break;
			case "custDash":
				outline.Dash = method_5();
				break;
			case "headEnd":
				outline.HeadLineEndStyle = new Class6398();
				method_1(outline.HeadLineEndStyle);
				break;
			case "tailEnd":
				outline.TailLineEndStyle = new Class6399();
				method_1(outline.TailLineEndStyle);
				break;
			default:
				class5944_0.method_2();
				break;
			}
		}
	}

	private void method_1(Class6397 endStyle)
	{
		endStyle.Length = method_2("len");
		endStyle.Type = method_3();
		endStyle.Width = method_2("w");
	}

	private Enum813 method_2(string attribureName)
	{
		return class5944_0.method_4(attribureName, string.Empty) switch
		{
			"lg" => Enum813.const_1, 
			"med" => Enum813.const_2, 
			"sm" => Enum813.const_0, 
			_ => Enum813.const_0, 
		};
	}

	private Enum814 method_3()
	{
		return class5944_0.method_4("type", string.Empty) switch
		{
			"none" => Enum814.const_0, 
			"triangle" => Enum814.const_5, 
			"stealth" => Enum814.const_4, 
			"diamond" => Enum814.const_2, 
			"oval" => Enum814.const_3, 
			"arrow" => Enum814.const_1, 
			_ => Enum814.const_0, 
		};
	}

	private Class6393 method_4()
	{
		Class6395 @class = new Class6395();
		switch (class5944_0.method_4("val", string.Empty))
		{
		case "solid":
			@class.Preset = Enum816.const_0;
			break;
		case "dot":
			@class.Preset = Enum816.const_3;
			break;
		case "dash":
			@class.Preset = Enum816.const_1;
			break;
		case "lgDash":
			@class.Preset = Enum816.const_4;
			break;
		case "dashDot":
			@class.Preset = Enum816.const_2;
			break;
		case "lgDashDot":
			@class.Preset = Enum816.const_5;
			break;
		case "lgDashDotDot":
			@class.Preset = Enum816.const_6;
			break;
		case "sysDash":
			@class.Preset = Enum816.const_7;
			break;
		case "sysDot":
			@class.Preset = Enum816.const_10;
			break;
		case "sysDashDot":
			@class.Preset = Enum816.const_8;
			break;
		case "sysDashDotDot":
			@class.Preset = Enum816.const_9;
			break;
		}
		return @class;
	}

	private Class6393 method_5()
	{
		Class6394 @class = new Class6394();
		while (class5944_0.method_0("custDash"))
		{
			string localName;
			if ((localName = class5944_0.LocalName) != null && localName == "ds")
			{
				@class.DashStops.Add(method_6());
			}
			else
			{
				class5944_0.method_2();
			}
		}
		return @class;
	}

	private Class6396 method_6()
	{
		Class6396 @class = new Class6396();
		@class.DashLength = new Class6329(class5944_0.method_6("d", 0.0));
		@class.SpaceLength = new Class6329(class5944_0.method_6("sp", 0.0));
		return @class;
	}

	private void method_7(Class6400 outline)
	{
		outline.Width = method_11();
		outline.CompoundLineType = method_10();
		outline.LineEndingCapType = method_9();
		outline.StrokeAlignment = method_8();
	}

	private Enum815 method_8()
	{
		return class5944_0.method_4("algn", string.Empty) switch
		{
			"in" => Enum815.const_1, 
			"ctr" => Enum815.const_0, 
			_ => Enum815.const_0, 
		};
	}

	private Enum812 method_9()
	{
		return class5944_0.method_4("cap", string.Empty) switch
		{
			"flat" => Enum812.const_1, 
			"sq" => Enum812.const_0, 
			"rnd" => Enum812.const_2, 
			_ => Enum812.const_1, 
		};
	}

	private Enum811 method_10()
	{
		return class5944_0.method_4("cmpd", string.Empty) switch
		{
			"tri" => Enum811.const_4, 
			"thinThick" => Enum811.const_3, 
			"thickThin" => Enum811.const_2, 
			"dbl" => Enum811.const_1, 
			"sng" => Enum811.const_0, 
			_ => Enum811.const_0, 
		};
	}

	private double method_11()
	{
		return class5944_0.method_6("w", 0.0);
	}
}

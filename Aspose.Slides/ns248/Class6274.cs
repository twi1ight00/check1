using System.Collections.Generic;
using System.Drawing.Drawing2D;
using ns218;
using ns249;
using ns252;
using ns254;

namespace ns248;

internal class Class6274 : Interface266
{
	private Interface264 interface264_0;

	private Interface265 interface265_0;

	private Class5944 class5944_0;

	public Interface264 ColorBuilder
	{
		get
		{
			if (interface264_0 == null)
			{
				interface264_0 = new Class6271();
			}
			return interface264_0;
		}
		set
		{
			interface264_0 = value;
		}
	}

	internal Interface265 EffectBuilder
	{
		get
		{
			if (interface265_0 == null)
			{
				interface265_0 = new Class6273();
			}
			return interface265_0;
		}
		set
		{
			interface265_0 = value;
		}
	}

	public Class6350 imethod_0(Class5944 reader)
	{
		class5944_0 = reader;
		return reader.LocalName switch
		{
			"blipFill" => method_10(), 
			"gradFill" => method_2(), 
			"grpFill" => smethod_1(), 
			"noFill" => smethod_0(), 
			"pattFill" => method_1(), 
			"solidFill" => method_0(), 
			_ => null, 
		};
	}

	private Class6356 method_0()
	{
		Class6356 @class = new Class6356();
		@class.Color = ColorBuilder.imethod_0(class5944_0);
		return @class;
	}

	private Class6355 method_1()
	{
		Class6355 @class = new Class6355();
		@class.FillPresetPattern = method_17();
		while (class5944_0.method_0("solidFill"))
		{
			switch (class5944_0.LocalName)
			{
			case "fgClr":
				@class.ForegroundColor = ColorBuilder.imethod_0(class5944_0);
				break;
			case "bgClr":
				@class.BackgroundColor = ColorBuilder.imethod_0(class5944_0);
				break;
			default:
				class5944_0.method_2();
				break;
			}
		}
		return @class;
	}

	private static Class6354 smethod_0()
	{
		return new Class6354();
	}

	private static Class6353 smethod_1()
	{
		return new Class6353();
	}

	private Class6352 method_2()
	{
		Class6352 @class = new Class6352();
		@class.TileFlipMode = method_9();
		@class.RotateWithShape = class5944_0.method_7("rotWithShape", defaultValue: false);
		while (class5944_0.method_0("gradFill"))
		{
			switch (class5944_0.LocalName)
			{
			case "tileRect":
				@class.TileRectangle = method_4();
				break;
			case "path":
				@class.Gradient = method_3();
				break;
			case "lin":
				@class.Gradient = method_6();
				break;
			case "gsLst":
				@class.GradientStops = method_7();
				break;
			default:
				class5944_0.method_2();
				break;
			}
		}
		return @class;
	}

	private Class6363 method_3()
	{
		Class6363 @class = new Class6363();
		@class.Path = method_5();
		while (class5944_0.method_0("path"))
		{
			string localName;
			if ((localName = class5944_0.LocalName) != null && localName == "fillToRect")
			{
				@class.FillToRectangle = method_4();
			}
			else
			{
				class5944_0.method_2();
			}
		}
		return @class;
	}

	private Class6364 method_4()
	{
		Class6364 @class = new Class6364();
		@class.BottomOffset = new Class6329(class5944_0.method_6("b", 0.0));
		@class.TopOffset = new Class6329(class5944_0.method_6("t", 0.0));
		@class.LeftOffset = new Class6329(class5944_0.method_6("l", 0.0));
		@class.RightOffset = new Class6329(class5944_0.method_6("r", 0.0));
		return @class;
	}

	private Enum808 method_5()
	{
		return class5944_0.method_4("path", string.Empty) switch
		{
			"rect" => Enum808.const_2, 
			"circle" => Enum808.const_1, 
			"shape" => Enum808.const_0, 
			_ => Enum808.const_0, 
		};
	}

	private Class6362 method_6()
	{
		Class6362 @class = new Class6362();
		@class.Angle = new Class6323(class5944_0.method_6("ang", 0.0));
		@class.IsScaled = class5944_0.method_7("scaled", defaultValue: false);
		return @class;
	}

	private List<Class6361> method_7()
	{
		List<Class6361> list = new List<Class6361>();
		while (class5944_0.method_0("gsLst"))
		{
			string localName;
			if ((localName = class5944_0.LocalName) != null && localName == "gs")
			{
				list.Add(method_8());
			}
			else
			{
				class5944_0.method_2();
			}
		}
		return list;
	}

	private Class6361 method_8()
	{
		Class6361 @class = new Class6361();
		@class.Position = new Class6329(class5944_0.method_6("pos", 0.0));
		@class.Color = ColorBuilder.imethod_0(class5944_0);
		return @class;
	}

	private Enum810 method_9()
	{
		return class5944_0.method_4("flip", string.Empty) switch
		{
			"xy" => Enum810.const_3, 
			"y" => Enum810.const_2, 
			"x" => Enum810.const_1, 
			"none" => Enum810.const_0, 
			_ => Enum810.const_0, 
		};
	}

	private Class6351 method_10()
	{
		Class6351 @class = new Class6351();
		@class.DotsPerInch = (uint)class5944_0.method_5("dpi", 0);
		@class.RotateWithShape = class5944_0.method_7("rotWithShape", defaultValue: false);
		while (class5944_0.method_0("blipFill"))
		{
			switch (class5944_0.LocalName)
			{
			case "tile":
				@class.BlipFillMode = method_11();
				break;
			case "stretch":
				@class.BlipFillMode = method_13();
				break;
			case "srcRect":
				@class.SourceRectangle = method_4();
				break;
			case "blip":
				@class.Blip = method_14();
				break;
			default:
				class5944_0.method_2();
				break;
			}
		}
		return @class;
	}

	private Class6359 method_11()
	{
		Class6359 @class = new Class6359();
		@class.Alignment = method_12();
		@class.TileFlipMode = method_9();
		@class.HorizontalRatio = new Class6329(class5944_0.method_6("sx", 1.0));
		@class.VerticalRatio = new Class6329(class5944_0.method_6("sy", 1.0));
		@class.HorizontalOffset = class5944_0.method_6("tx", 0.0);
		@class.VerticalOffset = class5944_0.method_6("ty", 0.0);
		return @class;
	}

	private Enum809 method_12()
	{
		return class5944_0.method_4("algn", string.Empty) switch
		{
			"tl" => Enum809.const_0, 
			"t" => Enum809.const_1, 
			"tr" => Enum809.const_2, 
			"l" => Enum809.const_3, 
			"ctr" => Enum809.const_4, 
			"r" => Enum809.const_5, 
			"bl" => Enum809.const_6, 
			"b" => Enum809.const_7, 
			"br" => Enum809.const_8, 
			_ => Enum809.const_0, 
		};
	}

	private Class6358 method_13()
	{
		Class6358 @class = new Class6358();
		while (class5944_0.method_0("stretch"))
		{
			string localName;
			if ((localName = class5944_0.LocalName) != null && localName == "fillRect")
			{
				@class.FillRectangle = method_4();
			}
			else
			{
				class5944_0.method_2();
			}
		}
		return @class;
	}

	private Class6349 method_14()
	{
		Class6349 @class = new Class6349();
		@class.CompressionState = method_16();
		@class.EmbeddedPictureReference = class5944_0.method_4("embed", string.Empty);
		@class.LinkedPictureReference = class5944_0.method_4("link", string.Empty);
		@class.Effects = method_15();
		return @class;
	}

	private List<Interface281> method_15()
	{
		List<Interface281> list = new List<Interface281>();
		string localName = class5944_0.LocalName;
		while (class5944_0.method_0(localName))
		{
			switch (class5944_0.LocalName)
			{
			case "biLevel":
			case "clrChange":
			case "grayscl":
			case "lum":
				list.Add(EffectBuilder.imethod_0(class5944_0));
				break;
			default:
				class5944_0.method_2();
				break;
			}
		}
		return list;
	}

	private Enum806 method_16()
	{
		return class5944_0.method_4("cstate", string.Empty) switch
		{
			"none" => Enum806.const_4, 
			"hqprint" => Enum806.const_3, 
			"print" => Enum806.const_2, 
			"screen" => Enum806.const_1, 
			"email" => Enum806.const_0, 
			_ => Enum806.const_0, 
		};
	}

	private HatchStyle method_17()
	{
		return class5944_0.method_4("prst", string.Empty) switch
		{
			"pct5" => HatchStyle.Percent05, 
			"pct10" => HatchStyle.Percent10, 
			"pct20" => HatchStyle.Percent20, 
			"pct25" => HatchStyle.Percent25, 
			"pct30" => HatchStyle.Percent30, 
			"pct40" => HatchStyle.Percent40, 
			"pct50" => HatchStyle.Percent50, 
			"pct60" => HatchStyle.Percent60, 
			"pct70" => HatchStyle.Percent70, 
			"pct75" => HatchStyle.Percent75, 
			"pct80" => HatchStyle.Percent80, 
			"pct90" => HatchStyle.Percent90, 
			"horz" => HatchStyle.Horizontal, 
			"vert" => HatchStyle.Vertical, 
			"ltHorz" => HatchStyle.LightHorizontal, 
			"ltVert" => HatchStyle.LightVertical, 
			"dkHorz" => HatchStyle.DarkHorizontal, 
			"dkVert" => HatchStyle.DarkVertical, 
			"narHorz" => HatchStyle.NarrowHorizontal, 
			"narVert" => HatchStyle.NarrowVertical, 
			"dashHorz" => HatchStyle.DashedHorizontal, 
			"dashVert" => HatchStyle.DashedVertical, 
			"cross" => HatchStyle.Cross, 
			"dnDiag" => HatchStyle.BackwardDiagonal, 
			"upDiag" => HatchStyle.ForwardDiagonal, 
			"ltDnDiag" => HatchStyle.LightDownwardDiagonal, 
			"ltUpDiag" => HatchStyle.LightUpwardDiagonal, 
			"dkDnDiag" => HatchStyle.DarkDownwardDiagonal, 
			"dkUpDiag" => HatchStyle.DarkUpwardDiagonal, 
			"wdDnDiag" => HatchStyle.WideDownwardDiagonal, 
			"wdUpDiag" => HatchStyle.WideUpwardDiagonal, 
			"dashDnDiag" => HatchStyle.DashedDownwardDiagonal, 
			"dashUpDiag" => HatchStyle.DashedUpwardDiagonal, 
			"diagCross" => HatchStyle.DiagonalCross, 
			"smCheck" => HatchStyle.SmallCheckerBoard, 
			"lgCheck" => HatchStyle.LargeCheckerBoard, 
			"smGrid" => HatchStyle.SmallGrid, 
			"lgGrid" => HatchStyle.Cross, 
			"dotGrid" => HatchStyle.DottedGrid, 
			"smConfetti" => HatchStyle.SmallConfetti, 
			"lgConfetti" => HatchStyle.LargeConfetti, 
			"horzBrick" => HatchStyle.HorizontalBrick, 
			"diagBrick" => HatchStyle.DiagonalBrick, 
			"solidDmnd" => HatchStyle.SolidDiamond, 
			"openDmnd" => HatchStyle.OutlinedDiamond, 
			"dotDmnd" => HatchStyle.DottedDiamond, 
			"plaid" => HatchStyle.Plaid, 
			"sphere" => HatchStyle.Sphere, 
			"weave" => HatchStyle.Weave, 
			"divot" => HatchStyle.Divot, 
			"shingle" => HatchStyle.Shingle, 
			"wave" => HatchStyle.Wave, 
			"trellis" => HatchStyle.Trellis, 
			"zigZag" => HatchStyle.ZigZag, 
			_ => HatchStyle.Horizontal, 
		};
	}
}

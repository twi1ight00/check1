using System;
using ns219;
using ns249;
using ns259;

namespace ns248;

internal class Class6279
{
	private Class6409 class6409_0;

	private Class5945 class5945_0;

	private void method_0()
	{
		class6409_0.Height = class5945_0.method_6("h", -1.0);
		class6409_0.Width = class5945_0.method_6("w", -1.0);
		class6409_0.Stroke = class5945_0.method_7("stroke", defaultValue: true);
		class6409_0.FillMode = method_1();
		while (class5945_0.method_0("path"))
		{
			switch (class5945_0.LocalName)
			{
			case "close":
				class6409_0.method_1(smethod_0());
				break;
			case "lnTo":
				class6409_0.method_1(method_5());
				break;
			case "moveTo":
				class6409_0.method_1(method_7());
				break;
			case "arcTo":
				class6409_0.method_1(method_4());
				break;
			case "cubicBezTo":
				class6409_0.method_1(method_3());
				break;
			case "quadBezTo":
				class6409_0.method_1(method_2());
				break;
			default:
				class5945_0.method_2();
				break;
			}
		}
	}

	private Enum807 method_1()
	{
		return class5945_0.method_4("fill", string.Empty) switch
		{
			"darken" => Enum807.const_0, 
			"darkenLess" => Enum807.const_1, 
			"lighten" => Enum807.const_2, 
			"lightenLess" => Enum807.const_3, 
			"norm" => Enum807.const_5, 
			"none" => Enum807.const_4, 
			_ => Enum807.const_5, 
		};
	}

	private Interface295 method_2()
	{
		Class6410[] array = new Class6410[2];
		int num = 0;
		while (class5945_0.method_0("quadBezTo"))
		{
			string localName;
			if ((localName = class5945_0.LocalName) != null && localName == "pt")
			{
				if (num < array.Length)
				{
					array[num] = method_6();
					num++;
				}
				else
				{
					class5945_0.method_2();
				}
			}
			else
			{
				class5945_0.method_2();
			}
		}
		return new Class6411(array);
	}

	private Interface295 method_3()
	{
		Class6410[] array = new Class6410[3];
		int num = 0;
		while (class5945_0.method_0("cubicBezTo"))
		{
			string localName;
			if ((localName = class5945_0.LocalName) != null && localName == "pt")
			{
				if (num < array.Length)
				{
					array[num] = method_6();
					num++;
				}
				else
				{
					class5945_0.method_2();
				}
			}
			else
			{
				class5945_0.method_2();
			}
		}
		return new Class6406(array);
	}

	private Interface295 method_4()
	{
		Class6404 @class = new Class6404();
		@class.HeightRadius = new Class6403(class5945_0.method_4("hR", string.Empty));
		@class.WidthRadius = new Class6403(class5945_0.method_4("wR", string.Empty));
		@class.StartAngle = new Class6402(class5945_0.method_4("stAng", string.Empty));
		@class.SwingAngle = new Class6402(class5945_0.method_4("swAng", string.Empty));
		return @class;
	}

	private static Interface295 smethod_0()
	{
		return new Class6405();
	}

	private Interface295 method_5()
	{
		Class6407 @class = new Class6407();
		while (class5945_0.method_0("lnTo"))
		{
			string localName;
			if ((localName = class5945_0.LocalName) != null && localName == "pt")
			{
				@class.Point = method_6();
			}
			else
			{
				class5945_0.method_2();
			}
		}
		return @class;
	}

	private Class6410 method_6()
	{
		if (class5945_0.LocalName != "pt")
		{
			throw new InvalidOperationException("Cannot read a point from the '{0}' tag. The 'pt' tag is required.");
		}
		string x = class5945_0.method_4("x", string.Empty);
		string y = class5945_0.method_4("y", string.Empty);
		return new Class6410(x, y);
	}

	private Interface295 method_7()
	{
		Class6408 @class = new Class6408();
		while (true)
		{
			if (class5945_0.method_0("moveTo"))
			{
				string localName;
				if ((localName = class5945_0.LocalName) != null && localName == "pt")
				{
					break;
				}
				class5945_0.method_2();
				continue;
			}
			return @class;
		}
		@class.Point = method_6();
		return @class;
	}

	internal Class6409 method_8(Class5945 reader)
	{
		if (reader.LocalName != "path")
		{
			return null;
		}
		class5945_0 = reader;
		class6409_0 = new Class6409();
		method_0();
		return class6409_0;
	}
}

using System.Collections.Generic;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using ns1;
using ns26;
using ns48;

namespace ns15;

internal class Class1515
{
	internal static string smethod_0(Enum212 enum212_0)
	{
		return enum212_0 switch
		{
			Enum212.const_0 => "auto", 
			Enum212.const_1 => "column", 
			Enum212.const_2 => "page", 
			_ => "auto", 
		};
	}

	internal static Enum215 smethod_1(string string_0)
	{
		string key;
		if ((key = string_0.ToLower()) != null)
		{
			if (Class1742.dictionary_115 == null)
			{
				Class1742.dictionary_115 = new Dictionary<string, int>(8)
				{
					{ "tb-rl", 0 },
					{ "tb-lr", 1 },
					{ "tb", 2 },
					{ "rl-tb", 3 },
					{ "rl", 4 },
					{ "page", 5 },
					{ "lr-tb", 6 },
					{ "lr", 7 }
				};
			}
			if (Class1742.dictionary_115.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return Enum215.const_2;
				case 1:
					return Enum215.const_3;
				case 2:
					return Enum215.const_6;
				case 3:
					return Enum215.const_1;
				case 4:
					return Enum215.const_5;
				case 5:
					return Enum215.const_7;
				case 6:
					return Enum215.const_0;
				case 7:
					return Enum215.const_4;
				}
			}
		}
		return Enum215.const_0;
	}

	internal static Enum172 smethod_2(string string_0)
	{
		return string_0.ToLower() switch
		{
			"other" => Enum172.const_4, 
			"new" => Enum172.const_2, 
			"embed" => Enum172.const_1, 
			"replace" => Enum172.const_0, 
			_ => Enum172.const_3, 
		};
	}

	internal static Enum171 smethod_3(string string_0)
	{
		return string_0.ToLower() switch
		{
			"other" => Enum171.const_3, 
			"onrequest" => Enum171.const_1, 
			"onload" => Enum171.const_0, 
			_ => Enum171.const_2, 
		};
	}

	internal static BackgroundType smethod_4(string string_0)
	{
		string text;
		if ((text = string_0) != null && text == "solid")
		{
			return BackgroundType.Solid;
		}
		return BackgroundType.None;
	}

	internal static AutoShapeType smethod_5(string string_0)
	{
		return string_0 switch
		{
			"custom-shape" => AutoShapeType.Unknown, 
			"ellipse" => AutoShapeType.Oval, 
			"rect" => AutoShapeType.Rectangle, 
			_ => AutoShapeType.Unknown, 
		};
	}

	internal static string smethod_6(AutoShapeType autoShapeType_0)
	{
		return autoShapeType_0 switch
		{
			AutoShapeType.Unknown => "custom-shape", 
			AutoShapeType.Rectangle => "rect", 
			AutoShapeType.Oval => "ellipse", 
			_ => "custom-shape", 
		};
	}

	internal static string smethod_7(FillType fillType_0)
	{
		return fillType_0 switch
		{
			FillType.None => "none", 
			FillType.Solid => "solid", 
			FillType.Gradient => "gradient", 
			FillType.Texture => "texture", 
			FillType.Pattern => "pattern", 
			_ => "automatic", 
		};
	}
}

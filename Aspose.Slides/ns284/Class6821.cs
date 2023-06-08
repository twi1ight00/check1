using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using ns277;
using ns288;
using ns301;
using ns73;
using ns84;
using ns87;

namespace ns284;

internal class Class6821
{
	private const string string_0 = "path";

	private const string string_1 = "\\(\\\"?\\'?(?<path>[^\\)]+)\\\"?\\'?\\)";

	private Class4347 class4347_0;

	private Interface329 interface329_0;

	private Class6983 class6983_0;

	private Interface355 interface355_0;

	internal static float float_0 = 16f;

	private static Dictionary<Enum610, float> dictionary_0;

	public Class4347 Style => class4347_0;

	private static Dictionary<Enum610, float> FontSizeTable
	{
		get
		{
			if (dictionary_0 == null)
			{
				Dictionary<Enum610, float> dictionary = new Dictionary<Enum610, float>();
				dictionary.Add(Enum610.const_0, 7.5f);
				dictionary.Add(Enum610.const_1, 7.5f);
				dictionary.Add(Enum610.const_2, 10f);
				dictionary.Add(Enum610.const_3, 14f);
				dictionary.Add(Enum610.const_4, 16f);
				dictionary.Add(Enum610.const_5, 18f);
				dictionary.Add(Enum610.const_6, 24f);
				dictionary.Add(Enum610.const_7, 36f);
				dictionary_0 = dictionary;
			}
			return dictionary_0;
		}
	}

	public Class6821(Class4347 style, Interface329 owner, Class6983 element, Interface355 settings)
	{
		class4347_0 = style;
		interface329_0 = owner;
		class6983_0 = element;
		interface355_0 = settings;
	}

	private static float smethod_0(Enum610 size)
	{
		return FontSizeTable[size];
	}

	public FontStyle method_0()
	{
		FontStyle fontStyle = ((Style.Font.Style == Enum625.const_1 || Style.Font.Style == Enum625.const_2) ? FontStyle.Italic : FontStyle.Regular);
		if (Style.TextDecoration.Line == Enum615.flag_1)
		{
			fontStyle |= FontStyle.Underline;
		}
		if (Style.TextDecoration.Line == Enum615.flag_3)
		{
			fontStyle |= FontStyle.Strikeout;
		}
		if (Style.Font.Weight.Value >= 700)
		{
			fontStyle |= FontStyle.Bold;
		}
		return fontStyle;
	}

	public float method_1()
	{
		if (Style.Font.Size.IsAbsoluteSize)
		{
			return smethod_0(Style.Font.Size.AbsoluteSize);
		}
		float result = float_0;
		if (Class6969.smethod_1(Style.Font.Size.ToString(), ref result, float_0, ref interface329_0, class6983_0))
		{
			return result;
		}
		return 14f;
	}

	public string method_2()
	{
		if (class4347_0.Font.Family.Count == 0)
		{
			return "Times New Roman";
		}
		string[] array = new string[Style.Font.Family.Count];
		Style.Font.Family.CopyTo(array, 0);
		return string.Join(",", array).ToLower();
	}

	public bool method_3()
	{
		return Style.TextDecoration.Line == Enum615.flag_2;
	}

	public Color method_4()
	{
		return Style.Color;
	}

	public Color method_5()
	{
		return Style.Background.Color;
	}

	public Color method_6()
	{
		if (Style.FirstLine != null)
		{
			return Style.FirstLine.Color;
		}
		return Color.Empty;
	}

	public Color method_7()
	{
		if (Style.FirstLetter != null)
		{
			return Style.FirstLetter.Color;
		}
		return Color.Empty;
	}

	public object method_8()
	{
		Interface331 @interface = Class6915.smethod_0("display");
		return @interface.imethod_0(Class4342.smethod_2(Style.Display.Value)) ?? ((object)Enum952.const_15);
	}

	public object method_9()
	{
		return Style.Overflow.X switch
		{
			Enum619.const_1 => Enum953.const_1, 
			Enum619.const_2 => Enum953.const_2, 
			Enum619.const_3 => Enum953.const_3, 
			_ => Enum953.const_0, 
		};
	}

	public object method_10()
	{
		return Style.Float switch
		{
			Enum627.const_0 => Enum954.const_1, 
			Enum627.const_1 => Enum954.const_2, 
			_ => Enum954.const_0, 
		};
	}

	public object method_11()
	{
		return Style.Position switch
		{
			Enum633.const_1 => Enum956.const_3, 
			Enum633.const_2 => Enum956.const_1, 
			Enum633.const_3 => Enum956.const_2, 
			_ => Enum956.const_0, 
		};
	}

	public object method_12()
	{
		return Style.Clear switch
		{
			Enum609.const_0 => Enum935.const_1, 
			Enum609.const_1 => Enum935.const_2, 
			Enum609.const_2 => Enum935.const_3, 
			_ => Enum935.const_0, 
		};
	}

	public Rectangle method_13()
	{
		Rectangle result = default(Rectangle);
		if (!Style.Clip.Top.Auto && !Style.Clip.Right.Auto && !Style.Clip.Bottom.Auto && !Style.Clip.Left.Auto)
		{
			result.X = Convert.ToInt32(Class6969.smethod_10(Class6969.smethod_8(Style.Clip.Left.ToString())));
			result.Y = Convert.ToInt32(Class6969.smethod_10(Class6969.smethod_8(Style.Clip.Left.ToString())));
			result.Width = Convert.ToInt32(Class6969.smethod_10(Class6969.smethod_8(Style.Clip.Right.ToString()))) - result.X;
			result.Height = Convert.ToInt32(Class6969.smethod_10(Class6969.smethod_8(Style.Clip.Bottom.ToString()))) - result.Y;
		}
		return result;
	}

	public Class6959 method_14()
	{
		return Class6969.smethod_8(Style.Left.ToString());
	}

	public Class6959 method_15()
	{
		return Class6969.smethod_8(Style.Top.ToString());
	}

	public Class6959 method_16()
	{
		return Class6969.smethod_8(Style.Bottom.ToString());
	}

	public Class6959 method_17()
	{
		return Class6969.smethod_8(Style.Right.ToString());
	}

	public Class6959 method_18()
	{
		return Class6969.smethod_8(Style.ZIndex.ToString());
	}

	public Class6959 method_19()
	{
		return Class6969.smethod_8(Style.Width.ToString());
	}

	public Class6959 method_20()
	{
		return Class6969.smethod_8(Style.Height.ToString());
	}

	public Class6959 method_21(Class4337 unit)
	{
		return Class6969.smethod_8(unit.ToString());
	}

	public Class6959 method_22(Class4217 value)
	{
		return Class6969.smethod_8(value.ToString());
	}

	public Class6959 method_23(Class4221 value)
	{
		if (value.IsEnumValue)
		{
			return value.EnumValue switch
			{
				Enum607.const_0 => new Class6959(1f), 
				Enum607.const_2 => new Class6959(4f), 
				_ => new Class6959(2f), 
			};
		}
		return method_21(value.LengthValue);
	}

	public Class6959 method_24(Class4221 value)
	{
		if (!class6983_0.TagName.Equals("TABLE"))
		{
			return new Class6959(isAuto: true);
		}
		return method_23(value);
	}

	public Enum951 method_25(Enum605 borderStyle)
	{
		return borderStyle switch
		{
			Enum605.const_1 => Enum951.const_0, 
			Enum605.const_2 => Enum951.const_1, 
			Enum605.const_3 => Enum951.const_2, 
			Enum605.const_4 => Enum951.const_3, 
			Enum605.const_5 => Enum951.const_4, 
			Enum605.const_6 => Enum951.const_5, 
			Enum605.const_7 => Enum951.const_6, 
			Enum605.const_8 => Enum951.const_7, 
			Enum605.const_9 => Enum951.const_8, 
			_ => Enum951.const_0, 
		};
	}

	public Enum951 method_26(Enum605 borderStyle)
	{
		if (!class6983_0.TagName.Equals("TABLE"))
		{
			return Enum951.const_0;
		}
		return method_25(borderStyle);
	}

	public object method_27(Color color)
	{
		return color;
	}

	public object method_28(Color color)
	{
		if (!class6983_0.TagName.Equals("TABLE"))
		{
			return Color.Empty;
		}
		return color;
	}

	public object method_29()
	{
		Interface331 @interface = Class6915.smethod_0("text-align");
		return @interface.imethod_0(Class4342.smethod_2(Style.TextAlign)) ?? ((object)Enum616.const_0);
	}

	public object method_30()
	{
		Interface331 @interface = Class6915.smethod_0("vertical-align");
		return @interface.imethod_0(Class4342.smethod_2(Style.VerticalAlign.Align)) ?? ((object)Enum958.const_0);
	}

	public object method_31()
	{
		Interface331 @interface = Class6915.smethod_0("white-space");
		return @interface.imethod_0(Class4342.smethod_2(Style.WhiteSpace)) ?? ((object)Enum611.const_0);
	}

	public object method_32()
	{
		Interface331 @interface = Class6915.smethod_0("align");
		return @interface.imethod_0(Class4342.smethod_2(Style.TextAlign)) ?? ((object)Enum616.const_0);
	}

	public object method_33()
	{
		return class4347_0.TextTransform switch
		{
			Enum614.const_0 => Enum940.const_1, 
			Enum614.const_1 => Enum940.const_2, 
			Enum614.const_2 => Enum940.const_3, 
			_ => Enum940.const_0, 
		};
	}

	public object method_34()
	{
		return method_21(class4347_0.TextIndent);
	}

	public object method_35()
	{
		if (class4347_0.WordSpacing.IsNormal)
		{
			return new Class6959(isAuto: true);
		}
		return method_21(class4347_0.WordSpacing.Size);
	}

	public object method_36()
	{
		if (class4347_0.LineHeight.IsNormal)
		{
			return 1.3f;
		}
		SizeF sizeF = Class6971.Instance.method_1(interface329_0.FontFamilyName, interface329_0.FontSize, interface329_0.FontStyle);
		Class6959 @class = method_21(class4347_0.LineHeight.Size);
		if (@class.Unit == Enum955.const_9)
		{
			return Class6969.smethod_10(@class) * sizeF.Height;
		}
		if (@class.Unit == Enum955.const_3)
		{
			return @class.Value / 100f * sizeF.Height;
		}
		return Class6969.smethod_10(@class);
	}

	public object method_37()
	{
		Interface331 @interface = Class6915.smethod_0("table-layout");
		return @interface.imethod_0(Class4342.smethod_2(Style.TableLayout)) ?? ((object)Enum939.const_0);
	}

	public object method_38()
	{
		if (!class4347_0.Content.IsNormal && !class4347_0.Content.IsNone)
		{
			return class4347_0.Content.ToString();
		}
		return null;
	}

	public object method_39()
	{
		Interface331 @interface = Class6915.smethod_0("border-collapse");
		return @interface.imethod_0(Class4342.smethod_2(Style.Border.Collapse)) ?? ((object)Enum933.const_0);
	}

	public object method_40()
	{
		Interface331 @interface = Class6915.smethod_0("empty-cells");
		return @interface.imethod_0(Class4342.smethod_2(Style.EmptyCells)) ?? ((object)Enum937.const_0);
	}

	public object method_41()
	{
		object obj = class6983_0.method_20("cell-padding");
		if (obj == null)
		{
			return new Class6959(isAuto: true);
		}
		return Class6969.smethod_8(obj.ToString());
	}

	public object method_42()
	{
		Interface331 @interface = Class6915.smethod_0("list-style-type");
		return @interface.imethod_0(Class4342.smethod_2(Style.ListStyle.Type)) ?? ((object)0);
	}

	public object method_43()
	{
		Interface331 @interface = Class6915.smethod_0("list-style-position");
		return @interface.imethod_0(Class4342.smethod_2(Style.ListStyle.Position)) ?? ((object)Enum938.const_0);
	}

	public object method_44()
	{
		return new Class6959(isAuto: true);
	}

	public object method_45()
	{
		if (class4347_0.Background.Image.None)
		{
			return string.Empty;
		}
		string text = class4347_0.Background.Image.Uri;
		if (text.StartsWith("url(", StringComparison.OrdinalIgnoreCase))
		{
			Match match = Regex.Match(text, "\\(\\\"?\\'?(?<path>[^\\)]+)\\\"?\\'?\\)");
			if (match.Success && match.Groups["path"] != null)
			{
				text = match.Groups["path"].Value;
			}
		}
		if (interface355_0 != null && interface355_0.ImgPath.Length > 0 && text.IndexOf(interface355_0.ImgPath) != 0)
		{
			text = interface355_0.ImgPath + text;
		}
		return text;
	}

	public object method_46()
	{
		Interface331 @interface = Class6915.smethod_0("direction");
		return @interface.imethod_0(Class4342.smethod_2(Style.Direction)) ?? ((object)Enum936.const_0);
	}

	public object method_47(Enum618 pageBreak)
	{
		return pageBreak switch
		{
			Enum618.const_1 => Enum950.const_1, 
			Enum618.const_2 => Enum950.const_2, 
			Enum618.const_3 => Enum950.const_3, 
			Enum618.const_4 => Enum950.const_4, 
			_ => Enum950.const_0, 
		};
	}

	public object method_48()
	{
		object obj = class6983_0.method_20("wrap");
		if (obj == null)
		{
			return true;
		}
		string text = obj.ToString();
		if (text.Equals("soft", StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		return false;
	}

	public object method_49()
	{
		return class4347_0.Visibility switch
		{
			Enum612.const_1 => Enum960.const_1, 
			Enum612.const_2 => Enum960.const_2, 
			_ => Enum960.const_0, 
		};
	}

	public Interface329 method_50(Class4347 style)
	{
		if (style == null)
		{
			return new Class6896();
		}
		return new Class6818(style.Before, class6983_0, interface355_0);
	}
}

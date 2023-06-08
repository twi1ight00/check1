using System.Runtime.CompilerServices;
using Aspose.Cells;
using ns15;

namespace ns26;

internal class Class1496
{
	internal string string_0;

	internal Class1501 class1501_0;

	private string string_1;

	private string string_2;

	internal Style style_0;

	internal bool bool_0;

	internal bool bool_1;

	internal bool bool_2;

	internal bool bool_3;

	internal string Name => string_1;

	internal Class1496(Style style_1, int int_0)
	{
		Style style = null;
		bool flag = false;
		if (style_1.Name != null)
		{
			string_1 = style_1.Name;
			string text;
			if ((text = string_1) != null && text == "Normal")
			{
				string_1 = "Default";
				flag = true;
			}
		}
		else
		{
			string_1 = "ce" + Class1516.smethod_13(int_0);
			if (style_1.method_12() >= 0 && style_1.method_12() >= 0 && style_1.method_12() < style_1.method_5().method_58().Count)
			{
				style = style_1.method_5().method_58()[style_1.method_12()];
				string name;
				if ((name = style.Name) != null && name == "Normal")
				{
					method_1("Default");
				}
				else
				{
					method_1(style.Name);
				}
			}
		}
		Style defaultStyle = style_1.method_5().DefaultStyle;
		if (style_1.method_19())
		{
			class1501_0 = new Class1501(style_1.Font);
		}
		else if (style != null && style_1.method_40() != null)
		{
			Font font_ = (style.method_19() ? style.Font : style_1.method_5().DefaultFont);
			if (style_1.Font.method_21() != 0 && !style_1.Font.method_20(font_, style_1.method_5().Workbook, style_1.method_5().Workbook))
			{
				class1501_0 = new Class1501(style_1.Font);
			}
		}
		style_0 = style_1;
		style_1.method_41(out var number, out var _);
		if (style_1.method_17())
		{
			string_0 = "N" + number;
		}
		else if (style != null && number != style.Number)
		{
			string_0 = "N" + number;
		}
		if (flag)
		{
			bool_3 = true;
			bool_2 = true;
			bool_1 = true;
			bool_0 = true;
			return;
		}
		bool_3 = style_0.method_21();
		if (!bool_3 && style != null)
		{
			Style style2 = (style.method_21() ? style : defaultStyle);
			if (style_1.HorizontalAlignment != style2.HorizontalAlignment || style_1.IndentLevel != style2.IndentLevel || style_1.VerticalAlignment != style2.VerticalAlignment || style_1.IsTextWrapped != style2.IsTextWrapped || style_1.ShrinkToFit != style2.ShrinkToFit || style_1.RotationAngle != style2.RotationAngle || style_1.TextDirection != style2.TextDirection)
			{
				bool_3 = true;
			}
		}
		bool_2 = style_0.method_23();
		if (!bool_2 && style != null && !style.method_23() && style_1.method_9())
		{
			bool_2 = true;
		}
		bool_1 = style_0.method_27();
		if (!bool_1 && style != null)
		{
			Style style3 = (style.method_27() ? style : defaultStyle);
			if (style_1.IsLocked != style3.IsLocked || style_1.IsFormulaHidden != style3.IsFormulaHidden)
			{
				bool_1 = true;
			}
		}
		bool_0 = style_0.method_25();
		if (!bool_0 && style != null)
		{
			Style style4 = (style.method_25() ? style : defaultStyle);
			if (style_1.Pattern != style4.Pattern)
			{
				bool_0 = true;
			}
		}
	}

	[SpecialName]
	internal string method_0()
	{
		return string_2;
	}

	[SpecialName]
	internal void method_1(string string_3)
	{
		string_2 = string_3;
	}
}

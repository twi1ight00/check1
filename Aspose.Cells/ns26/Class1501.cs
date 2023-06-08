using System.Drawing;
using Aspose.Cells;

namespace ns26;

internal class Class1501
{
	private Color color_0;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private string string_0;

	private double double_0;

	private FontUnderlineType fontUnderlineType_0;

	internal Aspose.Cells.Font font_0;

	internal bool bool_5 = true;

	internal Color Color => color_0;

	internal bool IsBold => bool_0;

	internal bool IsItalic => bool_1;

	internal bool IsStrikeout => bool_2;

	internal bool IsSubscript => bool_3;

	internal bool IsSuperscript => bool_4;

	internal string Name => string_0;

	internal double Size => double_0;

	internal FontUnderlineType Underline => fontUnderlineType_0;

	internal Class1501()
	{
	}

	internal Class1501(Aspose.Cells.Font font_1)
	{
		if (font_1 != null)
		{
			font_0 = font_1;
			bool_5 = font_1.InternalColor.method_2();
			color_0 = font_1.Color;
			bool_0 = font_1.IsBold;
			bool_1 = font_1.IsItalic;
			bool_2 = font_1.IsStrikeout;
			bool_3 = font_1.IsSubscript;
			bool_4 = font_1.IsSuperscript;
			string_0 = font_1.Name;
			double_0 = font_1.DoubleSize;
			fontUnderlineType_0 = font_1.Underline;
		}
	}
}

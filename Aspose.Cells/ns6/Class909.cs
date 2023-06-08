using System.Drawing;

namespace ns6;

internal class Class909
{
	internal RectangleF rectangleF_0 = new RectangleF(0f, 0f, 0f, 0f);

	internal Enum125 enum125_0;

	internal SizeF sizeF_0;

	private Font font_0;

	private string string_0 = "";

	private Color color_0;

	public string Text
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Font Font => font_0;

	public Color FontColor => color_0;

	internal Class909(string string_1, Font font_1, Color color_1, Enum125 enum125_1)
	{
		string_0 = string_1;
		font_0 = font_1;
		color_0 = color_1;
		enum125_0 = enum125_1;
		if (enum125_1 == Enum125.const_2 && (string_1 == null || string_1 == ""))
		{
			enum125_0 = Enum125.const_1;
		}
	}
}

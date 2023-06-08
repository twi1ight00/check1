using System.Drawing;

namespace ns5;

internal class Class892
{
	internal RectangleF rectangleF_0 = new RectangleF(0f, 0f, 0f, 0f);

	internal Enum111 enum111_0;

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

	internal Class892(string string_1, Font font_1, Color color_1, Enum111 enum111_1)
	{
		string_0 = string_1;
		font_0 = font_1;
		color_0 = color_1;
		enum111_0 = enum111_1;
		if (enum111_1 == Enum111.const_2 && (string_1 == null || string_1 == ""))
		{
			enum111_0 = Enum111.const_1;
		}
	}
}

using System.Drawing;

namespace ns36;

internal class Class779 : Interface30
{
	internal RectangleF rectangleF_0 = new RectangleF(0f, 0f, 0f, 0f);

	internal Enum156 enum156_0;

	internal SizeF sizeF_0;

	private Font font_0;

	private string string_0 = "";

	private Color color_0;

	public Enum156 TextType
	{
		get
		{
			return enum156_0;
		}
		set
		{
			enum156_0 = value;
		}
	}

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

	public Font Font
	{
		get
		{
			return font_0;
		}
		set
		{
			font_0 = value;
		}
	}

	public Color FontColor
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
		}
	}

	internal Class779(string text, Font font, Color fontColor, Enum156 textType)
	{
		string_0 = text;
		font_0 = font;
		color_0 = fontColor;
		enum156_0 = textType;
		if (textType == Enum156.const_2 && (text == null || text == ""))
		{
			TextType = Enum156.const_1;
		}
	}
}

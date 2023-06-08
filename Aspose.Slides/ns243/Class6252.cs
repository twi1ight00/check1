using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using ns224;
using ns234;

namespace ns243;

internal abstract class Class6252
{
	private readonly Graphics graphics_0;

	protected Class6252()
	{
		graphics_0 = Graphics.FromImage(new Bitmap(1, 1));
		graphics_0.Clear(Color.White);
	}

	public SizeF method_0(string text, Font font)
	{
		graphics_0.PageUnit = GraphicsUnit.Point;
		graphics_0.TextRenderingHint = TextRenderingHint.AntiAlias;
		return graphics_0.MeasureString(text, font, 1000, StringFormat.GenericTypographic);
	}

	public SizeF method_1(string text, Class5999 font)
	{
		using Class6163 privateFontCache = new Class6163();
		return method_0(text, Class6158.smethod_0(font, privateFontCache));
	}

	protected virtual Class6235[] vmethod_0(string text, float width, Class5998 foreColor, Class5999 font)
	{
		List<Class6235> list = new List<Class6235>();
		while (text.Length > 0)
		{
			string text2 = string.Empty;
			int num = 0;
			while (method_1(text2, font).Width < width && num != text.Length)
			{
				text2 += text[num++];
			}
			list.Add(new Class6235(foreColor, font, text2.Trim(), this));
			text = text.Remove(0, num);
		}
		return list.ToArray();
	}

	public abstract Class6235[] vmethod_1(string text, float width, Class5998 foreColor, Class5999 font);

	public abstract string vmethod_2(Class6235 row, float width);
}

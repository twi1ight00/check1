using System;
using System.Drawing;
using System.Windows.Forms;
using ns221;
using ns224;
using ns233;
using ns234;

namespace ns218;

internal class Class5971 : IDisposable
{
	private Graphics graphics_0;

	private Class6150 class6150_0;

	private StringFormat stringFormat_0;

	private bool bool_0 = true;

	private static readonly Form form_0 = ((Class6166.smethod_2() == Enum742.const_1) ? new Form() : null);

	private object object_0 = new object();

	public StringFormat StringFormat
	{
		get
		{
			lock (object_0)
			{
				return stringFormat_0;
			}
		}
	}

	public Class5971()
	{
		lock (object_0)
		{
			class6150_0 = new Class6150(1, 1);
			graphics_0 = ((Class6166.smethod_2() == Enum742.const_1) ? form_0.CreateGraphics() : Class6148.smethod_42(class6150_0.method_2()));
			graphics_0.PageUnit = GraphicsUnit.Point;
			bool_0 = true;
			stringFormat_0 = new StringFormat(StringFormat.GenericTypographic);
			stringFormat_0.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
		}
	}

	public Class5971(StringFormat stringFormat)
		: this()
	{
		lock (object_0)
		{
			stringFormat_0 = stringFormat;
		}
	}

	public Class5971(Graphics graphics, StringFormat stringFormat)
	{
		lock (object_0)
		{
			graphics_0 = graphics;
			stringFormat_0 = stringFormat;
			bool_0 = false;
		}
	}

	public void Dispose()
	{
		lock (object_0)
		{
			if (bool_0)
			{
				if (class6150_0 != null)
				{
					class6150_0.Dispose();
					class6150_0 = null;
				}
				if (graphics_0 != null)
				{
					graphics_0.Dispose();
					graphics_0 = null;
				}
			}
		}
	}

	public SizeF method_0(string text, Font font)
	{
		lock (object_0)
		{
			if (smethod_0(font, ref text))
			{
				return graphics_0.MeasureString(text, font, PointF.Empty, stringFormat_0);
			}
			return graphics_0.MeasureString(text, font, PointF.Empty, stringFormat_0);
		}
	}

	public SizeF method_1(string text, Class5999 font)
	{
		using Class6163 privateFontCache = new Class6163();
		return method_0(text, Class6158.smethod_0(font, privateFontCache));
	}

	public SizeF method_2(string text, Font font, SizeF layoutArea, StringFormat stringFormat, out int charactersFitted, out int linesFilled)
	{
		lock (object_0)
		{
			if (smethod_0(font, ref text))
			{
				return graphics_0.MeasureString(text, font, layoutArea, stringFormat, out charactersFitted, out linesFilled);
			}
			return graphics_0.MeasureString(text, font, layoutArea, stringFormat, out charactersFitted, out linesFilled);
		}
	}

	public float method_3(char c, Font font)
	{
		return method_0(c.ToString(), font).Width;
	}

	private static bool smethod_0(Font font, ref string text)
	{
		if (font.Name.IndexOf("Tai") != -1)
		{
			text = text.Replace("ᦵ", "ᦵ◌");
			text = text.Replace("ᦶ", "ᦶ◌");
			text = text.Replace("ᦷ", "ᦷ◌");
			text = text.Replace("ᦺ", "ᦺ◌");
			return true;
		}
		return false;
	}
}

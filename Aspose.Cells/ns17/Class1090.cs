using System;
using System.Drawing;
using ns16;
using ns18;
using ns47;

namespace ns17;

internal class Class1090 : Class1088
{
	private Class1544 class1544_0;

	public Class1090(Class1544 class1544_1)
	{
		class1544_0 = class1544_1;
		SizeF sizeF;
		if (class1544_0.string_0 == "\n")
		{
			class1544_0.string_0 = "I";
			sizeF = method_0(class1544_0);
			class1544_0.string_0 = "";
			sizeF.Width = 0f;
		}
		else
		{
			sizeF = method_0(class1544_1);
		}
		float_0 = sizeF.Height;
		float_1 = sizeF.Width;
	}

	public override void vmethod_0(ref Class454 class454_0, PointF pointF_0)
	{
		float x = pointF_0.X;
		float y = pointF_0.Y;
		method_1(ref class454_0, class1544_0, new PointF(x, y));
	}

	private SizeF method_0(Class1544 class1544_1)
	{
		Class1396 @class = method_2(class1544_1);
		Class463 class2 = new Class463(@class, Color.Black, new PointF(0f, 0f), class1544_1.string_0, class1544_1.font_0.IsSuperscript, class1544_1.font_0.IsSubscript);
		SizeF result = new SizeF(class2.Size.Width, Class1460.smethod_0(@class.Name, (int)@class.Size, "|", @class.Style).Height);
		return result;
	}

	private void method_1(ref Class454 class454_0, Class1544 class1544_1, PointF pointF_0)
	{
		Class1396 @class = method_2(class1544_1);
		if (class1544_1.string_0.Length > 0)
		{
			Color color_ = Color.FromArgb(255, class1544_1.font_0.Color.R, class1544_1.font_0.Color.G, class1544_1.font_0.Color.B);
			class1544_1.string_0 = class1544_1.string_0.Replace('\r', ' ');
			Class463 class452_ = new Class463(@class, color_, new PointF(pointF_0.X, pointF_0.Y - @class.method_2()), class1544_1.string_0, class1544_1.font_0.IsSuperscript, class1544_1.font_0.IsSubscript);
			class454_0.Add(class452_);
		}
	}

	private Class1396 method_2(Class1544 class1544_1)
	{
		float float_ = Math.Max(1f, class1544_1.font_0.Size);
		Color.FromArgb(255, class1544_1.font_0.Color);
		FontStyle fontStyle_ = (class1544_1.font_0.IsBold ? FontStyle.Bold : FontStyle.Regular) | (class1544_1.font_0.IsItalic ? FontStyle.Italic : FontStyle.Regular) | (class1544_1.font_0.IsStrikeout ? FontStyle.Strikeout : FontStyle.Regular) | ((class1544_1.font_0.Underline != 0) ? FontStyle.Underline : FontStyle.Regular);
		return Class1396.smethod_1(class1544_1.font_0.Name, float_, fontStyle_);
	}
}

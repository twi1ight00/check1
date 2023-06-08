using System;
using System.Drawing;
using System.Drawing.Imaging;
using Aspose.Slides;

namespace ns4;

internal class Class59 : IPatternFormatEffectiveData, IEffectiveData
{
	private PatternFormat patternFormat_0;

	private bool bool_0;

	private Class21.Delegate3 delegate3_0;

	private IBaseSlide ibaseSlide_0;

	internal Class18 class18_0;

	internal Class18 class18_1;

	private PatternStyle patternStyle_0;

	public PatternStyle PatternStyle => patternStyle_0;

	public Color ForeColor => class18_0.Color;

	public Color BackColor => class18_1.Color;

	internal Class59()
	{
		class18_0 = new Class18();
		class18_1 = new Class18();
		patternStyle_0 = PatternStyle.NotDefined;
	}

	internal void method_0(PatternFormat source)
	{
		if (source.PatternStyle != PatternStyle.NotDefined)
		{
			patternStyle_0 = source.PatternStyle;
		}
		if (source.ForeColor.ColorType != ColorType.NotDefined)
		{
			class18_0.ColorResolver = ((ColorFormat)source.ForeColor).method_5;
		}
		if (source.BackColor.ColorType != ColorType.NotDefined)
		{
			class18_1.ColorResolver = ((ColorFormat)source.BackColor).method_5;
		}
	}

	internal void method_1(IBaseSlide slide, FloatColor styleColor)
	{
		class18_0.method_0(slide, styleColor);
		class18_1.method_0(slide, styleColor);
	}

	internal void method_2(Class59 source)
	{
		patternStyle_0 = source.PatternStyle;
		class18_0.ColorResolver = source.class18_0.ColorResolver;
		class18_1.ColorResolver = source.class18_1.ColorResolver;
	}

	public Bitmap GetTileImage(Color background, Color foreground)
	{
		return smethod_0(PixelFormat.Format32bppArgb, PatternStyle, background, foreground);
	}

	internal static Bitmap smethod_0(PixelFormat pixelFormat, PatternStyle patternStyle, Color background, Color foreground)
	{
		byte[,] byte_ = PatternFormat.dictionary_0[(int)patternStyle].byte_0;
		if (byte_ == null)
		{
			byte_ = PatternFormat.dictionary_0[1].byte_0;
		}
		Bitmap bitmap = new Bitmap(byte_.GetUpperBound(1) + 1, byte_.GetUpperBound(0) + 1, pixelFormat);
		for (int i = 0; i <= byte_.GetUpperBound(0); i++)
		{
			for (int j = 0; j <= byte_.GetUpperBound(1); j++)
			{
				float num = (float)(int)byte_[i, j] / 255f;
				float num2 = 1f - num;
				bitmap.SetPixel(j, i, Color.FromArgb((int)Math.Round((float)(int)foreground.A * num + (float)(int)background.A * num2), (int)Math.Round((float)(int)foreground.R * num + (float)(int)background.R * num2), (int)Math.Round((float)(int)foreground.G * num + (float)(int)background.G * num2), (int)Math.Round((float)(int)foreground.B * num + (float)(int)background.B * num2)));
			}
		}
		return bitmap;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Class59 obj2))
		{
			return false;
		}
		return method_3(obj2);
	}

	internal bool method_3(Class59 obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (patternStyle_0 != obj.patternStyle_0)
		{
			return false;
		}
		if (!class18_0.Equals(obj.class18_0))
		{
			return false;
		}
		if (!class18_1.Equals(obj.class18_1))
		{
			return false;
		}
		return true;
	}

	internal bool method_4(PatternFormatEffectiveData obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (patternStyle_0 != obj.PatternStyle)
		{
			return false;
		}
		if (!class18_0.Color.Equals(obj.ForeColor))
		{
			return false;
		}
		if (!class18_1.Color.Equals(obj.BackColor))
		{
			return false;
		}
		return true;
	}

	public override int GetHashCode()
	{
		return 23454;
	}
}

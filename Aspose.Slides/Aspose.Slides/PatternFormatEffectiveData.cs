using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Aspose.Slides;

public class PatternFormatEffectiveData : IPatternFormatEffectiveData, IEffectiveData
{
	private Color color_0;

	private Color color_1;

	private PatternStyle patternStyle_0;

	public PatternStyle PatternStyle => patternStyle_0;

	public Color ForeColor => color_0;

	public Color BackColor => color_1;

	internal PatternFormatEffectiveData()
	{
		patternStyle_0 = PatternStyle.NotDefined;
		color_0 = Color.Black;
		color_1 = Color.White;
	}

	internal PatternFormatEffectiveData(PatternFormat source, IBaseSlide slide, FloatColor styleColor)
	{
		method_0(source, slide, styleColor);
	}

	internal void method_0(PatternFormat source, IBaseSlide slide, FloatColor styleColor)
	{
		if (source != null)
		{
			patternStyle_0 = source.PatternStyle;
			color_0 = ((ColorFormat)source.ForeColor).method_5(slide, styleColor);
			color_1 = ((ColorFormat)source.BackColor).method_5(slide, styleColor);
		}
	}

	internal void method_1(PatternFormat source, BaseSlide slide, FloatColor styleColor)
	{
		if (source != null)
		{
			if (source.PatternStyle != PatternStyle.NotDefined)
			{
				patternStyle_0 = source.PatternStyle;
			}
			if (source.ForeColor.ColorType != ColorType.NotDefined)
			{
				color_0 = ((ColorFormat)source.ForeColor).method_5(slide, styleColor);
			}
			if (source.BackColor.ColorType != ColorType.NotDefined)
			{
				color_1 = ((ColorFormat)source.BackColor).method_5(slide, styleColor);
			}
		}
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
		if (!(obj is PatternFormatEffectiveData obj2))
		{
			return false;
		}
		return method_2(obj2);
	}

	internal bool method_2(PatternFormatEffectiveData obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (patternStyle_0 != obj.PatternStyle)
		{
			return false;
		}
		if (!color_0.Equals(obj.ForeColor))
		{
			return false;
		}
		if (!color_1.Equals(obj.BackColor))
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

using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ns233;

internal class Class6143
{
	public static Bitmap smethod_0(Bitmap original, Class6144 colorSettings)
	{
		if (Class6148.smethod_43(original.Width, original.Height))
		{
			return original;
		}
		if (colorSettings.ColorMode == Enum787.const_2)
		{
			Bitmap original2 = smethod_2(original, colorSettings.Contrast, colorSettings.Brightness);
			return smethod_1(original2, colorSettings.ColorMode);
		}
		Bitmap original3 = smethod_1(original, colorSettings.ColorMode);
		return smethod_2(original3, colorSettings.Contrast, colorSettings.Brightness);
	}

	private static Bitmap smethod_1(Bitmap original, Enum787 colorMode)
	{
		switch (colorMode)
		{
		default:
			throw new InvalidOperationException("Unknown color mode.");
		case Enum787.const_0:
			return original;
		case Enum787.const_1:
		{
			ImageAttributes imageAttributes2 = new ImageAttributes();
			imageAttributes2.SetColorMatrix(smethod_5());
			return smethod_3(original, imageAttributes2);
		}
		case Enum787.const_2:
		{
			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetColorMatrix(smethod_5());
			imageAttributes.SetThreshold(0.5f);
			return smethod_3(original, imageAttributes);
		}
		}
	}

	private static Bitmap smethod_2(Bitmap original, float contrast, float brightness)
	{
		if (Class6144.smethod_2(brightness) && Class6144.smethod_1(contrast))
		{
			return original;
		}
		ImageAttributes imageAttributes = new ImageAttributes();
		imageAttributes.SetColorMatrix(smethod_4(contrast, brightness));
		return smethod_3(original, imageAttributes);
	}

	private static Bitmap smethod_3(Bitmap original, ImageAttributes attributes)
	{
		Bitmap bitmap = new Bitmap(original.Width, original.Height);
		bitmap.SetResolution(original.HorizontalResolution, original.VerticalResolution);
		using (Graphics graphics = Class6148.smethod_42(bitmap))
		{
			graphics.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
		}
		original.Dispose();
		return bitmap;
	}

	private static ColorMatrix smethod_4(float contrast, float brightness)
	{
		float num = ((contrast < 0.5f) ? (2f * contrast) : ((!(contrast > 0.99f)) ? Math.Min(1.1f * (float)Math.Tan(Math.PI * (double)(contrast - 0.5f)) + 1f, 500f) : 500f));
		float num2 = num * (brightness - 1f) + brightness;
		float[][] newColorMatrix = new float[5][]
		{
			new float[5] { num, 0f, 0f, 0f, 0f },
			new float[5] { 0f, num, 0f, 0f, 0f },
			new float[5] { 0f, 0f, num, 0f, 0f },
			new float[5] { 0f, 0f, 0f, 1f, 0f },
			new float[5] { num2, num2, num2, 0f, 1f }
		};
		return new ColorMatrix(newColorMatrix);
	}

	private static ColorMatrix smethod_5()
	{
		float[][] newColorMatrix = new float[5][]
		{
			new float[5] { 0.3f, 0.3f, 0.3f, 0f, 0f },
			new float[5] { 0.59f, 0.59f, 0.59f, 0f, 0f },
			new float[5] { 0.11f, 0.11f, 0.11f, 0f, 0f },
			new float[5] { 0f, 0f, 0f, 1f, 0f },
			new float[5] { 0.001f, 0.001f, 0.001f, 0.001f, 0.001f }
		};
		return new ColorMatrix(newColorMatrix);
	}
}

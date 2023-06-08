using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace ns18;

internal class Class1402
{
	private static readonly Hashtable hashtable_0;

	private Class1402()
	{
	}

	public static void smethod_0(Image image_0, Stream stream_0, int int_0)
	{
		ImageCodecInfo encoder = smethod_6(ImageFormat.Jpeg);
		EncoderParameters encoderParameters = new EncoderParameters(1);
		encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, int_0);
		image_0.Save(stream_0, encoder, encoderParameters);
	}

	public static Struct74 smethod_1(Image image_0, Stream stream_0, Enum201 enum201_0, bool bool_0)
	{
		if (smethod_7(enum201_0) && image_0.PixelFormat != PixelFormat.Format1bppIndexed)
		{
			image_0 = smethod_3((Bitmap)image_0);
		}
		EncoderParameters encoderParameters = smethod_4(enum201_0, bool_0);
		ImageCodecInfo encoder = smethod_6(ImageFormat.Tiff);
		image_0.Save(stream_0, encoder, encoderParameters);
		Struct74 result = default(Struct74);
		result.method_0(image_0);
		result.method_1(enum201_0);
		result.method_2(encoderParameters);
		return result;
	}

	private static Bitmap smethod_2(Bitmap bitmap_0)
	{
		Bitmap bitmap = new Bitmap(bitmap_0.Width, bitmap_0.Height);
		bitmap.SetResolution(bitmap_0.HorizontalResolution, bitmap_0.VerticalResolution);
		Graphics graphics = Graphics.FromImage(bitmap);
		graphics.DrawImage(bitmap_0, new Point(0, 0));
		return bitmap;
	}

	private static Bitmap smethod_3(Bitmap bitmap_0)
	{
		if (bitmap_0.PixelFormat != PixelFormat.Format32bppArgb)
		{
			bitmap_0 = smethod_2(bitmap_0);
		}
		BitmapData bitmapData = bitmap_0.LockBits(new Rectangle(0, 0, bitmap_0.Width, bitmap_0.Height), ImageLockMode.ReadOnly, bitmap_0.PixelFormat);
		Bitmap bitmap = new Bitmap(bitmapData.Width, bitmap_0.Height, PixelFormat.Format1bppIndexed);
		bitmap.SetResolution(bitmap_0.HorizontalResolution, bitmap_0.VerticalResolution);
		BitmapData bitmapData2 = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format1bppIndexed);
		int num = 0;
		int num2 = bitmapData2.Stride - bitmapData2.Width / 8 - 1;
		int num3 = bitmapData.Stride * bitmapData.Height;
		byte[] array = new byte[num3];
		Marshal.Copy(bitmapData.Scan0, array, 0, num3);
		bitmap_0.UnlockBits(bitmapData);
		num3 = bitmapData2.Stride * bitmapData2.Height;
		byte[] array2 = new byte[num3];
		Marshal.Copy(bitmapData2.Scan0, array2, 0, num3);
		int num4 = 0;
		int num5 = 0;
		for (int i = 0; i < bitmapData.Height; i++)
		{
			byte b = 0;
			for (int j = 0; j < bitmapData.Width; j++)
			{
				byte blue = array[num5++];
				byte green = array[num5++];
				byte red = array[num5++];
				byte alpha = array[num5++];
				if (Color.FromArgb(alpha, red, green, blue).GetBrightness() > 0.5f)
				{
					b = (byte)(b | (byte)(128 >> num));
				}
				if (++num == 8)
				{
					array2[num4++] = b;
					num = 0;
					b = 0;
				}
			}
			if (num != 0)
			{
				array2[num4++] = b;
				num = 0;
			}
			if (i < bitmapData.Height - 1)
			{
				num4 += num2;
			}
		}
		Marshal.Copy(array2, 0, bitmapData2.Scan0, num3);
		bitmap.UnlockBits(bitmapData2);
		return bitmap;
	}

	private static EncoderParameters smethod_4(Enum201 enum201_0, bool bool_0)
	{
		EncoderParameter encoderParameter = new EncoderParameter(Encoder.Compression, (long)smethod_5(enum201_0));
		if (bool_0)
		{
			EncoderParameters encoderParameters = new EncoderParameters(2);
			encoderParameters.Param[0] = new EncoderParameter(Encoder.SaveFlag, 18L);
			encoderParameters.Param[1] = encoderParameter;
			return encoderParameters;
		}
		EncoderParameters encoderParameters2 = new EncoderParameters();
		encoderParameters2.Param[0] = encoderParameter;
		return encoderParameters2;
	}

	private static EncoderValue smethod_5(Enum201 enum201_0)
	{
		return (EncoderValue)hashtable_0[enum201_0];
	}

	private static ImageCodecInfo smethod_6(ImageFormat imageFormat_0)
	{
		ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
		int num = 0;
		while (true)
		{
			if (num < imageEncoders.Length)
			{
				if (imageEncoders[num].FormatID == imageFormat_0.Guid)
				{
					break;
				}
				num++;
				continue;
			}
			throw new ArgumentException(string.Concat("Cannot find a codec for ", imageFormat_0, "."));
		}
		return imageEncoders[num];
	}

	private static bool smethod_7(Enum201 enum201_0)
	{
		switch (enum201_0)
		{
		default:
			return false;
		case Enum201.const_1:
		case Enum201.const_3:
		case Enum201.const_4:
			return true;
		}
	}

	static Class1402()
	{
		hashtable_0 = new Hashtable();
		hashtable_0.Add(Enum201.const_0, EncoderValue.CompressionNone);
		hashtable_0.Add(Enum201.const_1, EncoderValue.CompressionRle);
		hashtable_0.Add(Enum201.const_2, EncoderValue.CompressionLZW);
		hashtable_0.Add(Enum201.const_3, EncoderValue.CompressionCCITT3);
		hashtable_0.Add(Enum201.const_4, EncoderValue.CompressionCCITT4);
	}
}

using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace ns233;

internal static class Class6146
{
	private static readonly Hashtable hashtable_0;

	public static void smethod_0(Image image, Stream stream, int quality)
	{
		ImageCodecInfo encoder = smethod_6(ImageFormat.Jpeg);
		EncoderParameters encoderParameters = new EncoderParameters();
		encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, quality);
		try
		{
			image.Save(stream, encoder, encoderParameters);
		}
		catch (ExternalException)
		{
			stream.Position = 0L;
			using Bitmap bitmap = new Bitmap(image);
			bitmap.Save(stream, encoder, encoderParameters);
		}
	}

	public static Struct218 smethod_1(Image frame, Stream stream, Enum789 compression, bool isMultiframe)
	{
		if (smethod_7(compression) && frame.PixelFormat != PixelFormat.Format1bppIndexed)
		{
			frame = new Class6138().method_1((Bitmap)frame);
		}
		EncoderParameters encoderParameters = smethod_4(compression, isMultiframe);
		ImageCodecInfo encoder = smethod_6(ImageFormat.Tiff);
		frame.Save(stream, encoder, encoderParameters);
		Struct218 result = default(Struct218);
		result.FirstFrame = frame;
		result.Compression = compression;
		result.EncoderParameters = encoderParameters;
		return result;
	}

	public static void smethod_2(Image frame, Struct218 tiffData)
	{
		if (smethod_7(tiffData.Compression) && frame.PixelFormat != PixelFormat.Format1bppIndexed)
		{
			frame = new Class6138().method_1((Bitmap)frame);
		}
		tiffData.EncoderParameters.Param[0] = new EncoderParameter(tiffData.EncoderParameters.Param[0].Encoder, 23L);
		tiffData.FirstFrame.SaveAdd(frame, tiffData.EncoderParameters);
	}

	public static void smethod_3(Struct218 tiffData)
	{
		tiffData.EncoderParameters.Param[0] = new EncoderParameter(tiffData.EncoderParameters.Param[0].Encoder, 20L);
		tiffData.FirstFrame.SaveAdd(tiffData.EncoderParameters);
	}

	private static EncoderParameters smethod_4(Enum789 compression, bool isMultiframe)
	{
		EncoderParameter encoderParameter = new EncoderParameter(Encoder.Compression, (long)smethod_5(compression));
		if (isMultiframe)
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

	private static EncoderValue smethod_5(Enum789 compression)
	{
		return (EncoderValue)hashtable_0[compression];
	}

	private static ImageCodecInfo smethod_6(ImageFormat format)
	{
		ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
		int num = 0;
		while (true)
		{
			if (num < imageEncoders.Length)
			{
				if (imageEncoders[num].FormatID == format.Guid)
				{
					break;
				}
				num++;
				continue;
			}
			throw new ArgumentException(string.Concat("Cannot find a codec for ", format, "."));
		}
		return imageEncoders[num];
	}

	private static bool smethod_7(Enum789 compression)
	{
		switch (compression)
		{
		default:
			return false;
		case Enum789.const_1:
		case Enum789.const_3:
		case Enum789.const_4:
			return true;
		}
	}

	static Class6146()
	{
		hashtable_0 = new Hashtable();
		hashtable_0.Add(Enum789.const_0, EncoderValue.CompressionNone);
		hashtable_0.Add(Enum789.const_1, EncoderValue.CompressionRle);
		hashtable_0.Add(Enum789.const_2, EncoderValue.CompressionLZW);
		hashtable_0.Add(Enum789.const_3, EncoderValue.CompressionCCITT3);
		hashtable_0.Add(Enum789.const_4, EncoderValue.CompressionCCITT4);
	}
}

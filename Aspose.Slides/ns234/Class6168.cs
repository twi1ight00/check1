using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ns233;

namespace ns234;

internal class Class6168 : IDisposable
{
	private static readonly Hashtable hashtable_0;

	private Enum789 enum789_0;

	private Image image_0;

	private EncoderParameters encoderParameters_0;

	private bool bool_0;

	public void Dispose()
	{
		if (bool_0 && image_0 != null)
		{
			image_0.Dispose();
			image_0 = null;
		}
		GC.SuppressFinalize(this);
	}

	public void method_0(Bitmap bitmap, Stream stream, Enum789 compression, bool isMultiframe)
	{
		enum789_0 = compression;
		image_0 = smethod_0(bitmap, compression);
		ImageCodecInfo encoder = Class6142.smethod_0(ImageFormat.Tiff);
		encoderParameters_0 = smethod_1(compression, isMultiframe);
		image_0.Save(stream, encoder, encoderParameters_0);
		bool_0 = image_0 != bitmap;
	}

	public void method_1(Class6150 bitmap)
	{
		Bitmap image = smethod_0(bitmap.method_2(), enum789_0);
		encoderParameters_0.Param[0] = new EncoderParameter(encoderParameters_0.Param[0].Encoder, 23L);
		image_0.SaveAdd(image, encoderParameters_0);
	}

	public void method_2()
	{
		encoderParameters_0.Param[0] = new EncoderParameter(encoderParameters_0.Param[0].Encoder, 20L);
		image_0.SaveAdd(encoderParameters_0);
	}

	private static Bitmap smethod_0(Bitmap bitmap, Enum789 compression)
	{
		switch (compression)
		{
		case Enum789.const_1:
		case Enum789.const_3:
		case Enum789.const_4:
			if (bitmap.PixelFormat != PixelFormat.Format1bppIndexed)
			{
				bitmap = new Class6138().method_1(bitmap);
			}
			break;
		}
		return bitmap;
	}

	private static EncoderParameters smethod_1(Enum789 compression, bool isMultiframe)
	{
		EncoderParameter encoderParameter = new EncoderParameter(Encoder.Compression, (long)smethod_2(compression));
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

	private static EncoderValue smethod_2(Enum789 compression)
	{
		return (EncoderValue)hashtable_0[compression];
	}

	static Class6168()
	{
		hashtable_0 = new Hashtable();
		hashtable_0.Add(Enum789.const_0, EncoderValue.CompressionNone);
		hashtable_0.Add(Enum789.const_1, EncoderValue.CompressionRle);
		hashtable_0.Add(Enum789.const_2, EncoderValue.CompressionLZW);
		hashtable_0.Add(Enum789.const_3, EncoderValue.CompressionCCITT3);
		hashtable_0.Add(Enum789.const_4, EncoderValue.CompressionCCITT4);
	}
}

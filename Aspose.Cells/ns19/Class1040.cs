using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using Aspose.Cells.Rendering;

namespace ns19;

internal class Class1040 : Class1039
{
	private Interface6 interface6_0;

	private Stream stream_0;

	private Bitmap bitmap_0;

	private ImageFormat imageFormat_0;

	private ImageOrPrintOptions imageOrPrintOptions_0;

	private Stream stream_1;

	internal Class1040(Graphics graphics_1, Bitmap bitmap_1, ImageFormat imageFormat_1, ImageOrPrintOptions imageOrPrintOptions_1, Stream stream_2, Interface6 interface6_1)
		: base(graphics_1)
	{
		bitmap_0 = bitmap_1;
		imageFormat_0 = imageFormat_1;
		if (imageOrPrintOptions_1 == null)
		{
			imageOrPrintOptions_0 = new ImageOrPrintOptions();
		}
		else
		{
			imageOrPrintOptions_0 = imageOrPrintOptions_1;
		}
		stream_0 = stream_2;
		stream_1 = null;
		interface6_0 = interface6_1;
	}

	public override void imethod_2()
	{
		if (bitmap_0 == null || stream_0 == null)
		{
			return;
		}
		try
		{
			if (imageOrPrintOptions_0.bool_2)
			{
				stream_1 = new MemoryStream();
				ImageOrPrintOptions imageOrPrintOptions = null;
				Interface42 @interface = Class1036.smethod_0(Class1036.int_0, bitmap_0.Width, bitmap_0.Height, ImageFormat.Emf, imageOrPrintOptions, stream_1, interface6_0);
				((Class1041)@interface).bool_0 = true;
				@interface.imethod_2();
				method_0(bitmap_0, stream_0);
			}
			else
			{
				interface6_0.imethod_2();
				method_0(bitmap_0, stream_0);
			}
		}
		finally
		{
			Dispose();
		}
	}

	public override Bitmap imethod_3()
	{
		if (bitmap_0 == null)
		{
			return null;
		}
		try
		{
			if (imageOrPrintOptions_0.bool_2)
			{
				stream_1 = new MemoryStream();
				ImageOrPrintOptions imageOrPrintOptions = null;
				Interface42 @interface = Class1036.smethod_0(Class1036.int_0, bitmap_0.Width, bitmap_0.Height, ImageFormat.Emf, imageOrPrintOptions, stream_1, interface6_0);
				((Class1041)@interface).bool_0 = true;
				@interface.imethod_2();
				return method_3(bitmap_0);
			}
			interface6_0.imethod_2();
			return bitmap_0;
		}
		finally
		{
			vmethod_0();
		}
	}

	public override void vmethod_0()
	{
		if (graphics_0 != null)
		{
			graphics_0.Dispose();
			graphics_0 = null;
		}
	}

	public override void Dispose()
	{
		if (bitmap_0 != null)
		{
			bitmap_0.Dispose();
			bitmap_0 = null;
		}
		vmethod_0();
	}

	private void method_0(Bitmap bitmap_1, Stream stream_2)
	{
		if (imageFormat_0 == ImageFormat.Jpeg)
		{
			method_1(bitmap_1, stream_2);
			return;
		}
		if (imageFormat_0 == ImageFormat.Tiff)
		{
			method_2(bitmap_1, stream_2);
			return;
		}
		Bitmap bitmap = method_3(bitmap_1);
		bitmap.Save(stream_2, imageFormat_0);
		bitmap.Dispose();
	}

	private void method_1(Bitmap bitmap_1, Stream stream_2)
	{
		ImageOrPrintOptions imageOrPrintOptions = imageOrPrintOptions_0;
		if (imageOrPrintOptions.Quality < 0 || imageOrPrintOptions.Quality > 100)
		{
			throw new ArgumentOutOfRangeException("Quality must be between 0 and 100");
		}
		EncoderParameter encoderParameter = new EncoderParameter(Encoder.Quality, imageOrPrintOptions.Quality);
		ImageCodecInfo encoder = method_5("image/jpeg");
		EncoderParameters encoderParameters = new EncoderParameters(1);
		encoderParameters.Param[0] = encoderParameter;
		Bitmap bitmap = method_3(bitmap_1);
		bitmap.Save(stream_2, encoder, encoderParameters);
		bitmap.Dispose();
	}

	private void method_2(Bitmap bitmap_1, Stream stream_2)
	{
		ImageOrPrintOptions imageOrPrintOptions = imageOrPrintOptions_0;
		EncoderValue encoderValue = EncoderValue.CompressionLZW;
		bool flag = false;
		switch (imageOrPrintOptions.TiffCompression)
		{
		case TiffCompression.CompressionNone:
			encoderValue = EncoderValue.CompressionNone;
			break;
		case TiffCompression.CompressionRle:
			flag = true;
			encoderValue = EncoderValue.CompressionRle;
			break;
		default:
			encoderValue = EncoderValue.CompressionLZW;
			break;
		case TiffCompression.CompressionCCITT3:
			flag = true;
			encoderValue = EncoderValue.CompressionCCITT3;
			break;
		case TiffCompression.CompressionCCITT4:
			flag = true;
			encoderValue = EncoderValue.CompressionCCITT4;
			break;
		}
		Bitmap bitmap = null;
		if (!flag)
		{
			bitmap = method_3(bitmap_1);
		}
		else
		{
			Bitmap bitmap_2 = method_3(bitmap_1);
			bitmap = method_4(bitmap_2, imageOrPrintOptions);
		}
		ImageCodecInfo encoder = method_5("image/tiff");
		Encoder compression = Encoder.Compression;
		EncoderParameters encoderParameters = new EncoderParameters(1);
		EncoderParameter encoderParameter = new EncoderParameter(compression, (long)encoderValue);
		encoderParameters.Param[0] = encoderParameter;
		bitmap.Save(stream_2, encoder, encoderParameters);
		bitmap.Dispose();
	}

	internal Bitmap method_3(Bitmap bitmap_1)
	{
		ImageOrPrintOptions imageOrPrintOptions = imageOrPrintOptions_0;
		Stream stream = stream_1;
		if (imageOrPrintOptions.bool_2 && stream != null)
		{
			stream.Seek(0L, SeekOrigin.Begin);
			Image image = Image.FromStream(stream);
			int width = (int)((float)(image.Width * imageOrPrintOptions.HorizontalResolution) / graphics_0.DpiX + 0.5f);
			int height = (int)((float)(image.Height * imageOrPrintOptions.VerticalResolution) / graphics_0.DpiY + 0.5f);
			Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
			bitmap.SetResolution(imageOrPrintOptions.HorizontalResolution, imageOrPrintOptions.VerticalResolution);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.DrawImage(image, 0, 0, bitmap.Width, bitmap.Height);
			}
			stream.Close();
			bitmap_1?.Dispose();
			return bitmap;
		}
		return bitmap_1;
	}

	private Bitmap method_4(Bitmap bitmap_1, ImageOrPrintOptions imageOrPrintOptions_1)
	{
		if (bitmap_1 == null)
		{
			return bitmap_1;
		}
		Bitmap bitmap = null;
		if (bitmap_1.PixelFormat != PixelFormat.Format32bppArgb)
		{
			bitmap = new Bitmap(bitmap_1.Width, bitmap_1.Height, PixelFormat.Format32bppArgb);
			bitmap.SetResolution(imageOrPrintOptions_1.HorizontalResolution, imageOrPrintOptions_1.VerticalResolution);
			using Graphics graphics = Graphics.FromImage(bitmap);
			graphics.DrawImageUnscaled(bitmap_1, 0, 0);
		}
		else
		{
			bitmap = bitmap_1;
		}
		BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
		int num = bitmapData.Stride * bitmapData.Height;
		byte[] array = new byte[num];
		Marshal.Copy(bitmapData.Scan0, array, 0, num);
		bitmap.UnlockBits(bitmapData);
		Bitmap bitmap2 = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format1bppIndexed);
		bitmap2.SetResolution(imageOrPrintOptions_1.HorizontalResolution, imageOrPrintOptions_1.VerticalResolution);
		BitmapData bitmapData2 = bitmap2.LockBits(new Rectangle(0, 0, bitmap2.Width, bitmap2.Height), ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);
		num = bitmapData2.Stride * bitmapData2.Height;
		byte[] array2 = new byte[num];
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		byte b = 0;
		int num5 = 128;
		int height = bitmap.Height;
		int width = bitmap.Width;
		int num6 = 500;
		for (int i = 0; i < height; i++)
		{
			num2 = i * bitmapData.Stride;
			num3 = i * bitmapData2.Stride;
			b = 0;
			num5 = 128;
			for (int j = 0; j < width; j++)
			{
				num4 = array[num2 + 1] + array[num2 + 2] + array[num2 + 3];
				if (num4 > num6)
				{
					b = (byte)(b + (byte)num5);
				}
				if (num5 == 1)
				{
					array2[num3] = b;
					num3++;
					b = 0;
					num5 = 128;
				}
				else
				{
					num5 >>= 1;
				}
				num2 += 4;
			}
			if (num5 != 128)
			{
				array2[num3] = b;
			}
		}
		Marshal.Copy(array2, 0, bitmapData2.Scan0, num);
		bitmap2.UnlockBits(bitmapData2);
		if (bitmap != bitmap_1)
		{
			bitmap.Dispose();
		}
		return bitmap2;
	}

	private ImageCodecInfo method_5(string string_0)
	{
		ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
		int num = 0;
		while (true)
		{
			if (num < imageEncoders.Length)
			{
				if (imageEncoders[num].MimeType == string_0)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return imageEncoders[num];
	}
}

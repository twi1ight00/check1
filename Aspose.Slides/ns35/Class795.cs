using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace ns35;

internal class Class795 : Class794
{
	private Interface4 interface4_0;

	private Stream stream_0;

	private Bitmap bitmap_0;

	private ImageFormat imageFormat_0;

	private Class806 class806_0;

	private Stream stream_1;

	internal Class795(Graphics g, Bitmap Bitmap, ImageFormat format, Class806 imageOption, Stream stream, Interface4 shapeDrawing)
		: base(g)
	{
		bitmap_0 = Bitmap;
		imageFormat_0 = format;
		if (imageOption == null)
		{
			class806_0 = new Class806();
		}
		else
		{
			class806_0 = imageOption;
		}
		stream_0 = stream;
		stream_1 = null;
		interface4_0 = shapeDrawing;
	}

	public override void imethod_0()
	{
		if (bitmap_0 == null || stream_0 == null)
		{
			return;
		}
		try
		{
			if (class806_0.bool_2)
			{
				stream_1 = new MemoryStream();
				Interface32 @interface = Class792.smethod_1(Class792.int_0, bitmap_0.Width, bitmap_0.Height, ImageFormat.Emf, class806_0, stream_1, interface4_0);
				@interface.imethod_0();
				method_1(bitmap_0, stream_0);
			}
			else
			{
				interface4_0.imethod_0();
				method_1(bitmap_0, stream_0);
			}
		}
		finally
		{
			Dispose();
		}
	}

	public override Bitmap imethod_1()
	{
		if (bitmap_0 == null)
		{
			return null;
		}
		try
		{
			if (class806_0.bool_2)
			{
				stream_1 = new MemoryStream();
				Interface32 @interface = Class792.smethod_1(Class792.int_0, bitmap_0.Width, bitmap_0.Height, ImageFormat.Emf, class806_0, stream_1, interface4_0);
				@interface.imethod_0();
				return method_4(bitmap_0);
			}
			interface4_0.imethod_0();
			return bitmap_0;
		}
		finally
		{
			imethod_2();
		}
	}

	public override void imethod_2()
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
		imethod_2();
	}

	private void method_1(Bitmap bitmap, Stream stream)
	{
		if (imageFormat_0 == ImageFormat.Jpeg)
		{
			method_2(bitmap, stream);
			return;
		}
		if (imageFormat_0 == ImageFormat.Tiff)
		{
			method_3(bitmap, stream);
			return;
		}
		Bitmap bitmap2 = method_4(bitmap);
		bitmap2.Save(stream, imageFormat_0);
		bitmap2.Dispose();
	}

	private void method_2(Bitmap bitmap, Stream stream)
	{
		Class806 @class = class806_0;
		if (@class.Quality < 0 || @class.Quality > 100)
		{
			throw new ArgumentOutOfRangeException("Quality must be between 0 and 100");
		}
		EncoderParameter encoderParameter = new EncoderParameter(Encoder.Quality, @class.Quality);
		ImageCodecInfo encoder = method_7("image/jpeg");
		EncoderParameters encoderParameters = new EncoderParameters(1);
		encoderParameters.Param[0] = encoderParameter;
		Bitmap bitmap2 = method_4(bitmap);
		bitmap2.Save(stream, encoder, encoderParameters);
		bitmap2.Dispose();
	}

	private void method_3(Bitmap bitmap, Stream stream)
	{
		Class806 @class = class806_0;
		EncoderValue encoderValue = EncoderValue.CompressionLZW;
		bool flag = false;
		switch (@class.TiffCompression)
		{
		case Enum163.const_0:
			encoderValue = EncoderValue.CompressionNone;
			break;
		case Enum163.const_1:
			flag = true;
			encoderValue = EncoderValue.CompressionRle;
			break;
		default:
			encoderValue = EncoderValue.CompressionLZW;
			break;
		case Enum163.const_3:
			flag = true;
			encoderValue = EncoderValue.CompressionCCITT3;
			break;
		case Enum163.const_4:
			flag = true;
			encoderValue = EncoderValue.CompressionCCITT4;
			break;
		}
		Bitmap bitmap2 = null;
		if (!flag)
		{
			bitmap2 = method_4(bitmap);
		}
		else
		{
			Bitmap original = method_4(bitmap);
			bitmap2 = method_6(original, @class);
		}
		ImageCodecInfo encoder = method_7("image/tiff");
		Encoder compression = Encoder.Compression;
		EncoderParameters encoderParameters = new EncoderParameters(1);
		EncoderParameter encoderParameter = new EncoderParameter(compression, (long)encoderValue);
		encoderParameters.Param[0] = encoderParameter;
		bitmap2.Save(stream, encoder, encoderParameters);
		bitmap2.Dispose();
	}

	internal Bitmap method_4(Bitmap bitmap)
	{
		Class806 @class = class806_0;
		Stream stream = stream_1;
		if (@class.bool_2 && stream != null)
		{
			stream.Seek(0L, SeekOrigin.Begin);
			Image image = Image.FromStream(stream);
			int width = (int)((float)(image.Width * @class.HorizontalResolution) / 96f + 0.5f);
			int height = (int)((float)(image.Height * @class.VerticalResolution) / 96f + 0.5f);
			Bitmap bitmap2 = new Bitmap(width, height, PixelFormat.Format32bppArgb);
			bitmap2.SetResolution(@class.HorizontalResolution, @class.VerticalResolution);
			using (Graphics graphics = Graphics.FromImage(bitmap2))
			{
				graphics.DrawImage(image, 0, 0, bitmap2.Width, bitmap2.Height);
			}
			stream.Close();
			bitmap?.Dispose();
			return bitmap2;
		}
		return bitmap;
	}

	private Bitmap method_5(Bitmap original)
	{
		Bitmap bitmap = new Bitmap(original.Width, original.Height, PixelFormat.Format32bppArgb);
		bitmap.SetResolution(original.HorizontalResolution, original.VerticalResolution);
		Graphics graphics = Graphics.FromImage(bitmap);
		graphics.DrawImageUnscaled(original, 0, 0);
		graphics.Dispose();
		return bitmap;
	}

	private Bitmap method_6(Bitmap original, Class806 options)
	{
		if (original == null)
		{
			return original;
		}
		Bitmap bitmap = null;
		if (original.PixelFormat != PixelFormat.Format32bppArgb)
		{
			bitmap = new Bitmap(original.Width, original.Height, PixelFormat.Format32bppArgb);
			bitmap.SetResolution(options.HorizontalResolution, options.VerticalResolution);
			using Graphics graphics = Graphics.FromImage(bitmap);
			graphics.DrawImageUnscaled(original, 0, 0);
		}
		else
		{
			bitmap = original;
		}
		BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
		int num = bitmapData.Stride * bitmapData.Height;
		byte[] array = new byte[num];
		Marshal.Copy(bitmapData.Scan0, array, 0, num);
		bitmap.UnlockBits(bitmapData);
		Bitmap bitmap2 = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format1bppIndexed);
		bitmap2.SetResolution(options.HorizontalResolution, options.VerticalResolution);
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
		if (bitmap != original)
		{
			bitmap.Dispose();
		}
		return bitmap2;
	}

	private ImageCodecInfo method_7(string mimeType)
	{
		ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
		int num = 0;
		while (true)
		{
			if (num < imageEncoders.Length)
			{
				if (imageEncoders[num].MimeType == mimeType)
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

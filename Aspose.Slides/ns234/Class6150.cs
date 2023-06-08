using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using ns218;
using ns221;
using ns224;
using ns233;

namespace ns234;

internal class Class6150 : IDisposable
{
	private const double double_0 = 0.0254;

	private const int int_0 = 1;

	private const int int_1 = 2;

	private const int int_2 = 4;

	private const int int_3 = 8207;

	private Bitmap bitmap_0;

	private Enum788 enum788_0;

	private bool bool_0;

	public int Width => bitmap_0.Width;

	public int Height => bitmap_0.Height;

	public float HorizontalResolution
	{
		get
		{
			if (!bool_0)
			{
				return bitmap_0.HorizontalResolution;
			}
			return 96f;
		}
	}

	public float VerticalResolution
	{
		get
		{
			if (!bool_0)
			{
				return bitmap_0.VerticalResolution;
			}
			return 96f;
		}
	}

	public Enum788 ImageType => enum788_0;

	public Class6150(int width, int height)
		: this(width, height, 96f, 96f)
	{
	}

	public Class6150(int width, int height, float hRes, float vRes)
		: this(width, height, hRes, vRes, PixelFormat.Format32bppArgb)
	{
	}

	public Class6150(int width, int height, float hRes, float vRes, PixelFormat pixelFormat)
	{
		if (smethod_5(pixelFormat) == Enum786.const_1)
		{
			pixelFormat = PixelFormat.Format32bppArgb;
		}
		Bitmap bitmap = new Bitmap(width, height, pixelFormat);
		bitmap.SetResolution(hRes, vRes);
		method_0(bitmap);
	}

	public Class6150(byte[] imageBytes)
	{
		using (MemoryStream stream = new MemoryStream(imageBytes))
		{
			Bitmap bitmap = new Bitmap(stream);
			if (bitmap.PixelFormat == (PixelFormat)8207)
			{
				method_0(new Bitmap(bitmap));
				bitmap.Dispose();
			}
			else
			{
				method_0(bitmap);
			}
		}
		bool_0 = Class6148.smethod_3(imageBytes).IsOriginalResolutionZero;
	}

	public Class6150(Class5995 brush)
	{
		if (brush.BrushType != Enum746.const_2)
		{
			throw new ArgumentException("Texture brush is expected.");
		}
		using TextureBrush textureBrush = (TextureBrush)Class6151.smethod_0(brush);
		method_0((Bitmap)textureBrush.Image);
		bool_0 = Class6148.smethod_3(brush.ImageBytes).IsOriginalResolutionZero || Class6148.smethod_17(brush.ImageBytes);
	}

	private Class6150(Bitmap bitmap)
	{
		method_0(bitmap);
	}

	private void method_0(Bitmap bitmap)
	{
		bitmap_0 = bitmap;
		enum788_0 = smethod_18(bitmap_0.RawFormat);
	}

	public void Dispose()
	{
		Close();
		GC.SuppressFinalize(this);
	}

	public void Close()
	{
		if (bitmap_0 != null)
		{
			bitmap_0.Dispose();
			bitmap_0 = null;
		}
	}

	public Enum786 method_1()
	{
		return smethod_5(smethod_4(bitmap_0.PixelFormat));
	}

	public Bitmap method_2()
	{
		return bitmap_0;
	}

	public void method_3(int x, int y, Class5998 color)
	{
		bitmap_0.SetPixel(x, y, color.method_0());
	}

	public int method_4(int x, int y)
	{
		return bitmap_0.GetPixel(x, y).ToArgb();
	}

	public void method_5(Rectangle srcRect, Class6150 dstBitmap, Rectangle dstRect)
	{
		using Graphics graphics = Graphics.FromImage(dstBitmap.bitmap_0);
		graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
		graphics.DrawImage(bitmap_0, dstRect, srcRect, GraphicsUnit.Pixel);
	}

	public Class6150 method_6(Rectangle srcRect)
	{
		Class6150 @class = new Class6150(srcRect.Width, srcRect.Height, HorizontalResolution, VerticalResolution, bitmap_0.PixelFormat);
		method_5(srcRect, @class, @class.method_8());
		return @class;
	}

	public Class6150 method_7(int width, int height, float hRes, float vRes)
	{
		Class6150 @class = new Class6150(width, height, hRes, vRes, bitmap_0.PixelFormat);
		method_5(method_8(), @class, @class.method_8());
		return @class;
	}

	public Rectangle method_8()
	{
		return new Rectangle(0, 0, bitmap_0.Width, bitmap_0.Height);
	}

	public void Save(string fileName, Enum788 imageType)
	{
		using Stream stream = File.Create(fileName);
		Save(stream, imageType);
	}

	public void Save(Stream stream, Enum788 imageType)
	{
		switch (imageType)
		{
		case Enum788.const_4:
			method_9(stream, 80);
			break;
		case Enum788.const_5:
			method_10(stream);
			break;
		case Enum788.const_6:
			method_11(stream);
			break;
		default:
			throw new InvalidOperationException("Cannot save in this image format.");
		case Enum788.const_8:
			method_12(stream, Enum789.const_2);
			break;
		}
	}

	public void method_9(Stream stream, int jpegQuality)
	{
		method_13();
		if (bitmap_0.PixelFormat == (PixelFormat)8207)
		{
			method_16();
		}
		smethod_0(bitmap_0, stream, jpegQuality);
	}

	public void method_10(Stream stream)
	{
		method_13();
		if (Class6166.smethod_2() == Enum742.const_0)
		{
			smethod_1(bitmap_0, stream);
			return;
		}
		Stream stream2 = new MemoryStream();
		smethod_1(bitmap_0, stream2);
		smethod_11(stream2, stream, HorizontalResolution, VerticalResolution);
	}

	public void method_11(Stream stream)
	{
		method_13();
		smethod_2(bitmap_0, stream);
	}

	public void method_12(Stream stream, Enum789 compression)
	{
		method_13();
		using Class6168 @class = new Class6168();
		@class.method_0(bitmap_0, stream, compression, isMultiframe: false);
	}

	private static void smethod_0(Image image, Stream stream, int jpegQuality)
	{
		ImageCodecInfo encoder = Class6142.smethod_0(ImageFormat.Jpeg);
		EncoderParameters encoderParameters = new EncoderParameters();
		encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, jpegQuality);
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

	private static void smethod_1(Image image, Stream stream)
	{
		image.Save(stream, Class6142.smethod_0(ImageFormat.Png), null);
	}

	private static void smethod_2(Image image, Stream stream)
	{
		image.Save(stream, Class6142.smethod_0(ImageFormat.Bmp), null);
	}

	private void method_13()
	{
		if (bool_0)
		{
			Bitmap bitmap = smethod_19(bitmap_0);
			bitmap.SetResolution(96f, 96f);
			bitmap_0.Dispose();
			bitmap_0 = bitmap;
			bool_0 = false;
		}
	}

	public static byte[] smethod_3(byte[] imageBytes)
	{
		if (Class6166.smethod_2() == Enum742.const_0)
		{
			return imageBytes;
		}
		if (imageBytes[0] != 66 || imageBytes[1] != 77)
		{
			return imageBytes;
		}
		uint num = BitConverter.ToUInt16(imageBytes, 10);
		uint num2 = BitConverter.ToUInt32(imageBytes, 14);
		bool flag = num2 == 12;
		uint num3 = BitConverter.ToUInt16(imageBytes, flag ? 24 : 28);
		if (num3 == 16)
		{
			using (Image image = Image.FromStream(new MemoryStream(imageBytes)))
			{
				using Image image2 = (Image)image.Clone();
				using Graphics graphics = Class6148.smethod_42(image2);
				image.RotateFlip(RotateFlipType.Rotate180FlipX);
				switch (num)
				{
				case 70u:
					graphics.DrawImage(image, new Point(image.Width - 8, 1));
					graphics.DrawImage(image, new Point(-8, 0));
					break;
				case 66u:
					graphics.DrawImage(image, Point.Empty);
					break;
				case 54u:
					graphics.DrawImage(image, new Point(-(image.Width - 6), -1));
					graphics.DrawImage(image, new Point(6, 0));
					break;
				}
				MemoryStream memoryStream = new MemoryStream();
				smethod_2(image2, memoryStream);
				return memoryStream.ToArray();
			}
		}
		return imageBytes;
	}

	public Class5998[] method_14()
	{
		Color[] entries = bitmap_0.Palette.Entries;
		Class5998[] array = new Class5998[entries.Length];
		for (int i = 0; i < entries.Length; i++)
		{
			array[i] = Class5998.smethod_0(entries[i]);
		}
		return array;
	}

	public Class6004 method_15(bool isConvertTo1Bpp, bool isAllowTransparencyToColorHack)
	{
		if (isConvertTo1Bpp)
		{
			Class6138 @class = new Class6138();
			byte[] colorValues = @class.method_0(bitmap_0);
			return new Class6004(colorValues, null, hasTransparentPixels: false, Enum786.const_2, 1);
		}
		BitmapData bitmapData = null;
		try
		{
			PixelFormat pixelFormat = smethod_4(bitmap_0.PixelFormat);
			bitmapData = bitmap_0.LockBits(new Rectangle(0, 0, bitmap_0.Width, bitmap_0.Height), ImageLockMode.ReadOnly, pixelFormat);
			switch (smethod_5(pixelFormat))
			{
			default:
				throw new InvalidOperationException("Unknown color space.");
			case Enum786.const_0:
				return smethod_6(bitmapData, isAllowTransparencyToColorHack);
			case Enum786.const_2:
				throw new InvalidOperationException("Have not seen any gray scale images yet.");
			case Enum786.const_1:
			{
				bool hasAlpha = (bitmap_0.Palette.Flags & 1) == 1;
				return smethod_7(bitmapData, hasAlpha);
			}
			}
		}
		finally
		{
			if (bitmapData != null)
			{
				bitmap_0.UnlockBits(bitmapData);
			}
		}
	}

	private static PixelFormat smethod_4(PixelFormat pixelFormat)
	{
		switch (pixelFormat)
		{
		case PixelFormat.Format16bppGrayScale:
			return PixelFormat.Format24bppRgb;
		case PixelFormat.Format16bppRgb555:
		case PixelFormat.Format16bppRgb565:
		case PixelFormat.Format48bppRgb:
			return PixelFormat.Format24bppRgb;
		default:
			return PixelFormat.Format32bppArgb;
		case PixelFormat.Format24bppRgb:
		case PixelFormat.Format32bppRgb:
		case PixelFormat.Format1bppIndexed:
		case PixelFormat.Format4bppIndexed:
		case PixelFormat.Format8bppIndexed:
		case PixelFormat.Format32bppPArgb:
		case PixelFormat.Format32bppArgb:
			return pixelFormat;
		}
	}

	private static Enum786 smethod_5(PixelFormat pixelFormat)
	{
		switch (pixelFormat)
		{
		case PixelFormat.Format1bppIndexed:
		case PixelFormat.Format4bppIndexed:
		case PixelFormat.Format8bppIndexed:
			return Enum786.const_1;
		case PixelFormat.Format16bppGrayScale:
			return Enum786.const_2;
		default:
			throw new InvalidOperationException("Unknown pixel format.");
		case PixelFormat.Format16bppRgb555:
		case PixelFormat.Format16bppRgb565:
		case PixelFormat.Format24bppRgb:
		case PixelFormat.Format32bppRgb:
		case PixelFormat.Format16bppArgb1555:
		case PixelFormat.Format32bppPArgb:
		case PixelFormat.Format48bppRgb:
		case PixelFormat.Format64bppPArgb:
		case PixelFormat.Format32bppArgb:
		case PixelFormat.Format64bppArgb:
			return Enum786.const_0;
		}
	}

	private static Class6004 smethod_6(BitmapData bitmapData, bool isAllowTransparencyToColorHack)
	{
		switch (bitmapData.PixelFormat)
		{
		default:
			throw new InvalidOperationException("Cannot parse this pixel format.");
		case PixelFormat.Format24bppRgb:
		case PixelFormat.Format32bppRgb:
		case PixelFormat.Format32bppPArgb:
		case PixelFormat.Format32bppArgb:
		{
			if (bitmapData.Stride < 0)
			{
				throw new InvalidOperationException("A bitmap has a negative stride and this is not yet supported.");
			}
			byte[] array = new byte[bitmapData.Width * bitmapData.Height * 3];
			bool flag;
			byte[] array2 = new byte[(flag = (bitmapData.PixelFormat & PixelFormat.Alpha) != 0) ? (bitmapData.Width * bitmapData.Height) : 0];
			bool flag2 = false;
			bool flag3 = false;
			int num = 0;
			int num2 = 0;
			byte[] array3 = new byte[bitmapData.Stride];
			long num3 = bitmapData.Scan0.ToInt64();
			bool flag4 = bitmapData.PixelFormat == PixelFormat.Format32bppRgb;
			for (int i = 0; i < bitmapData.Height; i++)
			{
				if (i == 301)
				{
					Console.WriteLine();
				}
				Marshal.Copy(new IntPtr(num3), array3, 0, array3.Length);
				int num4 = 0;
				for (int j = 0; j < bitmapData.Width; j++)
				{
					byte b = array3[num4++];
					byte b2 = array3[num4++];
					byte b3 = array3[num4++];
					array[num + 2] = b;
					array[num + 1] = b2;
					array[num] = b3;
					num += 3;
					if (b > 0 || b2 > 0 || b3 > 0)
					{
						flag3 = true;
					}
					if (flag)
					{
						byte b4 = array3[num4++];
						if (b4 < byte.MaxValue)
						{
							flag2 = true;
						}
						array2[num2++] = b4;
					}
					else if (flag4)
					{
						num4++;
					}
				}
				num3 += bitmapData.Stride;
			}
			if (isAllowTransparencyToColorHack && flag2 && !flag3)
			{
				for (int k = 0; k < array2.Length; k++)
				{
					array[k * 3 + 2] = (array[k * 3 + 1] = (array[k * 3] = (byte)(array2[k] ^ 0xFFu)));
				}
				array2 = Class5964.byte_0;
				flag2 = false;
			}
			return new Class6004(array, array2, flag2, Enum786.const_0, 8);
		}
		}
	}

	private static Class6004 smethod_7(BitmapData bitmapData, bool hasAlpha)
	{
		int num = bitmapData.PixelFormat switch
		{
			PixelFormat.Format8bppIndexed => 8, 
			PixelFormat.Format4bppIndexed => 4, 
			PixelFormat.Format1bppIndexed => 1, 
			_ => throw new InvalidOperationException("Cannot parse this pixel format."), 
		};
		if (bitmapData.Stride < 0)
		{
			throw new InvalidOperationException("A bitmap has a negative stride and this is not yet supported.");
		}
		int num2 = (int)Math.Ceiling((float)bitmapData.Width * (float)num / 8f);
		byte[] array = new byte[num2 * bitmapData.Height];
		byte[] alphaValues = new byte[hasAlpha ? (bitmapData.Width * bitmapData.Height) : 0];
		int num3 = 0;
		long num4 = bitmapData.Scan0.ToInt64();
		for (int i = 0; i < bitmapData.Height; i++)
		{
			Marshal.Copy(new IntPtr(num4), array, num3, num2);
			num3 += num2;
			num4 += bitmapData.Stride;
		}
		return new Class6004(array, alphaValues, hasTransparentPixels: false, Enum786.const_1, num);
	}

	public static Image smethod_8(Stream stream)
	{
		return Image.FromStream(stream);
	}

	public static void smethod_9(Image image, Stream stream)
	{
		Bitmap bitmap = image as Bitmap;
		switch (smethod_18(image.RawFormat))
		{
		case Enum788.const_1:
		case Enum788.const_2:
			smethod_10((Metafile)image, stream);
			break;
		case Enum788.const_4:
		{
			Class6150 class2 = new Class6150(bitmap);
			class2.method_9(stream, 80);
			class2.bitmap_0 = null;
			break;
		}
		default:
		{
			Class6150 @class = new Class6150(bitmap);
			@class.method_10(stream);
			@class.bitmap_0 = null;
			break;
		}
		}
	}

	private static void smethod_10(Metafile srcMetafile, Stream dstStream)
	{
		using Class6150 @class = new Class6150(1, 1);
		@class.method_2().SetResolution(srcMetafile.HorizontalResolution, srcMetafile.VerticalResolution);
		using Graphics graphics = Class6148.smethod_42(@class.method_2());
		IntPtr hdc = graphics.GetHdc();
		try
		{
			using Metafile image = new Metafile(dstStream, hdc, EmfType.EmfPlusDual);
			using (Graphics graphics2 = Class6148.smethod_42(image))
			{
				Rectangle bounds = srcMetafile.GetMetafileHeader().Bounds;
				graphics2.DrawImageUnscaled(srcMetafile, bounds);
			}
			dstStream.Flush();
		}
		finally
		{
			graphics.ReleaseHdc(hdc);
		}
	}

	private static void smethod_11(Stream inputStream, Stream outputStream, double horizontalResolution, double verticalResolution)
	{
		inputStream.Position = 0L;
		Class5950 @class = new Class5950(inputStream);
		Class5951 class2 = new Class5951(outputStream);
		byte[] buffer = @class.method_8(8);
		class2.method_4(buffer, 0, 8);
		bool flag = false;
		string @string;
		do
		{
			uint num = @class.method_1();
			byte[] array = @class.method_8(4);
			byte[] buffer2 = @class.method_8((int)num);
			uint value = @class.method_1();
			@string = Encoding.ASCII.GetString(array);
			if (@string == "pHYs")
			{
				flag = true;
			}
			if (@string == "IDAT" && !flag)
			{
				class2.method_1(9u);
				class2.method_4(new byte[4] { 112, 72, 89, 115 }, 0, 4);
				class2.method_1(Convert.ToUInt32(Math.Round(horizontalResolution / 0.0254)));
				class2.method_1(Convert.ToUInt32(Math.Round(verticalResolution / 0.0254)));
				class2.WriteByte(1);
				class2.method_1(0u);
				flag = true;
			}
			class2.method_1(num);
			class2.method_4(array, 0, 4);
			class2.method_4(buffer2, 0, (int)num);
			class2.method_1(value);
		}
		while (!(@string == "IEND"));
		class2.Flush();
	}

	private void method_16()
	{
		Class6150 @class = new Class6150(Width, Height, HorizontalResolution, VerticalResolution, PixelFormat.Format24bppRgb);
		Rectangle rectangle = method_8();
		method_5(rectangle, @class, rectangle);
		bitmap_0.Dispose();
		bitmap_0 = @class.bitmap_0;
		@class.bitmap_0 = null;
	}

	public void method_17()
	{
		using ImageAttributes imageAttributes = new ImageAttributes();
		imageAttributes.SetColorMatrix(smethod_17());
		bitmap_0 = smethod_14(bitmap_0, imageAttributes);
	}

	public void method_18(Class6140 chromaKey)
	{
		Color color = Color.FromArgb(0, 0, 0, 0);
		Color black = Color.Black;
		Class6150 @class = new Class6150(Width, Height, HorizontalResolution, VerticalResolution, PixelFormat.Format32bppArgb);
		for (int i = 0; i < bitmap_0.Width; i++)
		{
			for (int j = 0; j < bitmap_0.Height; j++)
			{
				Class5998 color2 = Class5998.smethod_0(bitmap_0.GetPixel(i, j));
				@class.bitmap_0.SetPixel(i, j, chromaKey.method_0(color2) ? color : black);
			}
		}
		bitmap_0.Dispose();
		bitmap_0 = @class.bitmap_0;
		@class.bitmap_0 = null;
	}

	public void method_19(Class6144 colorSettings)
	{
		if (!Class6148.smethod_43(bitmap_0.Width, bitmap_0.Height))
		{
			if (colorSettings.ColorMode == Enum787.const_2)
			{
				Bitmap original = smethod_13(bitmap_0, colorSettings.Contrast, colorSettings.Brightness);
				bitmap_0 = smethod_12(original, colorSettings.ColorMode);
			}
			else
			{
				Bitmap original2 = smethod_12(bitmap_0, colorSettings.ColorMode);
				bitmap_0 = smethod_13(original2, colorSettings.Contrast, colorSettings.Brightness);
			}
		}
	}

	private static Bitmap smethod_12(Bitmap original, Enum787 colorMode)
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
			imageAttributes2.SetColorMatrix(smethod_16());
			return smethod_14(original, imageAttributes2);
		}
		case Enum787.const_2:
		{
			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetColorMatrix(smethod_16());
			imageAttributes.SetThreshold(0.5f);
			return smethod_14(original, imageAttributes);
		}
		}
	}

	private static Bitmap smethod_13(Bitmap original, float contrast, float brightness)
	{
		if (Class6144.smethod_2(brightness) && Class6144.smethod_1(contrast))
		{
			return original;
		}
		ImageAttributes imageAttributes = new ImageAttributes();
		imageAttributes.SetColorMatrix(smethod_15(contrast, brightness));
		return smethod_14(original, imageAttributes);
	}

	private static Bitmap smethod_14(Bitmap original, ImageAttributes attributes)
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

	private static ColorMatrix smethod_15(float contrast, float brightness)
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

	private static ColorMatrix smethod_16()
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

	private static ColorMatrix smethod_17()
	{
		float[][] newColorMatrix = new float[5][]
		{
			new float[5] { 0.5f, 0.5f, 0.5f, 0f, 0f },
			new float[5] { 0.5f, 0.5f, 0.5f, 0f, 0f },
			new float[5] { 0.5f, 0.5f, 0.5f, 0f, 0f },
			new float[5] { 0f, 0f, 0f, 1f, 0f },
			new float[5] { 0f, 0f, 0f, 0f, 1f }
		};
		return new ColorMatrix(newColorMatrix);
	}

	private static Enum788 smethod_18(ImageFormat imageFormat)
	{
		if (imageFormat.Equals(ImageFormat.Jpeg))
		{
			return Enum788.const_4;
		}
		if (imageFormat.Equals(ImageFormat.Png))
		{
			return Enum788.const_5;
		}
		if (imageFormat.Equals(ImageFormat.Emf))
		{
			return Enum788.const_1;
		}
		if (imageFormat.Equals(ImageFormat.Wmf))
		{
			return Enum788.const_2;
		}
		if (imageFormat.Equals(ImageFormat.Bmp))
		{
			return Enum788.const_6;
		}
		if (imageFormat.Equals(ImageFormat.Gif))
		{
			return Enum788.const_7;
		}
		if (imageFormat.Equals(ImageFormat.Tiff))
		{
			return Enum788.const_8;
		}
		return Enum788.const_0;
	}

	internal void method_20(Class5998 color)
	{
		if (!Image.IsAlphaPixelFormat(method_2().PixelFormat) || !method_15(isConvertTo1Bpp: false, isAllowTransparencyToColorHack: false).HasTransparentPixels)
		{
			return;
		}
		byte b = (byte)color.R;
		byte b2 = (byte)color.G;
		byte b3 = (byte)color.B;
		BitmapData bitmapData = null;
		try
		{
			bitmapData = bitmap_0.LockBits(new Rectangle(0, 0, bitmap_0.Width, bitmap_0.Height), ImageLockMode.ReadWrite, bitmap_0.PixelFormat);
			if (smethod_5(bitmap_0.PixelFormat) != 0)
			{
				return;
			}
			byte[] array = new byte[bitmapData.Stride];
			long num = bitmapData.Scan0.ToInt64();
			for (int i = 0; i < bitmapData.Height; i++)
			{
				Marshal.Copy(new IntPtr(num), array, 0, array.Length);
				int num2 = 0;
				for (int j = 0; j < bitmapData.Width; j++)
				{
					byte b4 = array[num2++];
					byte b5 = array[num2++];
					byte b6 = array[num2++];
					if (array[num2++] == 0)
					{
						if (b6 != b)
						{
							array[num2 - 2] = b;
						}
						if (b5 != b2)
						{
							array[num2 - 3] = b2;
						}
						if (b4 != b3)
						{
							array[num2 - 4] = b3;
						}
					}
				}
				Marshal.Copy(array, 0, new IntPtr(num), array.Length);
				num += bitmapData.Stride;
			}
		}
		finally
		{
			if (bitmapData != null)
			{
				bitmap_0.UnlockBits(bitmapData);
			}
		}
	}

	private static Bitmap smethod_19(Bitmap bitmap)
	{
		if (smethod_5(bitmap.PixelFormat) != 0)
		{
			return new Bitmap(bitmap);
		}
		Bitmap bitmap2 = new Bitmap(bitmap.Width, bitmap.Height, bitmap.PixelFormat);
		BitmapData bitmapData = null;
		BitmapData bitmapData2 = null;
		try
		{
			bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
			bitmapData2 = bitmap2.LockBits(new Rectangle(0, 0, bitmap2.Width, bitmap2.Height), ImageLockMode.WriteOnly, bitmap2.PixelFormat);
			byte[] array = new byte[bitmapData.Stride];
			long num = bitmapData.Scan0.ToInt64();
			long num2 = bitmapData2.Scan0.ToInt64();
			int stride = bitmapData.Stride;
			for (int i = 0; i < bitmapData.Height; i++)
			{
				Marshal.Copy(new IntPtr(num), array, 0, stride);
				Marshal.Copy(array, 0, new IntPtr(num2), stride);
				num += stride;
				num2 += stride;
			}
		}
		finally
		{
			if (bitmapData != null)
			{
				bitmap.UnlockBits(bitmapData);
			}
			if (bitmapData2 != null)
			{
				bitmap2.UnlockBits(bitmapData2);
			}
		}
		return bitmap2;
	}
}

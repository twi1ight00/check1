using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ns18;

namespace ns22;

internal class Class1021 : IDisposable
{
	private Bitmap bitmap_0;

	private Enum200 enum200_0;

	public Enum200 ImageType => enum200_0;

	public Class1021(int int_0, int int_1)
	{
		method_0(Class1404.smethod_35(int_0, int_1));
	}

	public Class1021(byte[] byte_0)
	{
		method_0(new Bitmap(new MemoryStream(byte_0)));
	}

	public Class1021(TextureBrush textureBrush_0)
	{
		method_0((Bitmap)textureBrush_0.Image);
	}

	private void method_0(Bitmap bitmap_1)
	{
		bitmap_0 = bitmap_1;
		enum200_0 = Class1404.smethod_3(bitmap_0.RawFormat);
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

	public void method_1(int int_0, int int_1, Color color_0)
	{
		bitmap_0.SetPixel(int_0, int_1, color_0);
	}

	public void Save(Stream stream_0, Enum200 enum200_1)
	{
		switch (enum200_1)
		{
		case Enum200.const_4:
			smethod_1(bitmap_0, stream_0, 80);
			break;
		case Enum200.const_5:
			smethod_0(bitmap_0, stream_0);
			break;
		default:
			throw new InvalidOperationException("Cannot save in this image format.");
		case Enum200.const_8:
			smethod_2(bitmap_0, stream_0, Enum201.const_2, bool_0: false);
			break;
		}
	}

	public void method_2(Stream stream_0, int int_0)
	{
		smethod_1(bitmap_0, stream_0, int_0);
	}

	private static void smethod_0(Bitmap bitmap_1, Stream stream_0)
	{
		bitmap_1.Save(stream_0, ImageFormat.Png);
	}

	private static void smethod_1(Bitmap bitmap_1, Stream stream_0, int int_0)
	{
		Class1402.smethod_0(bitmap_1, stream_0, int_0);
	}

	private static void smethod_2(Bitmap bitmap_1, Stream stream_0, Enum201 enum201_0, bool bool_0)
	{
		Class1402.smethod_1(bitmap_1, stream_0, enum201_0, bool_0);
	}
}

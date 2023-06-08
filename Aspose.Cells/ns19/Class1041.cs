using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Aspose.Cells.Rendering;

namespace ns19;

internal class Class1041 : Class1039
{
	internal static EmfType emfType_0 = EmfType.EmfOnly;

	private int int_0;

	private int int_1;

	private ImageOrPrintOptions imageOrPrintOptions_0;

	private Stream stream_0;

	private Interface6 interface6_0;

	internal bool bool_0;

	internal Class1041(int int_2, int int_3, ImageOrPrintOptions imageOrPrintOptions_1, Stream stream_1, Interface6 interface6_1)
	{
		stream_0 = stream_1;
		int_0 = int_2;
		int_1 = int_3;
		if (imageOrPrintOptions_1 == null)
		{
			imageOrPrintOptions_0 = new ImageOrPrintOptions();
		}
		else
		{
			imageOrPrintOptions_0 = imageOrPrintOptions_1;
		}
		interface6_0 = interface6_1;
	}

	public override void imethod_2()
	{
		if (stream_0 == null)
		{
			return;
		}
		MemoryStream memoryStream = null;
		Bitmap bitmap = null;
		Graphics graphics = null;
		IntPtr intPtr = IntPtr.Zero;
		Metafile metafile = null;
		try
		{
			bitmap = new Bitmap(1, 1);
			graphics = Graphics.FromImage(bitmap);
			intPtr = graphics.GetHdc();
			if (!bool_0 && imageOrPrintOptions_0.bool_2)
			{
				memoryStream = new MemoryStream();
				metafile = new Metafile(memoryStream, intPtr, new RectangleF(0f, 0f, int_0, int_1), MetafileFrameUnit.Pixel, emfType_0);
			}
			else
			{
				metafile = new Metafile(stream_0, intPtr, new RectangleF(0f, 0f, int_0, int_1), MetafileFrameUnit.Pixel, emfType_0);
			}
			graphics_0 = Graphics.FromImage(metafile);
			imethod_1(new Class1042(graphics_0));
			graphics_0.FillRectangle(new SolidBrush(Color.Empty), 0, 0, int_0, int_1);
			interface6_0.imethod_2();
		}
		finally
		{
			metafile?.Dispose();
			if (intPtr != IntPtr.Zero)
			{
				graphics.ReleaseHdc(intPtr);
			}
			graphics?.Dispose();
			bitmap?.Dispose();
			if (!bool_0 && imageOrPrintOptions_0.bool_2)
			{
				memoryStream.Seek(0L, SeekOrigin.Begin);
			}
			else
			{
				method_0(stream_0);
				stream_0.Seek(0L, SeekOrigin.Begin);
			}
			Dispose();
		}
		if (bool_0 || !imageOrPrintOptions_0.bool_2 || memoryStream == null)
		{
			return;
		}
		Graphics graphics2 = null;
		try
		{
			bitmap = new Bitmap(1, 1);
			graphics = Graphics.FromImage(bitmap);
			intPtr = graphics.GetHdc();
			Image image = Image.FromStream(memoryStream);
			int num = (int)((float)(image.Width * imageOrPrintOptions_0.HorizontalResolution) / bitmap.HorizontalResolution + 0.5f);
			int num2 = (int)((float)(image.Height * imageOrPrintOptions_0.VerticalResolution) / bitmap.VerticalResolution + 0.5f);
			metafile = new Metafile(stream_0, intPtr, new RectangleF(0f, 0f, num, num2), MetafileFrameUnit.Pixel, emfType_0);
			graphics2 = Graphics.FromImage(metafile);
			graphics2.DrawImage(image, 0, 0, num, num2);
		}
		finally
		{
			metafile?.Dispose();
			if (intPtr != IntPtr.Zero)
			{
				graphics.ReleaseHdc(intPtr);
			}
			graphics?.Dispose();
			bitmap?.Dispose();
			method_0(stream_0);
			stream_0.Seek(0L, SeekOrigin.Begin);
			if (graphics2 != null)
			{
				graphics2.Dispose();
				graphics2 = null;
			}
			if (memoryStream != null)
			{
				memoryStream.Close();
				memoryStream = null;
			}
		}
	}

	private void method_0(Stream stream_1)
	{
		stream_0.Seek(8L, SeekOrigin.Begin);
		byte[] array = new byte[16];
		stream_0.Read(array, 0, 16);
		int num = BitConverter.ToInt32(array, 0);
		int num2 = BitConverter.ToInt32(array, 4);
		int num3 = BitConverter.ToInt32(array, 8);
		int num4 = BitConverter.ToInt32(array, 12);
		stream_0.Seek(24L, SeekOrigin.Begin);
		byte[] array2 = new byte[16];
		stream_0.Read(array2, 0, 16);
		int num5 = BitConverter.ToInt32(array2, 0);
		int num6 = BitConverter.ToInt32(array2, 4);
		int num7 = BitConverter.ToInt32(array2, 8);
		int num8 = BitConverter.ToInt32(array2, 12);
		stream_0.Seek(72L, SeekOrigin.Begin);
		byte[] array3 = new byte[8];
		stream_0.Read(array3, 0, 8);
		int num9 = BitConverter.ToInt32(array3, 0);
		int num10 = BitConverter.ToInt32(array3, 4);
		byte[] array4 = new byte[8];
		stream_0.Read(array4, 0, 8);
		int num11 = BitConverter.ToInt32(array4, 0);
		int num12 = BitConverter.ToInt32(array4, 4);
		float num13 = (float)num9 / ((float)num11 / 25.4f);
		float num14 = (float)num10 / ((float)num12 / 25.4f);
		float num15 = num13 / (float)imageOrPrintOptions_0.HorizontalResolution;
		float num16 = num14 / (float)imageOrPrintOptions_0.VerticalResolution;
		stream_0.Seek(8L, SeekOrigin.Begin);
		stream_0.Write(BitConverter.GetBytes((int)((float)num * num15)), 0, 4);
		stream_0.Write(BitConverter.GetBytes((int)((float)num2 * num16)), 0, 4);
		stream_0.Write(BitConverter.GetBytes((int)((float)num3 * num15)), 0, 4);
		stream_0.Write(BitConverter.GetBytes((int)((float)num4 * num16)), 0, 4);
		stream_0.Write(BitConverter.GetBytes((int)((float)num5 * num15)), 0, 4);
		stream_0.Write(BitConverter.GetBytes((int)((float)num6 * num16)), 0, 4);
		stream_0.Write(BitConverter.GetBytes((int)((float)num7 * num15)), 0, 4);
		stream_0.Write(BitConverter.GetBytes((int)((float)num8 * num16)), 0, 4);
		stream_0.Seek(72L, SeekOrigin.Begin);
		stream_0.Write(BitConverter.GetBytes((int)((float)num9 / num15)), 0, 4);
		stream_0.Write(BitConverter.GetBytes((int)((float)num10 / num16)), 0, 4);
	}

	public override Bitmap imethod_3()
	{
		throw new InvalidOperationException("Calls wrong method!");
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
		vmethod_0();
	}
}

using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using ns221;

namespace ns233;

internal class Class6138
{
	private const int int_0 = 500;

	private bool bool_0;

	public byte[] method_0(Bitmap original)
	{
		Class6135 @class = smethod_0(original);
		int bytesPerLine = @class.Width / 8 + ((@class.Width % 8 > 0) ? 1 : 0);
		return method_2(@class, bytesPerLine);
	}

	public Bitmap method_1(Bitmap original)
	{
		bool_0 = true;
		Class6135 bitmapBytes = smethod_0(original);
		Bitmap bitmap = new Bitmap(original.Width, original.Height, PixelFormat.Format1bppIndexed);
		bitmap.SetResolution(original.HorizontalResolution, original.VerticalResolution);
		BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);
		byte[] array = method_2(bitmapBytes, bitmapData.Stride);
		Marshal.Copy(array, 0, bitmapData.Scan0, array.Length);
		bitmap.UnlockBits(bitmapData);
		return bitmap;
	}

	private byte[] method_2(Class6135 bitmapBytes, int bytesPerLine)
	{
		int num = bytesPerLine * bitmapBytes.Height;
		byte[] array = new byte[num];
		Class5953 @class = new Class5953(array);
		for (int i = 0; i < bitmapBytes.Height; i++)
		{
			int byteOffset = i * bitmapBytes.Stride;
			@class.ByteIndex = i * bytesPerLine;
			method_3(bitmapBytes, @class, byteOffset);
		}
		@class.Flush();
		return array;
	}

	private void method_3(Class6135 bitmapBytes, Class5953 writer, int byteOffset)
	{
		for (int i = 0; i < bitmapBytes.Width; i++)
		{
			int num = bitmapBytes.Bytes[byteOffset + 1] + bitmapBytes.Bytes[byteOffset + 2] + bitmapBytes.Bytes[byteOffset + 3];
			if (bool_0 ? (num > 500) : (num < 500))
			{
				writer.method_0();
			}
			writer.method_1();
			byteOffset += 4;
		}
	}

	private static Class6135 smethod_0(Bitmap original)
	{
		Bitmap bitmap = null;
		try
		{
			if (original.PixelFormat != PixelFormat.Format32bppArgb)
			{
				bitmap = new Bitmap(original.Width, original.Height, PixelFormat.Format32bppArgb);
				bitmap.SetResolution(original.HorizontalResolution, original.VerticalResolution);
				using Graphics graphics = Class6148.smethod_42(bitmap);
				graphics.DrawImageUnscaled(original, 0, 0);
			}
			else
			{
				bitmap = original;
			}
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
			Class6135 result = new Class6135(bitmapData);
			bitmap.UnlockBits(bitmapData);
			return result;
		}
		finally
		{
			if (bitmap != original)
			{
				bitmap?.Dispose();
			}
		}
	}
}

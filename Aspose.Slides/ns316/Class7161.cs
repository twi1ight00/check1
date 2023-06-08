using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ns316;

internal class Class7161 : IDisposable
{
	private Bitmap bitmap_0;

	private BitmapData bitmapData_0;

	private IntPtr intptr_0;

	private int int_0;

	private byte[] byte_0;

	public int Stride => bitmapData_0.Stride;

	public byte[] ArgbValues
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public Bitmap Bitmap
	{
		get
		{
			Marshal.Copy(byte_0, 0, intptr_0, int_0);
			return bitmap_0;
		}
	}

	public int ImageWidth => bitmapData_0.Width;

	public int ImageHeight => bitmapData_0.Height;

	public Class7161(Bitmap bitmap)
	{
		bitmap_0 = bitmap;
		bitmapData_0 = bitmap_0.LockBits(new Rectangle(0, 0, bitmap_0.Width, bitmap_0.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
		intptr_0 = bitmapData_0.Scan0;
		int_0 = Stride * bitmap_0.Height;
		byte_0 = new byte[int_0];
		Marshal.Copy(intptr_0, byte_0, 0, int_0);
	}

	public void Dispose()
	{
		bitmap_0.UnlockBits(bitmapData_0);
	}
}

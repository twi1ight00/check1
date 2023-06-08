using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ns233;

internal class Class6135
{
	private readonly byte[] byte_0;

	private readonly int int_0;

	private readonly int int_1;

	private readonly int int_2;

	public byte[] Bytes => byte_0;

	public int Width => int_2;

	public int Height => int_0;

	public int Stride => int_1;

	public Class6135(BitmapData bitmapData)
	{
		int_2 = bitmapData.Width;
		int_0 = bitmapData.Height;
		int_1 = bitmapData.Stride;
		int num = bitmapData.Stride * bitmapData.Height;
		byte_0 = new byte[num];
		Marshal.Copy(bitmapData.Scan0, byte_0, 0, num);
	}
}

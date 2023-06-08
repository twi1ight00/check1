using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Aspose;

namespace x38a89dee67fc7a16;

[JavaDelete("Not needed in java.")]
internal class xc9a7e4afe8c1d1fe
{
	private readonly byte[] xd4251e57da4db8b6;

	private readonly int x8918dc7c534575e5;

	private readonly int x672f775836571051;

	private readonly int xd74c65b8d28b1740;

	public byte[] x90427ee74997bf7a => xd4251e57da4db8b6;

	public int xdc1bf80853046136 => xd74c65b8d28b1740;

	public int xb0f146032f47c24e => x8918dc7c534575e5;

	public int xee2b9ecb75e0f358 => x672f775836571051;

	public xc9a7e4afe8c1d1fe(BitmapData bitmapData)
	{
		xd74c65b8d28b1740 = bitmapData.Width;
		x8918dc7c534575e5 = bitmapData.Height;
		x672f775836571051 = bitmapData.Stride;
		int num = bitmapData.Stride * bitmapData.Height;
		xd4251e57da4db8b6 = new byte[num];
		Marshal.Copy(bitmapData.Scan0, xd4251e57da4db8b6, 0, num);
	}
}

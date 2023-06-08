using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Aspose;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x38a89dee67fc7a16;

[JavaDelete("In Java we do conversion using Java's BufferedImage capabilities.")]
internal class x67f5e4db5e884ab4
{
	private const int xd3f06edc344811a0 = 500;

	private bool x7035c677b81f3ef7;

	public byte[] xb21a089ee19dd853(Bitmap xfcad4c0a9c5890c6)
	{
		xc9a7e4afe8c1d1fe xc9a7e4afe8c1d1fe2 = x4b67e320b8c12ba1(xfcad4c0a9c5890c6);
		int xdfa65465b256f88b = xc9a7e4afe8c1d1fe2.xdc1bf80853046136 / 8 + ((xc9a7e4afe8c1d1fe2.xdc1bf80853046136 % 8 > 0) ? 1 : 0);
		return x95249947c7e021f2(xc9a7e4afe8c1d1fe2, xdfa65465b256f88b);
	}

	public Bitmap x5772bbb43a8ca973(Bitmap xfcad4c0a9c5890c6)
	{
		x7035c677b81f3ef7 = true;
		xc9a7e4afe8c1d1fe xc966b77fcbbd8fcb = x4b67e320b8c12ba1(xfcad4c0a9c5890c6);
		Bitmap bitmap = new Bitmap(xfcad4c0a9c5890c6.Width, xfcad4c0a9c5890c6.Height, PixelFormat.Format1bppIndexed);
		bitmap.SetResolution(xfcad4c0a9c5890c6.HorizontalResolution, xfcad4c0a9c5890c6.VerticalResolution);
		BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);
		byte[] array = x95249947c7e021f2(xc966b77fcbbd8fcb, bitmapData.Stride);
		Marshal.Copy(array, 0, bitmapData.Scan0, array.Length);
		bitmap.UnlockBits(bitmapData);
		return bitmap;
	}

	private byte[] x95249947c7e021f2(xc9a7e4afe8c1d1fe xc966b77fcbbd8fcb, int xdfa65465b256f88b)
	{
		int num = xdfa65465b256f88b * xc966b77fcbbd8fcb.xb0f146032f47c24e;
		byte[] array = new byte[num];
		x7041a8fbebe086c6 x7041a8fbebe086c = new x7041a8fbebe086c6(array);
		for (int i = 0; i < xc966b77fcbbd8fcb.xb0f146032f47c24e; i++)
		{
			int xa3355ced27ba170a = i * xc966b77fcbbd8fcb.xee2b9ecb75e0f358;
			x7041a8fbebe086c.x6902704a206de8be = i * xdfa65465b256f88b;
			x8186fed8f70a50e1(xc966b77fcbbd8fcb, x7041a8fbebe086c, xa3355ced27ba170a);
		}
		x7041a8fbebe086c.xbb7550bbb62a218c();
		return array;
	}

	private void x8186fed8f70a50e1(xc9a7e4afe8c1d1fe xc966b77fcbbd8fcb, x7041a8fbebe086c6 xbdfb620b7167944b, int xa3355ced27ba170a)
	{
		for (int i = 0; i < xc966b77fcbbd8fcb.xdc1bf80853046136; i++)
		{
			int num = xc966b77fcbbd8fcb.x90427ee74997bf7a[xa3355ced27ba170a] + xc966b77fcbbd8fcb.x90427ee74997bf7a[xa3355ced27ba170a + 1] + xc966b77fcbbd8fcb.x90427ee74997bf7a[xa3355ced27ba170a + 2];
			if (x7035c677b81f3ef7 ? (num > 500) : (num < 500))
			{
				xbdfb620b7167944b.x310c586f4b637864();
			}
			xbdfb620b7167944b.xee48077742d1f032();
			xa3355ced27ba170a += 4;
		}
	}

	private static xc9a7e4afe8c1d1fe x4b67e320b8c12ba1(Bitmap xfcad4c0a9c5890c6)
	{
		Bitmap bitmap = null;
		try
		{
			if (xfcad4c0a9c5890c6.PixelFormat != PixelFormat.Format32bppArgb)
			{
				bitmap = new Bitmap(xfcad4c0a9c5890c6.Width, xfcad4c0a9c5890c6.Height, PixelFormat.Format32bppArgb);
				bitmap.SetResolution(xfcad4c0a9c5890c6.HorizontalResolution, xfcad4c0a9c5890c6.VerticalResolution);
				using Graphics graphics = xaf1d5886bde15736.x2c0e2b36cc23e6ca(bitmap);
				graphics.DrawImageUnscaled(xfcad4c0a9c5890c6, 0, 0);
			}
			else
			{
				bitmap = xfcad4c0a9c5890c6;
			}
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
			xc9a7e4afe8c1d1fe result = new xc9a7e4afe8c1d1fe(bitmapData);
			bitmap.UnlockBits(bitmapData);
			return result;
		}
		finally
		{
			if (bitmap != xfcad4c0a9c5890c6)
			{
				bitmap?.Dispose();
			}
		}
	}
}

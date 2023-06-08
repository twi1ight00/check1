using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Aspose;
using x13f1efc79617a47b;
using x38a89dee67fc7a16;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace xf9a9481c3f63a419;

[JavaManual("Manual porting by design.")]
[SecuritySafeCritical]
internal class x3cd5d648729cd9b6 : IDisposable
{
	private const double x9f3a1ece39275b1c = 0.0254;

	private const int x999099dcabde8c0a = 1;

	private const int x5d4905c08d650679 = 2;

	private const int x7cad4b94821556f5 = 4;

	private const int x8836e4ff257df1c5 = 8207;

	private Bitmap xbe9a01e942c44c35;

	private xfe2ff3c162b47c70 xedcf13d9a3fd42bd;

	private bool x5cf5da33ffcd8d6b;

	public int xdc1bf80853046136 => xbe9a01e942c44c35.Width;

	public int xb0f146032f47c24e => xbe9a01e942c44c35.Height;

	public float xf2b3620f7bfc9ed5
	{
		get
		{
			if (!x5cf5da33ffcd8d6b)
			{
				return xbe9a01e942c44c35.HorizontalResolution;
			}
			return 96f;
		}
	}

	public float x5c6fc5693c6898cd
	{
		get
		{
			if (!x5cf5da33ffcd8d6b)
			{
				return xbe9a01e942c44c35.VerticalResolution;
			}
			return 96f;
		}
	}

	public xfe2ff3c162b47c70 x688d6f6524ba3c8b => xedcf13d9a3fd42bd;

	public x3cd5d648729cd9b6(int width, int height)
		: this(width, height, 96f, 96f)
	{
	}

	public x3cd5d648729cd9b6(int width, int height, float hRes, float vRes)
		: this(width, height, hRes, vRes, PixelFormat.Format32bppArgb)
	{
	}

	public x3cd5d648729cd9b6(int width, int height, float hRes, float vRes, PixelFormat pixelFormat)
	{
		if (x42877f6edb0201a1(pixelFormat) == x342b86618ed63a10.x7bc2cd43944d90a3)
		{
			pixelFormat = PixelFormat.Format32bppArgb;
		}
		Bitmap bitmap = new Bitmap(width, height, pixelFormat);
		bitmap.SetResolution(hRes, vRes);
		x0ecee64b07d2d5b1(bitmap);
	}

	public x3cd5d648729cd9b6(int width, int height, int stride, PixelFormat pixelFormat, byte[] bytes, x26d9ecb4bdf0456d[] palette)
	{
		Bitmap bitmap = new Bitmap(width, height, pixelFormat);
		try
		{
			if (palette != null)
			{
				for (int i = 0; i < bitmap.Palette.Entries.Length && i < palette.Length; i++)
				{
					ref Color reference = ref bitmap.Palette.Entries[i];
					reference = palette[i].xc7656a130b2889c7();
				}
			}
			Rectangle rect = new Rectangle(0, 0, width, height);
			BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.WriteOnly, pixelFormat);
			try
			{
				Marshal.Copy(bytes, 0, bitmapData.Scan0, bytes.Length);
			}
			finally
			{
				bitmap.UnlockBits(bitmapData);
			}
			x0ecee64b07d2d5b1(bitmap);
		}
		catch
		{
			bitmap.Dispose();
			throw;
		}
	}

	public x3cd5d648729cd9b6(byte[] imageBytes)
	{
		x0ecee64b07d2d5b1(new Bitmap(new MemoryStream(imageBytes)));
		x5cf5da33ffcd8d6b = xdd1b8f14cc8ba86d.x16a7fb03c627ebfb(imageBytes).xc16040ff4dc683ab;
	}

	public x3cd5d648729cd9b6(x5e9754e56a4f759f brush)
	{
		if (brush.x4bc21f84846f912d != x0b257a9fb413b6c3.x7b6a6d281546db99)
		{
			throw new ArgumentException("Texture brush is expected.");
		}
		using TextureBrush textureBrush = (TextureBrush)x6fb77f4cc018ceba.x495baeffa83ca947(brush);
		x0ecee64b07d2d5b1((Bitmap)textureBrush.Image);
		x5cf5da33ffcd8d6b = xdd1b8f14cc8ba86d.x16a7fb03c627ebfb(brush.xcc18177a965e0313).xc16040ff4dc683ab || xdd1b8f14cc8ba86d.x94d6c004900d4806(brush.xcc18177a965e0313);
	}

	private x3cd5d648729cd9b6(Bitmap bitmap)
	{
		x0ecee64b07d2d5b1(bitmap);
	}

	private void x0ecee64b07d2d5b1(Bitmap xe205f0cd81228282)
	{
		xbe9a01e942c44c35 = xe205f0cd81228282;
		if (x12de99d3fe309d8f())
		{
			x6d243eb7984ec6b2();
		}
		xedcf13d9a3fd42bd = x6344246f3bef7a57(xbe9a01e942c44c35.RawFormat);
	}

	public void Dispose()
	{
		x8ffe90e7fbccfccd();
		GC.SuppressFinalize(this);
	}

	public void x8ffe90e7fbccfccd()
	{
		if (xbe9a01e942c44c35 != null)
		{
			xbe9a01e942c44c35.Dispose();
			xbe9a01e942c44c35 = null;
		}
	}

	public x342b86618ed63a10 x30a1d7c1aef14f56()
	{
		return x42877f6edb0201a1(x6732ec925116bb2b(xbe9a01e942c44c35.PixelFormat));
	}

	public Bitmap x45634637f3d108db()
	{
		return xbe9a01e942c44c35;
	}

	public void xd9c8acf0e5a12504(int x08db3aeabb253cb1, int x1e218ceaee1bb583, x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		xbe9a01e942c44c35.SetPixel(x08db3aeabb253cb1, x1e218ceaee1bb583, x6c50a99faab7d741.xc7656a130b2889c7());
	}

	public int x635976827427e3da(int x08db3aeabb253cb1, int x1e218ceaee1bb583)
	{
		return xbe9a01e942c44c35.GetPixel(x08db3aeabb253cb1, x1e218ceaee1bb583).ToArgb();
	}

	public void x558cc83610335d8b(Rectangle x0d1d762ec380db87, x3cd5d648729cd9b6 x87af39b6974827c2, Rectangle x47807e698c6282d5)
	{
		using Graphics graphics = Graphics.FromImage(x87af39b6974827c2.xbe9a01e942c44c35);
		graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
		graphics.DrawImage(xbe9a01e942c44c35, x47807e698c6282d5, x0d1d762ec380db87, GraphicsUnit.Pixel);
	}

	public x3cd5d648729cd9b6 xa4e45e1d9e114000(Rectangle x0d1d762ec380db87)
	{
		x3cd5d648729cd9b6 x3cd5d648729cd9b7 = new x3cd5d648729cd9b6(x0d1d762ec380db87.Width, x0d1d762ec380db87.Height, xf2b3620f7bfc9ed5, x5c6fc5693c6898cd, xbe9a01e942c44c35.PixelFormat);
		x558cc83610335d8b(x0d1d762ec380db87, x3cd5d648729cd9b7, x3cd5d648729cd9b7.x37b1dbbad6246778());
		return x3cd5d648729cd9b7;
	}

	public x3cd5d648729cd9b6 x5152a5707921c783(int x9b0739496f8b5475, int x4d5aabc7a55b12ba, float x6088974b0138bee7, float x722d7c3d74d98c33)
	{
		x3cd5d648729cd9b6 x3cd5d648729cd9b7 = new x3cd5d648729cd9b6(x9b0739496f8b5475, x4d5aabc7a55b12ba, x6088974b0138bee7, x722d7c3d74d98c33, xbe9a01e942c44c35.PixelFormat);
		x558cc83610335d8b(x37b1dbbad6246778(), x3cd5d648729cd9b7, x3cd5d648729cd9b7.x37b1dbbad6246778());
		return x3cd5d648729cd9b7;
	}

	public Rectangle x37b1dbbad6246778()
	{
		return new Rectangle(0, 0, xbe9a01e942c44c35.Width, xbe9a01e942c44c35.Height);
	}

	public void x0acd3c2012ea2ee8(string xafe2f3653ee64ebc, xfe2ff3c162b47c70 x0182a6dae298f8a4)
	{
		using Stream xcf18e5243f8d5fd = File.Create(xafe2f3653ee64ebc);
		x0acd3c2012ea2ee8(xcf18e5243f8d5fd, x0182a6dae298f8a4);
	}

	public void x0acd3c2012ea2ee8(Stream xcf18e5243f8d5fd3, xfe2ff3c162b47c70 x0182a6dae298f8a4)
	{
		switch (x0182a6dae298f8a4)
		{
		case xfe2ff3c162b47c70.x15c106572f1e1fbf:
			x295e4a690e69bfab(xcf18e5243f8d5fd3, x858159a2ee718ca5.x79eafe89940e5b0e);
			break;
		case xfe2ff3c162b47c70.x6339cdb9e2b512c7:
			x76d9d85825f57cda(xcf18e5243f8d5fd3);
			break;
		case xfe2ff3c162b47c70.x796ab23ce57ee1e0:
			x2746a43e49feca2f(xcf18e5243f8d5fd3, 80);
			break;
		case xfe2ff3c162b47c70.xc2746d872ce402e9:
			xccd8261f31df114c(xcf18e5243f8d5fd3);
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("bklnmlcogmjodmapbmhpdmopmgfamlmahkdbjlkbfkbcnficdkpcfkgdefndfkeegjleejcfljjffeaglihgmiognhfhaimhlhdiddkighbjmhijmhpjehgkfgnkfhelmcll", 805362526)));
		}
	}

	public void x2746a43e49feca2f(Stream xcf18e5243f8d5fd3, int x84ac8992b50dcee7)
	{
		x0a77a9cec36056d0();
		x26b15f27f6076ab7(xbe9a01e942c44c35, xcf18e5243f8d5fd3, x84ac8992b50dcee7);
	}

	public void x76d9d85825f57cda(Stream xcf18e5243f8d5fd3)
	{
		x0a77a9cec36056d0();
		if (xed747ca236d86aa0.xf40b599afa14f524() == x3bb20242a64c30a9.x8a2adacc78a4bcc9)
		{
			xb9b8a93cc6513f40(xbe9a01e942c44c35, xcf18e5243f8d5fd3);
			return;
		}
		Stream stream = new MemoryStream();
		xb9b8a93cc6513f40(xbe9a01e942c44c35, stream);
		xbfa1e705ecc26787(stream, xcf18e5243f8d5fd3, xf2b3620f7bfc9ed5, x5c6fc5693c6898cd);
	}

	public void xccd8261f31df114c(Stream xcf18e5243f8d5fd3)
	{
		x0a77a9cec36056d0();
		xe8858d77a12c34f8(xbe9a01e942c44c35, xcf18e5243f8d5fd3);
	}

	public void x295e4a690e69bfab(Stream xcf18e5243f8d5fd3, x858159a2ee718ca5 x66c2bb8e70f50527)
	{
		x0a77a9cec36056d0();
		using xebe2492c6fd44f51 xebe2492c6fd44f52 = new xebe2492c6fd44f51();
		xebe2492c6fd44f52.x2c68b59bdffce478(xbe9a01e942c44c35, xcf18e5243f8d5fd3, x66c2bb8e70f50527, x5229aac0e655112a: false);
	}

	private static void x26b15f27f6076ab7(Image xe058541ca798c059, Stream xcf18e5243f8d5fd3, int x84ac8992b50dcee7)
	{
		ImageCodecInfo encoder = x6a10b0e15f4796fb.xe9a31ec80cc211ff(ImageFormat.Jpeg);
		EncoderParameters encoderParameters = new EncoderParameters();
		encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, x84ac8992b50dcee7);
		try
		{
			xe058541ca798c059.Save(xcf18e5243f8d5fd3, encoder, encoderParameters);
		}
		catch (ExternalException)
		{
			xcf18e5243f8d5fd3.Position = 0L;
			using Bitmap bitmap = new Bitmap(xe058541ca798c059);
			bitmap.Save(xcf18e5243f8d5fd3, encoder, encoderParameters);
		}
	}

	private static void xb9b8a93cc6513f40(Image xe058541ca798c059, Stream xcf18e5243f8d5fd3)
	{
		xe058541ca798c059.Save(xcf18e5243f8d5fd3, x6a10b0e15f4796fb.xe9a31ec80cc211ff(ImageFormat.Png), null);
	}

	private static void xe8858d77a12c34f8(Image xe058541ca798c059, Stream xcf18e5243f8d5fd3)
	{
		xe058541ca798c059.Save(xcf18e5243f8d5fd3, x6a10b0e15f4796fb.xe9a31ec80cc211ff(ImageFormat.Bmp), null);
	}

	private void x0a77a9cec36056d0()
	{
		if (x5cf5da33ffcd8d6b)
		{
			Bitmap bitmap = new Bitmap(xbe9a01e942c44c35);
			bitmap.SetResolution(96f, 96f);
			xbe9a01e942c44c35.Dispose();
			xbe9a01e942c44c35 = bitmap;
			x5cf5da33ffcd8d6b = false;
		}
	}

	public static byte[] x9119dc963bd33df7(byte[] x43e181e083db6cdf)
	{
		if (xed747ca236d86aa0.xf40b599afa14f524() == x3bb20242a64c30a9.x8a2adacc78a4bcc9)
		{
			return x43e181e083db6cdf;
		}
		if (x43e181e083db6cdf[0] != 66 || x43e181e083db6cdf[1] != 77)
		{
			return x43e181e083db6cdf;
		}
		uint num = BitConverter.ToUInt16(x43e181e083db6cdf, 10);
		uint num2 = BitConverter.ToUInt32(x43e181e083db6cdf, 14);
		bool flag = num2 == 12;
		uint num3 = BitConverter.ToUInt16(x43e181e083db6cdf, flag ? 24 : 28);
		if (num3 == 16)
		{
			using (Image image = Image.FromStream(new MemoryStream(x43e181e083db6cdf)))
			{
				using Image xe058541ca798c = (Image)image.Clone();
				using Graphics graphics = xaf1d5886bde15736.x2c0e2b36cc23e6ca(xe058541ca798c);
				image.RotateFlip(RotateFlipType.Rotate180FlipX);
				switch (num)
				{
				case 54u:
					graphics.DrawImage(image, new Point(-(image.Width - 6), -1));
					graphics.DrawImage(image, new Point(6, 0));
					break;
				case 70u:
					graphics.DrawImage(image, new Point(image.Width - 8, 1));
					graphics.DrawImage(image, new Point(-8, 0));
					break;
				case 66u:
					graphics.DrawImage(image, Point.Empty);
					break;
				}
				MemoryStream memoryStream = new MemoryStream();
				xe8858d77a12c34f8(xe058541ca798c, memoryStream);
				return memoryStream.ToArray();
			}
		}
		return x43e181e083db6cdf;
	}

	public x26d9ecb4bdf0456d[] x063edd567c9c22da()
	{
		Color[] entries = xbe9a01e942c44c35.Palette.Entries;
		x26d9ecb4bdf0456d[] array = new x26d9ecb4bdf0456d[entries.Length];
		for (int i = 0; i < entries.Length; i++)
		{
			array[i] = x26d9ecb4bdf0456d.xcd907c08c553c15c(entries[i]);
		}
		return array;
	}

	public xedbd1996b60ba29c x51989911a6cd532e(bool xfc9f6120a37a69d7, bool xc2e8f3eda3048825)
	{
		return x5e245124259e7268(xfc9f6120a37a69d7, xc2e8f3eda3048825, null);
	}

	public xedbd1996b60ba29c x5e245124259e7268(bool xfc9f6120a37a69d7, bool xc2e8f3eda3048825, xf276f6a75b584d31 xe4eb37da4d22423c)
	{
		if (xfc9f6120a37a69d7)
		{
			x67f5e4db5e884ab4 x67f5e4db5e884ab = new x67f5e4db5e884ab4();
			byte[] colorValues = x67f5e4db5e884ab.xb21a089ee19dd853(xbe9a01e942c44c35);
			return new xedbd1996b60ba29c(colorValues, null, hasTransparentPixels: false, x342b86618ed63a10.x4ad4518443afe7c9, 1);
		}
		BitmapData bitmapData = null;
		try
		{
			PixelFormat pixelFormat = x6732ec925116bb2b(xbe9a01e942c44c35.PixelFormat);
			bitmapData = xbe9a01e942c44c35.LockBits(new Rectangle(0, 0, xbe9a01e942c44c35.Width, xbe9a01e942c44c35.Height), ImageLockMode.ReadOnly, pixelFormat);
			return x42877f6edb0201a1(pixelFormat) switch
			{
				x342b86618ed63a10.x2c689d7a8a2c3c93 => xb2b1df5d1853ef37(bitmapData, xc2e8f3eda3048825, xe4eb37da4d22423c), 
				x342b86618ed63a10.x7bc2cd43944d90a3 => xb6ab599d969d678e(bitmapData, xbe9a01e942c44c35.Palette, xe4eb37da4d22423c), 
				x342b86618ed63a10.x4ad4518443afe7c9 => throw new InvalidOperationException("Have not seen any gray scale images yet."), 
				_ => throw new InvalidOperationException("Unknown color space."), 
			};
		}
		finally
		{
			if (bitmapData != null)
			{
				xbe9a01e942c44c35.UnlockBits(bitmapData);
			}
		}
	}

	public xedbd1996b60ba29c xd611027d44ab2966()
	{
		x3cd5d648729cd9b6 x3cd5d648729cd9b7 = null;
		try
		{
			x3cd5d648729cd9b7 = x4e5bb841d4663c53();
			return x3cd5d648729cd9b7.x51989911a6cd532e(xfc9f6120a37a69d7: false, xc2e8f3eda3048825: false);
		}
		finally
		{
			if (x3cd5d648729cd9b7 != this)
			{
				x3cd5d648729cd9b7?.Dispose();
			}
		}
	}

	private static PixelFormat x6732ec925116bb2b(PixelFormat xe794eba09b6f3cf9)
	{
		switch (xe794eba09b6f3cf9)
		{
		case PixelFormat.Format24bppRgb:
		case PixelFormat.Format32bppRgb:
		case PixelFormat.Format1bppIndexed:
		case PixelFormat.Format4bppIndexed:
		case PixelFormat.Format8bppIndexed:
		case PixelFormat.Format32bppPArgb:
		case PixelFormat.Format32bppArgb:
			return xe794eba09b6f3cf9;
		case PixelFormat.Format16bppRgb555:
		case PixelFormat.Format16bppRgb565:
		case PixelFormat.Format48bppRgb:
			return PixelFormat.Format24bppRgb;
		case PixelFormat.Format16bppGrayScale:
			return PixelFormat.Format24bppRgb;
		default:
			return PixelFormat.Format32bppArgb;
		}
	}

	private static x342b86618ed63a10 x42877f6edb0201a1(PixelFormat xe794eba09b6f3cf9)
	{
		switch (xe794eba09b6f3cf9)
		{
		case PixelFormat.Format1bppIndexed:
		case PixelFormat.Format4bppIndexed:
		case PixelFormat.Format8bppIndexed:
			return x342b86618ed63a10.x7bc2cd43944d90a3;
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
			return x342b86618ed63a10.x2c689d7a8a2c3c93;
		case PixelFormat.Format16bppGrayScale:
			return x342b86618ed63a10.x4ad4518443afe7c9;
		default:
			throw new InvalidOperationException("Unknown pixel format.");
		}
	}

	private static xedbd1996b60ba29c xb2b1df5d1853ef37(BitmapData x77eebfd431f6213f, bool xc2e8f3eda3048825, xf276f6a75b584d31 xe4eb37da4d22423c)
	{
		switch (x77eebfd431f6213f.PixelFormat)
		{
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("npbkibjkccalpbhlnbolpbfmimlmfbdndaknbbbopaioopooglfphanpipdagpkanpbbhkibeppbkogcgpncaoedeoldfjceinjeonafonhfgnofhmfghnmgoidh", 189178298)));
		case PixelFormat.Format24bppRgb:
		case PixelFormat.Format32bppRgb:
		case PixelFormat.Format32bppPArgb:
		case PixelFormat.Format32bppArgb:
		{
			if (x77eebfd431f6213f.Stride < 0)
			{
				throw new InvalidOperationException("A bitmap has a negative stride and this is not yet supported.");
			}
			byte[] array = new byte[x77eebfd431f6213f.Width * x77eebfd431f6213f.Height * 3];
			bool flag = (x77eebfd431f6213f.PixelFormat & PixelFormat.Alpha) != 0;
			bool flag2 = flag || xe4eb37da4d22423c != null;
			byte[] array2 = new byte[flag2 ? (x77eebfd431f6213f.Width * x77eebfd431f6213f.Height) : 0];
			bool flag3 = false;
			int num = 0;
			int num2 = 0;
			byte[] array3 = new byte[x77eebfd431f6213f.Stride];
			long num3 = x77eebfd431f6213f.Scan0.ToInt64();
			bool flag4 = x77eebfd431f6213f.PixelFormat == PixelFormat.Format32bppRgb;
			for (int i = 0; i < x77eebfd431f6213f.Height; i++)
			{
				Marshal.Copy(new IntPtr(num3), array3, 0, array3.Length);
				int num4 = 0;
				for (int j = 0; j < x77eebfd431f6213f.Width; j++)
				{
					byte b = array3[num4++];
					byte b2 = array3[num4++];
					byte b3 = array3[num4++];
					array[num + 2] = b;
					array[num + 1] = b2;
					array[num] = b3;
					num += 3;
					byte b4 = byte.MaxValue;
					if (flag)
					{
						b4 = array3[num4++];
					}
					else if (flag4)
					{
						num4++;
					}
					if (flag2)
					{
						if (xe4eb37da4d22423c != null)
						{
							b4 = (byte)((!xe4eb37da4d22423c.x01be14848dc45cb8(b3, b2, b)) ? b4 : 0);
						}
						if (b4 < byte.MaxValue)
						{
							flag3 = true;
						}
						array2[num2++] = b4;
					}
				}
				num3 += x77eebfd431f6213f.Stride;
			}
			bool hadTransparentPixels = flag3;
			if (xc2e8f3eda3048825 && flag3)
			{
				for (int k = 0; k < array2.Length; k++)
				{
					float x6ad505c7ef981b0e = 1f - (float)(array2[k] ^ 0xFF) / 255f;
					int num5 = k * 3;
					array[num5] = (byte)x26d9ecb4bdf0456d.x2952bc8481699a0f(255, array[num5], x6ad505c7ef981b0e);
					array[num5 + 1] = (byte)x26d9ecb4bdf0456d.x2952bc8481699a0f(255, array[num5 + 1], x6ad505c7ef981b0e);
					array[num5 + 2] = (byte)x26d9ecb4bdf0456d.x2952bc8481699a0f(255, array[num5 + 2], x6ad505c7ef981b0e);
				}
				array2 = xcd4bd3abd72ff2da.x2b0797e1bb4e840a;
				flag3 = false;
			}
			return new xedbd1996b60ba29c(array, array2, flag3, hadTransparentPixels, x342b86618ed63a10.x2c689d7a8a2c3c93, 8);
		}
		}
	}

	private static xedbd1996b60ba29c xb6ab599d969d678e(BitmapData x77eebfd431f6213f, ColorPalette xec84d9599a290299, xf276f6a75b584d31 xe4eb37da4d22423c)
	{
		int num = x77eebfd431f6213f.PixelFormat switch
		{
			PixelFormat.Format1bppIndexed => 1, 
			PixelFormat.Format4bppIndexed => 4, 
			PixelFormat.Format8bppIndexed => 8, 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("nfggihngciehphlhnhciphjiicajfhhjdgojbhfkpgmkofdlgbklhgbmifimgfpmnfgnhannefeokelogfcpaejpeeaafpgaidoaodfbodmbgddchckchdbdoohd", 691430938))), 
		};
		if (x77eebfd431f6213f.Stride < 0)
		{
			throw new InvalidOperationException("A bitmap has a negative stride and this is not yet supported.");
		}
		int num2 = (int)Math.Ceiling((float)x77eebfd431f6213f.Width * (float)num / 8f);
		byte[] array = new byte[num2 * x77eebfd431f6213f.Height];
		bool flag = xe4eb37da4d22423c != null || x486e50a752bb7e53(xec84d9599a290299);
		byte[] array2 = new byte[flag ? (x77eebfd431f6213f.Width * x77eebfd431f6213f.Height) : 0];
		int num3 = 0;
		bool hasTransparentPixels = false;
		int num4 = 0;
		long num5 = x77eebfd431f6213f.Scan0.ToInt64();
		for (int i = 0; i < x77eebfd431f6213f.Height; i++)
		{
			Marshal.Copy(new IntPtr(num5), array, num4, num2);
			if (flag)
			{
				for (int j = 0; j < x77eebfd431f6213f.Width; j++)
				{
					x26d9ecb4bdf0456d x26d9ecb4bdf0456d = x7b33ceee63066880(array, num, xec84d9599a290299, num4, j);
					byte b = (byte)x26d9ecb4bdf0456d.xda71bf6f7c07c3bc;
					if (xe4eb37da4d22423c != null)
					{
						b = (byte)((!xe4eb37da4d22423c.x01be14848dc45cb8(x26d9ecb4bdf0456d)) ? b : 0);
					}
					array2[num3++] = b;
					if (b < byte.MaxValue)
					{
						hasTransparentPixels = true;
					}
				}
			}
			num4 += num2;
			num5 += x77eebfd431f6213f.Stride;
		}
		return new xedbd1996b60ba29c(array, array2, hasTransparentPixels, x342b86618ed63a10.x7bc2cd43944d90a3, num);
	}

	private static bool x486e50a752bb7e53(ColorPalette xec84d9599a290299)
	{
		Color[] entries = xec84d9599a290299.Entries;
		foreach (Color color in entries)
		{
			if (color.A != byte.MaxValue)
			{
				return true;
			}
		}
		return false;
	}

	private static x26d9ecb4bdf0456d x7b33ceee63066880(byte[] xf1c258adc3c53c0e, int xea3e159ad24c1531, ColorPalette xec84d9599a290299, int xdd37b3ac593d051f, int xe3e287548b3d01f5)
	{
		int num = (int)Math.Floor((float)xe3e287548b3d01f5 * (float)xea3e159ad24c1531 / 8f);
		byte b = xf1c258adc3c53c0e[xdd37b3ac593d051f + num];
		int num2 = xe3e287548b3d01f5 * xea3e159ad24c1531 % 8;
		int num3 = (1 << xea3e159ad24c1531) - 1;
		int num4 = (b & (num3 << num2)) >> num2;
		return x26d9ecb4bdf0456d.xcd907c08c553c15c(xec84d9599a290299.Entries[num4]);
	}

	public static Image x40854b0899c49243(Stream xcf18e5243f8d5fd3)
	{
		return Image.FromStream(xcf18e5243f8d5fd3);
	}

	public static void x367bb145e7fa9226(Image xe058541ca798c059, Stream xcf18e5243f8d5fd3)
	{
		switch (x6344246f3bef7a57(xe058541ca798c059.RawFormat))
		{
		case xfe2ff3c162b47c70.xd69df86e2a88ddb2:
		case xfe2ff3c162b47c70.xb5fe04c34562f438:
			x6d137993062800f8((Metafile)xe058541ca798c059, xcf18e5243f8d5fd3);
			break;
		case xfe2ff3c162b47c70.x796ab23ce57ee1e0:
		{
			x3cd5d648729cd9b6 x3cd5d648729cd9b8 = new x3cd5d648729cd9b6((Bitmap)xe058541ca798c059);
			x3cd5d648729cd9b8.x2746a43e49feca2f(xcf18e5243f8d5fd3, 80);
			x3cd5d648729cd9b8.xbe9a01e942c44c35 = null;
			break;
		}
		default:
		{
			x3cd5d648729cd9b6 x3cd5d648729cd9b7 = new x3cd5d648729cd9b6((Bitmap)xe058541ca798c059);
			x3cd5d648729cd9b7.x76d9d85825f57cda(xcf18e5243f8d5fd3);
			x3cd5d648729cd9b7.xbe9a01e942c44c35 = null;
			break;
		}
		}
	}

	private static void x6d137993062800f8(Metafile x81824fe5a4bf0dd1, Stream xedc894794186020d)
	{
		using x3cd5d648729cd9b6 x3cd5d648729cd9b7 = new x3cd5d648729cd9b6(1, 1);
		x3cd5d648729cd9b7.x45634637f3d108db().SetResolution(x81824fe5a4bf0dd1.HorizontalResolution, x81824fe5a4bf0dd1.VerticalResolution);
		using Graphics graphics = xaf1d5886bde15736.x2c0e2b36cc23e6ca(x3cd5d648729cd9b7.x45634637f3d108db());
		IntPtr hdc = graphics.GetHdc();
		try
		{
			using Metafile xe058541ca798c = new Metafile(xedc894794186020d, hdc, EmfType.EmfPlusDual);
			using (Graphics graphics2 = xaf1d5886bde15736.x2c0e2b36cc23e6ca(xe058541ca798c))
			{
				Rectangle bounds = x81824fe5a4bf0dd1.GetMetafileHeader().Bounds;
				graphics2.DrawImageUnscaled(x81824fe5a4bf0dd1, bounds);
			}
			xedc894794186020d.Flush();
		}
		finally
		{
			graphics.ReleaseHdc(hdc);
		}
	}

	private static void xbfa1e705ecc26787(Stream xdc4cce4a2fe6be69, Stream xf823f0edaa261f3b, double xb73d9a1fc8dd845a, double x2463e0aa6364c53a)
	{
		xdc4cce4a2fe6be69.Position = 0L;
		xa8866d7566da0aa2 xa8866d7566da0aa = new xa8866d7566da0aa2(xdc4cce4a2fe6be69);
		x73087173962e3778 x73087173962e = new x73087173962e3778(xf823f0edaa261f3b);
		byte[] x5cafa8d49ea71ea = xa8866d7566da0aa.x0f6807cca84a8e5b(8);
		x73087173962e.x4c116b70372a3c6d(x5cafa8d49ea71ea, 0, 8);
		bool flag = false;
		string @string;
		do
		{
			uint num = xa8866d7566da0aa.x2aa9a7ff4efa6ddf();
			byte[] array = xa8866d7566da0aa.x0f6807cca84a8e5b(4);
			byte[] x5cafa8d49ea71ea2 = xa8866d7566da0aa.x0f6807cca84a8e5b((int)num);
			uint xbcea506a33cf = xa8866d7566da0aa.x2aa9a7ff4efa6ddf();
			@string = Encoding.ASCII.GetString(array);
			if (@string == "pHYs")
			{
				flag = true;
			}
			if (@string == "IDAT" && !flag)
			{
				x73087173962e.x04aa082effd9db6b(9u);
				x73087173962e.x4c116b70372a3c6d(new byte[4] { 112, 72, 89, 115 }, 0, 4);
				x73087173962e.x04aa082effd9db6b(Convert.ToUInt32(Math.Round(xb73d9a1fc8dd845a / 0.0254)));
				x73087173962e.x04aa082effd9db6b(Convert.ToUInt32(Math.Round(x2463e0aa6364c53a / 0.0254)));
				x73087173962e.xc351d479ff7ee789(1);
				x73087173962e.x04aa082effd9db6b(0u);
				flag = true;
			}
			x73087173962e.x04aa082effd9db6b(num);
			x73087173962e.x4c116b70372a3c6d(array, 0, 4);
			x73087173962e.x4c116b70372a3c6d(x5cafa8d49ea71ea2, 0, (int)num);
			x73087173962e.x04aa082effd9db6b(xbcea506a33cf);
		}
		while (!(@string == "IEND"));
		x73087173962e.xbb7550bbb62a218c();
	}

	private void x6d243eb7984ec6b2()
	{
		x3cd5d648729cd9b6 x3cd5d648729cd9b7 = new x3cd5d648729cd9b6(xdc1bf80853046136, xb0f146032f47c24e, xf2b3620f7bfc9ed5, x5c6fc5693c6898cd, PixelFormat.Format24bppRgb);
		Rectangle rectangle = x37b1dbbad6246778();
		x558cc83610335d8b(rectangle, x3cd5d648729cd9b7, rectangle);
		xbe9a01e942c44c35.Dispose();
		xbe9a01e942c44c35 = x3cd5d648729cd9b7.xbe9a01e942c44c35;
		x3cd5d648729cd9b7.xbe9a01e942c44c35 = null;
	}

	private x3cd5d648729cd9b6 x4e5bb841d4663c53()
	{
		x3cd5d648729cd9b6 x3cd5d648729cd9b7;
		if (xbe9a01e942c44c35.PixelFormat != PixelFormat.Format32bppArgb)
		{
			x3cd5d648729cd9b7 = new x3cd5d648729cd9b6(xdc1bf80853046136, xb0f146032f47c24e, xf2b3620f7bfc9ed5, x5c6fc5693c6898cd, PixelFormat.Format32bppArgb);
			Rectangle rectangle = x37b1dbbad6246778();
			x558cc83610335d8b(rectangle, x3cd5d648729cd9b7, rectangle);
		}
		else
		{
			x3cd5d648729cd9b7 = this;
		}
		return x3cd5d648729cd9b7;
	}

	public void xd9fb93ed9b732074(xf276f6a75b584d31 xe4eb37da4d22423c)
	{
		Color color = Color.FromArgb(0, 0, 0, 0);
		Color black = Color.Black;
		x3cd5d648729cd9b6 x3cd5d648729cd9b7 = new x3cd5d648729cd9b6(xdc1bf80853046136, xb0f146032f47c24e, xf2b3620f7bfc9ed5, x5c6fc5693c6898cd, PixelFormat.Format32bppArgb);
		for (int i = 0; i < xbe9a01e942c44c35.Width; i++)
		{
			for (int j = 0; j < xbe9a01e942c44c35.Height; j++)
			{
				x26d9ecb4bdf0456d x6c50a99faab7d = x26d9ecb4bdf0456d.xcd907c08c553c15c(xbe9a01e942c44c35.GetPixel(i, j));
				x3cd5d648729cd9b7.xbe9a01e942c44c35.SetPixel(i, j, xe4eb37da4d22423c.x01be14848dc45cb8(x6c50a99faab7d) ? color : black);
			}
		}
		xbe9a01e942c44c35.Dispose();
		xbe9a01e942c44c35 = x3cd5d648729cd9b7.xbe9a01e942c44c35;
		x3cd5d648729cd9b7.xbe9a01e942c44c35 = null;
	}

	public void x3a7f601b9a1adbf4(xdf4d4502e7d76522 xae6f327ee17553ea)
	{
		xbe9a01e942c44c35 = x3a7f601b9a1adbf4(xbe9a01e942c44c35, xae6f327ee17553ea);
	}

	public bool x12de99d3fe309d8f()
	{
		ImageFlags flags = (ImageFlags)xbe9a01e942c44c35.Flags;
		if ((flags & ImageFlags.ColorSpaceCmyk) == ImageFlags.ColorSpaceCmyk || (flags & ImageFlags.ColorSpaceYcck) == ImageFlags.ColorSpaceYcck)
		{
			return true;
		}
		return xbe9a01e942c44c35.PixelFormat == (PixelFormat)8207;
	}

	private static ColorMap[] x6773be2c8998389d(xaf230aa026fb819b[] x23029bec4dd3e949)
	{
		ColorMap[] array = new ColorMap[x23029bec4dd3e949.Length];
		for (int i = 0; i < x23029bec4dd3e949.Length; i++)
		{
			ColorMap colorMap = new ColorMap();
			colorMap.OldColor = x23029bec4dd3e949[i].x7292fb9ddd3c1688.xc7656a130b2889c7();
			colorMap.NewColor = x23029bec4dd3e949[i].x9a101e8986ce2172.xc7656a130b2889c7();
			array[i] = colorMap;
		}
		return array;
	}

	private static void xa66628579b772056(ImageAttributes xe1406b9c58e08a6f, xf276f6a75b584d31 x58a274f10d52df0b)
	{
		xe1406b9c58e08a6f.SetColorKey(x58a274f10d52df0b.xdf863a776b239667.xc7656a130b2889c7(), x58a274f10d52df0b.xb07c4db017102b70.xc7656a130b2889c7());
	}

	private static ColorMatrix x5b19f7cac0cfaa88(x1f2ba9b7cb678190 xd6ee666025336f11)
	{
		ColorMatrix colorMatrix = new ColorMatrix();
		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 5; j++)
			{
				colorMatrix[i, j] = xd6ee666025336f11.get_xe6d4b1b411ed94b5(i, j);
			}
		}
		return colorMatrix;
	}

	public void x729755e64b399531(x24fae39da17573bb x688ec2320d23fe44)
	{
		if (!xdd1b8f14cc8ba86d.x92d069eca6ec3dfb(xbe9a01e942c44c35.Width, xbe9a01e942c44c35.Height))
		{
			if (x688ec2320d23fe44.x11a0eb5c9c3f84e0 == xb56653ec61f2ac36.x478ac70dbc87f772)
			{
				Bitmap xfcad4c0a9c5890c = xd4538e5a6afe25db(xbe9a01e942c44c35, x688ec2320d23fe44.x4f7155e57c89d548, x688ec2320d23fe44.x6389c51ad2820f52);
				xbe9a01e942c44c35 = xb74035a84a496bec(xfcad4c0a9c5890c, x688ec2320d23fe44.x11a0eb5c9c3f84e0);
			}
			else
			{
				Bitmap xfcad4c0a9c5890c2 = xb74035a84a496bec(xbe9a01e942c44c35, x688ec2320d23fe44.x11a0eb5c9c3f84e0);
				xbe9a01e942c44c35 = xd4538e5a6afe25db(xfcad4c0a9c5890c2, x688ec2320d23fe44.x4f7155e57c89d548, x688ec2320d23fe44.x6389c51ad2820f52);
			}
		}
	}

	private static Bitmap xb74035a84a496bec(Bitmap xfcad4c0a9c5890c6, xb56653ec61f2ac36 x83e290a8ccdceb7e)
	{
		switch (x83e290a8ccdceb7e)
		{
		case xb56653ec61f2ac36.x4d0b9d4447ba7566:
			return xfcad4c0a9c5890c6;
		case xb56653ec61f2ac36.x478ac70dbc87f772:
		{
			xdf4d4502e7d76522 xdf4d4502e7d2 = new xdf4d4502e7d76522();
			xdf4d4502e7d2.xb526ae6a95468f9a(xc06ff6ce7d4ff5b3.x4e37abf1fefccbb0());
			xdf4d4502e7d2.xd3f06edc344811a0 = 0.5f;
			return x3a7f601b9a1adbf4(xfcad4c0a9c5890c6, xdf4d4502e7d2);
		}
		case xb56653ec61f2ac36.x3d4eb3afdab166b1:
		{
			xdf4d4502e7d76522 xdf4d4502e7d = new xdf4d4502e7d76522();
			xdf4d4502e7d.xb526ae6a95468f9a(xc06ff6ce7d4ff5b3.x4e37abf1fefccbb0());
			return x3a7f601b9a1adbf4(xfcad4c0a9c5890c6, xdf4d4502e7d);
		}
		default:
			throw new InvalidOperationException("Unknown color mode.");
		}
	}

	private static Bitmap xd4538e5a6afe25db(Bitmap xfcad4c0a9c5890c6, float x6eebe5873d5613d0, float x7245ca8139eba392)
	{
		if (x24fae39da17573bb.x83cdafbb59ee3eb7(x7245ca8139eba392) && x24fae39da17573bb.x660d4544111e2562(x6eebe5873d5613d0))
		{
			return xfcad4c0a9c5890c6;
		}
		xdf4d4502e7d76522 xdf4d4502e7d = new xdf4d4502e7d76522();
		xdf4d4502e7d.xb526ae6a95468f9a(xc06ff6ce7d4ff5b3.xd2ad080e85a27b04(x6eebe5873d5613d0, x7245ca8139eba392));
		return x3a7f601b9a1adbf4(xfcad4c0a9c5890c6, xdf4d4502e7d);
	}

	private static Bitmap x3a7f601b9a1adbf4(Bitmap xfcad4c0a9c5890c6, xdf4d4502e7d76522 xae6f327ee17553ea)
	{
		ImageAttributes imageAttr = x7252252a780660cf(xae6f327ee17553ea);
		Bitmap bitmap = new Bitmap(xfcad4c0a9c5890c6.Width, xfcad4c0a9c5890c6.Height);
		bitmap.SetResolution(xfcad4c0a9c5890c6.HorizontalResolution, xfcad4c0a9c5890c6.VerticalResolution);
		using (Graphics graphics = xaf1d5886bde15736.x2c0e2b36cc23e6ca(bitmap))
		{
			graphics.DrawImage(xfcad4c0a9c5890c6, new Rectangle(0, 0, xfcad4c0a9c5890c6.Width, xfcad4c0a9c5890c6.Height), 0, 0, xfcad4c0a9c5890c6.Width, xfcad4c0a9c5890c6.Height, GraphicsUnit.Pixel, imageAttr);
		}
		xfcad4c0a9c5890c6.Dispose();
		return bitmap;
	}

	private static ImageAttributes x7252252a780660cf(xdf4d4502e7d76522 xae6f327ee17553ea)
	{
		ImageAttributes imageAttributes = new ImageAttributes();
		if (xae6f327ee17553ea.xdc6051967ab838b7)
		{
			imageAttributes.SetThreshold(xae6f327ee17553ea.xd3f06edc344811a0);
		}
		if (xae6f327ee17553ea.xdd55432873547248.Length > 0)
		{
			imageAttributes.SetRemapTable(x6773be2c8998389d(xae6f327ee17553ea.xdd55432873547248));
		}
		if (!xae6f327ee17553ea.x45f18b4d2446e7cd.xb22bde0e9b6be655)
		{
			imageAttributes.SetColorMatrix(x5b19f7cac0cfaa88(xae6f327ee17553ea.x45f18b4d2446e7cd));
		}
		if (xae6f327ee17553ea.xf276f6a75b584d31 != null)
		{
			xa66628579b772056(imageAttributes, xae6f327ee17553ea.xf276f6a75b584d31);
		}
		return imageAttributes;
	}

	private static xfe2ff3c162b47c70 x6344246f3bef7a57(ImageFormat x0d9146d51b0e6ca4)
	{
		if (x0d9146d51b0e6ca4.Equals(ImageFormat.Jpeg))
		{
			return xfe2ff3c162b47c70.x796ab23ce57ee1e0;
		}
		if (x0d9146d51b0e6ca4.Equals(ImageFormat.Png))
		{
			return xfe2ff3c162b47c70.x6339cdb9e2b512c7;
		}
		if (x0d9146d51b0e6ca4.Equals(ImageFormat.Emf))
		{
			return xfe2ff3c162b47c70.xd69df86e2a88ddb2;
		}
		if (x0d9146d51b0e6ca4.Equals(ImageFormat.Wmf))
		{
			return xfe2ff3c162b47c70.xb5fe04c34562f438;
		}
		if (x0d9146d51b0e6ca4.Equals(ImageFormat.Bmp))
		{
			return xfe2ff3c162b47c70.xc2746d872ce402e9;
		}
		if (x0d9146d51b0e6ca4.Equals(ImageFormat.Gif))
		{
			return xfe2ff3c162b47c70.x8e716ec1cb703e9f;
		}
		if (x0d9146d51b0e6ca4.Equals(ImageFormat.Tiff))
		{
			return xfe2ff3c162b47c70.x15c106572f1e1fbf;
		}
		return xfe2ff3c162b47c70.xf6c17f648b65c793;
	}
}

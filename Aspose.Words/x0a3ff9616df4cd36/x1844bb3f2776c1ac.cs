using System;
using System.Drawing;
using System.IO;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x0a3ff9616df4cd36;

internal class x1844bb3f2776c1ac : IDisposable
{
	private bool x5fee49399a34d16d;

	private x3cd5d648729cd9b6 xbe9a01e942c44c35;

	private xdf4d4502e7d76522 x9b37d768c10b658a;

	public xdf4d4502e7d76522 x698e9b05d858b9d7
	{
		get
		{
			if (x9b37d768c10b658a == null)
			{
				x9b37d768c10b658a = new xdf4d4502e7d76522();
			}
			return x9b37d768c10b658a;
		}
		set
		{
			x9b37d768c10b658a = value;
		}
	}

	public x1844bb3f2776c1ac(x5e9754e56a4f759f textureBrush)
		: this(new x3cd5d648729cd9b6(textureBrush))
	{
		x5fee49399a34d16d = true;
	}

	public x1844bb3f2776c1ac(byte[] imageBytes)
		: this(new x3cd5d648729cd9b6(imageBytes))
	{
		x5fee49399a34d16d = true;
	}

	public x1844bb3f2776c1ac(x3cd5d648729cd9b6 bitmap)
	{
		if (bitmap == null)
		{
			throw new ArgumentNullException("bitmap");
		}
		xbe9a01e942c44c35 = bitmap;
	}

	public void x3a7f601b9a1adbf4()
	{
		if (xbe9a01e942c44c35 == null)
		{
			throw new ObjectDisposedException("ImageProcessor");
		}
		if (x9b37d768c10b658a != null)
		{
			xbe9a01e942c44c35.x3a7f601b9a1adbf4(x9b37d768c10b658a);
			x9b37d768c10b658a = null;
		}
	}

	public void x4c3c038aa99fff39(x26d9ecb4bdf0456d x824bfb65f06865bd)
	{
		if (x824bfb65f06865bd == null)
		{
			throw new ArgumentNullException("backgroundColor");
		}
		x3a7f601b9a1adbf4();
		Rectangle rectangle = new Rectangle(0, 0, xbe9a01e942c44c35.xdc1bf80853046136, xbe9a01e942c44c35.xb0f146032f47c24e);
		x3cd5d648729cd9b6 x3cd5d648729cd9b = new x3cd5d648729cd9b6(rectangle.Width, rectangle.Height);
		using (x3dacf8cbb5aec9f0 x3dacf8cbb5aec9f = new x3dacf8cbb5aec9f0(x3cd5d648729cd9b))
		{
			x3dacf8cbb5aec9f.x7cfc143904bcbd0a(x824bfb65f06865bd, 0f, 0f, rectangle.Width, rectangle.Height);
		}
		xbe9a01e942c44c35.x558cc83610335d8b(rectangle, x3cd5d648729cd9b, rectangle);
		xbe9a01e942c44c35.Dispose();
		xbe9a01e942c44c35 = x3cd5d648729cd9b;
		x5fee49399a34d16d = true;
	}

	public byte[] x601e9a2243ca6720()
	{
		using MemoryStream memoryStream = new MemoryStream();
		xbe9a01e942c44c35.x0acd3c2012ea2ee8(memoryStream, xfe2ff3c162b47c70.x6339cdb9e2b512c7);
		return x0d299f323d241756.xa0aed4cd3b3d5d92(memoryStream);
	}

	public void Dispose()
	{
		x8ffe90e7fbccfccd();
		GC.SuppressFinalize(this);
	}

	public void x8ffe90e7fbccfccd()
	{
		if (xbe9a01e942c44c35 != null && x5fee49399a34d16d)
		{
			xbe9a01e942c44c35.Dispose();
			xbe9a01e942c44c35 = null;
		}
	}
}

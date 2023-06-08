using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using x5794c252ba25e723;

namespace x1c8faa688b1f0b0c;

internal class xeb74be576dcd2dd2 : xf51865b83a7a0b3b
{
	private readonly Hashtable x18e3c454adbda42d = new Hashtable();

	private float xfc99b466dae7f5df;

	private bool x1b22fc24e6d8903d;

	public bool xbf200fb0098a05e6
	{
		get
		{
			return x1b22fc24e6d8903d;
		}
		set
		{
			x1b22fc24e6d8903d = value;
		}
	}

	private float x659232b8b6a0c76b
	{
		get
		{
			return xfc99b466dae7f5df;
		}
		set
		{
			xfc99b466dae7f5df = value;
		}
	}

	public void x5152a5707921c783(x4fdf549af9de6b97 xda5bf54deb817e37, x56ef2519e07fdbb4 x7f8a886f51b477eb, x56ef2519e07fdbb4 x3ed4f4f0195b98d7)
	{
		if (x7f8a886f51b477eb != x3ed4f4f0195b98d7)
		{
			x5152a5707921c783(xda5bf54deb817e37, (double)x3ed4f4f0195b98d7 / (double)x7f8a886f51b477eb);
		}
	}

	public void x5152a5707921c783(x4fdf549af9de6b97 xda5bf54deb817e37, double x4767f061bb089e3f)
	{
		if (x4767f061bb089e3f != 1.0)
		{
			xb92b9f52422fe898();
			x659232b8b6a0c76b = (float)x4767f061bb089e3f;
			xda5bf54deb817e37.Accept(this);
		}
	}

	private void xb92b9f52422fe898()
	{
		x18e3c454adbda42d.Clear();
	}

	public override void VisitCanvasStart(xb8e7e788f6d59708 canvas)
	{
		if (!x0f02ea64b227a765(canvas))
		{
			canvas.x52dde376accdec7d = x89150d565c85ebb3(canvas.x52dde376accdec7d);
			canvas.xc9bcfb2d9630b0c7 = xb777d9f6040a728b(canvas.xc9bcfb2d9630b0c7);
			if (canvas.x0e1bf8242ad10272 != null)
			{
				canvas.x0e1bf8242ad10272.Accept(this);
			}
		}
	}

	public RectangleF x15757bad678c94c4(RectangleF x26545669838eb36e)
	{
		return new RectangleF(x26545669838eb36e.X * x659232b8b6a0c76b, x26545669838eb36e.Y * x659232b8b6a0c76b, x26545669838eb36e.Width * x659232b8b6a0c76b, x26545669838eb36e.Height * x659232b8b6a0c76b);
	}

	public override void VisitGlyphs(xcc8c7739d82c63ba glyphs)
	{
		if (!x0f02ea64b227a765(glyphs))
		{
			if (glyphs.x0e1bf8242ad10272 != null)
			{
				glyphs.x0e1bf8242ad10272.Accept(this);
			}
			glyphs.x52dde376accdec7d = x89150d565c85ebb3(glyphs.x52dde376accdec7d);
			if (glyphs.xc2d4efc42998d87b != null)
			{
				x7ebe5a2a720718c2(glyphs.xc2d4efc42998d87b);
			}
			glyphs.xc22eade24b085d91 = xd707a971fae3d0a1(glyphs.xc22eade24b085d91);
			glyphs.x437e3b626c0fdd43 = x115ac5da51236136(glyphs.x437e3b626c0fdd43);
		}
	}

	public override void VisitPathStart(xab391c46ff9a0a38 path)
	{
		if (!x0f02ea64b227a765(path))
		{
			path.x52dde376accdec7d = x89150d565c85ebb3(path.x52dde376accdec7d);
			if (path.x9e5d5f9128c69a8f != null)
			{
				x0d11287b26b8dc60(path.x9e5d5f9128c69a8f);
			}
			if (path.x60465f602599d327 != null)
			{
				xe4889845a990d27e(path.x60465f602599d327);
			}
			if (path.x0e1bf8242ad10272 != null)
			{
				path.x0e1bf8242ad10272.Accept(this);
			}
		}
	}

	public override void VisitPolyLineSegment(x60c040f35bb272aa segment)
	{
		if (!x0f02ea64b227a765(segment))
		{
			for (int i = 0; i < segment.x4d7474e8f1849803.Count; i++)
			{
				segment.x4d7474e8f1849803[i] = xd707a971fae3d0a1((PointF)segment.x4d7474e8f1849803[i]);
			}
		}
	}

	public override void VisitBezierSegment(x519b1bd0625473ff segment)
	{
		if (!x0f02ea64b227a765(segment))
		{
			x9fe47a4de491f4aa x56b911bdb6515aed = default(x9fe47a4de491f4aa);
			x56b911bdb6515aed.xc7cf0e43653f9c41 = xd707a971fae3d0a1(segment.x56b911bdb6515aed.xc7cf0e43653f9c41);
			x56b911bdb6515aed.xf52fe1c3cad11afd = xd707a971fae3d0a1(segment.x56b911bdb6515aed.xf52fe1c3cad11afd);
			x56b911bdb6515aed.x2271dea312f4a835 = xd707a971fae3d0a1(segment.x56b911bdb6515aed.x2271dea312f4a835);
			x56b911bdb6515aed.xaf4e0fbe61814cf5 = xd707a971fae3d0a1(segment.x56b911bdb6515aed.xaf4e0fbe61814cf5);
			segment.x56b911bdb6515aed = x56b911bdb6515aed;
		}
	}

	public override void VisitImage(x72c34b8dbaec3734 image)
	{
		if (!x0f02ea64b227a765(image))
		{
			image.xc9bcfb2d9630b0c7 = xb777d9f6040a728b(image.xc9bcfb2d9630b0c7);
			image.xc22eade24b085d91 = xd707a971fae3d0a1(image.xc22eade24b085d91);
			image.x437e3b626c0fdd43 = x115ac5da51236136(image.x437e3b626c0fdd43);
		}
	}

	public override void VisitBookmark(x9a66d03de2ff27e1 bookmark)
	{
		if (!x0f02ea64b227a765(bookmark))
		{
			bookmark.xc22eade24b085d91 = xd707a971fae3d0a1(bookmark.xc22eade24b085d91);
		}
	}

	public override void VisitOutlineItem(x2e5b68a308682b82 outlineItem)
	{
		if (!x0f02ea64b227a765(outlineItem))
		{
			outlineItem.xc22eade24b085d91 = xd707a971fae3d0a1(outlineItem.xc22eade24b085d91);
		}
	}

	public override void VisitFormFieldText(x8fd773b74dcec1bc field)
	{
		if (!x0f02ea64b227a765(field))
		{
			field.xc22eade24b085d91 = xd707a971fae3d0a1(field.xc22eade24b085d91);
			field.x437e3b626c0fdd43 = x115ac5da51236136(field.x437e3b626c0fdd43);
		}
	}

	public override void VisitFormFieldCheckbox(xf8b7d3491a4bc1b0 field)
	{
		if (!x0f02ea64b227a765(field))
		{
			field.xc22eade24b085d91 = xd707a971fae3d0a1(field.xc22eade24b085d91);
			field.x437e3b626c0fdd43 *= x659232b8b6a0c76b;
		}
	}

	public override void VisitFormComboBox(x3a68442d168cdd44 field)
	{
		if (!x0f02ea64b227a765(field))
		{
			field.xc22eade24b085d91 = xd707a971fae3d0a1(field.xc22eade24b085d91);
		}
	}

	private xa702b771604efc86 xb777d9f6040a728b(xa702b771604efc86 xe0abc8f59346647b)
	{
		if (xe0abc8f59346647b != null)
		{
			return new xa702b771604efc86(x15757bad678c94c4(xe0abc8f59346647b.x316e48914c4b28b5), xe0abc8f59346647b.x42f4c234c9358072);
		}
		return null;
	}

	private x54366fa5f75a02f7 x89150d565c85ebb3(x54366fa5f75a02f7 xa801ccff44b0c7eb)
	{
		if (xa801ccff44b0c7eb == null)
		{
			return null;
		}
		x54366fa5f75a02f7 x54366fa5f75a02f = xa801ccff44b0c7eb.x8b61531c8ea35b85();
		x54366fa5f75a02f.x5152a5707921c783(x659232b8b6a0c76b, x659232b8b6a0c76b, MatrixOrder.Append);
		x54366fa5f75a02f.x5152a5707921c783((float)(1.0 / (double)x659232b8b6a0c76b), (float)(1.0 / (double)x659232b8b6a0c76b), MatrixOrder.Prepend);
		return x54366fa5f75a02f;
	}

	private void x7ebe5a2a720718c2(xe39d06eee35dd23d x26094932cf7a9139)
	{
		if (!x0f02ea64b227a765(x26094932cf7a9139) && x1b22fc24e6d8903d)
		{
			x26094932cf7a9139.x53531537bb3331e6 *= x659232b8b6a0c76b;
		}
	}

	private void xe4889845a990d27e(x845d6a068e0b03c5 xd8f1949f8950238a)
	{
		if (xd8f1949f8950238a != null && xd8f1949f8950238a is x7fafd7c73d78a86d && !x0f02ea64b227a765(xd8f1949f8950238a))
		{
			x7fafd7c73d78a86d x7fafd7c73d78a86d = (x7fafd7c73d78a86d)xd8f1949f8950238a;
			x7fafd7c73d78a86d.xaccac17571a8d9fa = x89150d565c85ebb3(x7fafd7c73d78a86d.xaccac17571a8d9fa);
			switch (xd8f1949f8950238a.x4bc21f84846f912d)
			{
			case x0b257a9fb413b6c3.x37b6ad6b01d0c641:
			{
				x5f55370cc09dd787 x5f55370cc09dd = (x5f55370cc09dd787)xd8f1949f8950238a;
				x5f55370cc09dd.x404d528fe2f10961 = x15757bad678c94c4(x5f55370cc09dd.x404d528fe2f10961);
				break;
			}
			case x0b257a9fb413b6c3.x73039d25e580af15:
			{
				xa587dcb499c221cc xa587dcb499c221cc = (xa587dcb499c221cc)xd8f1949f8950238a;
				xa587dcb499c221cc.xf9d280c0b1a71761 = xd707a971fae3d0a1(xa587dcb499c221cc.xf9d280c0b1a71761);
				xa587dcb499c221cc.x632b457a1248cdb1.Accept(this);
				break;
			}
			}
		}
	}

	private void x0d11287b26b8dc60(x31c19fcb724dfaf5 x90279591611601bc)
	{
		if (!x0f02ea64b227a765(x90279591611601bc))
		{
			x90279591611601bc.xdc1bf80853046136 *= x659232b8b6a0c76b;
		}
	}

	private PointF xd707a971fae3d0a1(PointF x2f7096dac971d6ec)
	{
		return new PointF(x2f7096dac971d6ec.X * x659232b8b6a0c76b, x2f7096dac971d6ec.Y * x659232b8b6a0c76b);
	}

	private SizeF x115ac5da51236136(SizeF x0ceec69a97f73617)
	{
		return new SizeF(x0ceec69a97f73617.Width * x659232b8b6a0c76b, x0ceec69a97f73617.Height * x659232b8b6a0c76b);
	}

	private bool x0f02ea64b227a765(object x04790b1520d24d59)
	{
		if (x18e3c454adbda42d.Contains(x04790b1520d24d59))
		{
			return true;
		}
		x18e3c454adbda42d.Add(x04790b1520d24d59, null);
		return false;
	}
}

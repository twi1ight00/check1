using System;
using System.Drawing;
using x5794c252ba25e723;

namespace x1c8faa688b1f0b0c;

internal class x12aabb49dc07bbe6 : xf51865b83a7a0b3b
{
	private bool xbd24aded9e68e9ed;

	private float x6b92c97d65e2e987;

	private float xe4484d3b16e9ba3b;

	private int x26ff8cdedc1087ee;

	private int x83a95095012f53a4;

	public float x83d36262f4284272 => x6b92c97d65e2e987;

	public float x1b6b05a324a79cfa => xe4484d3b16e9ba3b;

	public int x634c915d222ba098 => x26ff8cdedc1087ee;

	public int x9a130f8688122b2d => x83a95095012f53a4;

	public void xb1de1ba20faeeff8(x4fdf549af9de6b97 xda5bf54deb817e37)
	{
		x353954500d6438ab();
		xbd24aded9e68e9ed = false;
		xda5bf54deb817e37.Accept(this);
	}

	private void x353954500d6438ab()
	{
		x6b92c97d65e2e987 = 0f;
		xe4484d3b16e9ba3b = 0f;
		x26ff8cdedc1087ee = 0;
		x83a95095012f53a4 = 0;
	}

	public override void VisitCanvasStart(xb8e7e788f6d59708 canvas)
	{
		x26ff8cdedc1087ee++;
		if (canvas.x52dde376accdec7d != null)
		{
			x93685a910a259378(canvas.x52dde376accdec7d);
		}
		if (canvas.xc9bcfb2d9630b0c7 != null)
		{
			x08b4c570d8e5e330(canvas.xc9bcfb2d9630b0c7);
		}
		x7f64d7934dd25990(canvas.x0e1bf8242ad10272);
	}

	private void x08b4c570d8e5e330(xa702b771604efc86 xe0abc8f59346647b)
	{
		x79eade12518004d1(xe0abc8f59346647b.x316e48914c4b28b5);
	}

	private void x7b3346deecfb7203(float xbcea506a33cf9111)
	{
		if (Math.Abs(xbcea506a33cf9111) > x6b92c97d65e2e987)
		{
			x6b92c97d65e2e987 = Math.Abs(xbcea506a33cf9111);
		}
	}

	private void xd2ca446ca3df9964(float xbcea506a33cf9111)
	{
		if (Math.Abs(xbcea506a33cf9111) > xe4484d3b16e9ba3b)
		{
			xe4484d3b16e9ba3b = Math.Abs(xbcea506a33cf9111);
		}
	}

	private void x79eade12518004d1(RectangleF x26545669838eb36e)
	{
		x7b3346deecfb7203(x26545669838eb36e.Top);
		x7b3346deecfb7203(x26545669838eb36e.Left);
		x7b3346deecfb7203(x26545669838eb36e.Right);
		x7b3346deecfb7203(x26545669838eb36e.Bottom);
	}

	private void x93685a910a259378(x54366fa5f75a02f7 xa801ccff44b0c7eb)
	{
	}

	private void x7f64d7934dd25990(xab391c46ff9a0a38 xe125219852864557)
	{
		if (xe125219852864557 != null)
		{
			if (xe125219852864557.x52dde376accdec7d != null)
			{
				x93685a910a259378(xe125219852864557.x52dde376accdec7d);
			}
			xbd24aded9e68e9ed = true;
			for (int i = 0; i < xe125219852864557.xd44988f225497f3a; i++)
			{
				x4fdf549af9de6b97 x4fdf549af9de6b98 = ((xbaec545ec01f92ca)xe125219852864557).get_xe6d4b1b411ed94b5(i);
				x4fdf549af9de6b98.Accept(this);
			}
			xbd24aded9e68e9ed = false;
		}
	}

	public override void VisitGlyphs(xcc8c7739d82c63ba glyphs)
	{
		x26ff8cdedc1087ee++;
		x7f64d7934dd25990(glyphs.x0e1bf8242ad10272);
		if (glyphs.x52dde376accdec7d != null)
		{
			x93685a910a259378(glyphs.x52dde376accdec7d);
		}
		if (glyphs.xc2d4efc42998d87b != null)
		{
			x1ffb979e0662c457(glyphs.xc2d4efc42998d87b);
		}
		x476cf93dd87700c4(glyphs.xc22eade24b085d91);
		x81e20d43cc9ee4c1(glyphs.x437e3b626c0fdd43);
	}

	private void x1ffb979e0662c457(xe39d06eee35dd23d x26094932cf7a9139)
	{
	}

	public override void VisitPathStart(xab391c46ff9a0a38 path)
	{
		if (!xbd24aded9e68e9ed)
		{
			x26ff8cdedc1087ee++;
			x83a95095012f53a4++;
		}
		if (path.x52dde376accdec7d != null)
		{
			x93685a910a259378(path.x52dde376accdec7d);
		}
		if (path.x9e5d5f9128c69a8f != null)
		{
			xaf84ec0e6972f23d(path.x9e5d5f9128c69a8f);
		}
		if (path.x60465f602599d327 != null)
		{
			x13351730ae0fdf34(path.x60465f602599d327);
		}
		x7f64d7934dd25990(path.x0e1bf8242ad10272);
	}

	private void x13351730ae0fdf34(x845d6a068e0b03c5 xd8f1949f8950238a)
	{
		if (xd8f1949f8950238a != null && xd8f1949f8950238a is x7fafd7c73d78a86d)
		{
			x93685a910a259378(((x7fafd7c73d78a86d)xd8f1949f8950238a).xaccac17571a8d9fa);
			switch (xd8f1949f8950238a.x4bc21f84846f912d)
			{
			case x0b257a9fb413b6c3.x37b6ad6b01d0c641:
			{
				x5f55370cc09dd787 x5f55370cc09dd = (x5f55370cc09dd787)xd8f1949f8950238a;
				x79eade12518004d1(x5f55370cc09dd.x404d528fe2f10961);
				break;
			}
			case x0b257a9fb413b6c3.x73039d25e580af15:
			{
				xa587dcb499c221cc xa587dcb499c221cc = (xa587dcb499c221cc)xd8f1949f8950238a;
				x476cf93dd87700c4(xa587dcb499c221cc.xf9d280c0b1a71761);
				xa587dcb499c221cc.x632b457a1248cdb1.Accept(this);
				break;
			}
			}
		}
	}

	private void xaf84ec0e6972f23d(x31c19fcb724dfaf5 x90279591611601bc)
	{
		x7b3346deecfb7203(x90279591611601bc.xdc1bf80853046136);
	}

	public override void VisitPolyLineSegment(x60c040f35bb272aa segment)
	{
		if (!xbd24aded9e68e9ed)
		{
			x26ff8cdedc1087ee++;
		}
		foreach (PointF item in segment.x4d7474e8f1849803)
		{
			x476cf93dd87700c4(item);
			if (xbd24aded9e68e9ed)
			{
				x97b4d2a8333e3d7e(item);
			}
		}
	}

	private void x476cf93dd87700c4(PointF x2f7096dac971d6ec)
	{
		x7b3346deecfb7203(x2f7096dac971d6ec.X);
		x7b3346deecfb7203(x2f7096dac971d6ec.Y);
	}

	private void x97b4d2a8333e3d7e(PointF x2f7096dac971d6ec)
	{
		xd2ca446ca3df9964(x2f7096dac971d6ec.X);
		xd2ca446ca3df9964(x2f7096dac971d6ec.Y);
	}

	public override void VisitBezierSegment(x519b1bd0625473ff segment)
	{
		if (!xbd24aded9e68e9ed)
		{
			x26ff8cdedc1087ee++;
		}
		x476cf93dd87700c4(segment.x56b911bdb6515aed.xc7cf0e43653f9c41);
		x476cf93dd87700c4(segment.x56b911bdb6515aed.xf52fe1c3cad11afd);
		x476cf93dd87700c4(segment.x56b911bdb6515aed.x2271dea312f4a835);
		x476cf93dd87700c4(segment.x56b911bdb6515aed.xaf4e0fbe61814cf5);
		if (xbd24aded9e68e9ed)
		{
			x97b4d2a8333e3d7e(segment.x56b911bdb6515aed.xc7cf0e43653f9c41);
			x97b4d2a8333e3d7e(segment.x56b911bdb6515aed.xf52fe1c3cad11afd);
			x97b4d2a8333e3d7e(segment.x56b911bdb6515aed.xaf4e0fbe61814cf5);
			x97b4d2a8333e3d7e(segment.x56b911bdb6515aed.x2271dea312f4a835);
		}
	}

	public override void VisitImage(x72c34b8dbaec3734 image)
	{
		x26ff8cdedc1087ee++;
		if (image.xc9bcfb2d9630b0c7 != null)
		{
			x08b4c570d8e5e330(image.xc9bcfb2d9630b0c7);
		}
		x476cf93dd87700c4(image.xc22eade24b085d91);
		x81e20d43cc9ee4c1(image.x437e3b626c0fdd43);
	}

	private void x81e20d43cc9ee4c1(SizeF x0ceec69a97f73617)
	{
		x7b3346deecfb7203(x0ceec69a97f73617.Width);
		x7b3346deecfb7203(x0ceec69a97f73617.Height);
	}

	public override void VisitBookmark(x9a66d03de2ff27e1 bookmark)
	{
		x26ff8cdedc1087ee++;
		x476cf93dd87700c4(bookmark.xc22eade24b085d91);
	}

	public override void VisitOutlineItem(x2e5b68a308682b82 outlineItem)
	{
		x26ff8cdedc1087ee++;
		x476cf93dd87700c4(outlineItem.xc22eade24b085d91);
	}

	public override void VisitFormFieldText(x8fd773b74dcec1bc field)
	{
		x26ff8cdedc1087ee++;
		x476cf93dd87700c4(field.xc22eade24b085d91);
		x81e20d43cc9ee4c1(field.x437e3b626c0fdd43);
	}

	public override void VisitFormFieldCheckbox(xf8b7d3491a4bc1b0 field)
	{
		x26ff8cdedc1087ee++;
		x476cf93dd87700c4(field.xc22eade24b085d91);
		x7b3346deecfb7203(field.x437e3b626c0fdd43);
	}

	public override void VisitFormComboBox(x3a68442d168cdd44 field)
	{
		x26ff8cdedc1087ee++;
		x476cf93dd87700c4(field.xc22eade24b085d91);
	}

	public override bool VisitGroup(xdc4867bff1715a4b group)
	{
		x26ff8cdedc1087ee++;
		return true;
	}

	public override void VisitPageStart(xc67adcdbca121a26 page)
	{
		x26ff8cdedc1087ee++;
	}

	public override void VisitPathFigureStart(x1cab6af0a41b70e2 pathFigure)
	{
		if (!xbd24aded9e68e9ed)
		{
			x26ff8cdedc1087ee++;
		}
	}
}

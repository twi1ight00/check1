using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using x5794c252ba25e723;

namespace x1c8faa688b1f0b0c;

internal class x8abed58e51c8641c : xf51865b83a7a0b3b
{
	private x9b8ee01b0cc7a256 xb72675e43157edea;

	private RectangleF x18847e4f94b14ff7;

	private Stack xf79a519c14d8c253 = new Stack();

	private bool x5b1d0f65204f5bb6;

	private Stack x4d479ab0c0f0a869 = new Stack();

	private Stack x038f7a152e61fc2a = new Stack();

	private x9b8ee01b0cc7a256 xf5d538c8a140c3d8
	{
		get
		{
			if (xb72675e43157edea == null)
			{
				xb72675e43157edea = new x9b8ee01b0cc7a256();
			}
			return xb72675e43157edea;
		}
	}

	public override void VisitPageStart(xc67adcdbca121a26 page)
	{
	}

	public override void VisitPageEnd(xc67adcdbca121a26 page)
	{
	}

	public override void VisitCanvasStart(xb8e7e788f6d59708 canvas)
	{
		x757412b31cd98a96(canvas);
		x712a21779abca48b(canvas);
	}

	private void x757412b31cd98a96(x0c06161ccb9341e4 x8aea9c96000e55fd)
	{
		x54366fa5f75a02f7 x54366fa5f75a02f = x8aea9c96000e55fd.x52dde376accdec7d;
		if (x54366fa5f75a02f == null)
		{
			x54366fa5f75a02f = new x54366fa5f75a02f7();
		}
		if (x4d479ab0c0f0a869.Count > 0)
		{
			x54366fa5f75a02f7 x470ecea91abfd1aa = (x54366fa5f75a02f7)x4d479ab0c0f0a869.Peek();
			x54366fa5f75a02f7 x54366fa5f75a02f2 = x54366fa5f75a02f.x8b61531c8ea35b85();
			x54366fa5f75a02f2.x490e30087768649f(x470ecea91abfd1aa, MatrixOrder.Append);
			x4d479ab0c0f0a869.Push(x54366fa5f75a02f2);
		}
		else
		{
			x4d479ab0c0f0a869.Push(x54366fa5f75a02f);
		}
	}

	private void x712a21779abca48b(x0c06161ccb9341e4 x6b6b18307d88c235)
	{
		x8abed58e51c8641c x8abed58e51c8641c2 = new x8abed58e51c8641c();
		RectangleF rectangleF = ((x6b6b18307d88c235.x0e1bf8242ad10272 == null) ? RectangleF.Empty : x8abed58e51c8641c2.xb1de1ba20faeeff8(x6b6b18307d88c235.x0e1bf8242ad10272));
		x038f7a152e61fc2a.Push(rectangleF);
	}

	public override void VisitCanvasEnd(xb8e7e788f6d59708 canvas)
	{
		x6d21e7384fe1e903();
		x626b4e729d9fd8ce();
	}

	private void x6d21e7384fe1e903()
	{
		x4d479ab0c0f0a869.Pop();
	}

	private void x626b4e729d9fd8ce()
	{
		x038f7a152e61fc2a.Pop();
	}

	public override void VisitGlyphs(xcc8c7739d82c63ba glyphs)
	{
		x757412b31cd98a96(glyphs);
		x5c851ab1f6000f52(glyphs.x6ae4612a8469678e);
		x6d21e7384fe1e903();
	}

	public override void VisitPathStart(xab391c46ff9a0a38 path)
	{
		x757412b31cd98a96(path);
		if (path.x9e5d5f9128c69a8f != null)
		{
			xf79a519c14d8c253.Push(path.x9e5d5f9128c69a8f.xdc1bf80853046136 / 2f);
		}
		else
		{
			xf79a519c14d8c253.Push(0f);
		}
	}

	public override void VisitPathEnd(xab391c46ff9a0a38 path)
	{
		xf79a519c14d8c253.Pop();
		x6d21e7384fe1e903();
	}

	public override void VisitPathFigureStart(x1cab6af0a41b70e2 pathFigure)
	{
	}

	public override void VisitPathFigureEnd(x1cab6af0a41b70e2 pathFigure)
	{
	}

	public override void VisitPolyLineSegment(x60c040f35bb272aa segment)
	{
		foreach (PointF item in segment.x4d7474e8f1849803)
		{
			x5c851ab1f6000f52(item);
		}
	}

	public override void VisitBezierSegment(x519b1bd0625473ff segment)
	{
		RectangleF xda73fcb97c77d = xf5d538c8a140c3d8.x55fe8a62afa91ade(segment);
		x5c851ab1f6000f52(xda73fcb97c77d);
	}

	public override void VisitImage(x72c34b8dbaec3734 image)
	{
		x5c851ab1f6000f52(image.x6ae4612a8469678e);
	}

	public override void VisitBookmark(x9a66d03de2ff27e1 bookmark)
	{
		x5c851ab1f6000f52(bookmark.xc22eade24b085d91);
	}

	public override void VisitOutlineItem(x2e5b68a308682b82 outlineItem)
	{
		x5c851ab1f6000f52(outlineItem.xc22eade24b085d91);
	}

	public override void VisitFormFieldText(x8fd773b74dcec1bc field)
	{
		x5c851ab1f6000f52(field.BoundingBox);
	}

	public override void VisitFormFieldCheckbox(xf8b7d3491a4bc1b0 field)
	{
		x5c851ab1f6000f52(field.BoundingBox);
	}

	public override void VisitFormComboBox(x3a68442d168cdd44 field)
	{
		x5c851ab1f6000f52(field.BoundingBox);
	}

	public override bool VisitGroup(xdc4867bff1715a4b group)
	{
		return true;
	}

	public RectangleF xb1de1ba20faeeff8(x4fdf549af9de6b97 x9cd0b8c5999d2c9d)
	{
		x18847e4f94b14ff7 = RectangleF.Empty;
		x5b1d0f65204f5bb6 = false;
		if (x9cd0b8c5999d2c9d == null)
		{
			return RectangleF.Empty;
		}
		x9cd0b8c5999d2c9d.Accept(this);
		return x18847e4f94b14ff7;
	}

	private void x5c851ab1f6000f52(RectangleF xda73fcb97c77d998)
	{
		if (xf79a519c14d8c253.Count > 0)
		{
			float num = (float)xf79a519c14d8c253.Peek();
			xda73fcb97c77d998 = RectangleF.Inflate(xda73fcb97c77d998, num, num);
		}
		if (x038f7a152e61fc2a.Count > 0)
		{
			RectangleF rectangleF = (RectangleF)x038f7a152e61fc2a.Peek();
			if (rectangleF != RectangleF.Empty)
			{
				xda73fcb97c77d998 = RectangleF.Intersect(xda73fcb97c77d998, rectangleF);
			}
		}
		if (x4d479ab0c0f0a869.Count > 0)
		{
			x54366fa5f75a02f7 x54366fa5f75a02f = (x54366fa5f75a02f7)x4d479ab0c0f0a869.Peek();
			xda73fcb97c77d998 = x54366fa5f75a02f.xaccac17571a8d9fa(xda73fcb97c77d998);
		}
		if (x5b1d0f65204f5bb6)
		{
			x18847e4f94b14ff7 = RectangleF.Union(x18847e4f94b14ff7, xda73fcb97c77d998);
			return;
		}
		x18847e4f94b14ff7 = xda73fcb97c77d998;
		x5b1d0f65204f5bb6 = true;
	}

	private void x5c851ab1f6000f52(PointF x9c79b5ad7b769b12)
	{
		x5c851ab1f6000f52(new RectangleF(x9c79b5ad7b769b12, SizeF.Empty));
	}
}

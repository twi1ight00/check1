using System.Drawing;
using x1c8faa688b1f0b0c;
using x6c95d9cf46ff5f25;

namespace xc7ce8a6a920f8012;

internal class x0631e1e1fd3fb7bc : xf51865b83a7a0b3b
{
	private PointF xbb039cd20ebbd8f4 = PointF.Empty;

	private readonly x17f806869081a568 x4f82ba9a407218e1;

	private bool x4a40a5bf2b46d97b;

	public x0631e1e1fd3fb7bc(x34b34bf589d8ec1e context)
		: this(new x17f806869081a568(context))
	{
	}

	public x0631e1e1fd3fb7bc(x17f806869081a568 shapeRecordWriter)
	{
		x4f82ba9a407218e1 = shapeRecordWriter;
	}

	public void x6210059f049f0d48(xab391c46ff9a0a38 xe125219852864557)
	{
		xe125219852864557.Accept(this);
	}

	public override void VisitPathFigureStart(x1cab6af0a41b70e2 pathFigure)
	{
		x4a40a5bf2b46d97b = true;
	}

	public override void VisitPathFigureEnd(x1cab6af0a41b70e2 pathFigure)
	{
		if (pathFigure.x5e6c52cb3256cc85)
		{
			xb8bdc43bbb1e4ab0();
		}
	}

	public override void VisitPolyLineSegment(x60c040f35bb272aa segment)
	{
		if (segment.x4d7474e8f1849803.Count > 0)
		{
			if (x4a40a5bf2b46d97b)
			{
				xbb039cd20ebbd8f4 = (PointF)segment.x4d7474e8f1849803[0];
				x01b2723108ff3dfe(xbb039cd20ebbd8f4);
				x4a40a5bf2b46d97b = false;
			}
			for (int i = 0; i < segment.x4d7474e8f1849803.Count; i++)
			{
				PointF x2f7096dac971d6ec = (PointF)segment.x4d7474e8f1849803[i];
				xd0baff30d99dc152(x2f7096dac971d6ec);
			}
		}
	}

	public override void VisitBezierSegment(x519b1bd0625473ff segment)
	{
		if (x4a40a5bf2b46d97b)
		{
			xbb039cd20ebbd8f4 = segment.x56b911bdb6515aed.xaf4e0fbe61814cf5;
			x01b2723108ff3dfe(xbb039cd20ebbd8f4);
			x4a40a5bf2b46d97b = false;
		}
		else
		{
			xd0baff30d99dc152(segment.x56b911bdb6515aed.xaf4e0fbe61814cf5);
		}
		x67293147609631f8[] array = segment.x56b911bdb6515aed.xd3f5c72f5a1d6688();
		x67293147609631f8[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			x67293147609631f8 x67293147609631f = array2[i];
			x102c43569e36d6d1(x67293147609631f.x2f997a78d547d657, x67293147609631f.x2271dea312f4a835);
		}
	}

	private void x01b2723108ff3dfe(PointF x2f7096dac971d6ec)
	{
		x4f82ba9a407218e1.x8797f3d2cbd38dc0(x15e971129fd80714.x43fcc3f62534530b(x2f7096dac971d6ec.X), x15e971129fd80714.x43fcc3f62534530b(x2f7096dac971d6ec.Y));
	}

	private void xd0baff30d99dc152(PointF x2f7096dac971d6ec)
	{
		int num = x15e971129fd80714.x43fcc3f62534530b(x2f7096dac971d6ec.X) - x4f82ba9a407218e1.x7350e3054ecfd77e;
		int num2 = x15e971129fd80714.x43fcc3f62534530b(x2f7096dac971d6ec.Y) - x4f82ba9a407218e1.x73e62f0e25a6da6f;
		if (num != 0 || num2 != 0)
		{
			x4f82ba9a407218e1.x38014cf8ba92c74f(num, num2);
		}
	}

	private void x102c43569e36d6d1(PointF xb87b7305ef2b2389, PointF xa2da454aa40879d2)
	{
		int x665f288f8fc705b = x15e971129fd80714.x43fcc3f62534530b(xb87b7305ef2b2389.X) - x4f82ba9a407218e1.x7350e3054ecfd77e;
		int x2fff4ca1be55a = x15e971129fd80714.x43fcc3f62534530b(xb87b7305ef2b2389.Y) - x4f82ba9a407218e1.x73e62f0e25a6da6f;
		int xf6b69c8d543f = x15e971129fd80714.x43fcc3f62534530b(xa2da454aa40879d2.X) - x15e971129fd80714.x43fcc3f62534530b(xb87b7305ef2b2389.X);
		int x20df811316b9ab7a = x15e971129fd80714.x43fcc3f62534530b(xa2da454aa40879d2.Y) - x15e971129fd80714.x43fcc3f62534530b(xb87b7305ef2b2389.Y);
		x4f82ba9a407218e1.xd43262c22b6af9e4(x665f288f8fc705b, x2fff4ca1be55a, xf6b69c8d543f, x20df811316b9ab7a);
	}

	private void xb8bdc43bbb1e4ab0()
	{
		x4f82ba9a407218e1.x38014cf8ba92c74f(x15e971129fd80714.x43fcc3f62534530b(xbb039cd20ebbd8f4.X) - x4f82ba9a407218e1.x7350e3054ecfd77e, x15e971129fd80714.x43fcc3f62534530b(xbb039cd20ebbd8f4.Y) - x4f82ba9a407218e1.x73e62f0e25a6da6f);
	}
}

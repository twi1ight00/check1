using System.Drawing;
using System.Text;
using Aspose;
using xf9a9481c3f63a419;

namespace x1c8faa688b1f0b0c;

internal class x4ff8ecf10eb0714f : xf51865b83a7a0b3b
{
	private StringBuilder x336289835451ba12;

	private bool x4a40a5bf2b46d97b;

	[JavaThrows(true)]
	internal string x38b39e52c8321dc8(xab391c46ff9a0a38 xe125219852864557)
	{
		x336289835451ba12 = new StringBuilder();
		xe125219852864557.Accept(this);
		return x336289835451ba12.ToString();
	}

	public override void VisitPathFigureStart(x1cab6af0a41b70e2 pathFigure)
	{
		x4a40a5bf2b46d97b = true;
	}

	public override void VisitPathFigureEnd(x1cab6af0a41b70e2 pathFigure)
	{
		if (pathFigure.x5e6c52cb3256cc85)
		{
			x336289835451ba12.Append("Z");
		}
	}

	public override void VisitPolyLineSegment(x60c040f35bb272aa segment)
	{
		if (segment.x4d7474e8f1849803.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < segment.x4d7474e8f1849803.Count; i++)
		{
			if (x4a40a5bf2b46d97b)
			{
				x01b2723108ff3dfe((PointF)segment.x4d7474e8f1849803[0]);
				x4a40a5bf2b46d97b = false;
			}
			else
			{
				xd0baff30d99dc152((PointF)segment.x4d7474e8f1849803[i]);
			}
		}
	}

	public override void VisitBezierSegment(x519b1bd0625473ff segment)
	{
		if (x4a40a5bf2b46d97b)
		{
			x01b2723108ff3dfe(segment.x56b911bdb6515aed.xaf4e0fbe61814cf5);
			x4a40a5bf2b46d97b = false;
		}
		else
		{
			xd0baff30d99dc152(segment.x56b911bdb6515aed.xaf4e0fbe61814cf5);
		}
		x102c43569e36d6d1(new PointF[3]
		{
			segment.x56b911bdb6515aed.xc7cf0e43653f9c41,
			segment.x56b911bdb6515aed.xf52fe1c3cad11afd,
			segment.x56b911bdb6515aed.x2271dea312f4a835
		});
	}

	private void x01b2723108ff3dfe(PointF x2f7096dac971d6ec)
	{
		x336289835451ba12.Append("M");
		x610120f69eaddbd6(x2f7096dac971d6ec);
	}

	private void xd0baff30d99dc152(PointF x2f7096dac971d6ec)
	{
		x336289835451ba12.Append("L");
		x610120f69eaddbd6(x2f7096dac971d6ec);
	}

	private void x102c43569e36d6d1(PointF[] x6fa2570084b2ad39)
	{
		x336289835451ba12.Append("C");
		for (int i = 0; i < x6fa2570084b2ad39.Length; i++)
		{
			x610120f69eaddbd6(x6fa2570084b2ad39[i]);
		}
	}

	private void x610120f69eaddbd6(PointF x2f7096dac971d6ec)
	{
		x336289835451ba12.Append(xca004f56614e2431.x37804260a70f74eb(x2f7096dac971d6ec.X));
		x336289835451ba12.Append(",");
		x336289835451ba12.Append(xca004f56614e2431.x37804260a70f74eb(x2f7096dac971d6ec.Y));
		x336289835451ba12.Append(" ");
	}
}

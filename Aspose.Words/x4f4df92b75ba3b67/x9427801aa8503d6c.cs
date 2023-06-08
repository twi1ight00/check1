using System.Drawing;
using x1c8faa688b1f0b0c;

namespace x4f4df92b75ba3b67;

internal class x9427801aa8503d6c : xf51865b83a7a0b3b
{
	private readonly x4d8917c8186e8cb2 xa49cef274042e702;

	private bool x4a40a5bf2b46d97b;

	public x9427801aa8503d6c(x4d8917c8186e8cb2 stream)
	{
		xa49cef274042e702 = stream;
	}

	public override void VisitPathFigureStart(x1cab6af0a41b70e2 pathFigure)
	{
		x4a40a5bf2b46d97b = true;
	}

	public override void VisitPathFigureEnd(x1cab6af0a41b70e2 pathFigure)
	{
		if (!x4a40a5bf2b46d97b && pathFigure.x5e6c52cb3256cc85)
		{
			xa49cef274042e702.x241b3c2e8c3aaa86("h");
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
		xa49cef274042e702.xfedf842bc95b0880(x2f7096dac971d6ec);
		xa49cef274042e702.x6210059f049f0d48(" m ");
	}

	private void xd0baff30d99dc152(PointF x2f7096dac971d6ec)
	{
		xa49cef274042e702.xfedf842bc95b0880(x2f7096dac971d6ec);
		xa49cef274042e702.x6210059f049f0d48(" l ");
	}

	private void x102c43569e36d6d1(PointF[] x6fa2570084b2ad39)
	{
		for (int i = 0; i < x6fa2570084b2ad39.Length; i++)
		{
			xa49cef274042e702.xfedf842bc95b0880(x6fa2570084b2ad39[i]);
			if (i < x6fa2570084b2ad39.Length - 1)
			{
				xa49cef274042e702.x6210059f049f0d48(" ");
			}
		}
		xa49cef274042e702.x6210059f049f0d48(" c ");
	}
}

using System.Drawing;

namespace x3d94286fe72124a8;

internal class x6a17e4a87b609da7
{
	private bool xd0b4396ff1537c95;

	private bool xc9f9d21a4169c807;

	private bool x477d2d3181c623c1;

	private int x35a5073ffeb125c5;

	private PointF[] xb83ec6d728d62633;

	private float[] xf3fd5bf97dd43cf6;

	internal bool x6e93b8ed0215d172
	{
		get
		{
			return xd0b4396ff1537c95;
		}
		set
		{
			xd0b4396ff1537c95 = value;
		}
	}

	internal bool x4b7d545d48ec0c15
	{
		get
		{
			return xc9f9d21a4169c807;
		}
		set
		{
			xc9f9d21a4169c807 = value;
		}
	}

	internal bool xf4d85c8619117aaa
	{
		get
		{
			return x477d2d3181c623c1;
		}
		set
		{
			x477d2d3181c623c1 = value;
		}
	}

	internal int xd44988f225497f3a
	{
		get
		{
			return x35a5073ffeb125c5;
		}
		set
		{
			x35a5073ffeb125c5 = value;
		}
	}

	internal PointF[] xa3fcbdd38f2ce050
	{
		get
		{
			return xb83ec6d728d62633;
		}
		set
		{
			xb83ec6d728d62633 = value;
		}
	}

	internal float[] xfd40c4e850df5469
	{
		get
		{
			return xf3fd5bf97dd43cf6;
		}
		set
		{
			xf3fd5bf97dd43cf6 = value;
		}
	}

	internal x6a17e4a87b609da7(bool intersect, bool firstOnSegmentLine, bool secondOnSegmentLine, int count, PointF[] intersectionPoints, float[] intersectionCurveParameters)
	{
		x6e93b8ed0215d172 = intersect;
		x4b7d545d48ec0c15 = firstOnSegmentLine;
		xf4d85c8619117aaa = secondOnSegmentLine;
		xd44988f225497f3a = count;
		xa3fcbdd38f2ce050 = intersectionPoints;
		xfd40c4e850df5469 = intersectionCurveParameters;
	}

	internal static x6a17e4a87b609da7 x43e7db181a6b7a7e()
	{
		return new x6a17e4a87b609da7(intersect: false, firstOnSegmentLine: false, secondOnSegmentLine: false, 0, null, null);
	}
}

using System.Drawing;

namespace x3d94286fe72124a8;

internal class x9658c5adb216d1cb
{
	private bool xd0b4396ff1537c95;

	private int x35a5073ffeb125c5;

	private float[] x35df2f13000223e7;

	private float[] x31432518849ed970;

	private PointF[] xb83ec6d728d62633;

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

	internal float[] x8a261cc1dcc8df70
	{
		get
		{
			return x35df2f13000223e7;
		}
		set
		{
			x35df2f13000223e7 = value;
		}
	}

	internal float[] x0588143eef5e79ed
	{
		get
		{
			return x31432518849ed970;
		}
		set
		{
			x31432518849ed970 = value;
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

	internal x9658c5adb216d1cb(bool intersect, int count, float[] intersectionCurve1Parameters, float[] intersectionCurve2Parameters, PointF[] intersectionPoints)
	{
		x6e93b8ed0215d172 = intersect;
		xd44988f225497f3a = count;
		x8a261cc1dcc8df70 = intersectionCurve1Parameters;
		x0588143eef5e79ed = intersectionCurve2Parameters;
		xa3fcbdd38f2ce050 = intersectionPoints;
	}

	internal static x9658c5adb216d1cb x43e7db181a6b7a7e()
	{
		return new x9658c5adb216d1cb(intersect: false, 0, null, null, null);
	}
}

using System;
using System.Drawing.Drawing2D;
using x5794c252ba25e723;

namespace xa769c310fbec8a5a;

internal class x72234568f2993bba : xa127f6c5c99ca9d4
{
	private static readonly float[] xd077b8e3f21f0768 = new float[4] { 4f, 3f, 1f, 3f };

	private static readonly float[] xe199701996b7635b = new float[2] { 4f, 3f };

	private static readonly float[] x7a5e1068fae60db5 = new float[2] { 1f, 3f };

	private static readonly float[] xc161269891d2dfa0 = new float[6] { 8f, 3f, 1f, 3f, 1f, 3f };

	private static readonly float[] xb82735bf03f5a70a = new float[4] { 8f, 3f, 1f, 3f };

	private static readonly float[] x78a3ab781c77db31 = new float[2] { 8f, 3f };

	private x8e20f24908b63efd x93ac0245fc548571;

	public x8e20f24908b63efd x86d76ee96fa83686
	{
		get
		{
			return x93ac0245fc548571;
		}
		set
		{
			x93ac0245fc548571 = value;
		}
	}

	public override void AdjustPen(x31c19fcb724dfaf5 pen)
	{
		switch (x86d76ee96fa83686)
		{
		case x8e20f24908b63efd.xb8751dec55f64252:
			pen.xca08e8eb525b8a1a = DashStyle.Solid;
			break;
		case x8e20f24908b63efd.x455a4ef0872765fc:
			pen.xca08e8eb525b8a1a = DashStyle.Dash;
			break;
		case x8e20f24908b63efd.x6476cf042953dd24:
			pen.xca08e8eb525b8a1a = DashStyle.DashDot;
			break;
		case x8e20f24908b63efd.x343f4269e84bd2af:
			pen.xca08e8eb525b8a1a = DashStyle.DashDotDot;
			break;
		case x8e20f24908b63efd.x7df72ec7b05118a6:
			pen.xca08e8eb525b8a1a = DashStyle.Dot;
			break;
		case x8e20f24908b63efd.x35078e8db43b001f:
			pen.x358988d12e56bf69 = xe199701996b7635b;
			break;
		case x8e20f24908b63efd.x41084163454410db:
			pen.x358988d12e56bf69 = xd077b8e3f21f0768;
			break;
		case x8e20f24908b63efd.x3cb6807e93737c2d:
			pen.x358988d12e56bf69 = x7a5e1068fae60db5;
			break;
		case x8e20f24908b63efd.xb724154bfaf220a7:
			pen.x358988d12e56bf69 = x78a3ab781c77db31;
			break;
		case x8e20f24908b63efd.xf24b332dc105a24e:
			pen.x358988d12e56bf69 = xb82735bf03f5a70a;
			break;
		case x8e20f24908b63efd.xa6ae62095f92d6dc:
			pen.x358988d12e56bf69 = xc161269891d2dfa0;
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	public override xa127f6c5c99ca9d4 Clone()
	{
		x72234568f2993bba x72234568f2993bba2 = new x72234568f2993bba();
		x72234568f2993bba2.x86d76ee96fa83686 = x86d76ee96fa83686;
		return x72234568f2993bba2;
	}
}

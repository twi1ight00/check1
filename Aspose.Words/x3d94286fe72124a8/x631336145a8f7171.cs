using System;
using System.Collections;
using System.Drawing;
using x1c8faa688b1f0b0c;

namespace x3d94286fe72124a8;

internal class x631336145a8f7171 : xf51865b83a7a0b3b
{
	private bool x8a8f4f51c327f796;

	private bool x6be37f9dc69e77ec;

	private PointF x7e0ea7eb286876e3 = PointF.Empty;

	private float x68fefe387091c65e;

	private float x883d2889be606ede;

	public override void VisitPolyLineSegment(x60c040f35bb272aa segment)
	{
		if (x8a8f4f51c327f796 && x6be37f9dc69e77ec)
		{
			return;
		}
		ArrayList x4d7474e8f = segment.x4d7474e8f1849803;
		if (x4d7474e8f.Count < 2)
		{
			return;
		}
		for (int i = 1; i < x4d7474e8f.Count; i++)
		{
			PointF x10aaa7cdfa38f = (PointF)x4d7474e8f[i - 1];
			PointF xca09b6c2b5b = (PointF)x4d7474e8f[i];
			float num = xfde8a66a3e6995b3(x10aaa7cdfa38f, xca09b6c2b5b);
			x68fefe387091c65e += num;
			if (x8a8f4f51c327f796 && x68fefe387091c65e >= x883d2889be606ede)
			{
				x7e0ea7eb286876e3 = x86329abe226ef8ef(x10aaa7cdfa38f, xca09b6c2b5b, num - (x68fefe387091c65e - x883d2889be606ede));
				x6be37f9dc69e77ec = true;
				break;
			}
		}
	}

	public override void VisitBezierSegment(x519b1bd0625473ff segment)
	{
		throw new x5ba85f4e196ffeb3("Bezier paths are not yet supported.");
	}

	private float x1deebb03a3d03a50(x1cab6af0a41b70e2 x1e8706aef1ad2b94)
	{
		x74f5a1ef3906e23c();
		x1e8706aef1ad2b94.Accept(this);
		float result = x68fefe387091c65e;
		x74f5a1ef3906e23c();
		return result;
	}

	internal PointF x1ea772e6d628a391(x1cab6af0a41b70e2 xe125219852864557, float x27b336b929c0851c)
	{
		float num = x1deebb03a3d03a50(xe125219852864557);
		x883d2889be606ede = num * x27b336b929c0851c;
		xd0fb442b2038c24b();
		xe125219852864557.Accept(this);
		return x7e0ea7eb286876e3;
	}

	internal static PointF x86329abe226ef8ef(PointF x10aaa7cdfa38f254, PointF xca09b6c2b5b18485, float x374ea4fe62468d0f)
	{
		float num = xca09b6c2b5b18485.Y - x10aaa7cdfa38f254.Y;
		float num2 = xca09b6c2b5b18485.X - x10aaa7cdfa38f254.X;
		float num3 = num / num2;
		if (num2 == 0f)
		{
			return new PointF(x10aaa7cdfa38f254.X, x10aaa7cdfa38f254.Y + x374ea4fe62468d0f * (float)Math.Sign(num));
		}
		float num4 = x374ea4fe62468d0f / (float)Math.Sqrt(1f + num3 * num3);
		if (x10aaa7cdfa38f254.X > xca09b6c2b5b18485.X)
		{
			num4 = 0f - num4;
		}
		float num5 = num3 * num4;
		return new PointF(x10aaa7cdfa38f254.X + num4, x10aaa7cdfa38f254.Y + num5);
	}

	internal static float xfde8a66a3e6995b3(PointF x10aaa7cdfa38f254, PointF xca09b6c2b5b18485)
	{
		float num = xca09b6c2b5b18485.X - x10aaa7cdfa38f254.X;
		float num2 = xca09b6c2b5b18485.Y - x10aaa7cdfa38f254.Y;
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	private void x74f5a1ef3906e23c()
	{
		x68fefe387091c65e = 0f;
		x8a8f4f51c327f796 = false;
		x6be37f9dc69e77ec = false;
	}

	private void xd0fb442b2038c24b()
	{
		x68fefe387091c65e = 0f;
		x8a8f4f51c327f796 = true;
		x6be37f9dc69e77ec = false;
	}
}

using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Words.Drawing;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x3d94286fe72124a8;

internal class xb1ba701d4aec15c8 : xf51865b83a7a0b3b
{
	private const float xe1660eece565de47 = 3f;

	private const float xe05c08d2a70fc07a = 3f;

	private const float x48eb019849058dea = 3f;

	private const float xc8cf3fd87d67a1f4 = 3f;

	private const float x2d92380df0bc31a3 = 1.8000001f;

	private const float xe7bc211a2753d8a8 = 3.5f;

	private const float xea45552656811018 = 3f;

	private const float x37421ab4e88460fb = 1.5f;

	private const float x32419f161d764dde = 1.5f;

	private static readonly float[] x14e439918bf8455b = new float[6] { -1.5f, 3f, 0f, 0f, 1.5f, 3f };

	private static readonly float[] xc1c8fe7f232f95b4 = new float[8] { -1.5f, 3f, 0f, 0f, 1.5f, 3f, 0f, 1.8000001f };

	private static readonly float[] x211f7638bbf4ec2e = new float[6] { -1.75f, 3f, 0f, 0f, 1.75f, 3f };

	private static readonly float[] x5cb5260cc08cb507 = new float[8] { 0f, -1.5f, 1.5f, 0f, 0f, 1.5f, -1.5f, 0f };

	private static readonly float[] x0dbdb61ecdaa019c = new float[3] { 0.65f, 1f, 1.68f };

	private static readonly SizeF[][] xc699d61a0f30633d = new SizeF[3][]
	{
		new SizeF[3]
		{
			new SizeF(0.7f, 0.65f),
			new SizeF(0.7f, 1f),
			new SizeF(0.7f, 1.5f)
		},
		new SizeF[3]
		{
			new SizeF(1f, 0.65f),
			new SizeF(1f, 1f),
			new SizeF(1f, 1.5f)
		},
		new SizeF[3]
		{
			new SizeF(1.42f, 0.65f),
			new SizeF(1.42f, 1f),
			new SizeF(1.42f, 1.5f)
		}
	};

	private EndCap x34a69ca70dc2c2e0;

	private ArrowType x573a2ed865de020d;

	private ArrowWidth x1731913290f2e9e1;

	private ArrowLength x7c269b40e7ff7fa1;

	private ArrowType xfa203b1bf57071a5;

	private ArrowWidth x70e226e9eb56a659;

	private ArrowLength x8e08af362196d604;

	private float x5acc847a28ae4493;

	private bool xfd6f986a330339d6;

	private xab391c46ff9a0a38 x33a77d999deff2f7;

	private xab391c46ff9a0a38 x425727fe63df5c4d;

	internal xab391c46ff9a0a38[] xcfdb66715c8b7bf1(xab391c46ff9a0a38 xe125219852864557, Stroke xb1ed72b81a89125c)
	{
		x34a69ca70dc2c2e0 = xb1ed72b81a89125c.EndCap;
		x573a2ed865de020d = xb1ed72b81a89125c.EndArrowType;
		x1731913290f2e9e1 = xb1ed72b81a89125c.EndArrowWidth;
		x7c269b40e7ff7fa1 = xb1ed72b81a89125c.EndArrowLength;
		xfa203b1bf57071a5 = xb1ed72b81a89125c.StartArrowType;
		x70e226e9eb56a659 = xb1ed72b81a89125c.StartArrowWidth;
		x8e08af362196d604 = xb1ed72b81a89125c.StartArrowLength;
		x5acc847a28ae4493 = (float)xb1ed72b81a89125c.Weight;
		if (x34a69ca70dc2c2e0 == EndCap.Flat && xfa203b1bf57071a5 == ArrowType.None && x573a2ed865de020d == ArrowType.None)
		{
			return null;
		}
		x33a77d999deff2f7 = new xab391c46ff9a0a38();
		x33a77d999deff2f7.x60465f602599d327 = xe125219852864557.x9e5d5f9128c69a8f.x60465f602599d327;
		x425727fe63df5c4d = new xab391c46ff9a0a38(xe125219852864557.x9e5d5f9128c69a8f.xfe8f67360e300e88());
		x425727fe63df5c4d.x9e5d5f9128c69a8f.xdc1bf80853046136 = ((x5acc847a28ae4493 <= 0.75f) ? 0.75f : x5acc847a28ae4493);
		x425727fe63df5c4d.x9e5d5f9128c69a8f.xca08e8eb525b8a1a = System.Drawing.Drawing2D.DashStyle.Solid;
		x425727fe63df5c4d.x9e5d5f9128c69a8f.x03a8df074279275f = LineJoin.Miter;
		x425727fe63df5c4d.x9e5d5f9128c69a8f.xec7c14446b693774 = LineCap.Round;
		x425727fe63df5c4d.x9e5d5f9128c69a8f.x1e0dcb2cdd562cb2 = LineCap.Round;
		for (int i = 0; i < xe125219852864557.xd44988f225497f3a; i++)
		{
			x1cab6af0a41b70e2 x1cab6af0a41b70e = (x1cab6af0a41b70e2)((xbaec545ec01f92ca)xe125219852864557).get_xe6d4b1b411ed94b5(i);
			if (!x1cab6af0a41b70e.x5e6c52cb3256cc85 && x1cab6af0a41b70e.xd44988f225497f3a != 0)
			{
				xfd6f986a330339d6 = true;
				((xbaec545ec01f92ca)x1cab6af0a41b70e).get_xe6d4b1b411ed94b5(0).Accept(this);
				xfd6f986a330339d6 = false;
				((xbaec545ec01f92ca)x1cab6af0a41b70e).get_xe6d4b1b411ed94b5(x1cab6af0a41b70e.xd44988f225497f3a - 1).Accept(this);
			}
		}
		return new xab391c46ff9a0a38[2] { x33a77d999deff2f7, x425727fe63df5c4d };
	}

	public override void VisitPolyLineSegment(x60c040f35bb272aa segment)
	{
		ArrowType arrowType = x30569a7ed7d71874();
		ArrowWidth arrowWidth = xd7c29099003a3383();
		ArrowLength arrowLength = x9d26835f817a36c8();
		float num;
		switch (arrowType)
		{
		default:
			return;
		case ArrowType.Arrow:
		case ArrowType.Stealth:
			num = 1.5f * x5acc847a28ae4493 * x0dbdb61ecdaa019c[(int)arrowLength];
			break;
		case ArrowType.Open:
		{
			SizeF sizeF = xc699d61a0f30633d[(int)arrowWidth][(int)arrowLength];
			num = x5acc847a28ae4493 * sizeF.Height;
			num = ((arrowLength != ArrowLength.Long || arrowWidth != 0) ? (num * 1.3f) : (num * 2.5f));
			break;
		}
		case ArrowType.Diamond:
		case ArrowType.Oval:
			num = 0f;
			break;
		}
		int num2;
		int index;
		ArrowWidth x9b0739496f8b;
		ArrowLength x961016a387451f;
		if (xfd6f986a330339d6)
		{
			num2 = 0;
			index = 1;
			x9b0739496f8b = x70e226e9eb56a659;
			x961016a387451f = x8e08af362196d604;
		}
		else
		{
			num2 = segment.x4d7474e8f1849803.Count - 1;
			index = num2 - 1;
			x9b0739496f8b = x1731913290f2e9e1;
			x961016a387451f = x7c269b40e7ff7fa1;
		}
		PointF x9c3c185e7046dc = (PointF)segment.x4d7474e8f1849803[num2];
		PointF x1ec81c4ce7413e = (PointF)segment.x4d7474e8f1849803[index];
		if (num > 0f)
		{
			segment.x4d7474e8f1849803[num2] = xca744a03231a5534(x9c3c185e7046dc, x1ec81c4ce7413e, num);
		}
		PointF pointF = new PointF(x9c3c185e7046dc.X - x1ec81c4ce7413e.X, x9c3c185e7046dc.Y - x1ec81c4ce7413e.Y);
		float num3 = 0f;
		if (pointF.X != 0f || pointF.Y != 0f)
		{
			float num4 = 0f - pointF.Y;
			float num5 = num4 / (float)Math.Sqrt(pointF.X * pointF.X + pointF.Y * pointF.Y);
			num3 = (float)x15e971129fd80714.xc9211137ad7bfa2a(Math.Acos(num5));
			if (pointF.X < 0f)
			{
				num3 = 360f - num3;
			}
		}
		x4d6d6f87a3c476d3(x9c3c185e7046dc, num3, x9b0739496f8b, x961016a387451f);
	}

	public override void VisitBezierSegment(x519b1bd0625473ff segment)
	{
		float num;
		switch (x30569a7ed7d71874())
		{
		default:
			return;
		case ArrowType.Arrow:
		case ArrowType.Stealth:
		case ArrowType.Open:
			num = x5acc847a28ae4493;
			break;
		case ArrowType.Diamond:
		case ArrowType.Oval:
			num = 0f;
			break;
		}
		PointF x9c3c185e7046dc;
		PointF x1ec81c4ce7413e;
		ArrowWidth x9b0739496f8b;
		ArrowLength x961016a387451f;
		if (xfd6f986a330339d6)
		{
			x9c3c185e7046dc = segment.x56b911bdb6515aed.xaf4e0fbe61814cf5;
			x1ec81c4ce7413e = segment.x56b911bdb6515aed.xc7cf0e43653f9c41;
			if (num > 0f)
			{
				x9fe47a4de491f4aa x56b911bdb6515aed = default(x9fe47a4de491f4aa);
				x56b911bdb6515aed.xaf4e0fbe61814cf5 = xca744a03231a5534(x9c3c185e7046dc, x1ec81c4ce7413e, num);
				x56b911bdb6515aed.xc7cf0e43653f9c41 = segment.x56b911bdb6515aed.xc7cf0e43653f9c41;
				x56b911bdb6515aed.xf52fe1c3cad11afd = segment.x56b911bdb6515aed.xf52fe1c3cad11afd;
				x56b911bdb6515aed.x2271dea312f4a835 = segment.x56b911bdb6515aed.x2271dea312f4a835;
				segment.x56b911bdb6515aed = x56b911bdb6515aed;
			}
			x9b0739496f8b = x70e226e9eb56a659;
			x961016a387451f = x8e08af362196d604;
		}
		else
		{
			x9c3c185e7046dc = segment.x56b911bdb6515aed.x2271dea312f4a835;
			x1ec81c4ce7413e = segment.x56b911bdb6515aed.xf52fe1c3cad11afd;
			if (num > 0f)
			{
				x9fe47a4de491f4aa x56b911bdb6515aed2 = default(x9fe47a4de491f4aa);
				x56b911bdb6515aed2.x2271dea312f4a835 = xca744a03231a5534(x9c3c185e7046dc, x1ec81c4ce7413e, num);
				x56b911bdb6515aed2.xc7cf0e43653f9c41 = segment.x56b911bdb6515aed.xc7cf0e43653f9c41;
				x56b911bdb6515aed2.xf52fe1c3cad11afd = segment.x56b911bdb6515aed.xf52fe1c3cad11afd;
				x56b911bdb6515aed2.xaf4e0fbe61814cf5 = segment.x56b911bdb6515aed.xaf4e0fbe61814cf5;
				segment.x56b911bdb6515aed = x56b911bdb6515aed2;
			}
			x9b0739496f8b = x1731913290f2e9e1;
			x961016a387451f = x7c269b40e7ff7fa1;
		}
		PointF pointF = new PointF(x9c3c185e7046dc.X - x1ec81c4ce7413e.X, x9c3c185e7046dc.Y - x1ec81c4ce7413e.Y);
		float num2 = 0f - pointF.Y;
		float num3 = num2 / (float)Math.Sqrt(pointF.X * pointF.X + pointF.Y * pointF.Y);
		float num4 = (float)x15e971129fd80714.xc9211137ad7bfa2a(Math.Acos(num3));
		if (pointF.X < 0f)
		{
			num4 = 360f - num4;
		}
		x4d6d6f87a3c476d3(x9c3c185e7046dc, num4, x9b0739496f8b, x961016a387451f);
	}

	private static PointF xca744a03231a5534(PointF x9c3c185e7046dc72, PointF x1ec81c4ce7413e94, float x9d6d39edb48274cf)
	{
		double num = x1ec81c4ce7413e94.X - x9c3c185e7046dc72.X;
		double num2 = x1ec81c4ce7413e94.Y - x9c3c185e7046dc72.Y;
		double num3 = Math.Sqrt(x113cf57ce1569d99(num) + x113cf57ce1569d99(num2));
		double num4 = 0.0;
		if (num3 != 0.0)
		{
			num4 = (double)x9d6d39edb48274cf / num3;
		}
		return new PointF((float)((double)x9c3c185e7046dc72.X + num * num4), (float)((double)x9c3c185e7046dc72.Y + num2 * num4));
	}

	private void x4d6d6f87a3c476d3(PointF x9c3c185e7046dc72, float xcb83cdf6822fc99d, ArrowWidth x9b0739496f8b5475, ArrowLength x961016a387451f05)
	{
		ArrowType arrowType = x30569a7ed7d71874();
		x1cab6af0a41b70e2 x1cab6af0a41b70e = new x1cab6af0a41b70e2();
		ArrayList arrayList = new ArrayList();
		float num = (((double)x5acc847a28ae4493 <= 2.0) ? 2f : x5acc847a28ae4493);
		x1cab6af0a41b70e.x5e6c52cb3256cc85 = true;
		float num2 = x0dbdb61ecdaa019c[(int)x9b0739496f8b5475];
		float num3 = x0dbdb61ecdaa019c[(int)x961016a387451f05];
		switch (arrowType)
		{
		case ArrowType.Arrow:
			arrayList.Add(new x60c040f35bb272aa(x14e439918bf8455b));
			break;
		case ArrowType.Stealth:
			arrayList.Add(new x60c040f35bb272aa(xc1c8fe7f232f95b4));
			break;
		case ArrowType.Open:
		{
			x60c040f35bb272aa value = new x60c040f35bb272aa(x211f7638bbf4ec2e);
			arrayList.Add(value);
			x1cab6af0a41b70e.x5e6c52cb3256cc85 = false;
			num = x425727fe63df5c4d.x9e5d5f9128c69a8f.xdc1bf80853046136;
			SizeF sizeF = xc699d61a0f30633d[(int)x9b0739496f8b5475][(int)x961016a387451f05];
			num2 = sizeF.Width;
			num3 = sizeF.Height;
			break;
		}
		case ArrowType.Diamond:
			arrayList.Add(new x60c040f35bb272aa(x5cb5260cc08cb507));
			break;
		case ArrowType.Oval:
		{
			x1fb5d45c2d0b868a x1fb5d45c2d0b868a = new x1fb5d45c2d0b868a();
			x1fb5d45c2d0b868a.xab07b26048f600ba = new PointF(-1.5f, -1.5f);
			x1fb5d45c2d0b868a.x437e3b626c0fdd43 = new SizeF(3f, 3f);
			x1fb5d45c2d0b868a.xba40a5b113d122a1 = 0.0;
			x1fb5d45c2d0b868a.xae49680937687932 = 360.0;
			x9fe47a4de491f4aa[] array = x1fb5d45c2d0b868a.x1a10ab118b131ef0();
			for (int i = 0; i < array.Length; i++)
			{
				x519b1bd0625473ff x519b1bd0625473ff = new x519b1bd0625473ff();
				x519b1bd0625473ff.x56b911bdb6515aed = array[i];
				arrayList.Add(x519b1bd0625473ff);
			}
			break;
		}
		}
		if (arrayList.Count != 0)
		{
			num2 *= num;
			num3 *= num;
			x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
			x54366fa5f75a02f.x5152a5707921c783(num2, num3, MatrixOrder.Prepend);
			x54366fa5f75a02f.xce92de628aa023cf(0f, xf8783ae7924a4df7(arrowType, x9b0739496f8b5475, x961016a387451f05), MatrixOrder.Append);
			x54366fa5f75a02f.xa77087bb05d9ef76(xcb83cdf6822fc99d, MatrixOrder.Append);
			x54366fa5f75a02f.xce92de628aa023cf(x9c3c185e7046dc72.X, x9c3c185e7046dc72.Y, MatrixOrder.Append);
			for (int j = 0; j < arrayList.Count; j++)
			{
				x5e0582a42c97011a x5e0582a42c97011a = (x5e0582a42c97011a)arrayList[j];
				x5e0582a42c97011a.xaccac17571a8d9fa(x54366fa5f75a02f);
				x1cab6af0a41b70e.xd6b6ed77479ef68c((x4fdf549af9de6b97)x5e0582a42c97011a);
			}
			if (x1cab6af0a41b70e.x5e6c52cb3256cc85)
			{
				x33a77d999deff2f7.xd6b6ed77479ef68c(x1cab6af0a41b70e);
			}
			else
			{
				x425727fe63df5c4d.xd6b6ed77479ef68c(x1cab6af0a41b70e);
			}
		}
	}

	private float xf8783ae7924a4df7(ArrowType x56e30755bce7e00e, ArrowWidth x1582c29a67732b01, ArrowLength x6963bf5d820c9349)
	{
		if (x56e30755bce7e00e == ArrowType.Open)
		{
			if (x1582c29a67732b01 == ArrowWidth.Narrow && x6963bf5d820c9349 == ArrowLength.Long)
			{
				return x425727fe63df5c4d.x9e5d5f9128c69a8f.xdc1bf80853046136 * 2.5f;
			}
			return x425727fe63df5c4d.x9e5d5f9128c69a8f.xdc1bf80853046136;
		}
		return 0f;
	}

	private ArrowType x30569a7ed7d71874()
	{
		if (!xfd6f986a330339d6)
		{
			return x573a2ed865de020d;
		}
		return xfa203b1bf57071a5;
	}

	private ArrowLength x9d26835f817a36c8()
	{
		if (!xfd6f986a330339d6)
		{
			return x7c269b40e7ff7fa1;
		}
		return x8e08af362196d604;
	}

	private ArrowWidth xd7c29099003a3383()
	{
		if (!xfd6f986a330339d6)
		{
			return x1731913290f2e9e1;
		}
		return x70e226e9eb56a659;
	}

	private static double x113cf57ce1569d99(double x0078185e1040c523)
	{
		return x0078185e1040c523 * x0078185e1040c523;
	}
}

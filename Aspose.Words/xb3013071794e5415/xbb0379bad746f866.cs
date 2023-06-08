using System;
using System.Drawing;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xad5c68c1ad3b0224;
using xcc8a79815d76af85;

namespace xb3013071794e5415;

internal class xbb0379bad746f866 : x66e735b434e6b412
{
	private x45a2840d0d8821ab xad9273213efc3176;

	private x9b87766ad1dbe8d6 x21ad465cfac3f62e => (x9b87766ad1dbe8d6)xad9273213efc3176.xc869533ad93d98d3[0];

	private bool x4b6d3e12690a7c2c => xad9273213efc3176.x13c22d4630b556cf == x8f04e4e6e23bd1f5.xa6f6d1f412552b3c;

	public xbb0379bad746f866(x958ddf7e6db1ce94 chart)
		: base(chart)
	{
		xad9273213efc3176 = (x45a2840d0d8821ab)chart;
	}

	internal override void xe406325e56f74b46(x43c3197706cb18d9 x7458794d854f9b68, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		x5b215895ce9a4c9a x5b215895ce9a4c9a2 = (x5b215895ce9a4c9a)x7458794d854f9b68;
		PointF x9e8f25190daa42b = x5b215895ce9a4c9a2.xeed202914e7c06d3();
		float xd6ed827fa7f = x89ecd5d22a6e0cb1(x5b215895ce9a4c9a2);
		RectangleF x26545669838eb36e = x807b0fc50efe1edc(x9e8f25190daa42b, xd6ed827fa7f);
		RectangleF x26545669838eb36e2 = x9dee679d0dea29d4(x9e8f25190daa42b, xd6ed827fa7f);
		float[] array = x3f1711fc4bb819ec(x21ad465cfac3f62e);
		float num = x54beaf27ca67cc75(array);
		float num2 = xad9273213efc3176.x297e14bc7c061d46 - 90;
		for (int i = 0; i < array.Length; i++)
		{
			float num3 = array[i] * num;
			x0c3d704ad3ea61a6 x0c3d704ad3ea61a = x21ad465cfac3f62e.x320382c5f1993a78.get_xe6d4b1b411ed94b5(i);
			x54366fa5f75a02f7 x54366fa5f75a02f = xa840a269667c3505(num2, num3, xd6ed827fa7f, x0c3d704ad3ea61a.xebda71a9872c4199, x5b215895ce9a4c9a2);
			RectangleF x844601209fcf3e = x54366fa5f75a02f.xaccac17571a8d9fa(x26545669838eb36e);
			RectangleF xb36e3e4e5a9114e = x54366fa5f75a02f.xaccac17571a8d9fa(x26545669838eb36e2);
			xab391c46ff9a0a38 xab391c46ff9a0a = x3f6fc26fe00b2518(x844601209fcf3e, xb36e3e4e5a9114e, num2, num3);
			x318f74746d616ef0.x5bd690fbaae89142(xab391c46ff9a0a, x0c3d704ad3ea61a.xff13b489d81606b6, x0f7b23d1c393aed9.x5e969e12ada2aab2.xa32838f54072b660, i);
			x0f7b23d1c393aed9.xc9443bca5b0a56d8.xd6b6ed77479ef68c(xab391c46ff9a0a);
			num2 += num3;
		}
	}

	protected override void RenderLegendForDataPoints(xc48e9faacc88a3d5 legendLayout, xcd7d6e7318ee6574 context)
	{
		string[] array = x66e735b434e6b412.x785802445639dd33(xad9273213efc3176, x21ad465cfac3f62e);
		for (int i = 0; i < array.Length; i++)
		{
			xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.x7c89cd07f845b8e1(legendLayout.xc49ca4c0d3cc766e);
			x318f74746d616ef0.x5bd690fbaae89142(xab391c46ff9a0a, x21ad465cfac3f62e.x320382c5f1993a78.get_xe6d4b1b411ed94b5(i).xff13b489d81606b6, context.x5e969e12ada2aab2.xa32838f54072b660, i);
			legendLayout.xd7d75c376e5ae843(xab391c46ff9a0a, array[i]);
		}
	}

	private RectangleF x807b0fc50efe1edc(PointF x9e8f25190daa42b1, float xd6ed827fa7f40115)
	{
		return new RectangleF(x9e8f25190daa42b1.X - xd6ed827fa7f40115, x9e8f25190daa42b1.Y - xd6ed827fa7f40115, xd6ed827fa7f40115 * 2f, xd6ed827fa7f40115 * 2f);
	}

	private RectangleF x9dee679d0dea29d4(PointF x9e8f25190daa42b1, float xd6ed827fa7f40115)
	{
		RectangleF result = RectangleF.Empty;
		if (x4b6d3e12690a7c2c)
		{
			x66dc804c153d0fac x66dc804c153d0fac = (x66dc804c153d0fac)xad9273213efc3176;
			float num = xd6ed827fa7f40115 * (float)x66dc804c153d0fac.xd66c446deaa4e705 / 100f;
			result = new RectangleF(x9e8f25190daa42b1.X - num, x9e8f25190daa42b1.Y - num, num * 2f, num * 2f);
		}
		return result;
	}

	private float x89ecd5d22a6e0cb1(x5b215895ce9a4c9a xb9c9374f2307475b)
	{
		float num = xb9c9374f2307475b.xac703ffc184eb346;
		if (x21ad465cfac3f62e.x4ccdf3e6468ad446.xebda71a9872c4199 >= 0)
		{
			num /= 1f + (float)x21ad465cfac3f62e.x4ccdf3e6468ad446.xebda71a9872c4199 / 100f;
		}
		return num;
	}

	private static x54366fa5f75a02f7 xa840a269667c3505(float x32bf744f8e9a8c29, float x4b7a727a9fc82698, float xd6ed827fa7f40115, int x47e028b66078ff5a, x5b215895ce9a4c9a xb9c9374f2307475b)
	{
		if (x47e028b66078ff5a <= 0)
		{
			return new x54366fa5f75a02f7();
		}
		float num = x32bf744f8e9a8c29 + 90f;
		double num2 = x15e971129fd80714.xcdc7b29a812dd7df(num + x4b7a727a9fc82698 / 2f);
		float num3 = xd6ed827fa7f40115 * ((float)x47e028b66078ff5a / 100f);
		float num4 = num3 * (float)Math.Sin(num2);
		float num5 = (0f - num3) * (float)Math.Cos(num2);
		SizeF sizeF = xa6489cb8ac745ab5(num, x4b7a727a9fc82698, xd6ed827fa7f40115);
		RectangleF rectangleF = xb9c9374f2307475b.xb7d97a6d836eba66();
		if (sizeF.Width + Math.Abs(num4) > rectangleF.Width / 2f)
		{
			num4 = (rectangleF.Width / 2f - sizeF.Width) * (float)((!(num4 < 0f)) ? 1 : (-1));
			num5 = (0f - num4) / (float)Math.Tan(num2);
		}
		if (sizeF.Height + Math.Abs(num5) > rectangleF.Height / 2f)
		{
			num5 = (rectangleF.Height / 2f - sizeF.Height) * (float)((!(num5 < 0f)) ? 1 : (-1));
			num4 = (0f - num5) * (float)Math.Tan(num2);
		}
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		x54366fa5f75a02f.xce92de628aa023cf(num4, num5);
		return x54366fa5f75a02f;
	}

	private static SizeF xa6489cb8ac745ab5(float x32bf744f8e9a8c29, float x4b7a727a9fc82698, float xd6ed827fa7f40115)
	{
		float num = x32bf744f8e9a8c29 + x4b7a727a9fc82698;
		float num2 = x32bf744f8e9a8c29 + x4b7a727a9fc82698 / 2f;
		if (num2 >= 0f && num2 <= 90f)
		{
			x32bf744f8e9a8c29 = ((x32bf744f8e9a8c29 < 0f) ? 0f : x32bf744f8e9a8c29);
			num = ((num > 90f) ? 90f : num);
		}
		else if (num2 > 90f && num2 <= 180f)
		{
			x32bf744f8e9a8c29 = ((x32bf744f8e9a8c29 < 90f) ? 90f : x32bf744f8e9a8c29);
			num = ((num > 180f) ? 180f : num);
		}
		else if (num2 > 180f && num2 <= 270f)
		{
			x32bf744f8e9a8c29 = ((x32bf744f8e9a8c29 < 180f) ? 180f : x32bf744f8e9a8c29);
			num = ((num > 270f) ? 270f : num);
		}
		else if (num2 > 270f && num2 <= 360f)
		{
			x32bf744f8e9a8c29 = ((x32bf744f8e9a8c29 < 270f) ? 270f : x32bf744f8e9a8c29);
			num = ((num > 360f) ? 360f : num);
		}
		double num3 = x15e971129fd80714.xcdc7b29a812dd7df(x32bf744f8e9a8c29);
		double num4 = x15e971129fd80714.xcdc7b29a812dd7df(num);
		float width = x25edc0e50a9f287b(xd6ed827fa7f40115 * (float)Math.Sin(num3), xd6ed827fa7f40115 * (float)Math.Sin(num4));
		float height = x25edc0e50a9f287b(xd6ed827fa7f40115 * (float)Math.Cos(num3), xd6ed827fa7f40115 * (float)Math.Cos(num4));
		return new SizeF(width, height);
	}

	private static float x25edc0e50a9f287b(float xb70c6f9ce4b00539, float x20d2e82fd739e3f8)
	{
		return Math.Max(Math.Abs(xb70c6f9ce4b00539), Math.Abs(x20d2e82fd739e3f8));
	}

	private static xab391c46ff9a0a38 x3f6fc26fe00b2518(RectangleF x844601209fcf3e02, RectangleF xb36e3e4e5a9114e3, float x32bf744f8e9a8c29, float x4b7a727a9fc82698)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38();
		x1cab6af0a41b70e2 x1cab6af0a41b70e = new x1cab6af0a41b70e2();
		x1fb5d45c2d0b868a x1fb5d45c2d0b868a = new x1fb5d45c2d0b868a(x844601209fcf3e02, x32bf744f8e9a8c29, x4b7a727a9fc82698);
		x1cab6af0a41b70e.xb6e955ab98a0878c(x1fb5d45c2d0b868a);
		if (xb36e3e4e5a9114e3.IsEmpty)
		{
			x1cab6af0a41b70e.x8992595b6d42d9bd(new PointF[3]
			{
				x1fb5d45c2d0b868a.x0f74da0eed3dd981(),
				x1fb5d45c2d0b868a.x58d2ccae3c5cfd08,
				x1fb5d45c2d0b868a.x7739898ad73de905()
			});
		}
		else
		{
			x1fb5d45c2d0b868a x1fb5d45c2d0b868a2 = new x1fb5d45c2d0b868a(xb36e3e4e5a9114e3, x32bf744f8e9a8c29 + x4b7a727a9fc82698, 0f - x4b7a727a9fc82698);
			x1cab6af0a41b70e.x49babf6761229eb5(x1fb5d45c2d0b868a.x0f74da0eed3dd981(), x1fb5d45c2d0b868a2.x7739898ad73de905());
			x1cab6af0a41b70e.xb6e955ab98a0878c(x1fb5d45c2d0b868a2);
			x1cab6af0a41b70e.x49babf6761229eb5(x1fb5d45c2d0b868a2.x0f74da0eed3dd981(), x1fb5d45c2d0b868a.x7739898ad73de905());
		}
		x1cab6af0a41b70e.x5e6c52cb3256cc85 = true;
		xab391c46ff9a0a.xd6b6ed77479ef68c(x1cab6af0a41b70e);
		return xab391c46ff9a0a;
	}

	private static float[] x3f1711fc4bb819ec(x9b87766ad1dbe8d6 x7acb8518c8ed6133)
	{
		float[] array = new float[x7acb8518c8ed6133.x2205bab75ecf5743];
		for (int i = 0; i < x7acb8518c8ed6133.x2205bab75ecf5743; i++)
		{
			array[i] = (float)((x8feaf55aff422186)x7acb8518c8ed6133.x141ab7d3c1198e04.x2206903f9421fd4b(i)).xd2f68ee6f47e9dfb;
		}
		return array;
	}

	private static float x54beaf27ca67cc75(float[] x0788cd5a9865fc16)
	{
		float num = 0f;
		for (int i = 0; i < x0788cd5a9865fc16.Length; i++)
		{
			num += x0788cd5a9865fc16[i];
		}
		return 360f / num;
	}
}

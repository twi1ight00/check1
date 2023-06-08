using System.Drawing;
using x1c8faa688b1f0b0c;
using x32a884d842a34446;
using xad5c68c1ad3b0224;
using xcc8a79815d76af85;

namespace xb3013071794e5415;

internal class xfe5444ccd1cc86b5 : x66e735b434e6b412
{
	private xabc88d45b902a4a1 x42191bb9670ca2da;

	private float x57e1e2b6dbd00624;

	private x4609f02542532aa8 x24ff467b392c1a38 => x42191bb9670ca2da.x24ff467b392c1a38;

	private bool xc1fcd83e11f98132 => x42191bb9670ca2da.x47443c66c2e1bad9.x5e7a899338a3ee20.x2c5926113e101674 == x2c5926113e101674.xb89ee8a7212e25c8;

	public xfe5444ccd1cc86b5(x958ddf7e6db1ce94 chart)
		: base(chart)
	{
		x42191bb9670ca2da = (xabc88d45b902a4a1)chart;
	}

	internal override void xe406325e56f74b46(x43c3197706cb18d9 x7458794d854f9b68, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		switch (x42191bb9670ca2da.x1c0d56aa74903bbc)
		{
		case x1c0d56aa74903bbc.x7b3f79b8ae65a772:
		case x1c0d56aa74903bbc.x4f7bed84dc733f96:
			xe6f82eab96b08bdb((x7f6e105e40e31dae)x7458794d854f9b68, x0f7b23d1c393aed9);
			break;
		default:
			xff6d3c837b0f54f8((x7f6e105e40e31dae)x7458794d854f9b68, x0f7b23d1c393aed9);
			break;
		}
	}

	private void xff6d3c837b0f54f8(x7f6e105e40e31dae x7458794d854f9b68, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		x57e1e2b6dbd00624 = x7458794d854f9b68.x156bf83d1a77efc1(x42191bb9670ca2da.xc869533ad93d98d3.Count, x42191bb9670ca2da.x831803cdfcd433fb);
		PointF pointF = x7458794d854f9b68.xeed202914e7c06d3();
		for (int i = 0; i < x42191bb9670ca2da.xc869533ad93d98d3.Count; i++)
		{
			x9b87766ad1dbe8d6 x9b87766ad1dbe8d = (x9b87766ad1dbe8d6)x42191bb9670ca2da.xc869533ad93d98d3[i];
			for (int j = 0; j < x9b87766ad1dbe8d.x2205bab75ecf5743; j++)
			{
				x86270791cf6a92b9 x86270791cf6a92b = x9b87766ad1dbe8d.x3440cb7904436598.x2206903f9421fd4b(j);
				x86270791cf6a92b9 x86270791cf6a92b2 = x9b87766ad1dbe8d.x141ab7d3c1198e04.x2206903f9421fd4b(j);
				PointF xcb09bd0cee4909a = ((x86270791cf6a92b != null && x86270791cf6a92b2 != null) ? x7458794d854f9b68.x2206903f9421fd4b(x86270791cf6a92b.FloatValue, x86270791cf6a92b2.FloatValue) : pointF);
				xe1c141179272461a(x42191bb9670ca2da.xc869533ad93d98d3.Count, i, j, xcb09bd0cee4909a, pointF, x9b87766ad1dbe8d, x0f7b23d1c393aed9);
			}
		}
	}

	private void xe6f82eab96b08bdb(x7f6e105e40e31dae x7458794d854f9b68, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		x57e1e2b6dbd00624 = x7458794d854f9b68.x156bf83d1a77efc1(1, x42191bb9670ca2da.x831803cdfcd433fb);
		float[] array = x318f74746d616ef0.xfdf7ff990b986a85(x42191bb9670ca2da);
		float[] array2 = new float[x42191bb9670ca2da.x28627c25cb262062];
		PointF[] array3 = xfb62dd4bcdac7729(x42191bb9670ca2da, x7458794d854f9b68);
		foreach (x9b87766ad1dbe8d6 item in x42191bb9670ca2da.xc869533ad93d98d3)
		{
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] += item.x141ab7d3c1198e04.x2206903f9421fd4b(i).FloatValue;
				float floatValue = item.x3440cb7904436598.x2206903f9421fd4b(i).FloatValue;
				float xfb4c1c76fc5d2a6f = ((x42191bb9670ca2da.x1c0d56aa74903bbc == x1c0d56aa74903bbc.x7b3f79b8ae65a772) ? (array2[i] / array[i]) : array2[i]);
				PointF pointF = x7458794d854f9b68.x2206903f9421fd4b(floatValue, xfb4c1c76fc5d2a6f);
				xe1c141179272461a(1, 0, i, pointF, array3[i], item, x0f7b23d1c393aed9);
				array3[i] = pointF;
			}
		}
	}

	private static PointF[] xfb62dd4bcdac7729(xabc88d45b902a4a1 xc1250dcd78d70635, x7f6e105e40e31dae x7458794d854f9b68)
	{
		PointF[] array = new PointF[xc1250dcd78d70635.x28627c25cb262062];
		PointF pointF = x7458794d854f9b68.x2206903f9421fd4b(xc1250dcd78d70635.x47443c66c2e1bad9.x32c37895c4f182b8, xc1250dcd78d70635.xd14c2707620ef55a.x32c37895c4f182b8);
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = pointF;
		}
		return array;
	}

	private void xe1c141179272461a(int x349f5e3405601040, int x8579a518b84b8005, int x05bc5c783f15ae12, PointF xcb09bd0cee4909a3, PointF xa2da454aa40879d2, x9b87766ad1dbe8d6 x7acb8518c8ed6133, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		RectangleF x26545669838eb36e = x0c628fca3d5e6671(x349f5e3405601040, x8579a518b84b8005, xcb09bd0cee4909a3, xa2da454aa40879d2);
		xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.x7c89cd07f845b8e1(x26545669838eb36e);
		x318f74746d616ef0.x5bd690fbaae89142(xab391c46ff9a0a, x7acb8518c8ed6133.x320382c5f1993a78.get_xe6d4b1b411ed94b5(x05bc5c783f15ae12).xff13b489d81606b6, x0f7b23d1c393aed9.x5e969e12ada2aab2.xa32838f54072b660, x7acb8518c8ed6133.xd1bdf42207dd3638);
		x0f7b23d1c393aed9.xc9443bca5b0a56d8.xd6b6ed77479ef68c(xab391c46ff9a0a);
	}

	private RectangleF x0c628fca3d5e6671(int x349f5e3405601040, int x8579a518b84b8005, PointF xcb09bd0cee4909a3, PointF xa2da454aa40879d2)
	{
		float num = x57e1e2b6dbd00624 * (float)x349f5e3405601040;
		float num2 = (xc1fcd83e11f98132 ? (num - x57e1e2b6dbd00624 * (float)(x8579a518b84b8005 + 1)) : (x57e1e2b6dbd00624 * (float)x8579a518b84b8005));
		float num3 = ((x24ff467b392c1a38 == x4609f02542532aa8.x4c38e800e85b21ad) ? (xcb09bd0cee4909a3.X - num / 2f) : xa2da454aa40879d2.X);
		float num4 = ((x24ff467b392c1a38 == x4609f02542532aa8.xced856c17df679c5) ? (xcb09bd0cee4909a3.Y + num / 2f - x57e1e2b6dbd00624) : xa2da454aa40879d2.Y);
		float x = ((x24ff467b392c1a38 == x4609f02542532aa8.x4c38e800e85b21ad) ? (num3 + num2) : num3);
		float y = ((x24ff467b392c1a38 == x4609f02542532aa8.xced856c17df679c5) ? (num4 - num2) : xcb09bd0cee4909a3.Y);
		float width = ((x24ff467b392c1a38 == x4609f02542532aa8.x4c38e800e85b21ad) ? x57e1e2b6dbd00624 : (xcb09bd0cee4909a3.X - xa2da454aa40879d2.X));
		float height = ((x24ff467b392c1a38 == x4609f02542532aa8.xced856c17df679c5) ? x57e1e2b6dbd00624 : (xa2da454aa40879d2.Y - xcb09bd0cee4909a3.Y));
		return new RectangleF(x, y, width, height);
	}
}

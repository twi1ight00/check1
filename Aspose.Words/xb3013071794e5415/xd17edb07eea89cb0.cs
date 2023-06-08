using System;
using System.Drawing;
using x1c8faa688b1f0b0c;
using x32a884d842a34446;
using xad5c68c1ad3b0224;
using xcc8a79815d76af85;

namespace xb3013071794e5415;

internal class xd17edb07eea89cb0 : x66e735b434e6b412
{
	private x2a40f5b1b8618269 xdd52df84e01aa0c8;

	public xd17edb07eea89cb0(x958ddf7e6db1ce94 chart)
		: base(chart)
	{
		xdd52df84e01aa0c8 = (x2a40f5b1b8618269)chart;
	}

	internal override void xe406325e56f74b46(x43c3197706cb18d9 x7458794d854f9b68, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		switch (xdd52df84e01aa0c8.x1c0d56aa74903bbc)
		{
		case x1c0d56aa74903bbc.x7b3f79b8ae65a772:
		case x1c0d56aa74903bbc.x4f7bed84dc733f96:
			xe6f82eab96b08bdb(x7458794d854f9b68, x0f7b23d1c393aed9);
			break;
		default:
			xff6d3c837b0f54f8(x7458794d854f9b68, x0f7b23d1c393aed9);
			break;
		}
	}

	protected override void RenderLegendForDataPoints(xc48e9faacc88a3d5 legendLayout, xcd7d6e7318ee6574 context)
	{
		x44675b8bc366701b(xdd52df84e01aa0c8, xdd52df84e01aa0c8.x138f3e7bd8930522, legendLayout, context);
	}

	protected override void RenderLegendForSeries(xc48e9faacc88a3d5 legendLayut, xcd7d6e7318ee6574 context)
	{
		xbdcf7a2be6955201(xdd52df84e01aa0c8, xdd52df84e01aa0c8.x138f3e7bd8930522, legendLayut, context);
	}

	internal static void x44675b8bc366701b(x958ddf7e6db1ce94 xe640ebcce83ddadc, bool x927f2167ab24729f, xc48e9faacc88a3d5 x07f5d57888ef4f31, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		x9b87766ad1dbe8d6 x9b87766ad1dbe8d = (x9b87766ad1dbe8d6)xe640ebcce83ddadc.xc869533ad93d98d3[0];
		if (x9b87766ad1dbe8d.x320382c5f1993a78.xddf2b5348950b232)
		{
			string[] array = x66e735b434e6b412.x785802445639dd33(xe640ebcce83ddadc, x9b87766ad1dbe8d);
			for (int i = 0; i < array.Length; i++)
			{
				xb8e7e788f6d59708 x8f2400368d1c57d = x5e67d041941eced1(xe0d12474c5395154: true, x927f2167ab24729f, x07f5d57888ef4f31, x9b87766ad1dbe8d.x320382c5f1993a78.get_xe6d4b1b411ed94b5(i), x9b87766ad1dbe8d.xd1bdf42207dd3638, x0f7b23d1c393aed9);
				x07f5d57888ef4f31.xd7d75c376e5ae843(x8f2400368d1c57d, array[i]);
			}
		}
		else
		{
			xbdcf7a2be6955201(xe640ebcce83ddadc, x927f2167ab24729f, x07f5d57888ef4f31, x0f7b23d1c393aed9);
		}
	}

	internal static void xbdcf7a2be6955201(x958ddf7e6db1ce94 xe640ebcce83ddadc, bool x927f2167ab24729f, xc48e9faacc88a3d5 x07f5d57888ef4f31, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		foreach (x9b87766ad1dbe8d6 item in xe640ebcce83ddadc.xc869533ad93d98d3)
		{
			xb8e7e788f6d59708 x8f2400368d1c57d = x5e67d041941eced1(xe0d12474c5395154: true, x927f2167ab24729f, x07f5d57888ef4f31, item.x4ccdf3e6468ad446, item.xd1bdf42207dd3638, x0f7b23d1c393aed9);
			x07f5d57888ef4f31.xd7d75c376e5ae843(x8f2400368d1c57d, item.x759aa16c2016a289);
		}
	}

	private void xff6d3c837b0f54f8(x43c3197706cb18d9 x7458794d854f9b68, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		foreach (x9b87766ad1dbe8d6 item in xdd52df84e01aa0c8.xc869533ad93d98d3)
		{
			PointF[] x6fa2570084b2ad = x7458794d854f9b68.x466c8609d8f6c6c1(item);
			x3a117dc4e99db559(item, x6fa2570084b2ad, x0f7b23d1c393aed9);
		}
	}

	private void xe6f82eab96b08bdb(x43c3197706cb18d9 x7458794d854f9b68, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		float[] array = x318f74746d616ef0.xfdf7ff990b986a85(xdd52df84e01aa0c8);
		float[] array2 = new float[xdd52df84e01aa0c8.x28627c25cb262062];
		foreach (x9b87766ad1dbe8d6 item in xdd52df84e01aa0c8.xc869533ad93d98d3)
		{
			PointF[] array3 = new PointF[xdd52df84e01aa0c8.x28627c25cb262062];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] += item.x141ab7d3c1198e04.x2206903f9421fd4b(i).FloatValue;
				float floatValue = item.x3440cb7904436598.x2206903f9421fd4b(i).FloatValue;
				float xfb4c1c76fc5d2a6f = ((xdd52df84e01aa0c8.x1c0d56aa74903bbc == x1c0d56aa74903bbc.x7b3f79b8ae65a772) ? (array2[i] / array[i]) : array2[i]);
				ref PointF reference = ref array3[i];
				reference = x7458794d854f9b68.x2206903f9421fd4b(floatValue, xfb4c1c76fc5d2a6f);
			}
			x3a117dc4e99db559(item, array3, x0f7b23d1c393aed9);
		}
	}

	private void x3a117dc4e99db559(x9b87766ad1dbe8d6 x7acb8518c8ed6133, PointF[] x6fa2570084b2ad39, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		bool x559292b5f7ade8c = xdd52df84e01aa0c8.x22925f509223ea15 || x7acb8518c8ed6133.x22925f509223ea15;
		x02c01e0bd89aaaa0(x6fa2570084b2ad39, x0f7b23d1c393aed9, x7acb8518c8ed6133, xd925f447ef7e00a4: false, x559292b5f7ade8c);
		if (xdd52df84e01aa0c8.x138f3e7bd8930522)
		{
			x188700e4cffdf544(x6fa2570084b2ad39, x0f7b23d1c393aed9, x7acb8518c8ed6133);
		}
	}

	private static xb8e7e788f6d59708 x5e67d041941eced1(bool xe0d12474c5395154, bool x927f2167ab24729f, xc48e9faacc88a3d5 x07f5d57888ef4f31, x0c3d704ad3ea61a6 x6a2484744dda7709, int xf8bace4f66441872, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		if (xe0d12474c5395154)
		{
			PointF[] x6fa2570084b2ad = new PointF[2] { x07f5d57888ef4f31.x60e47f278f2e3258, x07f5d57888ef4f31.xafbdb5baf173ebe2 };
			xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.xa7b580afa8756d69(x6fa2570084b2ad, x7a848427f2a9a3b5: false);
			x318f74746d616ef0.x5bd690fbaae89142(xab391c46ff9a0a, x6a2484744dda7709.xff13b489d81606b6, x0f7b23d1c393aed9.x5e969e12ada2aab2.x7643de555a55ad21, xf8bace4f66441872);
			xb8e7e788f6d.xd6b6ed77479ef68c(xab391c46ff9a0a);
		}
		if (x927f2167ab24729f)
		{
			xab391c46ff9a0a38 xab391c46ff9a0a2 = x6377ccfa099ac593.x8c30fba0ce6ba6c8(x07f5d57888ef4f31.x1ec127a2b0d2b01c, x6a2484744dda7709.x94e4690631260a6c, xf8bace4f66441872, x0f7b23d1c393aed9);
			if (xab391c46ff9a0a2 != null)
			{
				xb8e7e788f6d.xd6b6ed77479ef68c(xab391c46ff9a0a2);
			}
		}
		return xb8e7e788f6d;
	}

	internal static void x02c01e0bd89aaaa0(PointF[] x6fa2570084b2ad39, xcd7d6e7318ee6574 x0f7b23d1c393aed9, x9b87766ad1dbe8d6 x7acb8518c8ed6133, bool xd925f447ef7e00a4, bool x559292b5f7ade8c2)
	{
		xb8e7e788f6d59708 xda5bf54deb817e = x22eeb7dfd7bac3bd(x6fa2570084b2ad39, x0f7b23d1c393aed9, x7acb8518c8ed6133, xd925f447ef7e00a4, x559292b5f7ade8c2);
		x0f7b23d1c393aed9.xc9443bca5b0a56d8.xd6b6ed77479ef68c(xda5bf54deb817e);
	}

	private static xb8e7e788f6d59708 x22eeb7dfd7bac3bd(PointF[] x6fa2570084b2ad39, xcd7d6e7318ee6574 x0f7b23d1c393aed9, x9b87766ad1dbe8d6 x7acb8518c8ed6133, bool xd925f447ef7e00a4, bool x559292b5f7ade8c2)
	{
		if (!xd925f447ef7e00a4)
		{
			return xb2b6ea820737e805(x6fa2570084b2ad39, x0f7b23d1c393aed9, x7acb8518c8ed6133, x559292b5f7ade8c2);
		}
		return xeac67e01135f95a5(x6fa2570084b2ad39, x0f7b23d1c393aed9, x7acb8518c8ed6133, x559292b5f7ade8c2);
	}

	private static xb8e7e788f6d59708 xb2b6ea820737e805(PointF[] x6fa2570084b2ad39, xcd7d6e7318ee6574 x0f7b23d1c393aed9, x9b87766ad1dbe8d6 x7acb8518c8ed6133, bool x559292b5f7ade8c2)
	{
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		if (x559292b5f7ade8c2 || x7acb8518c8ed6133.x22925f509223ea15)
		{
			xad215e3c2559f0f5(x7acb8518c8ed6133, x6fa2570084b2ad39, xb8e7e788f6d, x0f7b23d1c393aed9);
		}
		else
		{
			xae480b9fe9e0e9f7(x7acb8518c8ed6133, x6fa2570084b2ad39, xb8e7e788f6d, x0f7b23d1c393aed9);
		}
		return xb8e7e788f6d;
	}

	private static void xae480b9fe9e0e9f7(x9b87766ad1dbe8d6 x7acb8518c8ed6133, PointF[] x6fa2570084b2ad39, xb8e7e788f6d59708 x08ce8f4769eb3234, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		PointF x10aaa7cdfa38f = x6fa2570084b2ad39[0];
		for (int i = 0; i < x6fa2570084b2ad39.Length; i++)
		{
			xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.xb471d14948c54f27(x10aaa7cdfa38f, x6fa2570084b2ad39[i]);
			x08ce8f4769eb3234.xd6b6ed77479ef68c(xab391c46ff9a0a);
			x318f74746d616ef0.x5bd690fbaae89142(xab391c46ff9a0a, x7acb8518c8ed6133.x320382c5f1993a78.get_xe6d4b1b411ed94b5(i).xff13b489d81606b6, x0f7b23d1c393aed9.x5e969e12ada2aab2.x7643de555a55ad21, x7acb8518c8ed6133.xd1bdf42207dd3638);
			x10aaa7cdfa38f = x6fa2570084b2ad39[i];
		}
	}

	private static void xad215e3c2559f0f5(x9b87766ad1dbe8d6 x7acb8518c8ed6133, PointF[] x6fa2570084b2ad39, xb8e7e788f6d59708 x08ce8f4769eb3234, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		PointF[] array = xbf050539970fcabe(x6fa2570084b2ad39);
		int num = 0;
		for (int i = 0; i < array.Length - 3; i += 3)
		{
			xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38();
			x08ce8f4769eb3234.xd6b6ed77479ef68c(xab391c46ff9a0a);
			num++;
			PointF[] x6fa2570084b2ad40 = new PointF[4]
			{
				array[i],
				array[i + 1],
				array[i + 2],
				array[i + 3]
			};
			xab391c46ff9a0a.xd6b6ed77479ef68c(x1cab6af0a41b70e2.xd224a32bc1c49a2c(x6fa2570084b2ad40));
			x318f74746d616ef0.x5bd690fbaae89142(xab391c46ff9a0a, x7acb8518c8ed6133.x320382c5f1993a78.get_xe6d4b1b411ed94b5(num).xff13b489d81606b6, x0f7b23d1c393aed9.x5e969e12ada2aab2.x7643de555a55ad21, x7acb8518c8ed6133.xd1bdf42207dd3638);
		}
	}

	private static xb8e7e788f6d59708 xeac67e01135f95a5(PointF[] x6fa2570084b2ad39, xcd7d6e7318ee6574 x0f7b23d1c393aed9, x9b87766ad1dbe8d6 x7acb8518c8ed6133, bool x559292b5f7ade8c2)
	{
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38();
		x1cab6af0a41b70e2 xda5bf54deb817e = ((x559292b5f7ade8c2 || x7acb8518c8ed6133.x22925f509223ea15) ? x1cab6af0a41b70e2.xd224a32bc1c49a2c(xbf050539970fcabe(x6fa2570084b2ad39)) : x1cab6af0a41b70e2.xa7b580afa8756d69(x6fa2570084b2ad39, x7a848427f2a9a3b5: false));
		xab391c46ff9a0a.xd6b6ed77479ef68c(xda5bf54deb817e);
		x318f74746d616ef0.x5bd690fbaae89142(xab391c46ff9a0a, x7acb8518c8ed6133.x4ccdf3e6468ad446.xff13b489d81606b6, x0f7b23d1c393aed9.x5e969e12ada2aab2.xa32838f54072b660, x7acb8518c8ed6133.xd1bdf42207dd3638);
		xb8e7e788f6d.xd6b6ed77479ef68c(xab391c46ff9a0a);
		return xb8e7e788f6d;
	}

	internal static void x188700e4cffdf544(PointF[] x6fa2570084b2ad39, xcd7d6e7318ee6574 x0f7b23d1c393aed9, x9b87766ad1dbe8d6 x7acb8518c8ed6133)
	{
		x0f7b23d1c393aed9.xf5b0b9b6ff7ac462();
		x0f7b23d1c393aed9.x490834a62c46f14d(new xb8e7e788f6d59708());
		for (int i = 0; i < x6fa2570084b2ad39.Length; i++)
		{
			x6377ccfa099ac593.xe406325e56f74b46(x6fa2570084b2ad39[i], x7acb8518c8ed6133.x320382c5f1993a78.get_xe6d4b1b411ed94b5(i).x94e4690631260a6c, x7acb8518c8ed6133.xd1bdf42207dd3638, x0f7b23d1c393aed9);
		}
	}

	private static PointF[] xbf050539970fcabe(PointF[] x6cdadf67f18407c4)
	{
		if (x6cdadf67f18407c4 == null)
		{
			throw new ArgumentNullException("knots");
		}
		if (x6cdadf67f18407c4.Length < 2)
		{
			throw new ArgumentException("At least two knot points required", "knots");
		}
		PointF[] array = x84cb5c2baa8c23b2(x6cdadf67f18407c4);
		PointF[] x8623cb332c43a3ee = x0a54b940b2b502e0(x6cdadf67f18407c4, array);
		return xf75af31ac529957b(x6cdadf67f18407c4, array, x8623cb332c43a3ee);
	}

	private static PointF[] x84cb5c2baa8c23b2(PointF[] x6cdadf67f18407c4)
	{
		int num = x6cdadf67f18407c4.Length - 1;
		PointF[] array = new PointF[num];
		if (num == 1)
		{
			ref PointF reference = ref array[0];
			reference = new PointF((2f * x6cdadf67f18407c4[0].X + x6cdadf67f18407c4[1].X) / 3f, (2f * x6cdadf67f18407c4[0].Y + x6cdadf67f18407c4[1].Y) / 3f);
		}
		else
		{
			PointF[] array2 = x084771a5d8f8c36f(x6cdadf67f18407c4);
			float[] array3 = new float[array2.Length];
			float[] array4 = new float[array2.Length];
			for (int i = 0; i < array2.Length; i++)
			{
				array3[i] = array2[i].X;
				array4[i] = array2[i].Y;
			}
			float[] array5 = xa0e25a9e66eb62c4(array3);
			float[] array6 = xa0e25a9e66eb62c4(array4);
			for (int j = 0; j < num; j++)
			{
				ref PointF reference2 = ref array[j];
				reference2 = new PointF(array5[j], array6[j]);
			}
		}
		return array;
	}

	private static PointF[] x0a54b940b2b502e0(PointF[] x6cdadf67f18407c4, PointF[] x3419a4eb4629614c)
	{
		int num = x3419a4eb4629614c.Length;
		PointF[] array = new PointF[num];
		if (num == 1)
		{
			ref PointF reference = ref array[0];
			reference = new PointF(2f * x3419a4eb4629614c[0].X - x6cdadf67f18407c4[0].X, 2f * x3419a4eb4629614c[0].Y - x6cdadf67f18407c4[0].Y);
		}
		else
		{
			for (int i = 0; i < num; i++)
			{
				ref PointF reference2 = ref array[i];
				reference2 = ((i < num - 1) ? new PointF(2f * x6cdadf67f18407c4[i + 1].X - x3419a4eb4629614c[i + 1].X, 2f * x6cdadf67f18407c4[i + 1].Y - x3419a4eb4629614c[i + 1].Y) : new PointF((x6cdadf67f18407c4[num].X + x3419a4eb4629614c[num - 1].X) / 2f, (x6cdadf67f18407c4[num].Y + x3419a4eb4629614c[num - 1].Y) / 2f));
			}
		}
		return array;
	}

	private static PointF[] xf75af31ac529957b(PointF[] x6cdadf67f18407c4, PointF[] x7b5564fd618eec26, PointF[] x8623cb332c43a3ee)
	{
		PointF[] array = new PointF[x6cdadf67f18407c4.Length * 3 - 2];
		for (int i = 0; i < x6cdadf67f18407c4.Length; i++)
		{
			int num = i * 3;
			ref PointF reference = ref array[num];
			reference = x6cdadf67f18407c4[i];
			if (num + 1 < array.Length)
			{
				ref PointF reference2 = ref array[num + 1];
				reference2 = x7b5564fd618eec26[i];
				ref PointF reference3 = ref array[num + 2];
				reference3 = x8623cb332c43a3ee[i];
			}
		}
		return array;
	}

	private static PointF[] x084771a5d8f8c36f(PointF[] x6cdadf67f18407c4)
	{
		int num = x6cdadf67f18407c4.Length - 1;
		PointF[] array = new PointF[num];
		for (int i = 1; i < num - 1; i++)
		{
			ref PointF reference = ref array[i];
			reference = new PointF(4f * x6cdadf67f18407c4[i].X + 2f * x6cdadf67f18407c4[i + 1].X, 4f * x6cdadf67f18407c4[i].Y + 2f * x6cdadf67f18407c4[i + 1].Y);
		}
		ref PointF reference2 = ref array[0];
		reference2 = new PointF(x6cdadf67f18407c4[0].X + 2f * x6cdadf67f18407c4[1].X, x6cdadf67f18407c4[0].Y + 2f * x6cdadf67f18407c4[1].Y);
		ref PointF reference3 = ref array[num - 1];
		reference3 = new PointF((8f * x6cdadf67f18407c4[num - 1].X + x6cdadf67f18407c4[num].X) / 2f, (8f * x6cdadf67f18407c4[num - 1].Y + x6cdadf67f18407c4[num].Y) / 2f);
		return array;
	}

	private static float[] xa0e25a9e66eb62c4(float[] xd6efc2d6e891a521)
	{
		int num = xd6efc2d6e891a521.Length;
		float[] array = new float[num];
		float[] array2 = new float[num];
		float num2 = 2f;
		array[0] = xd6efc2d6e891a521[0] / num2;
		for (int i = 1; i < num; i++)
		{
			array2[i] = 1f / num2;
			num2 = ((i < num - 1) ? 4f : 3.5f) - array2[i];
			array[i] = (xd6efc2d6e891a521[i] - array[i - 1]) / num2;
		}
		for (int j = 1; j < num; j++)
		{
			array[num - j - 1] -= array2[num - j] * array[num - j];
		}
		return array;
	}
}

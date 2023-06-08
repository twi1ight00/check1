using System.Collections;
using System.Drawing;
using x1c8faa688b1f0b0c;
using x32a884d842a34446;
using xad5c68c1ad3b0224;

namespace xb3013071794e5415;

internal class xded5af631865b15c : x66e735b434e6b412
{
	private x363f7b37bdb0c3e1 x144d8726fd33d5e3;

	public xded5af631865b15c(x958ddf7e6db1ce94 chart)
		: base(chart)
	{
		x144d8726fd33d5e3 = (x363f7b37bdb0c3e1)chart;
	}

	internal override void xe406325e56f74b46(x43c3197706cb18d9 x7458794d854f9b68, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		switch (x144d8726fd33d5e3.x1c0d56aa74903bbc)
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

	private void xff6d3c837b0f54f8(x43c3197706cb18d9 x7458794d854f9b68, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		foreach (x9b87766ad1dbe8d6 item in x144d8726fd33d5e3.xc869533ad93d98d3)
		{
			PointF[] x58975b6368bcdcf = x7458794d854f9b68.x466c8609d8f6c6c1(item);
			xab391c46ff9a0a38 xda5bf54deb817e = xb4bbbd28c0a19568(x58975b6368bcdcf, x7458794d854f9b68, x0f7b23d1c393aed9, item);
			x0f7b23d1c393aed9.xc9443bca5b0a56d8.xd6b6ed77479ef68c(xda5bf54deb817e);
		}
	}

	private void xe6f82eab96b08bdb(x43c3197706cb18d9 x7458794d854f9b68, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		float[] array = x318f74746d616ef0.xfdf7ff990b986a85(x144d8726fd33d5e3);
		float[] array2 = new float[x144d8726fd33d5e3.x28627c25cb262062];
		Stack stack = new Stack();
		foreach (x9b87766ad1dbe8d6 item in x144d8726fd33d5e3.xc869533ad93d98d3)
		{
			PointF[] array3 = new PointF[x144d8726fd33d5e3.x28627c25cb262062];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] += item.x141ab7d3c1198e04.x2206903f9421fd4b(i).FloatValue;
				float floatValue = item.x3440cb7904436598.x2206903f9421fd4b(i).FloatValue;
				float xfb4c1c76fc5d2a6f = ((x144d8726fd33d5e3.x1c0d56aa74903bbc == x1c0d56aa74903bbc.x7b3f79b8ae65a772) ? (array2[i] / array[i]) : array2[i]);
				ref PointF reference = ref array3[i];
				reference = x7458794d854f9b68.x2206903f9421fd4b(floatValue, xfb4c1c76fc5d2a6f);
			}
			xab391c46ff9a0a38 obj = xb4bbbd28c0a19568(array3, x7458794d854f9b68, x0f7b23d1c393aed9, item);
			stack.Push(obj);
		}
		while (stack.Count > 0)
		{
			x0f7b23d1c393aed9.xc9443bca5b0a56d8.xd6b6ed77479ef68c((xab391c46ff9a0a38)stack.Pop());
		}
	}

	private static xab391c46ff9a0a38 xb4bbbd28c0a19568(PointF[] x58975b6368bcdcf3, x43c3197706cb18d9 x7458794d854f9b68, xcd7d6e7318ee6574 x0f7b23d1c393aed9, x9b87766ad1dbe8d6 x7acb8518c8ed6133)
	{
		PointF[] array = new PointF[x58975b6368bcdcf3.Length + 2];
		x58975b6368bcdcf3.CopyTo(array, 1);
		PointF pointF = x7458794d854f9b68.xeed202914e7c06d3();
		ref PointF reference = ref array[0];
		reference = new PointF(x58975b6368bcdcf3[0].X, pointF.Y);
		ref PointF reference2 = ref array[^1];
		reference2 = new PointF(x58975b6368bcdcf3[^1].X, pointF.Y);
		xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.xa7b580afa8756d69(array, x7a848427f2a9a3b5: true);
		x318f74746d616ef0.x5bd690fbaae89142(xab391c46ff9a0a, x7acb8518c8ed6133.x320382c5f1993a78.x24d50ab5d64a016e.xff13b489d81606b6, x0f7b23d1c393aed9.x5e969e12ada2aab2.xa32838f54072b660, x7acb8518c8ed6133.xd1bdf42207dd3638);
		return xab391c46ff9a0a;
	}
}

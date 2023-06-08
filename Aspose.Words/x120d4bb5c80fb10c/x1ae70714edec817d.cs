using System;
using System.Collections;
using System.Drawing;
using System.Reflection;
using x6c95d9cf46ff5f25;

namespace x120d4bb5c80fb10c;

[DefaultMember("Item")]
internal class x1ae70714edec817d
{
	private readonly ArrayList xe8964bdc3284e1e7;

	internal int xe9e87df45862c20a => xe8964bdc3284e1e7.Count;

	internal x03d68de1c2f74051 xe6d4b1b411ed94b5
	{
		get
		{
			if (0 > xc0c4c459c6ccbd00 || xc0c4c459c6ccbd00 >= xe9e87df45862c20a)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return (x03d68de1c2f74051)xe8964bdc3284e1e7[xc0c4c459c6ccbd00];
		}
	}

	internal x1ae70714edec817d(x03d68de1c2f74051 polygon)
		: this()
	{
		xe8964bdc3284e1e7.Add(polygon);
	}

	internal x1ae70714edec817d(x03d68de1c2f74051 polygon1, x03d68de1c2f74051 polygon2)
		: this()
	{
		xe8964bdc3284e1e7.Add(polygon1);
		xe8964bdc3284e1e7.Add(polygon2);
	}

	internal x1ae70714edec817d()
	{
		xe8964bdc3284e1e7 = new ArrayList();
	}

	internal void x89d9fcfbcec41d3c(x03d68de1c2f74051 x3031d6cbcb74de47)
	{
		ArrayList arrayList = (ArrayList)xe8964bdc3284e1e7.Clone();
		bool flag = false;
		for (int i = 0; i < arrayList.Count; i++)
		{
			x03d68de1c2f74051 x03d68de1c2f74052 = (x03d68de1c2f74051)arrayList[i];
			x1ae70714edec817d x1ae70714edec817d2 = xb48468b763132e39.x302217f6a82ceb2a(x03d68de1c2f74052, x3031d6cbcb74de47);
			if (x1ae70714edec817d2.xe9e87df45862c20a == 1)
			{
				flag = true;
				xe8964bdc3284e1e7.Remove(x03d68de1c2f74052);
				xe8964bdc3284e1e7.Remove(x3031d6cbcb74de47);
				x3031d6cbcb74de47 = x1ae70714edec817d2.get_xe6d4b1b411ed94b5(0);
				xe8964bdc3284e1e7.Add(x3031d6cbcb74de47);
			}
		}
		if (!flag)
		{
			xe8964bdc3284e1e7.Add(x3031d6cbcb74de47);
		}
	}

	internal void xcacd30c6b3be9db7(x03d68de1c2f74051 x3031d6cbcb74de47)
	{
		xe8964bdc3284e1e7.Add(x3031d6cbcb74de47);
	}

	internal void x638f09a63b4c2c2c(bool x2c8de54beeb6f890)
	{
		for (int i = 0; i < xe9e87df45862c20a; i++)
		{
			((x03d68de1c2f74051)xe8964bdc3284e1e7[i]).x638f09a63b4c2c2c(x2c8de54beeb6f890);
		}
	}

	internal x03d68de1c2f74051[] x543681a74a4a8026()
	{
		return (x03d68de1c2f74051[])xe8964bdc3284e1e7.ToArray(typeof(x03d68de1c2f74051));
	}

	internal RectangleF x7b2401fb9a2ead15()
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < xe9e87df45862c20a; i++)
		{
			arrayList.AddRange(this.get_xe6d4b1b411ed94b5(i).xc8bd66f519a24321());
		}
		if (arrayList.Count != 0)
		{
			return x37d2d88f96f87b47.x37b1dbbad6246778((PointF[])arrayList.ToArray(typeof(PointF)));
		}
		return RectangleF.Empty;
	}

	internal void x0e1bf8242ad10272(x03d68de1c2f74051 x6c4ee5bee33998e6)
	{
		ArrayList arrayList = new ArrayList(xe8964bdc3284e1e7.Count);
		for (int i = 0; i < xe9e87df45862c20a; i++)
		{
			x03d68de1c2f74051 x03d68de1c2f74052 = xb48468b763132e39.x1d844bc824c86667(x6c4ee5bee33998e6, this.get_xe6d4b1b411ed94b5(i));
			if (x03d68de1c2f74052.xe161fd465603c384 != 0)
			{
				arrayList.Add(x03d68de1c2f74052);
			}
		}
		xe8964bdc3284e1e7.Clear();
		xe8964bdc3284e1e7.AddRange(arrayList);
	}
}

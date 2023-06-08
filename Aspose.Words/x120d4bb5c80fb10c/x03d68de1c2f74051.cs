using System;
using System.Collections;
using System.Drawing;
using System.Reflection;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x120d4bb5c80fb10c;

[DefaultMember("Item")]
internal class x03d68de1c2f74051
{
	private readonly ArrayList x72e3d4e59d215bd0;

	internal int xe161fd465603c384 => x72e3d4e59d215bd0.Count;

	internal x319a5291e0303fb7 xe6d4b1b411ed94b5
	{
		get
		{
			if (0 > xc0c4c459c6ccbd00 || xc0c4c459c6ccbd00 >= xe161fd465603c384)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return (x319a5291e0303fb7)x72e3d4e59d215bd0[xc0c4c459c6ccbd00];
		}
		set
		{
			if (0 > xc0c4c459c6ccbd00 || xc0c4c459c6ccbd00 >= xe161fd465603c384)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			x72e3d4e59d215bd0[xc0c4c459c6ccbd00] = value;
		}
	}

	internal bool x7a0b193d493a9b59 => x37d2d88f96f87b47.xb81c335b66ecc867(xc8bd66f519a24321());

	internal int x8c048278b4338c82
	{
		get
		{
			int result = 0;
			float num = float.MaxValue;
			float num2 = float.MaxValue;
			for (int i = 0; i < xe161fd465603c384; i++)
			{
				PointF x755f16bdf92ce7c = this.get_xe6d4b1b411ed94b5(i).x755f16bdf92ce7c4;
				if (!(x755f16bdf92ce7c.X >= num) || (x755f16bdf92ce7c.X == num && !(x755f16bdf92ce7c.Y >= num2)))
				{
					num = x755f16bdf92ce7c.X;
					num2 = x755f16bdf92ce7c.Y;
					result = i;
				}
			}
			return result;
		}
	}

	internal int xad14e18a8527909a
	{
		get
		{
			int result = 0;
			float num = float.MinValue;
			for (int i = 0; i < xe161fd465603c384; i++)
			{
				PointF x755f16bdf92ce7c = this.get_xe6d4b1b411ed94b5(i).x755f16bdf92ce7c4;
				if (!(x755f16bdf92ce7c.X <= num))
				{
					num = x755f16bdf92ce7c.X;
					result = i;
				}
			}
			return result;
		}
	}

	internal int x3fc82f9493755797
	{
		get
		{
			int result = 0;
			float num = float.MaxValue;
			for (int i = 0; i < xe161fd465603c384; i++)
			{
				PointF x755f16bdf92ce7c = this.get_xe6d4b1b411ed94b5(i).x755f16bdf92ce7c4;
				if (!(x755f16bdf92ce7c.Y >= num))
				{
					num = x755f16bdf92ce7c.Y;
					result = i;
				}
			}
			return result;
		}
	}

	internal int x8712a541c1c434f8
	{
		get
		{
			int result = 0;
			float num = float.MinValue;
			for (int i = 0; i < xe161fd465603c384; i++)
			{
				PointF x755f16bdf92ce7c = this.get_xe6d4b1b411ed94b5(i).x755f16bdf92ce7c4;
				if (!(x755f16bdf92ce7c.Y <= num))
				{
					num = x755f16bdf92ce7c.Y;
					result = i;
				}
			}
			return result;
		}
	}

	internal x03d68de1c2f74051()
		: this(new PointF[0])
	{
	}

	internal x03d68de1c2f74051(RectangleF rectangle)
		: this(new PointF[4]
		{
			new PointF(rectangle.Left, rectangle.Top),
			new PointF(rectangle.Right, rectangle.Top),
			new PointF(rectangle.Right, rectangle.Bottom),
			new PointF(rectangle.Left, rectangle.Bottom)
		})
	{
	}

	internal x03d68de1c2f74051(PointF[] points)
	{
		if (points == null)
		{
			throw new NullReferenceException("points");
		}
		x72e3d4e59d215bd0 = new ArrayList(points.Length);
		for (int i = 0; i < points.Length; i++)
		{
			x319a5291e0303fb7 xca6378e60d4a2ec = new x319a5291e0303fb7(points[i]);
			x9e8a4f197cec3cdd(xca6378e60d4a2ec);
		}
	}

	internal void x638f09a63b4c2c2c(bool x2c8de54beeb6f890)
	{
		if (x7a0b193d493a9b59 != x2c8de54beeb6f890)
		{
			x72e3d4e59d215bd0.Reverse();
		}
	}

	internal void x7e8ee2030a44c305(ArrayList x4ec0cc7e5feca2c6, bool x940dba70fec6696a)
	{
		if (x940dba70fec6696a)
		{
			x7e8ee2030a44c305((PointF[])x4ec0cc7e5feca2c6.ToArray(typeof(PointF)));
		}
		else
		{
			x72e3d4e59d215bd0.AddRange(x4ec0cc7e5feca2c6);
		}
	}

	internal void x7e8ee2030a44c305(PointF[] x6fa2570084b2ad39)
	{
		x319a5291e0303fb7[] array = new x319a5291e0303fb7[x6fa2570084b2ad39.Length];
		for (int i = 0; i < x6fa2570084b2ad39.Length; i++)
		{
			array[i] = new x319a5291e0303fb7(x6fa2570084b2ad39[i]);
		}
		x72e3d4e59d215bd0.AddRange(array);
	}

	internal void x1db7da71f8033331(int xc0c4c459c6ccbd00, ArrayList x4ec0cc7e5feca2c6)
	{
		x72e3d4e59d215bd0.InsertRange(xc0c4c459c6ccbd00, x4ec0cc7e5feca2c6);
	}

	internal void x9e8a4f197cec3cdd(PointF x2f7096dac971d6ec)
	{
		x9e8a4f197cec3cdd(new x319a5291e0303fb7(x2f7096dac971d6ec));
	}

	internal void x9e8a4f197cec3cdd(x319a5291e0303fb7 xca6378e60d4a2ec2)
	{
		x72e3d4e59d215bd0.Add(xca6378e60d4a2ec2);
	}

	internal void x5c433c89069df74f(int xc0c4c459c6ccbd00, x319a5291e0303fb7 xca6378e60d4a2ec2)
	{
		if (0 > xc0c4c459c6ccbd00 || xc0c4c459c6ccbd00 >= xe161fd465603c384)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		x72e3d4e59d215bd0.Insert(xc0c4c459c6ccbd00, xca6378e60d4a2ec2);
	}

	internal void x81b9866957faac98(int xc0c4c459c6ccbd00)
	{
		if (0 > xc0c4c459c6ccbd00 || xc0c4c459c6ccbd00 >= xe161fd465603c384)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		x72e3d4e59d215bd0.RemoveAt(xc0c4c459c6ccbd00);
	}

	internal int xf58ae67e9db98f59(x319a5291e0303fb7 xca6378e60d4a2ec2)
	{
		return x72e3d4e59d215bd0.IndexOf(xca6378e60d4a2ec2);
	}

	internal ArrayList xe10fc86bc53f5f64(int xc0c4c459c6ccbd00)
	{
		ArrayList arrayList = new ArrayList(xe161fd465603c384);
		for (int i = 0; i < xe161fd465603c384; i++)
		{
			arrayList.Add(this.get_xe6d4b1b411ed94b5(x5138ebdd7c56c151(xc0c4c459c6ccbd00 + i)));
		}
		return arrayList;
	}

	internal int x5138ebdd7c56c151(int xc0c4c459c6ccbd00)
	{
		return xc0c4c459c6ccbd00 % xe161fd465603c384;
	}

	internal PointF[] xc8bd66f519a24321()
	{
		PointF[] array = new PointF[x72e3d4e59d215bd0.Count];
		for (int i = 0; i < x72e3d4e59d215bd0.Count; i++)
		{
			PointF x755f16bdf92ce7c = ((x319a5291e0303fb7)x72e3d4e59d215bd0[i]).x755f16bdf92ce7c4;
			ref PointF reference = ref array[i];
			reference = new PointF(x755f16bdf92ce7c.X, x755f16bdf92ce7c.Y);
		}
		return array;
	}

	internal Point[] xae9b39e97710953f()
	{
		PointF[] array = xc8bd66f519a24321();
		Point[] array2 = new Point[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			ref Point reference = ref array2[i];
			reference = x4574ea26106f0edb.x8d50b8a62ba1cd84(array[i]);
		}
		return array2;
	}

	internal void x4fdf47a12306c1b7(x54366fa5f75a02f7 xa801ccff44b0c7eb)
	{
		foreach (x319a5291e0303fb7 item in x72e3d4e59d215bd0)
		{
			item.x755f16bdf92ce7c4 = xa801ccff44b0c7eb.x5c785f1d561da269(item.x755f16bdf92ce7c4);
		}
	}

	internal bool xa24831e4ed96f36e(PointF x2f7096dac971d6ec)
	{
		return x0f32e10b18d9bea9(xc8bd66f519a24321(), x2f7096dac971d6ec);
	}

	internal void x36f62b8b1b3166e6()
	{
		foreach (x319a5291e0303fb7 item in x72e3d4e59d215bd0)
		{
			item.x68953f97ddfd5344 = x534d8847b46a0ceb.xefd793a3562fa636;
		}
	}

	internal bool x7cd03e8a08a03449(x534d8847b46a0ceb x43163d22e8cd5a71)
	{
		foreach (x319a5291e0303fb7 item in x72e3d4e59d215bd0)
		{
			if (item.x68953f97ddfd5344 != x43163d22e8cd5a71)
			{
				return false;
			}
		}
		return true;
	}

	internal static bool x0f32e10b18d9bea9(PointF[] xe40123f60e168eb8, PointF xcecb8058aa0ba5c0)
	{
		bool flag = false;
		if (xe40123f60e168eb8.Length < 3)
		{
			return false;
		}
		PointF pointF = new PointF(xe40123f60e168eb8[^1].X, xe40123f60e168eb8[^1].Y);
		for (int i = 0; i < xe40123f60e168eb8.Length; i++)
		{
			PointF pointF2 = new PointF(xe40123f60e168eb8[i].X, xe40123f60e168eb8[i].Y);
			PointF pointF3;
			PointF pointF4;
			if (pointF2.X > pointF.X)
			{
				pointF3 = pointF;
				pointF4 = pointF2;
			}
			else
			{
				pointF3 = pointF2;
				pointF4 = pointF;
			}
			if (pointF2.X < xcecb8058aa0ba5c0.X == xcecb8058aa0ba5c0.X <= pointF.X && (xcecb8058aa0ba5c0.Y - pointF3.Y) * (pointF4.X - pointF3.X) < (pointF4.Y - pointF3.Y) * (xcecb8058aa0ba5c0.X - pointF3.X))
			{
				flag = !flag;
			}
			pointF = pointF2;
		}
		return flag;
	}

	internal x03d68de1c2f74051 x8b61531c8ea35b85()
	{
		return new x03d68de1c2f74051(xc8bd66f519a24321());
	}
}

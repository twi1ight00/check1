using System.Collections;
using System.Drawing;
using x3d94286fe72124a8;
using x6c95d9cf46ff5f25;

namespace x120d4bb5c80fb10c;

internal class xb48468b763132e39
{
	internal static x1ae70714edec817d x302217f6a82ceb2a(x03d68de1c2f74051 xdafde7d9313c28e2, x03d68de1c2f74051 xc7e1dc7cb3b88874)
	{
		if (xdafde7d9313c28e2 == null && xc7e1dc7cb3b88874 == null)
		{
			return new x1ae70714edec817d();
		}
		if (xc7e1dc7cb3b88874 == null || xc7e1dc7cb3b88874.xe161fd465603c384 == 0)
		{
			return new x1ae70714edec817d(xdafde7d9313c28e2);
		}
		if (xdafde7d9313c28e2 == null || xdafde7d9313c28e2.xe161fd465603c384 == 0)
		{
			return new x1ae70714edec817d(xc7e1dc7cb3b88874);
		}
		return xd5da23b762ce52a2(xdafde7d9313c28e2, xc7e1dc7cb3b88874);
	}

	internal static x03d68de1c2f74051 x4a50984825eee908(x1ae70714edec817d xd6398ac5382774e3)
	{
		if (xd6398ac5382774e3.xe9e87df45862c20a == 0)
		{
			return new x03d68de1c2f74051();
		}
		if (xd6398ac5382774e3.xe9e87df45862c20a == 1)
		{
			return xd6398ac5382774e3.get_xe6d4b1b411ed94b5(0);
		}
		return x8ad6e16c011da0e8(xd6398ac5382774e3);
	}

	internal static x03d68de1c2f74051 x1d844bc824c86667(x03d68de1c2f74051 xdafde7d9313c28e2, x03d68de1c2f74051 xc7e1dc7cb3b88874)
	{
		if (xdafde7d9313c28e2 == null && xc7e1dc7cb3b88874 == null)
		{
			return new x03d68de1c2f74051();
		}
		if (xc7e1dc7cb3b88874 == null || xc7e1dc7cb3b88874.xe161fd465603c384 == 0)
		{
			return new x03d68de1c2f74051();
		}
		if (xdafde7d9313c28e2 == null || xdafde7d9313c28e2.xe161fd465603c384 == 0)
		{
			return new x03d68de1c2f74051();
		}
		return x48361165d808c135(xdafde7d9313c28e2, xc7e1dc7cb3b88874);
	}

	private static x1ae70714edec817d xd5da23b762ce52a2(x03d68de1c2f74051 xdafde7d9313c28e2, x03d68de1c2f74051 xc7e1dc7cb3b88874)
	{
		xdafde7d9313c28e2.x638f09a63b4c2c2c(x2c8de54beeb6f890: true);
		xc7e1dc7cb3b88874.x638f09a63b4c2c2c(x2c8de54beeb6f890: true);
		bool xdd0101b9b652fda = x0fe5daa5d8b0a214(xdafde7d9313c28e2, xc7e1dc7cb3b88874);
		return xb1327353cc303e41(xdafde7d9313c28e2, xc7e1dc7cb3b88874, xdd0101b9b652fda);
	}

	private static bool x0fe5daa5d8b0a214(x03d68de1c2f74051 xdafde7d9313c28e2, x03d68de1c2f74051 xc7e1dc7cb3b88874)
	{
		if (xdafde7d9313c28e2.xe161fd465603c384 < 3 || xc7e1dc7cb3b88874.xe161fd465603c384 < 3)
		{
			return false;
		}
		xdb993f83d3c3518d xdb993f83d3c3518d2 = new xdb993f83d3c3518d(xdafde7d9313c28e2, xc7e1dc7cb3b88874);
		for (int i = 0; i < xdafde7d9313c28e2.xe161fd465603c384; i++)
		{
			xdb993f83d3c3518d2.x11294912393cf4da = xdafde7d9313c28e2.get_xe6d4b1b411ed94b5(i).x755f16bdf92ce7c4;
			xdb993f83d3c3518d2.xeb2981f42da5479b = i;
			xdb993f83d3c3518d2.x7d8c1a8f7bce8aef = xdafde7d9313c28e2.x5138ebdd7c56c151(i + 1);
			xb2f06c7846241795 x0ee54d4c2d93d62c = x39ba2c22c7a24420(xdafde7d9313c28e2, i);
			for (int j = 0; j < xc7e1dc7cb3b88874.xe161fd465603c384; j++)
			{
				xdb993f83d3c3518d2.x0670b69f56b4ff17 = j;
				x128ea1555d736412(xdb993f83d3c3518d2, x0ee54d4c2d93d62c);
			}
		}
		if (xdb993f83d3c3518d2.x59588380b3c4e6d6)
		{
			xec5c7d774bd34620(xdb993f83d3c3518d2, xd94e2fb9583de033: true);
			xec5c7d774bd34620(xdb993f83d3c3518d2, xd94e2fb9583de033: false);
		}
		return xdb993f83d3c3518d2.x59588380b3c4e6d6;
	}

	private static void x128ea1555d736412(xdb993f83d3c3518d x4a3f0a05c02f235f, xb2f06c7846241795 x0ee54d4c2d93d62c)
	{
		x4a3f0a05c02f235f.x86a54cb9b074862a = x4a3f0a05c02f235f.xda1fa90ecfb45f47.get_xe6d4b1b411ed94b5(x4a3f0a05c02f235f.x0670b69f56b4ff17).x755f16bdf92ce7c4;
		x4a3f0a05c02f235f.xbc30aae3175af8d8 = x4a3f0a05c02f235f.xda1fa90ecfb45f47.x5138ebdd7c56c151(x4a3f0a05c02f235f.x0670b69f56b4ff17 + 1);
		xb2f06c7846241795 xb2f06c7846241795 = x39ba2c22c7a24420(x4a3f0a05c02f235f.xda1fa90ecfb45f47, x4a3f0a05c02f235f.x0670b69f56b4ff17);
		if (!xefbb9456082e03d6(x0ee54d4c2d93d62c, xb2f06c7846241795, x4a3f0a05c02f235f))
		{
			PointF[] array = new PointF[1];
			bool flag = xb2f06c7846241795.x07aa36934bec95f1(x0ee54d4c2d93d62c, xb2f06c7846241795, array, x0dc87af0058e6b62: true);
			x4a3f0a05c02f235f.xf35d8b856c1f3037 = array[0];
			if (flag && !x37d2d88f96f87b47.xd0fdca5aa42d16bc(x4a3f0a05c02f235f.xf35d8b856c1f3037, xb2f06c7846241795.x2271dea312f4a835) && !x37d2d88f96f87b47.xd0fdca5aa42d16bc(x4a3f0a05c02f235f.xf35d8b856c1f3037, x0ee54d4c2d93d62c.x2271dea312f4a835))
			{
				xe6fe51aefae0276b(x4a3f0a05c02f235f.xb9470426ecaacdf2(x4a3f0a05c02f235f.xeb2981f42da5479b), x4a3f0a05c02f235f.x315e0ef80871d679(x4a3f0a05c02f235f.xeb2981f42da5479b), x4a3f0a05c02f235f.x11294912393cf4da, array[0]);
				xe6fe51aefae0276b(x4a3f0a05c02f235f.x19ab0a16c4ddebbd(x4a3f0a05c02f235f.x0670b69f56b4ff17), x4a3f0a05c02f235f.xfc2f58086a8d500e(x4a3f0a05c02f235f.x0670b69f56b4ff17), x4a3f0a05c02f235f.x86a54cb9b074862a, array[0]);
				x4a3f0a05c02f235f.x59588380b3c4e6d6 = true;
			}
		}
	}

	private static bool xefbb9456082e03d6(xb2f06c7846241795 x0ee54d4c2d93d62c, xb2f06c7846241795 x569fd060c0a68d13, xdb993f83d3c3518d x4a3f0a05c02f235f)
	{
		bool result = false;
		if (x25bf895453c58f72(x0ee54d4c2d93d62c, x4a3f0a05c02f235f, x13028c52f4895dab: true))
		{
			result = true;
		}
		if (x25bf895453c58f72(x569fd060c0a68d13, x4a3f0a05c02f235f, x13028c52f4895dab: false))
		{
			result = true;
		}
		return result;
	}

	private static bool x25bf895453c58f72(xb2f06c7846241795 x311b46c396890b2f, xdb993f83d3c3518d x4a3f0a05c02f235f, bool x13028c52f4895dab)
	{
		if (x311b46c396890b2f.xb4ffd449b7335505(x13028c52f4895dab ? x4a3f0a05c02f235f.x86a54cb9b074862a : x4a3f0a05c02f235f.x11294912393cf4da))
		{
			x8ecc05d81b864648(x311b46c396890b2f, x4a3f0a05c02f235f, x13028c52f4895dab);
			return true;
		}
		return false;
	}

	private static void x8ecc05d81b864648(xb2f06c7846241795 x311b46c396890b2f, xdb993f83d3c3518d x4a3f0a05c02f235f, bool x13028c52f4895dab)
	{
		x4a3f0a05c02f235f.x59588380b3c4e6d6 = true;
		x319a5291e0303fb7 x319a5291e0303fb8 = (x13028c52f4895dab ? x4a3f0a05c02f235f.xda1fa90ecfb45f47.get_xe6d4b1b411ed94b5(x4a3f0a05c02f235f.x0670b69f56b4ff17) : x4a3f0a05c02f235f.x132706af982e66d4.get_xe6d4b1b411ed94b5(x4a3f0a05c02f235f.xeb2981f42da5479b));
		x319a5291e0303fb8.x68953f97ddfd5344 = x534d8847b46a0ceb.x1918b9f101f092cb;
		if (!xff2a5c3130896599(x311b46c396890b2f, x4a3f0a05c02f235f, x13028c52f4895dab, x5699ef936031040f: true, x319a5291e0303fb8) && !xff2a5c3130896599(x311b46c396890b2f, x4a3f0a05c02f235f, x13028c52f4895dab, x5699ef936031040f: false, x319a5291e0303fb8))
		{
			xe6fe51aefae0276b(x13028c52f4895dab ? x4a3f0a05c02f235f.xb9470426ecaacdf2(x4a3f0a05c02f235f.xeb2981f42da5479b) : x4a3f0a05c02f235f.x19ab0a16c4ddebbd(x4a3f0a05c02f235f.x0670b69f56b4ff17), x13028c52f4895dab ? x4a3f0a05c02f235f.x315e0ef80871d679(x4a3f0a05c02f235f.xeb2981f42da5479b) : x4a3f0a05c02f235f.xfc2f58086a8d500e(x4a3f0a05c02f235f.x0670b69f56b4ff17), x13028c52f4895dab ? x4a3f0a05c02f235f.x11294912393cf4da : x4a3f0a05c02f235f.x86a54cb9b074862a, x13028c52f4895dab ? x4a3f0a05c02f235f.x86a54cb9b074862a : x4a3f0a05c02f235f.x11294912393cf4da);
		}
	}

	private static bool xff2a5c3130896599(xb2f06c7846241795 x311b46c396890b2f, xdb993f83d3c3518d x4a3f0a05c02f235f, bool x13028c52f4895dab, bool x5699ef936031040f, x319a5291e0303fb7 xca6378e60d4a2ec2)
	{
		if (x37d2d88f96f87b47.xd0fdca5aa42d16bc(x5699ef936031040f ? x311b46c396890b2f.xaf4e0fbe61814cf5 : x311b46c396890b2f.x2271dea312f4a835, xca6378e60d4a2ec2.x755f16bdf92ce7c4))
		{
			x319a5291e0303fb7 x319a5291e0303fb8 = (x13028c52f4895dab ? x4a3f0a05c02f235f.x132706af982e66d4.get_xe6d4b1b411ed94b5(x5699ef936031040f ? x4a3f0a05c02f235f.xeb2981f42da5479b : x4a3f0a05c02f235f.x7d8c1a8f7bce8aef) : x4a3f0a05c02f235f.xda1fa90ecfb45f47.get_xe6d4b1b411ed94b5(x5699ef936031040f ? x4a3f0a05c02f235f.x0670b69f56b4ff17 : x4a3f0a05c02f235f.xbc30aae3175af8d8));
			x319a5291e0303fb8.x68953f97ddfd5344 = x534d8847b46a0ceb.x1918b9f101f092cb;
			x319a5291e0303fb8.x755f16bdf92ce7c4 = xca6378e60d4a2ec2.x755f16bdf92ce7c4;
			return true;
		}
		return false;
	}

	private static xb2f06c7846241795 x39ba2c22c7a24420(x03d68de1c2f74051 xe41c5c767887b961, int xc0c4c459c6ccbd00)
	{
		return new xb2f06c7846241795(xe41c5c767887b961.get_xe6d4b1b411ed94b5(xc0c4c459c6ccbd00).x755f16bdf92ce7c4, xe41c5c767887b961.get_xe6d4b1b411ed94b5(xe41c5c767887b961.x5138ebdd7c56c151(xc0c4c459c6ccbd00 + 1)).x755f16bdf92ce7c4);
	}

	private static void xe6fe51aefae0276b(ArrayList x3c995f79b5fe0ee9, ArrayList xdca2c5747154e6b4, PointF xca6378e60d4a2ec2, PointF xef84d0280a77e23c)
	{
		float num = x37d2d88f96f87b47.x5af88e61b614ce62(xca6378e60d4a2ec2, xef84d0280a77e23c);
		bool flag = false;
		for (int i = 0; i < xdca2c5747154e6b4.Count; i++)
		{
			if (num < (float)xdca2c5747154e6b4[i])
			{
				x3c995f79b5fe0ee9.Insert(i, new x319a5291e0303fb7(xef84d0280a77e23c, x534d8847b46a0ceb.x1918b9f101f092cb));
				xdca2c5747154e6b4.Insert(i, num);
				flag = true;
			}
			if (num == (float)xdca2c5747154e6b4[i])
			{
				flag = true;
			}
			if (flag)
			{
				break;
			}
		}
		if (!flag)
		{
			x3c995f79b5fe0ee9.Add(new x319a5291e0303fb7(xef84d0280a77e23c, x534d8847b46a0ceb.x1918b9f101f092cb));
			xdca2c5747154e6b4.Add(num);
		}
	}

	private static void xec5c7d774bd34620(xdb993f83d3c3518d x4a3f0a05c02f235f, bool xd94e2fb9583de033)
	{
		int num = 1;
		x03d68de1c2f74051 x03d68de1c2f74052 = (xd94e2fb9583de033 ? x4a3f0a05c02f235f.x132706af982e66d4 : x4a3f0a05c02f235f.xda1fa90ecfb45f47);
		int xe161fd465603c = x03d68de1c2f74052.xe161fd465603c384;
		for (int i = 0; i < xe161fd465603c; i++)
		{
			ArrayList arrayList = (xd94e2fb9583de033 ? x4a3f0a05c02f235f.xb9470426ecaacdf2(i) : x4a3f0a05c02f235f.x19ab0a16c4ddebbd(i));
			x03d68de1c2f74052.x1db7da71f8033331(i + num, arrayList);
			num += arrayList.Count;
		}
	}

	private static bool x9400618b79d13678(x03d68de1c2f74051 xdafde7d9313c28e2, x03d68de1c2f74051 xc7e1dc7cb3b88874, int[] xc0c4c459c6ccbd00)
	{
		int x8c048278b4338c = xdafde7d9313c28e2.x8c048278b4338c82;
		int x8c048278b4338c2 = xc7e1dc7cb3b88874.x8c048278b4338c82;
		bool flag;
		if (xdafde7d9313c28e2.x7cd03e8a08a03449(x534d8847b46a0ceb.x1918b9f101f092cb))
		{
			flag = false;
		}
		else if (xc7e1dc7cb3b88874.x7cd03e8a08a03449(x534d8847b46a0ceb.x1918b9f101f092cb))
		{
			flag = true;
		}
		else
		{
			PointF x755f16bdf92ce7c = xdafde7d9313c28e2.get_xe6d4b1b411ed94b5(x8c048278b4338c).x755f16bdf92ce7c4;
			PointF x755f16bdf92ce7c2 = xc7e1dc7cb3b88874.get_xe6d4b1b411ed94b5(x8c048278b4338c2).x755f16bdf92ce7c4;
			flag = x755f16bdf92ce7c.X < x755f16bdf92ce7c2.X || (x755f16bdf92ce7c.X == x755f16bdf92ce7c2.X && x755f16bdf92ce7c.Y < x755f16bdf92ce7c2.Y);
		}
		xc0c4c459c6ccbd00[0] = (flag ? x8c048278b4338c : x8c048278b4338c2);
		return flag;
	}

	private static x1ae70714edec817d xb1327353cc303e41(x03d68de1c2f74051 xdafde7d9313c28e2, x03d68de1c2f74051 xc7e1dc7cb3b88874, bool xdd0101b9b652fda7)
	{
		if (!xdd0101b9b652fda7)
		{
			return x5b1d198405d6e194(xdafde7d9313c28e2, xc7e1dc7cb3b88874);
		}
		int[] array = new int[1];
		bool x3dc1716043f337e = x9400618b79d13678(xdafde7d9313c28e2, xc7e1dc7cb3b88874, array);
		int xd4f974c06ffa392b = array[0];
		x03d68de1c2f74051 polygon = xb666742bae30a6fc(xdafde7d9313c28e2, xc7e1dc7cb3b88874, xd4f974c06ffa392b, x3dc1716043f337e, x7518faed3f5307d5: false);
		xdafde7d9313c28e2.x36f62b8b1b3166e6();
		xc7e1dc7cb3b88874.x36f62b8b1b3166e6();
		return new x1ae70714edec817d(polygon);
	}

	private static x03d68de1c2f74051 xb666742bae30a6fc(x03d68de1c2f74051 xdafde7d9313c28e2, x03d68de1c2f74051 xc7e1dc7cb3b88874, int xd4f974c06ffa392b, bool x3dc1716043f337e7, bool x7518faed3f5307d5)
	{
		x03d68de1c2f74051 x03d68de1c2f74052 = (x3dc1716043f337e7 ? xdafde7d9313c28e2 : xc7e1dc7cb3b88874);
		x03d68de1c2f74051 x03d68de1c2f74053 = new x03d68de1c2f74051();
		int num = xd4f974c06ffa392b;
		int num2 = xdafde7d9313c28e2.xe161fd465603c384 + xc7e1dc7cb3b88874.xe161fd465603c384;
		x03d68de1c2f74051 x03d68de1c2f74054 = x03d68de1c2f74052;
		while (true)
		{
			x319a5291e0303fb7 x319a5291e0303fb8 = x03d68de1c2f74054.get_xe6d4b1b411ed94b5(num);
			if (x03d68de1c2f74053.xe161fd465603c384 == 0 || (!x03d68de1c2f74053.get_xe6d4b1b411ed94b5(x03d68de1c2f74053.xe161fd465603c384 - 1).x755f16bdf92ce7c4.Equals(x319a5291e0303fb8.x755f16bdf92ce7c4) && !x03d68de1c2f74053.get_xe6d4b1b411ed94b5(0).x755f16bdf92ce7c4.Equals(x319a5291e0303fb8.x755f16bdf92ce7c4)))
			{
				x03d68de1c2f74053.x9e8a4f197cec3cdd(x319a5291e0303fb8);
			}
			num = ((num != x03d68de1c2f74054.xe161fd465603c384 - 1) ? (num + 1) : 0);
			if (x7518faed3f5307d5)
			{
				x7518faed3f5307d5 = false;
				continue;
			}
			if ((num == xd4f974c06ffa392b && x03d68de1c2f74054 == x03d68de1c2f74052) || x03d68de1c2f74053.xe161fd465603c384 > num2)
			{
				break;
			}
			if (x319a5291e0303fb8.x68953f97ddfd5344 != 0)
			{
				x03d68de1c2f74054 = ((x03d68de1c2f74054 == xdafde7d9313c28e2) ? xc7e1dc7cb3b88874 : xdafde7d9313c28e2);
				num = x03d68de1c2f74054.xf58ae67e9db98f59(x319a5291e0303fb8);
				if ((num == xd4f974c06ffa392b && x03d68de1c2f74054 == x03d68de1c2f74052) || num == -1)
				{
					break;
				}
				num = ((num != x03d68de1c2f74054.xe161fd465603c384 - 1) ? (num + 1) : 0);
				if (num == xd4f974c06ffa392b && x03d68de1c2f74054 == x03d68de1c2f74052)
				{
					break;
				}
			}
		}
		x03d68de1c2f74053.x36f62b8b1b3166e6();
		return x03d68de1c2f74053;
	}

	private static x1ae70714edec817d x5b1d198405d6e194(x03d68de1c2f74051 xdafde7d9313c28e2, x03d68de1c2f74051 xc7e1dc7cb3b88874)
	{
		int num = xb587fc8f77286d15(xdafde7d9313c28e2, xc7e1dc7cb3b88874);
		if (num == xc7e1dc7cb3b88874.xe161fd465603c384)
		{
			return new x1ae70714edec817d(xdafde7d9313c28e2);
		}
		if (num != 0)
		{
			return new x1ae70714edec817d(xdafde7d9313c28e2);
		}
		num = xb587fc8f77286d15(xc7e1dc7cb3b88874, xdafde7d9313c28e2);
		if (num == xdafde7d9313c28e2.xe161fd465603c384)
		{
			return new x1ae70714edec817d(xc7e1dc7cb3b88874);
		}
		if (num != 0)
		{
			return new x1ae70714edec817d(xc7e1dc7cb3b88874);
		}
		return new x1ae70714edec817d(xdafde7d9313c28e2, xc7e1dc7cb3b88874);
	}

	private static int xb587fc8f77286d15(x03d68de1c2f74051 xe41c5c767887b961, x03d68de1c2f74051 x8f34c734bfd2dc47)
	{
		int num = 0;
		for (int i = 0; i < x8f34c734bfd2dc47.xe161fd465603c384; i++)
		{
			if (xe41c5c767887b961.xa24831e4ed96f36e(x8f34c734bfd2dc47.get_xe6d4b1b411ed94b5(i).x755f16bdf92ce7c4))
			{
				num++;
			}
		}
		return num;
	}

	private static x03d68de1c2f74051 x8ad6e16c011da0e8(x1ae70714edec817d xd6398ac5382774e3)
	{
		xd6398ac5382774e3.x638f09a63b4c2c2c(x2c8de54beeb6f890: true);
		ArrayList arrayList = new ArrayList(xd6398ac5382774e3.x543681a74a4a8026());
		for (int num = arrayList.Count - 1; num > 0; num--)
		{
			xf824fb6c58793add(arrayList, num);
		}
		return (x03d68de1c2f74051)arrayList[0];
	}

	private static void xf824fb6c58793add(ArrayList xaaed4a3c2d8e85f1, int xc0c4c459c6ccbd00)
	{
		x06fd9daa29391ff0 x06fd9daa29391ff = x948d6e71599a59f8(xaaed4a3c2d8e85f1, xc0c4c459c6ccbd00);
		x03d68de1c2f74051 x03d68de1c2f74052 = (x03d68de1c2f74051)xaaed4a3c2d8e85f1[x06fd9daa29391ff.x1f15ffa1b12ab633];
		x03d68de1c2f74051 xc7e1dc7cb3b = (x03d68de1c2f74051)xaaed4a3c2d8e85f1[x06fd9daa29391ff.x38290c33d5098612];
		x96f455c7979a752f(x03d68de1c2f74052, xc7e1dc7cb3b, x06fd9daa29391ff);
		xaaed4a3c2d8e85f1.RemoveAt(x06fd9daa29391ff.x1f15ffa1b12ab633);
		xaaed4a3c2d8e85f1.RemoveAt(x06fd9daa29391ff.x38290c33d5098612);
		xaaed4a3c2d8e85f1.Insert(0, x03d68de1c2f74052);
	}

	private static void x96f455c7979a752f(x03d68de1c2f74051 xdafde7d9313c28e2, x03d68de1c2f74051 xc7e1dc7cb3b88874, x06fd9daa29391ff0 xf7b90603456caad3)
	{
		int x793941cecbedc2f = xf7b90603456caad3.x793941cecbedc2f2;
		int xd4eef988dd0bd = xf7b90603456caad3.xd4eef988dd0bd487;
		int x467ba1ccacfd2b6b = x41f7b0b43797e40c(xdafde7d9313c28e2, x793941cecbedc2f, xb53c342f6f760b8d: false);
		int num = x41f7b0b43797e40c(xdafde7d9313c28e2, x793941cecbedc2f, xb53c342f6f760b8d: true);
		int x467ba1ccacfd2b6b2 = x41f7b0b43797e40c(xc7e1dc7cb3b88874, xd4eef988dd0bd, xb53c342f6f760b8d: false);
		int num2 = x41f7b0b43797e40c(xc7e1dc7cb3b88874, xd4eef988dd0bd, xb53c342f6f760b8d: true);
		xb2f06c7846241795 x311b46c396890b2f = xec6a036612d5c47f(xdafde7d9313c28e2, x793941cecbedc2f, num);
		xb2f06c7846241795 x311b46c396890b2f2 = xec6a036612d5c47f(xc7e1dc7cb3b88874, xd4eef988dd0bd, x467ba1ccacfd2b6b2);
		PointF pointF = x0d0aa08710cb3bbd(x311b46c396890b2f);
		PointF pointF2 = x0d0aa08710cb3bbd(x311b46c396890b2f2);
		bool flag = xb2f06c7846241795.xcb5d0fc147e28bde(new xb2f06c7846241795(xdafde7d9313c28e2.get_xe6d4b1b411ed94b5(x793941cecbedc2f).x755f16bdf92ce7c4, xc7e1dc7cb3b88874.get_xe6d4b1b411ed94b5(xd4eef988dd0bd).x755f16bdf92ce7c4), new xb2f06c7846241795(pointF, pointF2));
		if (flag)
		{
			x311b46c396890b2f = xec6a036612d5c47f(xdafde7d9313c28e2, x793941cecbedc2f, x467ba1ccacfd2b6b);
			x311b46c396890b2f2 = xec6a036612d5c47f(xc7e1dc7cb3b88874, xd4eef988dd0bd, num2);
			pointF = x0d0aa08710cb3bbd(x311b46c396890b2f);
			pointF2 = x0d0aa08710cb3bbd(x311b46c396890b2f2);
		}
		if (pointF != PointF.Empty)
		{
			xdafde7d9313c28e2.x5c433c89069df74f(flag ? x793941cecbedc2f : num, new x319a5291e0303fb7(pointF));
		}
		if (pointF2 != PointF.Empty)
		{
			xc7e1dc7cb3b88874.x5c433c89069df74f(flag ? num2 : xd4eef988dd0bd, new x319a5291e0303fb7(pointF2));
		}
		num = x41f7b0b43797e40c(xdafde7d9313c28e2, x793941cecbedc2f, xb53c342f6f760b8d: true);
		num2 = x41f7b0b43797e40c(xc7e1dc7cb3b88874, xd4eef988dd0bd, xb53c342f6f760b8d: true);
		xdafde7d9313c28e2.x1db7da71f8033331(num, xc7e1dc7cb3b88874.xe10fc86bc53f5f64(num2));
	}

	private static x06fd9daa29391ff0 x948d6e71599a59f8(ArrayList xaaed4a3c2d8e85f1, int xbeb51874f32eb9c2)
	{
		x06fd9daa29391ff0 x06fd9daa29391ff = null;
		for (int i = 0; i < xaaed4a3c2d8e85f1.Count; i++)
		{
			if (xbeb51874f32eb9c2 != i)
			{
				x06fd9daa29391ff0 x06fd9daa29391ff2 = new x06fd9daa29391ff0((x03d68de1c2f74051)xaaed4a3c2d8e85f1[xbeb51874f32eb9c2], (x03d68de1c2f74051)xaaed4a3c2d8e85f1[i], xbeb51874f32eb9c2, i);
				if (x06fd9daa29391ff == null || x06fd9daa29391ff2.x58316dde3396e982 < x06fd9daa29391ff.x58316dde3396e982)
				{
					x06fd9daa29391ff = x06fd9daa29391ff2;
				}
			}
		}
		return x06fd9daa29391ff;
	}

	private static int x41f7b0b43797e40c(x03d68de1c2f74051 xe41c5c767887b961, int x77a4be227aff1505, bool xb53c342f6f760b8d)
	{
		if (!xb53c342f6f760b8d)
		{
			if (x77a4be227aff1505 != 0)
			{
				return x77a4be227aff1505 - 1;
			}
			return xe41c5c767887b961.xe161fd465603c384 - 1;
		}
		if (x77a4be227aff1505 != xe41c5c767887b961.xe161fd465603c384 - 1)
		{
			return x77a4be227aff1505 + 1;
		}
		return 0;
	}

	private static xb2f06c7846241795 xec6a036612d5c47f(x03d68de1c2f74051 xe41c5c767887b961, int x2bd4f7eeaedcdb8a, int x467ba1ccacfd2b6b)
	{
		return new xb2f06c7846241795(xe41c5c767887b961.get_xe6d4b1b411ed94b5(x2bd4f7eeaedcdb8a).x755f16bdf92ce7c4, xe41c5c767887b961.get_xe6d4b1b411ed94b5(x467ba1ccacfd2b6b).x755f16bdf92ce7c4);
	}

	private static PointF x0d0aa08710cb3bbd(xb2f06c7846241795 x311b46c396890b2f)
	{
		return x311b46c396890b2f.x61f22ac858654135(0.002f);
	}

	private static x03d68de1c2f74051 x48361165d808c135(x03d68de1c2f74051 xdafde7d9313c28e2, x03d68de1c2f74051 xc7e1dc7cb3b88874)
	{
		xdafde7d9313c28e2.x638f09a63b4c2c2c(x2c8de54beeb6f890: true);
		xc7e1dc7cb3b88874.x638f09a63b4c2c2c(x2c8de54beeb6f890: true);
		x03d68de1c2f74051 xdafde7d9313c28e3 = xdafde7d9313c28e2.x8b61531c8ea35b85();
		x03d68de1c2f74051 xc7e1dc7cb3b88875 = xc7e1dc7cb3b88874.x8b61531c8ea35b85();
		bool xdd0101b9b652fda = x0fe5daa5d8b0a214(xdafde7d9313c28e3, xc7e1dc7cb3b88875);
		return x613eb301015f212a(xdafde7d9313c28e3, xc7e1dc7cb3b88875, xdd0101b9b652fda, xdafde7d9313c28e2, xc7e1dc7cb3b88874);
	}

	private static x03d68de1c2f74051 x613eb301015f212a(x03d68de1c2f74051 xdafde7d9313c28e2, x03d68de1c2f74051 xc7e1dc7cb3b88874, bool xdd0101b9b652fda7, x03d68de1c2f74051 x79382d70c9fc7d23, x03d68de1c2f74051 xcba6c18798da23b2)
	{
		if (!xdd0101b9b652fda7)
		{
			x1ae70714edec817d x1ae70714edec817d2 = x5b1d198405d6e194(xdafde7d9313c28e2, xc7e1dc7cb3b88874);
			if (x1ae70714edec817d2.xe9e87df45862c20a == 1)
			{
				if (x1ae70714edec817d2.get_xe6d4b1b411ed94b5(0) != xdafde7d9313c28e2)
				{
					return x79382d70c9fc7d23;
				}
				return xcba6c18798da23b2;
			}
			return new x03d68de1c2f74051();
		}
		int[] array = new int[1];
		bool x3dc1716043f337e = xe5d0a9d48918fb4a(xdafde7d9313c28e2, xc7e1dc7cb3b88874, array);
		if (array[0] == -1)
		{
			return new x03d68de1c2f74051();
		}
		x03d68de1c2f74051 result = xb666742bae30a6fc(xdafde7d9313c28e2, xc7e1dc7cb3b88874, array[0], x3dc1716043f337e, x7518faed3f5307d5: true);
		xdafde7d9313c28e2.x36f62b8b1b3166e6();
		xc7e1dc7cb3b88874.x36f62b8b1b3166e6();
		return result;
	}

	private static bool xe5d0a9d48918fb4a(x03d68de1c2f74051 xdafde7d9313c28e2, x03d68de1c2f74051 xc7e1dc7cb3b88874, int[] xc0c4c459c6ccbd00)
	{
		int num = x5537cf265503a64a(xdafde7d9313c28e2, xc7e1dc7cb3b88874);
		if (num != -1)
		{
			xc0c4c459c6ccbd00[0] = num;
			return true;
		}
		xc0c4c459c6ccbd00[0] = x5537cf265503a64a(xc7e1dc7cb3b88874, xdafde7d9313c28e2);
		return false;
	}

	private static int x5537cf265503a64a(x03d68de1c2f74051 xe41c5c767887b961, x03d68de1c2f74051 xa8f411e8890e6549)
	{
		int result = -1;
		for (int i = 0; i < xe41c5c767887b961.xe161fd465603c384; i++)
		{
			if (xe41c5c767887b961.get_xe6d4b1b411ed94b5(i).x68953f97ddfd5344 == x534d8847b46a0ceb.x1918b9f101f092cb)
			{
				x319a5291e0303fb7 x319a5291e0303fb8 = xe41c5c767887b961.get_xe6d4b1b411ed94b5(xe41c5c767887b961.x5138ebdd7c56c151(i + 1));
				if (x319a5291e0303fb8.x68953f97ddfd5344 == x534d8847b46a0ceb.x1918b9f101f092cb || xa8f411e8890e6549.xa24831e4ed96f36e(x319a5291e0303fb8.x755f16bdf92ce7c4))
				{
					result = i;
					break;
				}
			}
		}
		return result;
	}
}

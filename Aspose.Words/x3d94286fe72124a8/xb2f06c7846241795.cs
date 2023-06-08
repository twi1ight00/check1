using System.Drawing;
using x6c95d9cf46ff5f25;

namespace x3d94286fe72124a8;

internal class xb2f06c7846241795 : x48cc0c3eaf9f5f05
{
	private readonly PointF x92be23f9da255ff5;

	private readonly PointF x1eb0f2079082dc31;

	private readonly float x823c6b25cc2689d8;

	internal float x1be93eed8950d961 => x37d2d88f96f87b47.x5af88e61b614ce62(x92be23f9da255ff5, x1eb0f2079082dc31);

	internal PointF xaf4e0fbe61814cf5 => x92be23f9da255ff5;

	internal PointF x2271dea312f4a835 => x1eb0f2079082dc31;

	internal xb2f06c7846241795(PointF startPoint, PointF endPoint)
		: base(startPoint, endPoint)
	{
		x92be23f9da255ff5 = startPoint;
		x1eb0f2079082dc31 = endPoint;
		x823c6b25cc2689d8 = x37d2d88f96f87b47.x5af88e61b614ce62(x92be23f9da255ff5, x1eb0f2079082dc31);
	}

	internal bool xb4ffd449b7335505(PointF x2f7096dac971d6ec)
	{
		if (x37d2d88f96f87b47.xd0fdca5aa42d16bc(x92be23f9da255ff5, x2f7096dac971d6ec) || x37d2d88f96f87b47.xd0fdca5aa42d16bc(x1eb0f2079082dc31, x2f7096dac971d6ec))
		{
			return true;
		}
		if (!xbd0a2eed2aaf0366(x2f7096dac971d6ec))
		{
			return false;
		}
		float num = x37d2d88f96f87b47.x5af88e61b614ce62(x92be23f9da255ff5, x2f7096dac971d6ec);
		if (num > x823c6b25cc2689d8)
		{
			return false;
		}
		if (base.x4d29b8b35306c675)
		{
			return x1eb0f2079082dc31.Y - x92be23f9da255ff5.Y > 0f == x2f7096dac971d6ec.Y - x92be23f9da255ff5.Y > 0f;
		}
		return x1eb0f2079082dc31.X - x92be23f9da255ff5.X > 0f == x2f7096dac971d6ec.X - x92be23f9da255ff5.X > 0f;
	}

	internal PointF x61f22ac858654135(float xf7b90603456caad3)
	{
		float num = x1be93eed8950d961;
		if (xf7b90603456caad3 < 0f || xf7b90603456caad3 > num)
		{
			return PointF.Empty;
		}
		if (xf7b90603456caad3 == 0f)
		{
			return xaf4e0fbe61814cf5;
		}
		if (x37d2d88f96f87b47.xe1aec5445964a68c(xf7b90603456caad3, num))
		{
			return x2271dea312f4a835;
		}
		bool flag = false;
		if ((base.x73539c44b735b7aa >= 0f && xaf4e0fbe61814cf5.X > x2271dea312f4a835.X) || (base.x73539c44b735b7aa < 0f && xaf4e0fbe61814cf5.X < x2271dea312f4a835.X) || (base.x4d29b8b35306c675 && xaf4e0fbe61814cf5.Y > x2271dea312f4a835.Y))
		{
			flag = true;
		}
		PointF[] array = new PointF[1] { PointF.Empty };
		x4a4f2059e53968cf(xaf4e0fbe61814cf5, xf7b90603456caad3 * (float)((!flag) ? 1 : (-1)), array);
		return array[0];
	}

	internal static bool x07aa36934bec95f1(xb2f06c7846241795 x0ee54d4c2d93d62c, xb2f06c7846241795 x569fd060c0a68d13, PointF[] x6fa2570084b2ad39, bool x0dc87af0058e6b62)
	{
		if (!x48cc0c3eaf9f5f05.x07aa36934bec95f1(x0ee54d4c2d93d62c, x569fd060c0a68d13, x6fa2570084b2ad39, x0dc87af0058e6b62))
		{
			return false;
		}
		if (x0ee54d4c2d93d62c.xb4ffd449b7335505(x6fa2570084b2ad39[0]) && x569fd060c0a68d13.xb4ffd449b7335505(x6fa2570084b2ad39[0]))
		{
			return true;
		}
		return false;
	}

	internal static bool x07aa36934bec95f1(xb2f06c7846241795 x0ee54d4c2d93d62c, x48cc0c3eaf9f5f05 x311e7a92306d7199, PointF[] x6fa2570084b2ad39, bool x0dc87af0058e6b62)
	{
		if (!x48cc0c3eaf9f5f05.x07aa36934bec95f1(x0ee54d4c2d93d62c, x311e7a92306d7199, x6fa2570084b2ad39, x0dc87af0058e6b62))
		{
			return false;
		}
		if (x0ee54d4c2d93d62c.xb4ffd449b7335505(x6fa2570084b2ad39[0]))
		{
			return true;
		}
		return false;
	}

	internal static bool xcb5d0fc147e28bde(xb2f06c7846241795 x0ee54d4c2d93d62c, xb2f06c7846241795 x569fd060c0a68d13)
	{
		return x07aa36934bec95f1(x0ee54d4c2d93d62c, x569fd060c0a68d13, new PointF[1] { PointF.Empty }, x0dc87af0058e6b62: true);
	}
}

using System.Collections;

namespace x2182451cabb5c30d;

internal class x49d9c71d05ebee3d
{
	private readonly xe5e546ef5f0503b2 x8cedcaa9a62c6e39;

	private x52108cac3d36b123 x9b529da35d1032aa;

	private readonly Stack x3d4b1a1699f2d6a4 = new Stack();

	internal x52108cac3d36b123 xffb3238a8fd59aa7
	{
		get
		{
			if (xd44988f225497f3a <= 0)
			{
				return x9b529da35d1032aa;
			}
			return (x52108cac3d36b123)x3d4b1a1699f2d6a4.Peek();
		}
	}

	internal x52108cac3d36b123 xcfc42ef22e03d2ce => xffb3238a8fd59aa7.xcfc42ef22e03d2ce;

	internal int xd44988f225497f3a => x3d4b1a1699f2d6a4.Count;

	internal x49d9c71d05ebee3d(xe5e546ef5f0503b2 context)
	{
		x8cedcaa9a62c6e39 = context;
		x9b529da35d1032aa = new x52108cac3d36b123(x8cedcaa9a62c6e39);
		x3d4b1a1699f2d6a4.Push(x9b529da35d1032aa);
	}

	internal void x1914eddf1fde1228(xbf575e106f2f2373 x86e1db1b4028be8b)
	{
		x9b529da35d1032aa = new x52108cac3d36b123(x8cedcaa9a62c6e39, xffb3238a8fd59aa7, x86e1db1b4028be8b);
		x3d4b1a1699f2d6a4.Push(x9b529da35d1032aa);
	}

	internal void x47c79a4d207183de()
	{
		x9b529da35d1032aa = (x52108cac3d36b123)x3d4b1a1699f2d6a4.Pop();
	}
}

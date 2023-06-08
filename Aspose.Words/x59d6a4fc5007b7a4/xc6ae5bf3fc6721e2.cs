using System.Drawing;
using Aspose.Words;
using x4adf554d20d941a6;
using x6c95d9cf46ff5f25;

namespace x59d6a4fc5007b7a4;

internal class xc6ae5bf3fc6721e2 : xb850ecb8335a2e09
{
	private Point xe79c881f80fec866 = Point.Empty;

	private readonly float x871b04f44d95866a;

	internal RectangleF xe74b2c668179aa09
	{
		get
		{
			x852fe8bb5ac31098 x852fe8bb5ac = (x852fe8bb5ac31098)x9fb0e9c0b1bdc4b3;
			if (x852fe8bb5ac.x76356d21d04ad431 || x852fe8bb5ac.x7149c962c02931b3 || !x852fe8bb5ac.x3c1c340351d94fbd.xf48cd6e82340ac70.x978429452a26becd)
			{
				return RectangleF.Empty;
			}
			int x849b3c2661d4477a = x852fe8bb5ac.x3c1c340351d94fbd.xf48cd6e82340ac70.x0d71ce357d91dc77[x852fe8bb5ac.xa7cb6e8d24f405a4.xa8c2682cb8534de2()] / 2;
			float x = (x852fe8bb5ac.x8786efe6471e0521 ? x1bd8431c755240f5(x849b3c2661d4477a) : x32c3472ae664223e(x849b3c2661d4477a));
			return new RectangleF(x, 0f, 1f, x871b04f44d95866a);
		}
	}

	internal override float x72d92bd1aff02e37 => x4574ea26106f0edb.xc96d70553223ee04(x9fb0e9c0b1bdc4b3.x8df91a2f90079e88 - xe79c881f80fec866.X);

	internal override float xe360b1885d8d4a41 => x4574ea26106f0edb.xc96d70553223ee04(x9fb0e9c0b1bdc4b3.xc821290d7ecc08bf - xe79c881f80fec866.Y);

	private x852fe8bb5ac31098 x4c38e800e85b21ad => (x852fe8bb5ac31098)x9fb0e9c0b1bdc4b3;

	internal xc6ae5bf3fc6721e2(x398b3bd0acd94b61 part, Point delta, float lineBetweenHeight)
		: base(part)
	{
		xe79c881f80fec866 = delta;
		x871b04f44d95866a = lineBetweenHeight;
	}

	internal override void x7012609bcdb39574(x3adba2572f6b9747 x672ff13faf031f3d)
	{
		x852fe8bb5ac31098 x852fe8bb5ac = (x852fe8bb5ac31098)x9fb0e9c0b1bdc4b3;
		x672ff13faf031f3d.x81b05dc513830622(this);
		xb850ecb8335a2e09.xa246eb87eda7b55d(x672ff13faf031f3d, x852fe8bb5ac.x8b8a0a04b3aeaf3a);
		x485635549ea46ebf(x672ff13faf031f3d, x852fe8bb5ac.x69d28a4aeef83a6f);
		x485635549ea46ebf(x672ff13faf031f3d, x852fe8bb5ac.xd90ac7fcbe961761);
		x672ff13faf031f3d.x8ebf847d0a00f979(this);
	}

	private static void x485635549ea46ebf(x3adba2572f6b9747 x672ff13faf031f3d, x78752dd11b777af5 xd7e5673853e47af4)
	{
		if (xd7e5673853e47af4 != null && !xd7e5673853e47af4.x7149c962c02931b3)
		{
			xd7e5673853e47af4.x43604484a3deae4f.x8df91a2f90079e88 = xd7e5673853e47af4.x8df91a2f90079e88;
			xd7e5673853e47af4.x43604484a3deae4f.xc821290d7ecc08bf = xd7e5673853e47af4.xc821290d7ecc08bf;
			xb850ecb8335a2e09 xd3311d815ca25f = new xb850ecb8335a2e09(xd7e5673853e47af4.x43604484a3deae4f);
			x672ff13faf031f3d.xdfc9ad174ecab9eb(xd3311d815ca25f);
			xb850ecb8335a2e09.xa246eb87eda7b55d(x672ff13faf031f3d, xd7e5673853e47af4.x43604484a3deae4f.x8b8a0a04b3aeaf3a);
			x672ff13faf031f3d.x3bd3c50d2c5e3ad7(xd3311d815ca25f);
			xb850ecb8335a2e09 xb850ecb8335a2e10 = new xb850ecb8335a2e09(xd7e5673853e47af4);
			xb850ecb8335a2e10.xe360b1885d8d4a41 += x4574ea26106f0edb.xc96d70553223ee04(xd7e5673853e47af4.x43604484a3deae4f.xb0f146032f47c24e);
			x672ff13faf031f3d.xdfc9ad174ecab9eb(xb850ecb8335a2e10);
			xb850ecb8335a2e09.xa246eb87eda7b55d(x672ff13faf031f3d, xd7e5673853e47af4.x8b8a0a04b3aeaf3a);
			x672ff13faf031f3d.x3bd3c50d2c5e3ad7(xb850ecb8335a2e10);
		}
	}

	internal RectangleF x1181ecbaa7830017(StoryType xdbbf47b5e620c262)
	{
		return x4574ea26106f0edb.xc96d70553223ee04(x4c38e800e85b21ad.x1181ecbaa7830017(xdbbf47b5e620c262));
	}

	private float x1bd8431c755240f5(int x849b3c2661d4477a)
	{
		return x72d92bd1aff02e37 + xdc1bf80853046136 + x4574ea26106f0edb.xc96d70553223ee04(x849b3c2661d4477a);
	}

	private float x32c3472ae664223e(int x849b3c2661d4477a)
	{
		return x72d92bd1aff02e37 - x4574ea26106f0edb.xc96d70553223ee04(x849b3c2661d4477a);
	}
}

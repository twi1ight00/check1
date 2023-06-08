using x6c95d9cf46ff5f25;

namespace x120d4bb5c80fb10c;

internal class x06fd9daa29391ff0
{
	private float x969a58dd03b1342f = float.MaxValue;

	private int x06224e0e0b177a2e;

	private int x195bbd7ed086a23b;

	private readonly int x6ef2e709ebf299d6;

	private readonly int xd9da5065bdaad20e;

	internal float x58316dde3396e982 => x969a58dd03b1342f;

	internal int x793941cecbedc2f2 => x06224e0e0b177a2e;

	internal int xd4eef988dd0bd487 => x195bbd7ed086a23b;

	internal int x1f15ffa1b12ab633 => x6ef2e709ebf299d6;

	internal int x38290c33d5098612 => xd9da5065bdaad20e;

	internal x06fd9daa29391ff0(x03d68de1c2f74051 polygon1, x03d68de1c2f74051 polygon2, int polygon1IndexInUnion, int polygon2IndexInUnion)
	{
		x6ef2e709ebf299d6 = polygon1IndexInUnion;
		xd9da5065bdaad20e = polygon2IndexInUnion;
		xbfbccd62eb82c84a(polygon1, polygon2);
	}

	private void xbfbccd62eb82c84a(x03d68de1c2f74051 xdafde7d9313c28e2, x03d68de1c2f74051 xc7e1dc7cb3b88874)
	{
		for (int i = 0; i < xdafde7d9313c28e2.xe161fd465603c384; i++)
		{
			for (int j = 0; j < xc7e1dc7cb3b88874.xe161fd465603c384; j++)
			{
				float num = x37d2d88f96f87b47.x5af88e61b614ce62(xdafde7d9313c28e2.get_xe6d4b1b411ed94b5(i).x755f16bdf92ce7c4, xc7e1dc7cb3b88874.get_xe6d4b1b411ed94b5(j).x755f16bdf92ce7c4);
				if (num < x969a58dd03b1342f)
				{
					x969a58dd03b1342f = num;
					x06224e0e0b177a2e = i;
					x195bbd7ed086a23b = j;
				}
			}
		}
	}
}

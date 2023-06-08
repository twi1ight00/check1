using System;
using x6c95d9cf46ff5f25;

namespace x66dd9eaee57cfba4;

internal class x954dd57976a05061 : x6c5a92230c2f59e2
{
	private readonly int xab1aa9a55818b87b;

	public int x448900fcb384c333 => xab1aa9a55818b87b;

	public x954dd57976a05061(int platformId, int encodingId, x09ce2c02826e31a6 charMap, int language)
		: base(platformId, encodingId, charMap)
	{
		xab1aa9a55818b87b = language;
	}

	public static x954dd57976a05061 x06b0e25aa6ad68a9(xa8866d7566da0aa2 xe134235b3526fa75, x84845c0d8e00bf00 x8881638314931eaa)
	{
		xe134235b3526fa75.x9e418ad9a56d1cf5.Position = x8881638314931eaa.xbe1e23e7d5b43370;
		xe134235b3526fa75.xdb264d863790ee7b();
		xe134235b3526fa75.xdb264d863790ee7b();
		xe134235b3526fa75.x95ea7d23cc8ee04d();
		int language = xe134235b3526fa75.x95ea7d23cc8ee04d();
		int num = xe134235b3526fa75.x95ea7d23cc8ee04d();
		x09ce2c02826e31a6 x09ce2c02826e31a = new x09ce2c02826e31a6();
		for (int i = 0; i < num; i++)
		{
			int num2 = xe134235b3526fa75.x95ea7d23cc8ee04d();
			int num3 = xe134235b3526fa75.x95ea7d23cc8ee04d();
			int num4 = xe134235b3526fa75.x95ea7d23cc8ee04d();
			if (num2 > num3 || num2 < 0 || num4 < 0)
			{
				throw new InvalidOperationException("Invalid Format12 'cmap' table entry.");
			}
			for (int j = num2; j <= num3; j++)
			{
				x09ce2c02826e31a.set_xe6d4b1b411ed94b5(j, (object)num4++);
			}
		}
		x09ce2c02826e31a.set_xe6d4b1b411ed94b5(65535, (object)0);
		return new x954dd57976a05061(x8881638314931eaa.xa6fc5ae695dd3435, x8881638314931eaa.xb120d6e4572c845b, x09ce2c02826e31a, language);
	}

	public override void Write(x73087173962e3778 writer)
	{
		writer.xb0c682b9901a2443(12);
		writer.xb0c682b9901a2443(0);
		writer.x6ff7c65ed4805c27(16 + 12 * base.xe6414aff183c47a1.xd44988f225497f3a);
		writer.x6ff7c65ed4805c27(xab1aa9a55818b87b);
		writer.x6ff7c65ed4805c27(base.xe6414aff183c47a1.xd44988f225497f3a);
		for (int i = 0; i < base.xe6414aff183c47a1.xd44988f225497f3a; i++)
		{
			int xbcea506a33cf = base.xe6414aff183c47a1.xf15263674eb297bb(i);
			int xbcea506a33cf2 = (int)base.xe6414aff183c47a1.x6d3720b962bd3112(i);
			writer.x6ff7c65ed4805c27(xbcea506a33cf);
			writer.x6ff7c65ed4805c27(xbcea506a33cf);
			writer.x6ff7c65ed4805c27(xbcea506a33cf2);
		}
	}
}

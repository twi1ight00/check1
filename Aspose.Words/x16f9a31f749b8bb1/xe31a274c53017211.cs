using System.IO;
using xa604c4d210ae0581;

namespace x16f9a31f749b8bb1;

internal class xe31a274c53017211 : x1d0ff20c6d05f948, xa38071b52e850907
{
	private xf8b5e62cf3165594 xfe54e3274b409600;

	internal static bool x492f529cee830a40;

	internal xe31a274c53017211(BinaryReader reader)
		: base(reader)
	{
	}

	internal void x06b0e25aa6ad68a9(xf8b5e62cf3165594 x290a8cdbc9dbb3c1)
	{
		xfe54e3274b409600 = x290a8cdbc9dbb3c1;
		x759e32a03439237a.x06b0e25aa6ad68a9(base.xf86de1bd2f396938, base.x73cd64f2630e68ba, this);
	}

	private void xb10f2c5426ecd7f6(BinaryReader xe134235b3526fa75, int xd59ec9a3f7a434cb, int x115e8b3958ad070b)
	{
		x4e1a1265364c495c x4e1a1265364c495c = new x4e1a1265364c495c(xe134235b3526fa75);
		_ = x492f529cee830a40;
		long position = xe134235b3526fa75.BaseStream.Position;
		try
		{
			x3ff949c473a702d2 xccb63ca5f63dc;
			if (x4e1a1265364c495c.xa7fd93208ce6c30b != 0)
			{
				long offset = base.x0a77cc42460213ba + x4e1a1265364c495c.xa7fd93208ce6c30b * 2;
				_ = x492f529cee830a40;
				xe134235b3526fa75.BaseStream.Seek(offset, SeekOrigin.Begin);
				xccb63ca5f63dc = new x3ff949c473a702d2(xe134235b3526fa75, isInFKP: true);
			}
			else
			{
				xccb63ca5f63dc = new x3ff949c473a702d2();
			}
			xfe54e3274b409600.xd6b6ed77479ef68c(xd59ec9a3f7a434cb, x115e8b3958ad070b, xccb63ca5f63dc);
		}
		finally
		{
			xe134235b3526fa75.BaseStream.Seek(position, SeekOrigin.Begin);
		}
	}

	void xa38071b52e850907.xa6a789f0e88511c3(BinaryReader xe134235b3526fa75, int xd59ec9a3f7a434cb, int x115e8b3958ad070b)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xb10f2c5426ecd7f6
		this.xb10f2c5426ecd7f6(xe134235b3526fa75, xd59ec9a3f7a434cb, x115e8b3958ad070b);
	}
}

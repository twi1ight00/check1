using System.IO;
using xa604c4d210ae0581;

namespace x16f9a31f749b8bb1;

internal class xdc4e21950f668b1f : x1d0ff20c6d05f948, xa38071b52e850907
{
	private xdb6ea7a460485a97 xedc9b5bc46353c3d;

	internal static bool x492f529cee830a40;

	internal xdc4e21950f668b1f(BinaryReader reader)
		: base(reader)
	{
	}

	internal void x06b0e25aa6ad68a9(xdb6ea7a460485a97 x143773bdbcddc306)
	{
		xedc9b5bc46353c3d = x143773bdbcddc306;
		x759e32a03439237a.x06b0e25aa6ad68a9(base.xf86de1bd2f396938, base.x73cd64f2630e68ba, this);
	}

	private void xb10f2c5426ecd7f6(BinaryReader xe134235b3526fa75, int xd59ec9a3f7a434cb, int x115e8b3958ad070b)
	{
		int num = xe134235b3526fa75.ReadByte();
		long position = xe134235b3526fa75.BaseStream.Position;
		try
		{
			x9dba795deb731d48 xccb63ca5f63dc;
			if (num != 0)
			{
				long offset = base.x0a77cc42460213ba + num * 2;
				xe134235b3526fa75.BaseStream.Seek(offset, SeekOrigin.Begin);
				xccb63ca5f63dc = new x9dba795deb731d48(xe134235b3526fa75, isInFKP: true);
			}
			else
			{
				xccb63ca5f63dc = new x9dba795deb731d48();
			}
			xedc9b5bc46353c3d.xd6b6ed77479ef68c(xd59ec9a3f7a434cb, x115e8b3958ad070b, xccb63ca5f63dc);
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

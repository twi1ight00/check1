using System.IO;
using xa604c4d210ae0581;

namespace xea819b8d8e4542a6;

internal class x60ed5de44ff5a65f : x456c8b07916a8790
{
	private readonly BinaryReader x7450cc1e48712286;

	private object xb277c46192ba7caa;

	private bool x77e5f07e886ef5ea;

	private int xc7a49c46bcac9bdb;

	internal bool xf50e7b664c72ba78 => x77e5f07e886ef5ea;

	internal int x6ecb6a2aa42199bb => (int)xb277c46192ba7caa;

	internal int x201455f59760aab0 => xc7a49c46bcac9bdb;

	internal int x17eca5ae06872a46 => (int)xb277c46192ba7caa - xc7a49c46bcac9bdb;

	internal bool x3ec58e06b4f761aa => xb277c46192ba7caa != null;

	internal x60ed5de44ff5a65f(BinaryReader dataReader)
	{
		x7450cc1e48712286 = dataReader;
	}

	internal void x06b0e25aa6ad68a9(byte[] x24c45257571ea504)
	{
		x77e5f07e886ef5ea = false;
		xb277c46192ba7caa = null;
		xc7a49c46bcac9bdb = 0;
		xd503583b32a53cea xd503583b32a53cea = new xd503583b32a53cea(this, x7450cc1e48712286);
		xd503583b32a53cea.x06b0e25aa6ad68a9(x24c45257571ea504);
	}

	private bool x9b1a5fd2bd42bd55(x875aca5784596b73 x28180b3c3774af93, x8de82539c936c298 xe780cde24dcce6f2, int x0d4f7f21e78721d6, BinaryReader xe134235b3526fa75)
	{
		if (x28180b3c3774af93 == x875aca5784596b73.x45d84ee9b173b612)
		{
			xb277c46192ba7caa = (int)xe134235b3526fa75.ReadInt16();
		}
		else if (x28180b3c3774af93 == x875aca5784596b73.xd959dd2c7aa008cc)
		{
			xc7a49c46bcac9bdb = xe134235b3526fa75.ReadInt16();
		}
		else
		{
			if (x28180b3c3774af93 == x875aca5784596b73.x79d0fad9e29c9f31)
			{
				x77e5f07e886ef5ea = true;
			}
			xe134235b3526fa75.ReadBytes(x0d4f7f21e78721d6);
		}
		return true;
	}

	bool x456c8b07916a8790.x09a3d4a7eac8f520(x875aca5784596b73 x28180b3c3774af93, x8de82539c936c298 xe780cde24dcce6f2, int x0d4f7f21e78721d6, BinaryReader xe134235b3526fa75)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x9b1a5fd2bd42bd55
		return this.x9b1a5fd2bd42bd55(x28180b3c3774af93, xe780cde24dcce6f2, x0d4f7f21e78721d6, xe134235b3526fa75);
	}
}

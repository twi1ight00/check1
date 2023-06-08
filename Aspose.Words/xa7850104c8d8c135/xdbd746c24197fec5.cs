using System;
using System.Drawing;
using System.IO;
using x13f1efc79617a47b;

namespace xa7850104c8d8c135;

internal class xdbd746c24197fec5
{
	private uint x824f14e92de69876;

	private short x4b088f70e8b96620;

	private short x933fbdb4e4f6c448;

	private short x51556d800a83de54;

	private short xed5d42e5ec2e2a9e;

	private short xc8ff13cb9454e1a9;

	private short xb10abf4f3d43bc69;

	private uint xb904d18ba713ce70;

	private short xaa32097f79659a6f;

	internal bool xbc6217e5154e192c
	{
		get
		{
			if (xed5d42e5ec2e2a9e - x933fbdb4e4f6c448 > 0)
			{
				return xc8ff13cb9454e1a9 - x51556d800a83de54 > 0;
			}
			return false;
		}
	}

	internal RectangleF x6ae4612a8469678e => new RectangleF(x933fbdb4e4f6c448, x51556d800a83de54, xed5d42e5ec2e2a9e - x933fbdb4e4f6c448, xc8ff13cb9454e1a9 - x51556d800a83de54);

	internal int x12a36b56521f3632 => xb10abf4f3d43bc69;

	internal xdbd746c24197fec5()
	{
	}

	internal void x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75)
	{
		x824f14e92de69876 = xe134235b3526fa75.ReadUInt32();
		x4b088f70e8b96620 = xe134235b3526fa75.ReadInt16();
		x933fbdb4e4f6c448 = xe134235b3526fa75.ReadInt16();
		x51556d800a83de54 = xe134235b3526fa75.ReadInt16();
		xed5d42e5ec2e2a9e = xe134235b3526fa75.ReadInt16();
		xc8ff13cb9454e1a9 = xe134235b3526fa75.ReadInt16();
		xb10abf4f3d43bc69 = xe134235b3526fa75.ReadInt16();
		xb904d18ba713ce70 = xe134235b3526fa75.ReadUInt32();
		xaa32097f79659a6f = xe134235b3526fa75.ReadInt16();
		x9fa888acc52ffb20();
	}

	private void x9fa888acc52ffb20()
	{
		short num = 0;
		num = (short)(num ^ (short)(x824f14e92de69876 & 0xFFFF));
		num = (short)(num ^ (short)((x824f14e92de69876 & 0xFFFF0000u) >> 16));
		num = (short)(num ^ x4b088f70e8b96620);
		num = (short)(num ^ x933fbdb4e4f6c448);
		num = (short)(num ^ x51556d800a83de54);
		num = (short)(num ^ xed5d42e5ec2e2a9e);
		num = (short)(num ^ xc8ff13cb9454e1a9);
		num = (short)(num ^ xb10abf4f3d43bc69);
		num = (short)(num ^ (short)(xb904d18ba713ce70 & 0xFFFF));
		num = (short)(num ^ (short)((xb904d18ba713ce70 & 0xFFFF0000u) >> 16));
		if (num != xaa32097f79659a6f)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("fkflklmlgmdmalkmclbnclinclpnikgoagnoakepcklpmjcahjjamjabbkhbakobfjfcfemcliddcjkdmdbeciieeipejigfbhnfjhegdhlglgchcdjh", 416200024)));
		}
	}
}

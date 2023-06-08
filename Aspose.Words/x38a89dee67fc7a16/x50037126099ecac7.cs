using System.IO;

namespace x38a89dee67fc7a16;

internal class x50037126099ecac7
{
	public const int xa230444f4711f2cc = 14;

	internal ushort x3146d638ec378671 = 19778;

	internal uint x437e3b626c0fdd43;

	internal ushort x5a31342e568cf755;

	internal ushort x974856e8e695b7e2;

	internal uint x990ff855f953a143;

	internal x50037126099ecac7()
	{
	}

	internal void x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75)
	{
		x3146d638ec378671 = xe134235b3526fa75.ReadUInt16();
		x437e3b626c0fdd43 = xe134235b3526fa75.ReadUInt32();
		x5a31342e568cf755 = xe134235b3526fa75.ReadUInt16();
		x974856e8e695b7e2 = xe134235b3526fa75.ReadUInt16();
		x990ff855f953a143 = xe134235b3526fa75.ReadUInt32();
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write((short)x3146d638ec378671);
		xbdfb620b7167944b.Write((int)x437e3b626c0fdd43);
		xbdfb620b7167944b.Write((short)x5a31342e568cf755);
		xbdfb620b7167944b.Write((short)x974856e8e695b7e2);
		xbdfb620b7167944b.Write((int)x990ff855f953a143);
	}
}

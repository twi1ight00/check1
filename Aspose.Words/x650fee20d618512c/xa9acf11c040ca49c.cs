using System.IO;
using x28925c9b27b37a46;

namespace x650fee20d618512c;

internal class xa9acf11c040ca49c
{
	internal int x86926a67348adc78;

	internal x74c5a2d6929342db xd0d3234fea469d3e;

	internal bool xac69d84f74b89ab0;

	internal xa9acf11c040ca49c()
	{
	}

	internal xa9acf11c040ca49c(BinaryReader reader)
	{
		x86926a67348adc78 = reader.ReadUInt16();
		int num = reader.ReadUInt16();
		xd0d3234fea469d3e = (x74c5a2d6929342db)(num & 0x1FFF);
		xac69d84f74b89ab0 = (num & 0x4000) != 0;
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write((ushort)x86926a67348adc78);
		int num = 0;
		num |= (int)xd0d3234fea469d3e;
		num |= 0x2000;
		num |= (xac69d84f74b89ab0 ? 16384 : 0);
		num |= ((!xac69d84f74b89ab0) ? 32768 : 0);
		xbdfb620b7167944b.Write((ushort)num);
	}
}

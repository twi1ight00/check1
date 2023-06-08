using System;
using System.IO;

namespace xcf014befd8b52c3b;

internal class xfcb24ed0e04e3b49
{
	internal int x397a0ed128412c8f;

	internal byte[] x005dbd4d94ca4423;

	internal byte[] x904f21ce603bf8df;

	internal int xbeb13e55b38b8ba3;

	internal byte[] xfaf76f2db63899a2;

	internal xfcb24ed0e04e3b49()
	{
	}

	internal xfcb24ed0e04e3b49(BinaryReader reader, bool isAes)
	{
		x397a0ed128412c8f = reader.ReadInt32();
		if (x397a0ed128412c8f != 16)
		{
			throw new InvalidOperationException("Unexpected salt size.");
		}
		x005dbd4d94ca4423 = reader.ReadBytes(x397a0ed128412c8f);
		x904f21ce603bf8df = reader.ReadBytes(16);
		xbeb13e55b38b8ba3 = reader.ReadInt32();
		xfaf76f2db63899a2 = reader.ReadBytes(isAes ? 32 : 20);
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write(16);
		xbdfb620b7167944b.Write(x005dbd4d94ca4423);
		xbdfb620b7167944b.Write(x904f21ce603bf8df);
		xbdfb620b7167944b.Write(20);
		xbdfb620b7167944b.Write(xfaf76f2db63899a2);
	}
}

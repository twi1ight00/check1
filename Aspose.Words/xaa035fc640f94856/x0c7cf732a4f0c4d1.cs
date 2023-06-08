using System.IO;
using xa604c4d210ae0581;

namespace xaa035fc640f94856;

internal class x0c7cf732a4f0c4d1 : xf67718a36ff889c3
{
	internal const int xa230444f4711f2cc = 6;

	internal int xff616fa638fdd6e3;

	internal int xebf45bdcaa1fd1e1;

	internal int x0363b0ac9a967bd2;

	internal x0c7cf732a4f0c4d1()
	{
	}

	internal x0c7cf732a4f0c4d1(BinaryReader reader)
	{
		xff616fa638fdd6e3 = reader.ReadUInt16();
		xebf45bdcaa1fd1e1 = reader.ReadUInt16();
		x0363b0ac9a967bd2 = reader.ReadInt16();
	}

	private void x85313d56ab6f266e(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write((ushort)xff616fa638fdd6e3);
		xbdfb620b7167944b.Write((ushort)xebf45bdcaa1fd1e1);
		xbdfb620b7167944b.Write((short)x0363b0ac9a967bd2);
	}

	void xf67718a36ff889c3.x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x85313d56ab6f266e
		this.x85313d56ab6f266e(xbdfb620b7167944b);
	}
}

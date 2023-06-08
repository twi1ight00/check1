using System.IO;
using xa604c4d210ae0581;

namespace xaa035fc640f94856;

internal class xf1e709b281c70a73 : xf67718a36ff889c3
{
	internal const int xa230444f4711f2cc = 4;

	internal int x59e3e1af7fa7fc44;

	internal int x0363b0ac9a967bd2;

	internal xf1e709b281c70a73()
	{
	}

	internal xf1e709b281c70a73(BinaryReader reader)
	{
		x59e3e1af7fa7fc44 = reader.ReadUInt16();
		x0363b0ac9a967bd2 = reader.ReadInt16();
	}

	private void x85313d56ab6f266e(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write((ushort)x59e3e1af7fa7fc44);
		xbdfb620b7167944b.Write((short)x0363b0ac9a967bd2);
	}

	void xf67718a36ff889c3.x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x85313d56ab6f266e
		this.x85313d56ab6f266e(xbdfb620b7167944b);
	}
}

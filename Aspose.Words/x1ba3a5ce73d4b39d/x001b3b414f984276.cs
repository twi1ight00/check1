using System.IO;
using xa604c4d210ae0581;

namespace x1ba3a5ce73d4b39d;

internal class x001b3b414f984276 : xf67718a36ff889c3
{
	internal const int xa230444f4711f2cc = 2;

	internal bool xa72bf798a679c0aa;

	internal x001b3b414f984276()
	{
	}

	internal x001b3b414f984276(BinaryReader reader)
	{
		xa72bf798a679c0aa = reader.ReadInt16() != 0;
	}

	private void x85313d56ab6f266e(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write((short)(xa72bf798a679c0aa ? 1 : 0));
	}

	void xf67718a36ff889c3.x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x85313d56ab6f266e
		this.x85313d56ab6f266e(xbdfb620b7167944b);
	}
}

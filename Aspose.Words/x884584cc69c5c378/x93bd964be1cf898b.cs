using System.IO;
using xa604c4d210ae0581;

namespace x884584cc69c5c378;

internal class x93bd964be1cf898b : xf67718a36ff889c3
{
	internal const int xa230444f4711f2cc = 6;

	internal int xd81f84c63877d333;

	internal int x59e6b81dfa7596de;

	internal int xebf45bdcaa1fd1e1;

	internal static bool x492f529cee830a40;

	internal x93bd964be1cf898b()
	{
	}

	internal x93bd964be1cf898b(BinaryReader reader)
	{
		x06b0e25aa6ad68a9(reader);
	}

	internal void x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75)
	{
		xd81f84c63877d333 = xe134235b3526fa75.ReadInt16();
		x59e6b81dfa7596de = xe134235b3526fa75.ReadInt16();
		xebf45bdcaa1fd1e1 = xe134235b3526fa75.ReadInt16();
		_ = x492f529cee830a40;
	}

	private void x85313d56ab6f266e(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write((short)xd81f84c63877d333);
		xbdfb620b7167944b.Write((short)x59e6b81dfa7596de);
		xbdfb620b7167944b.Write((short)xebf45bdcaa1fd1e1);
	}

	void xf67718a36ff889c3.x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x85313d56ab6f266e
		this.x85313d56ab6f266e(xbdfb620b7167944b);
	}
}

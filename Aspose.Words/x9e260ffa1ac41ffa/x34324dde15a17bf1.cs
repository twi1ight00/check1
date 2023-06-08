using System.IO;
using System.Text;
using x26869753cb97bfe9;
using xa604c4d210ae0581;
using xaa035fc640f94856;

namespace x9e260ffa1ac41ffa;

internal class x34324dde15a17bf1
{
	private readonly x9e131021ba70185c x7a1a247785b9a739;

	private readonly xf8b5e62cf3165594 x33b93318db8db4ed = new xf8b5e62cf3165594();

	private readonly xdb6ea7a460485a97 x43a58bc2c9b1fd20 = new xdb6ea7a460485a97();

	private readonly xc9072e4c3fa520ad xf4534a93f13f6ff3 = new xc9072e4c3fa520ad(2);

	private readonly x2b702525301ee74a x4bd039d469a1155d = new x2b702525301ee74a();

	private readonly x31a5ab258b5c21f3 x6b14c9185a3728ac = new x31a5ab258b5c21f3();

	private readonly x39a0e849afa5b554 x20429b97275cb2fb = new x39a0e849afa5b554();

	private readonly xd078c45cd488fe12 xd2a1236e4f89a0e2 = new xd078c45cd488fe12();

	private readonly StringBuilder xed4a7b1500064e12 = new StringBuilder();

	private int xc384acb8ea9a831e;

	internal x9e131021ba70185c x9e131021ba70185c => x7a1a247785b9a739;

	internal xf8b5e62cf3165594 xf8b5e62cf3165594 => x33b93318db8db4ed;

	internal xdb6ea7a460485a97 xdb6ea7a460485a97 => x43a58bc2c9b1fd20;

	internal xc9072e4c3fa520ad x84aa3570d857bec4 => xf4534a93f13f6ff3;

	internal x2b702525301ee74a xeafe18c850ae3127 => x4bd039d469a1155d;

	internal x31a5ab258b5c21f3 xd0816c20f484d380 => x6b14c9185a3728ac;

	internal x39a0e849afa5b554 x79d596439da1c44b => x20429b97275cb2fb;

	internal xd078c45cd488fe12 x32cf407a95cab3cd => xd2a1236e4f89a0e2;

	internal StringBuilder xf9ad6fb78355fe13 => xed4a7b1500064e12;

	internal int x1be93eed8950d961 => xed4a7b1500064e12.Length;

	internal int xb8414804f39a9e90 => xc384acb8ea9a831e;

	internal x34324dde15a17bf1(x9e131021ba70185c subDocType)
	{
		x7a1a247785b9a739 = subDocType;
	}

	internal void x5e3f44647fcfb8fc()
	{
		xc384acb8ea9a831e++;
	}

	internal void xbdbbc98113b6b783()
	{
		xc384acb8ea9a831e--;
	}

	internal void x692f3f46f8381b0f(int x5808173d78349062)
	{
		x33b93318db8db4ed.xd6b6ed77479ef68c(xed4a7b1500064e12.Length);
		xf4534a93f13f6ff3.xd6b6ed77479ef68c(x5808173d78349062);
	}

	internal int x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		for (int i = 0; i < xed4a7b1500064e12.Length; i++)
		{
			char c = xed4a7b1500064e12[i];
			xbdfb620b7167944b.Write((byte)c);
			xbdfb620b7167944b.Write((byte)((int)c >> 8));
		}
		return xed4a7b1500064e12.Length;
	}
}

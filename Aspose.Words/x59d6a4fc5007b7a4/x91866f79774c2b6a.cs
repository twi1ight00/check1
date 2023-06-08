using System.Collections;
using Aspose.Words;
using x28925c9b27b37a46;

namespace x59d6a4fc5007b7a4;

internal class x91866f79774c2b6a
{
	private readonly xa1a7cce7c5e4a4dc xb14db7591535b378;

	private readonly xd557958daa1f35fe x3c7daf51148ad769 = new xd557958daa1f35fe();

	internal xa1a7cce7c5e4a4dc xa1a7cce7c5e4a4dc => xb14db7591535b378;

	internal xd557958daa1f35fe xd557958daa1f35fe => x3c7daf51148ad769;

	internal x91866f79774c2b6a(RunCollection runs)
	{
		xb14db7591535b378 = new xa1a7cce7c5e4a4dc(xb56d9fb9d2a4a755(runs));
	}

	internal x91866f79774c2b6a(x7e263f21a73a027a nodes)
	{
		xb14db7591535b378 = new xa1a7cce7c5e4a4dc(xb56d9fb9d2a4a755(nodes));
	}

	private static string[] xb56d9fb9d2a4a755(IEnumerable xa955664f4f50999d)
	{
		Run xd9ff4dee1dba180e = null;
		ArrayList arrayList = new ArrayList();
		foreach (Node item in xa955664f4f50999d)
		{
			if (item.NodeType == NodeType.Run)
			{
				arrayList.Add(x633d57e35b6715a4((Run)item, xd9ff4dee1dba180e));
				xd9ff4dee1dba180e = (Run)item;
			}
		}
		return (string[])arrayList.ToArray(typeof(string));
	}

	private static string x633d57e35b6715a4(Run x3bd62873fafa6252, Run xd9ff4dee1dba180e)
	{
		string text = x3bd62873fafa6252.Text;
		if (xd9ff4dee1dba180e == null || xd9ff4dee1dba180e.Text == "" || text == "")
		{
			return text;
		}
		char xb867a42da3ae686d = xd9ff4dee1dba180e.Text[xd9ff4dee1dba180e.Text.Length - 1];
		char xb867a42da3ae686d2 = text[0];
		if (x34a37b5a89c466fd.x4c57b971f1a8d64d(xb867a42da3ae686d) && x34a37b5a89c466fd.x4c57b971f1a8d64d(xb867a42da3ae686d2) && !x2500d0f16e604ed3(xd9ff4dee1dba180e.xeedad81aaed42a76, x3bd62873fafa6252.xeedad81aaed42a76))
		{
			return '\u200c' + x3bd62873fafa6252.Text;
		}
		return text;
	}

	private static bool x2500d0f16e604ed3(xeedad81aaed42a76 xa447fc54e41dfe06, xeedad81aaed42a76 xfc2074a859a5db8c)
	{
		if (xa447fc54e41dfe06.xcedf9c82728ad579 == xfc2074a859a5db8c.xcedf9c82728ad579 && xa447fc54e41dfe06.xf3d194b4e6a2594a == xfc2074a859a5db8c.xf3d194b4e6a2594a && xa447fc54e41dfe06.xa7229a54449aaf49 == xfc2074a859a5db8c.xa7229a54449aaf49 && xa447fc54e41dfe06.x3312403c03667693 == xfc2074a859a5db8c.x3312403c03667693)
		{
			return xa447fc54e41dfe06.xab4229188249d97a == xfc2074a859a5db8c.xab4229188249d97a;
		}
		return false;
	}
}

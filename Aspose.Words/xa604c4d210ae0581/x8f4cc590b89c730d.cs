using System;
using System.Collections;
using System.IO;
using System.Reflection;
using x13f1efc79617a47b;

namespace xa604c4d210ae0581;

[DefaultMember("Item")]
internal class x8f4cc590b89c730d : xa38071b52e850907
{
	private readonly ArrayList x82b70567a5f68f41 = new ArrayList();

	private readonly xfff3a61dfa7055ba x9b7b7b9cf77f2ab1 = new xfff3a61dfa7055ba();

	private readonly BinaryReader xd5f978e76777d3f3;

	internal static bool x492f529cee830a40;

	internal xc77edd00162b84f4 xe6d4b1b411ed94b5 => (xc77edd00162b84f4)x82b70567a5f68f41[xc0c4c459c6ccbd00];

	internal int xd44988f225497f3a => x82b70567a5f68f41.Count;

	internal x8f4cc590b89c730d()
	{
	}

	internal x8f4cc590b89c730d(x8aeace2bf92692ab fib, BinaryReader tableStreamReader)
	{
		if (fib.x955a03f821588c52.x84d66a6d1fa468c7.x04c290dc4d04369c > 0)
		{
			xd5f978e76777d3f3 = tableStreamReader;
			tableStreamReader.BaseStream.Seek(fib.x955a03f821588c52.x84d66a6d1fa468c7.xe53f0e68147463d1, SeekOrigin.Begin);
			while (true)
			{
				switch (tableStreamReader.ReadByte())
				{
				case 1:
					break;
				case 2:
					xc7af7148d9b4b511();
					return;
				default:
					throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jkjeplafjlhfjlofhlfgmlmgaldhpfkhckbiikiiikpiakgjbjnjbkekkelkgjclkijlbeamcjhmdiomnhfnfdmncidoihkobhbpmgiplgppdcgaehnaofebmflbdgccjfjcpbad", 1813334356)));
				}
				int grpprlSize = tableStreamReader.ReadInt16();
				x9b7b7b9cf77f2ab1.Add(new x32939c68497cb083(tableStreamReader, grpprlSize));
			}
		}
		x82b70567a5f68f41.Add(new xc77edd00162b84f4(0, fib.x3ab228b2748114ba, fib.xfc37d20436abe4da, isUnicode: false));
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		xc9072e4c3fa520ad xc9072e4c3fa520ad2 = new xc9072e4c3fa520ad(xc77edd00162b84f4.xa230444f4711f2cc);
		foreach (xc77edd00162b84f4 item in x82b70567a5f68f41)
		{
			xc9072e4c3fa520ad2.xd6b6ed77479ef68c(item.x76bcde38a5a4c721.x12cb12b5d2cad53d, item.x76bcde38a5a4c721.x9fd888e65466818c, item);
		}
		xbdfb620b7167944b.Write((byte)2);
		xbdfb620b7167944b.Write((uint)xc9072e4c3fa520ad2.x437e3b626c0fdd43);
		xc9072e4c3fa520ad2.x6210059f049f0d48(xbdfb620b7167944b);
	}

	internal int x6e603e71a5cebe44(int x18d1054d82981887)
	{
		for (int i = 0; i < x82b70567a5f68f41.Count; i++)
		{
			xc77edd00162b84f4 xc77edd00162b84f5 = this.get_xe6d4b1b411ed94b5(i);
			if (xc77edd00162b84f5.x76bcde38a5a4c721.x263d579af1d0d43f(x18d1054d82981887))
			{
				return i;
			}
		}
		return -1;
	}

	private void xc7af7148d9b4b511()
	{
		int xa5750de2465a751c = xd5f978e76777d3f3.ReadInt32();
		x759e32a03439237a.x06b0e25aa6ad68a9(xd5f978e76777d3f3, xa5750de2465a751c, xc77edd00162b84f4.xa230444f4711f2cc, this, "PlcfPcd");
	}

	private void xb10f2c5426ecd7f6(BinaryReader xe134235b3526fa75, int xd59ec9a3f7a434cb, int x115e8b3958ad070b)
	{
		xc77edd00162b84f4 value = new xc77edd00162b84f4(xe134235b3526fa75, xd59ec9a3f7a434cb, x115e8b3958ad070b, x9b7b7b9cf77f2ab1);
		x82b70567a5f68f41.Add(value);
		_ = x492f529cee830a40;
	}

	void xa38071b52e850907.xa6a789f0e88511c3(BinaryReader xe134235b3526fa75, int xd59ec9a3f7a434cb, int x115e8b3958ad070b)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xb10f2c5426ecd7f6
		this.xb10f2c5426ecd7f6(xe134235b3526fa75, xd59ec9a3f7a434cb, x115e8b3958ad070b);
	}

	internal int xd6b6ed77479ef68c(xc77edd00162b84f4 xbfdac581682856b2)
	{
		return x82b70567a5f68f41.Add(xbfdac581682856b2);
	}
}

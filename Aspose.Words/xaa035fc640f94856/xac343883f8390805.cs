using System.Collections;
using System.IO;
using System.Reflection;
using xa604c4d210ae0581;

namespace xaa035fc640f94856;

[DefaultMember("Item")]
internal class xac343883f8390805 : IEnumerable
{
	private readonly ArrayList x82b70567a5f68f41 = new ArrayList();

	public x2e009080ad086857 xe6d4b1b411ed94b5 => (x2e009080ad086857)x82b70567a5f68f41[xc0c4c459c6ccbd00];

	internal int xd44988f225497f3a => x82b70567a5f68f41.Count;

	internal void x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75, x3fdb33c580a0bef3 x8046fc97e35e71d5)
	{
		if (x8046fc97e35e71d5.x04c290dc4d04369c != 0)
		{
			xe134235b3526fa75.BaseStream.Position = x8046fc97e35e71d5.xe53f0e68147463d1;
			int num = xe134235b3526fa75.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				x82b70567a5f68f41.Add(new x2e009080ad086857(xe134235b3526fa75));
			}
		}
	}

	internal x3fdb33c580a0bef3 x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		int num = (int)xbdfb620b7167944b.BaseStream.Position;
		xbdfb620b7167944b.Write(x82b70567a5f68f41.Count);
		foreach (x2e009080ad086857 item in x82b70567a5f68f41)
		{
			item.x6210059f049f0d48(xbdfb620b7167944b);
		}
		return new x3fdb33c580a0bef3(num, (int)(xbdfb620b7167944b.BaseStream.Position - num));
	}

	internal void xd6b6ed77479ef68c(x4c71ca8ed34db1c3 xa483dbadf7c7aa2f)
	{
		x82b70567a5f68f41.Add(xa483dbadf7c7aa2f);
	}

	public IEnumerator GetEnumerator()
	{
		return x82b70567a5f68f41.GetEnumerator();
	}

	internal int xe17ab9700f197029(string xbda579af315c6893)
	{
		x2e009080ad086857 x2e009080ad86858;
		for (int i = 0; i < x82b70567a5f68f41.Count; i++)
		{
			x2e009080ad86858 = (x2e009080ad086857)x82b70567a5f68f41[i];
			if (x2e009080ad86858.xb405a444ca77e2d4 == xbda579af315c6893)
			{
				return i;
			}
		}
		x2e009080ad86858 = new x2e009080ad086857(xbda579af315c6893);
		x82b70567a5f68f41.Add(x2e009080ad86858);
		return x82b70567a5f68f41.Count - 1;
	}
}

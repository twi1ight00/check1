using System.Collections;
using System.IO;
using System.Reflection;
using xa604c4d210ae0581;

namespace xaa035fc640f94856;

[DefaultMember("Item")]
internal class xeab2ca1efdce6a65 : IEnumerable
{
	private readonly ArrayList x82b70567a5f68f41 = new ArrayList();

	public x4c71ca8ed34db1c3 xe6d4b1b411ed94b5 => (x4c71ca8ed34db1c3)x82b70567a5f68f41[xc0c4c459c6ccbd00];

	internal int xd44988f225497f3a => x82b70567a5f68f41.Count;

	internal void x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75, x3fdb33c580a0bef3 x647dcec2a1df44a2)
	{
		if (x647dcec2a1df44a2.x04c290dc4d04369c != 0)
		{
			xe134235b3526fa75.BaseStream.Position = x647dcec2a1df44a2.xe53f0e68147463d1;
			xe134235b3526fa75.ReadUInt16();
			int num = xe134235b3526fa75.ReadInt32();
			xe134235b3526fa75.ReadInt16();
			for (int i = 0; i < num; i++)
			{
				x82b70567a5f68f41.Add(new x4c71ca8ed34db1c3(xe134235b3526fa75));
			}
		}
	}

	internal x3fdb33c580a0bef3 x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		int num = 1;
		int num2 = (int)xbdfb620b7167944b.BaseStream.Position;
		xbdfb620b7167944b.Write(ushort.MaxValue);
		xbdfb620b7167944b.Write(x82b70567a5f68f41.Count);
		xbdfb620b7167944b.Write((ushort)0);
		foreach (x4c71ca8ed34db1c3 item in x82b70567a5f68f41)
		{
			item.x6210059f049f0d48(xbdfb620b7167944b, num++);
		}
		return new x3fdb33c580a0bef3(num2, (int)(xbdfb620b7167944b.BaseStream.Position - num2));
	}

	internal void xd6b6ed77479ef68c(x4c71ca8ed34db1c3 xa483dbadf7c7aa2f)
	{
		x82b70567a5f68f41.Add(xa483dbadf7c7aa2f);
	}

	public IEnumerator GetEnumerator()
	{
		return x82b70567a5f68f41.GetEnumerator();
	}
}

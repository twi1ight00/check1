using System.Collections;
using System.IO;
using System.Reflection;
using System.Text;

namespace xb92b7270f78a4e8d;

[DefaultMember("Item")]
internal class x41ac37a3e855c773
{
	private readonly ArrayList x82b70567a5f68f41 = new ArrayList();

	internal xd686a7cfdb7bddb2 xe6d4b1b411ed94b5
	{
		get
		{
			return (xd686a7cfdb7bddb2)x82b70567a5f68f41[(int)xc0c4c459c6ccbd00];
		}
		set
		{
			x82b70567a5f68f41[(int)xc0c4c459c6ccbd00] = value;
		}
	}

	internal int xd44988f225497f3a => x82b70567a5f68f41.Count;

	internal void xd6b6ed77479ef68c(xd686a7cfdb7bddb2 x2451e88e57006ea5)
	{
		x82b70567a5f68f41.Add(x2451e88e57006ea5);
	}

	internal xd686a7cfdb7bddb2 xb0080c4621a1d053(string xc15bd84e01929885)
	{
		xd686a7cfdb7bddb2 xa85f9dbcec37a9e = x856a7e9b6bed6a7a(this.get_xe6d4b1b411ed94b5(0u), this.get_xe6d4b1b411ed94b5(0u).xafe684f748981f4f);
		return x0c6f2abcb879d8f2(xa85f9dbcec37a9e, xc15bd84e01929885);
	}

	private xd686a7cfdb7bddb2 x0c6f2abcb879d8f2(xd686a7cfdb7bddb2 xa85f9dbcec37a9e8, string xc15bd84e01929885)
	{
		if (xa85f9dbcec37a9e8.x759aa16c2016a289 == xc15bd84e01929885)
		{
			return xa85f9dbcec37a9e8;
		}
		xd686a7cfdb7bddb2 xd686a7cfdb7bddb3 = x856a7e9b6bed6a7a(xa85f9dbcec37a9e8, xa85f9dbcec37a9e8.xf469c807ba339d90);
		if (xd686a7cfdb7bddb3 != null)
		{
			xd686a7cfdb7bddb2 xd686a7cfdb7bddb4 = x0c6f2abcb879d8f2(xd686a7cfdb7bddb3, xc15bd84e01929885);
			if (xd686a7cfdb7bddb4 != null)
			{
				return xd686a7cfdb7bddb4;
			}
		}
		xd686a7cfdb7bddb2 xd686a7cfdb7bddb5 = x856a7e9b6bed6a7a(xa85f9dbcec37a9e8, xa85f9dbcec37a9e8.xcb628eae42e96691);
		if (xd686a7cfdb7bddb5 != null)
		{
			xd686a7cfdb7bddb2 xd686a7cfdb7bddb6 = x0c6f2abcb879d8f2(xd686a7cfdb7bddb5, xc15bd84e01929885);
			if (xd686a7cfdb7bddb6 != null)
			{
				return xd686a7cfdb7bddb6;
			}
		}
		return null;
	}

	internal xd686a7cfdb7bddb2 x856a7e9b6bed6a7a(xd686a7cfdb7bddb2 xf843659cd86e454f, uint x5ee9473dd019e764)
	{
		if (x5ee9473dd019e764 != uint.MaxValue && x5ee9473dd019e764 >= 0 && x5ee9473dd019e764 < x82b70567a5f68f41.Count && xf843659cd86e454f != this.get_xe6d4b1b411ed94b5(x5ee9473dd019e764))
		{
			return this.get_xe6d4b1b411ed94b5(x5ee9473dd019e764);
		}
		return null;
	}

	internal MemoryStream x0fe354a7e0ea7cc1()
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter xbdfb620b7167944b = new BinaryWriter(memoryStream, Encoding.Unicode);
		for (uint num = 0u; num < x82b70567a5f68f41.Count; num++)
		{
			this.get_xe6d4b1b411ed94b5(num).x6210059f049f0d48(xbdfb620b7167944b);
		}
		xd686a7cfdb7bddb2 xd686a7cfdb7bddb3 = new xd686a7cfdb7bddb2();
		while (memoryStream.Length % 512 != 0)
		{
			xd686a7cfdb7bddb3.x6210059f049f0d48(xbdfb620b7167944b);
		}
		return memoryStream;
	}
}

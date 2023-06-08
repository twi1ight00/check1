using System.Collections;
using System.IO;

namespace xa604c4d210ae0581;

internal class xb4278d25e0406614 : x6f211c5eac49c71c
{
	private readonly ArrayList x82b70567a5f68f41 = new ArrayList();

	internal string x72bca3f242b46d61(int x6f148b4649a10af0)
	{
		foreach (x67d187312abd4ca2 item in x82b70567a5f68f41)
		{
			if (item.x6f148b4649a10af0 == x6f148b4649a10af0)
			{
				return item.x759aa16c2016a289;
			}
		}
		return "";
	}

	internal int x3710c228da65de24(int xb4c9e2efc36c84fb, string xbcea506a33cf9111)
	{
		x67d187312abd4ca2 x67d187312abd4ca3 = new x67d187312abd4ca2();
		int count = x82b70567a5f68f41.Count;
		x67d187312abd4ca3.x6f148b4649a10af0 = xb4c9e2efc36c84fb | (count << 4);
		x67d187312abd4ca3.x4c7cddb8e85a71d7 = 255;
		x67d187312abd4ca3.x759aa16c2016a289 = xbcea506a33cf9111;
		x82b70567a5f68f41.Add(x67d187312abd4ca3);
		return x67d187312abd4ca3.x6f148b4649a10af0;
	}

	protected override void DoReadExtraData(string name, BinaryReader dataReader)
	{
		x67d187312abd4ca2 value = new x67d187312abd4ca2(name, dataReader);
		x82b70567a5f68f41.Add(value);
	}

	protected override int DoGetCountForWrite()
	{
		return x82b70567a5f68f41.Count;
	}

	protected override int DoGetExtraDataSize()
	{
		return 8;
	}

	protected override void DoWrite(BinaryWriter writer)
	{
		foreach (x67d187312abd4ca2 item in x82b70567a5f68f41)
		{
			x6f211c5eac49c71c.x3d1be38abe5723e3(item.x759aa16c2016a289, writer);
			item.x6210059f049f0d48(writer);
		}
	}
}

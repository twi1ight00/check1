using System.Collections;
using System.IO;
using System.Reflection;
using xa604c4d210ae0581;

namespace x681ccae5509c120d;

[DefaultMember("Item")]
internal class x38fe1b2a1bc6e0a4 : x6f211c5eac49c71c
{
	private readonly ArrayList x82b70567a5f68f41 = new ArrayList();

	internal int xe6d4b1b411ed94b5 => (int)x82b70567a5f68f41[xc0c4c459c6ccbd00];

	internal void xd6b6ed77479ef68c(int xeaf1b27180c0557b)
	{
		x82b70567a5f68f41.Add(xeaf1b27180c0557b);
	}

	protected override void DoReadExtraData(string name, BinaryReader dataReader)
	{
		dataReader.ReadUInt16();
		int num = dataReader.ReadInt32();
		x82b70567a5f68f41.Add(num);
		dataReader.ReadInt32();
	}

	protected override int DoGetCountForWrite()
	{
		return x82b70567a5f68f41.Count;
	}

	protected override int DoGetExtraDataSize()
	{
		return 10;
	}

	protected override void DoWrite(BinaryWriter writer)
	{
		foreach (int item in x82b70567a5f68f41)
		{
			x6f211c5eac49c71c.x3d1be38abe5723e3("", writer);
			writer.Write((short)256);
			writer.Write(item);
			writer.Write(-1);
		}
	}
}

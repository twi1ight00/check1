using System.IO;
using xa604c4d210ae0581;

namespace xcf014befd8b52c3b;

internal class x351441d1224241db
{
	internal x483d31a3017e817e x586b7652ac7cefe0;

	internal int x10cf8c7858f2e671;

	internal x9fbc9ab2fdb5f016 x4a502afaa8a41dce;

	internal x2e723c1a88f20a3b xb359f8e393e64393;

	internal int xcdfb13d91a75535a;

	internal int x2215ae2d7e6a4571;

	internal string x626a3bfbb12d8e15;

	internal x351441d1224241db(BinaryReader reader)
	{
		int num = reader.ReadInt32();
		x586b7652ac7cefe0 = (x483d31a3017e817e)reader.ReadInt32();
		x10cf8c7858f2e671 = reader.ReadInt32();
		x4a502afaa8a41dce = (x9fbc9ab2fdb5f016)reader.ReadInt32();
		xb359f8e393e64393 = (x2e723c1a88f20a3b)reader.ReadInt32();
		xcdfb13d91a75535a = reader.ReadInt32();
		x2215ae2d7e6a4571 = reader.ReadInt32();
		reader.ReadInt32();
		reader.ReadInt32();
		x626a3bfbb12d8e15 = x93b05c1ad709a695.x79739b9c4ddc2495(reader, num - 32);
	}
}

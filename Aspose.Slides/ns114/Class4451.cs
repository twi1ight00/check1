using ns108;
using ns112;

namespace ns114;

internal class Class4451
{
	private Class4449 class4449_0;

	public Class4451(Class4449 writer)
	{
		class4449_0 = writer;
	}

	internal void Write(Class4439 cffIndex, long offset)
	{
		class4449_0.Seek(offset);
		class4449_0.method_2((ushort)cffIndex.ObjectsCount);
		if (cffIndex.ObjectsCount > 0)
		{
			class4449_0.method_3(cffIndex.OffsetSize);
			for (int i = 0; i <= cffIndex.ObjectsCount; i++)
			{
				class4449_0.method_4(cffIndex.OffsetSize, cffIndex.Offsets[i]);
			}
			for (int j = 0; j < cffIndex.IndexData.Length; j++)
			{
				class4449_0.method_0(cffIndex.IndexData[j]);
			}
		}
	}
}

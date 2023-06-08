using ns108;

namespace ns112;

internal class Class4440
{
	private Class4437 class4437_0;

	public Class4440(Class4437 reader)
	{
		class4437_0 = reader;
	}

	internal void method_0(Class4439 cffIndex)
	{
		cffIndex.IndexBeginOffset = class4437_0.Position;
		cffIndex.ObjectsCount = class4437_0.method_2();
		if (cffIndex.ObjectsCount > 0)
		{
			cffIndex.OffsetSize = class4437_0.method_3();
			cffIndex.Offsets = new int[cffIndex.ObjectsCount + 1];
			for (int i = 0; i <= cffIndex.ObjectsCount; i++)
			{
				cffIndex.Offsets[i] = class4437_0.method_4(cffIndex.OffsetSize);
			}
			int num = cffIndex.Offsets[cffIndex.Offsets.Length - 1];
			int num2 = num - 1;
			cffIndex.IndexData = new byte[num2];
			for (int j = 0; j < cffIndex.IndexData.Length; j++)
			{
				cffIndex.IndexData[j] = class4437_0.method_0();
			}
		}
		cffIndex.IndexEndOffset = class4437_0.Position - 1L;
	}
}

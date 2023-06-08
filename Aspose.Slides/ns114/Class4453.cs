using System.IO;
using ns108;
using ns112;
using ns116;
using ns126;

namespace ns114;

internal class Class4453
{
	public byte[] method_0(Class4452 shifts, Class4439 topDictOriginal)
	{
		Class4450 @class = new Class4450(topDictOriginal.OffsetSize);
		for (int i = 0; i < topDictOriginal.ObjectsCount; i++)
		{
			topDictOriginal.method_0(i, out var offset, out var length);
			Class4470 class2 = new Class4470();
			Class4461 class3 = new Class4461(class2, new Class4438(), alteringMode: true);
			class3.OffsetShifts = shifts;
			class2.CommandProcessor = class3;
			class2.imethod_0(new Class4552(topDictOriginal.IndexData, offset, length));
			class3.AlterProgramStream.Seek(0L, SeekOrigin.Begin);
			class3.AlterProgramStream.Close();
			@class.method_0(class3.AlterProgramStream.ToArray());
		}
		using MemoryStream memoryStream = new MemoryStream();
		Class4449 writer = new Class4449(memoryStream);
		Class4451 class4 = new Class4451(writer);
		class4.Write(@class.ResultIndex, 0L);
		memoryStream.Close();
		return memoryStream.ToArray();
	}
}

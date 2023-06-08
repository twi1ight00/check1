using ns108;
using ns116;
using ns126;

namespace ns112;

internal class Class4445
{
	private Class4437 class4437_0;

	private Class4442 class4442_0;

	private Class4440 class4440_0;

	public Class4445(Class4442 rootParser, Class4437 reader)
	{
		class4437_0 = reader;
		class4442_0 = rootParser;
		class4440_0 = new Class4440(reader);
	}

	internal void method_0(Class4444 subFont, byte[] indexData, int offset, int length)
	{
		Class4470 @class = new Class4470();
		Class4461 commandProcessor = new Class4461(@class, subFont.FontDictionary, alteringMode: false);
		@class.CommandProcessor = commandProcessor;
		@class.imethod_0(new Class4552(indexData, offset, length));
		if (subFont.FontDictionary.long_9 > 0L && subFont.FontDictionary.long_8 > 0L)
		{
			class4437_0.Seek(subFont.FontDictionary.long_9);
			int num = (int)subFont.FontDictionary.long_8;
			byte[] array = new byte[num];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = class4437_0.method_0();
			}
			Class4472 class2 = new Class4472();
			Class4463 commandProcessor2 = new Class4463(class2, subFont.PrivateFontDictionary);
			class2.CommandProcessor = commandProcessor2;
			class2.imethod_0(new Class4552(array));
			if (subFont.PrivateFontDictionary.long_0 != long.MinValue)
			{
				class4437_0.Seek(subFont.FontDictionary.long_9 + subFont.PrivateFontDictionary.long_0);
				class4440_0.method_0(subFont.LocalSubrsIndex);
			}
		}
		subFont.CustomParams.LocalSubrsBias = class4442_0.method_1((ushort)subFont.LocalSubrsIndex.ObjectsCount);
	}
}

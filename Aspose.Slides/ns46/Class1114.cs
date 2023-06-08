using System;

namespace ns46;

internal class Class1114
{
	private Class1113[] class1113_0 = new Class1113[8];

	private int int_0;

	public Class1113 this[int index]
	{
		get
		{
			if (index < 0 || index >= int_0)
			{
				throw new IndexOutOfRangeException("");
			}
			return class1113_0[index];
		}
	}

	public int Count => int_0;

	public int method_0(string namespacePrefix, string localName, string value, int startPosition, int endPosition, Class1124 builder, bool fixRepeatingAttributes)
	{
		if (fixRepeatingAttributes)
		{
			for (int i = 0; i < int_0; i++)
			{
				Class1113 @class = class1113_0[i];
				if (namespacePrefix == @class.string_0 && localName == @class.string_1)
				{
					builder.method_1(startPosition, endPosition - startPosition);
					return -1;
				}
			}
		}
		if (int_0 + 1 > class1113_0.Length)
		{
			Class1113[] array = new Class1113[class1113_0.Length + class1113_0.Length / 2 + 8];
			for (int j = 0; j < class1113_0.Length; j++)
			{
				array[j] = class1113_0[j];
			}
			class1113_0 = array;
		}
		class1113_0[int_0] = new Class1113(namespacePrefix, localName, value, startPosition, endPosition);
		return int_0++;
	}

	public void Clear()
	{
		int_0 = 0;
	}
}

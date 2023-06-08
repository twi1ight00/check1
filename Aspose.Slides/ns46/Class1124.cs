using System.Collections.Generic;

namespace ns46;

internal class Class1124
{
	private List<Class1123> list_0;

	public bool IsIdentity
	{
		get
		{
			if (list_0.Count != 1)
			{
				return false;
			}
			Class1121 class1121_ = list_0[0].class1121_0;
			if (class1121_.int_0 == 0 && class1121_.int_1 == int.MaxValue)
			{
				return class1121_.char_0 == null;
			}
			return false;
		}
	}

	public Class1124()
	{
		list_0 = new List<Class1123>(16);
		list_0.Add(new Class1123(0, new Class1121(0, int.MaxValue, null)));
	}

	private int method_0(int position)
	{
		int num = 0;
		int num2 = list_0.Count;
		while (num2 - num > 1)
		{
			int num3 = num + num2 >> 1;
			Class1123 @class = list_0[num3];
			if (position < @class.int_0)
			{
				num2 = num3;
			}
			else
			{
				num = num3;
			}
		}
		return num;
	}

	public void method_1(int startPosition, int length)
	{
		int num = method_0(startPosition);
		int num2 = startPosition + length;
		int num3 = method_0(startPosition + length);
		Class1123 @class = list_0[num];
		if (startPosition < @class.int_0)
		{
			length -= @class.int_0 - startPosition;
			startPosition = @class.int_0;
			if (length < 0)
			{
				return;
			}
		}
		if (startPosition > @class.int_0)
		{
			if (@class.class1121_0.int_1 > startPosition)
			{
				@class.class1121_0.int_1 = startPosition;
			}
			num++;
		}
		if (num3 > num)
		{
			list_0.RemoveRange(num, num3 - num);
		}
		if (num == list_0.Count)
		{
			list_0.Add(new Class1123(num2, new Class1121(num2, int.MaxValue, null)));
			return;
		}
		Class1123 class2 = list_0[num];
		int num4 = num2 - class2.int_0;
		if (num4 > 0)
		{
			class2.int_0 = num2;
			class2.class1121_0.int_0 += num4;
		}
	}

	public void method_2(char[] data, int position)
	{
		method_3(data, 0, data.Length, position);
	}

	public void method_3(char[] data, int dataStartIndex, int dataLength, int position)
	{
		int num = method_0(position);
		Class1123 @class = list_0[num];
		if (@class.int_0 < position)
		{
			if (position < @class.int_0 + @class.class1121_0.Length)
			{
				Class1121 class1121_ = @class.class1121_0;
				Class1123 item = new Class1123(position, new Class1121(class1121_.int_0 + position - @class.int_0, class1121_.int_1, class1121_.char_0));
				class1121_.int_1 = class1121_.int_0 + position - @class.int_0;
				list_0.Insert(num + 1, item);
			}
			num++;
		}
		list_0.Insert(num, new Class1123(position, new Class1121(dataStartIndex, dataLength, data)));
	}

	internal Class1121[] method_4()
	{
		Class1121[] array = new Class1121[list_0.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = list_0[i].class1121_0;
		}
		return array;
	}
}

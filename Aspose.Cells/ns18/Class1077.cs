using System;
using System.IO;
using System.Runtime.CompilerServices;
using ns47;

namespace ns18;

internal class Class1077
{
	private readonly Class1398 class1398_0 = new Class1398();

	private readonly Class1398 class1398_1 = new Class1398();

	private readonly Class1460 class1460_0;

	public Class1077(Class1460 class1460_1, bool bool_0)
	{
		class1460_0 = class1460_1;
		if (!class1460_1.method_64() && !bool_0)
		{
			method_0('\uffff');
		}
		else
		{
			method_3();
		}
	}

	public int method_0(char char_0)
	{
		object obj = class1398_0[char_0];
		int num;
		if (obj != null)
		{
			num = (int)obj;
		}
		else
		{
			Class1463 @class = class1460_0.method_7().method_1(char_0);
			if (@class.method_2() == 0)
			{
				return -1;
			}
			obj = class1398_1[@class.method_1()];
			if (obj != null)
			{
				num = (int)obj;
				class1398_0.Add(char_0, num);
			}
			else
			{
				num = class1398_1.Count;
				class1398_1.Add(@class.method_1(), num);
				class1398_0.Add(char_0, num);
			}
		}
		return num;
	}

	public void method_1(Stream stream_0, bool bool_0, bool bool_1)
	{
		Class1462 @class = new Class1462(bool_0: false);
		try
		{
			@class.method_1(class1460_0, class1398_0, class1398_1, stream_0, bool_0, bool_1);
		}
		catch (Exception)
		{
			@class.method_1(class1460_0, class1398_0, class1398_1, stream_0, bool_0, bool_1: true);
		}
	}

	[SpecialName]
	public Class1460 method_2()
	{
		return class1460_0;
	}

	private void method_3()
	{
		int num = class1460_0.method_27().int_3 / 2;
		for (int i = 0; i < num; i++)
		{
			int num2 = class1460_0.method_27().int_8[i];
			int num3 = class1460_0.method_27().int_7[i];
			for (int j = num2; j <= num3; j++)
			{
				char c = (char)j;
				Class1463 @class = class1460_0.method_7().method_1(c);
				class1398_0.Add(c, @class.method_1());
			}
		}
	}
}

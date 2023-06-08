using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using ns18;

namespace ns47;

internal class Class1455
{
	[Flags]
	private enum Enum210
	{
		flag_0 = 1,
		flag_1 = 2,
		flag_2 = 4,
		flag_3 = 8,
		flag_4 = 0x10,
		flag_5 = 0x20,
		flag_6 = 0x40,
		flag_7 = 0x80,
		flag_8 = 0x100,
		flag_9 = 0x200
	}

	private Class1393 class1393_0;

	private bool bool_0;

	private Class1457 class1457_0;

	internal Class1398 class1398_0;

	private int[] int_0;

	private ArrayList arrayList_0;

	private MemoryStream memoryStream_0;

	private MemoryStream memoryStream_1;

	private MemoryStream memoryStream_2;

	[SpecialName]
	internal MemoryStream method_0()
	{
		return memoryStream_0;
	}

	[SpecialName]
	internal MemoryStream method_1()
	{
		return memoryStream_1;
	}

	[SpecialName]
	internal MemoryStream method_2()
	{
		return memoryStream_2;
	}

	internal Class1455(Class1393 class1393_1, bool bool_1, Class1457 class1457_1)
	{
		class1393_0 = class1393_1;
		bool_0 = bool_1;
		class1457_0 = class1457_1;
	}

	internal int method_3(Class1459 class1459_0, Class1459 class1459_1, Class1398 class1398_1)
	{
		method_4(class1459_0);
		method_6(class1459_1, class1398_1);
		method_5();
		return arrayList_0.Count - 1;
	}

	private void method_4(Class1459 class1459_0)
	{
		class1393_0.method_0().Position = class1459_0.int_1;
		if (bool_0)
		{
			int num = class1459_0.int_2 / 2;
			int_0 = new int[num];
			for (int i = 0; i < num; i++)
			{
				int_0[i] = class1393_0.method_4() * 2;
			}
		}
		else
		{
			int num2 = class1459_0.int_2 / 4;
			int_0 = new int[num2];
			for (int j = 0; j < num2; j++)
			{
				int_0[j] = class1393_0.method_1();
			}
		}
	}

	private void method_5()
	{
		memoryStream_0 = new MemoryStream();
		Class1394 @class = new Class1394(memoryStream_0);
		if (bool_0)
		{
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				@class.method_4((ushort)((int)arrayList_0[i] / 2));
			}
		}
		else
		{
			for (int j = 0; j < arrayList_0.Count; j++)
			{
				@class.method_1((int)arrayList_0[j]);
			}
		}
		@class.Flush();
	}

	private void method_6(Class1459 class1459_0, Class1398 class1398_1)
	{
		class1398_0 = new Class1398();
		for (int i = 0; i < class1398_1.Count; i++)
		{
			int num = class1398_1.method_3(i);
			int int_ = (int)class1398_1.GetByIndex(i);
			if (!class1398_0.method_1(int_))
			{
				class1398_0.Add(int_, num);
			}
		}
		arrayList_0 = new ArrayList();
		memoryStream_1 = new MemoryStream();
		Class1394 @class = new Class1394(memoryStream_1);
		memoryStream_2 = new MemoryStream();
		Class1394 class2 = new Class1394(memoryStream_2);
		int num2 = 0;
		while (num2 < class1398_0.Count)
		{
			int num3 = (int)class1398_0.GetByIndex(num2);
			if (num3 >= int_0.Length - 1)
			{
				num2++;
				continue;
			}
			arrayList_0.Add((int)@class.method_0().Position);
			class1393_0.method_0().Position = class1459_0.int_1 + int_0[num3];
			int num4 = 0;
			int num5 = num3 + 1;
			num4 = int_0[num5] - int_0[num3];
			num5++;
			int num6 = num4;
			short num7 = class1393_0.method_3();
			if (num4 > 0)
			{
				if (num7 <= 0)
				{
					@class.method_3(num7);
					byte[] array = class1393_0.method_5(8);
					@class.method_5(array, 0, array.Length);
					num6 -= array.Length;
					Enum210 @enum;
					do
					{
						@enum = (Enum210)class1393_0.method_4();
						@class.method_4((ushort)@enum);
						num6 -= 2;
						int num8 = class1393_0.method_4();
						object obj = class1398_1[num8];
						int num10;
						if (obj == null)
						{
							int num9 = class1398_0.method_3(class1398_0.Count - 1);
							num10 = num9 + 1;
							class1398_1.Add(num8, num10);
							class1398_0.Add(num10, num8);
						}
						else
						{
							num10 = (int)obj;
						}
						byte[] array2 = class1393_0.method_5(smethod_0(@enum));
						@class.method_4((ushort)num10);
						num6 -= 2;
						@class.method_5(array2, 0, array2.Length);
						num6 -= array2.Length;
					}
					while ((@enum & Enum210.flag_5) != 0);
					if ((@enum & Enum210.flag_8) != 0)
					{
						int num11 = class1393_0.method_4();
						byte[] array3 = class1393_0.method_5(num11);
						@class.method_4((ushort)num11);
						num6 -= 2;
						@class.method_5(array3, 0, array3.Length);
						num6 -= array3.Length;
					}
					if (num6 > 0)
					{
						class1393_0.method_5(num6);
						@class.method_5(new byte[20], 0, num6);
					}
				}
				else
				{
					class1393_0.method_0().Position -= 2L;
					byte[] array4 = class1393_0.method_5(num4);
					@class.method_5(array4, 0, array4.Length);
				}
			}
			class1457_0.method_0(num3).Write(class2);
			num2++;
		}
		@class.Flush();
		arrayList_0.Add(((int)@class.method_0().Position + 3) & -4);
		@class.method_5(new byte[4], 0, ((int)@class.method_0().Position + 3) & (-4 - (int)@class.method_0().Position));
		class2.Flush();
	}

	private static int smethod_0(Enum210 enum210_0)
	{
		int num = (((enum210_0 & Enum210.flag_0) == 0) ? 2 : 4);
		if ((enum210_0 & Enum210.flag_3) != 0)
		{
			num += 2;
		}
		else if ((enum210_0 & Enum210.flag_6) != 0)
		{
			num += 4;
		}
		else if ((enum210_0 & Enum210.flag_7) != 0)
		{
			num += 8;
		}
		return num;
	}
}

using System.IO;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class1020
{
	private readonly long long_0;

	private uint uint_0;

	private uint uint_1;

	private double double_0;

	private double double_1;

	private Enum140 enum140_0 = Enum140.const_8;

	private Enum142 enum142_0 = Enum142.const_1;

	private Enum201 enum201_0 = Enum201.const_0;

	private Enum141 enum141_0 = Enum141.const_0;

	private Enum139 enum139_0 = Enum139.const_0;

	private ushort ushort_0 = 1;

	private ushort ushort_1 = 4;

	private ushort[] ushort_2 = new ushort[1];

	public Class1020(byte[] byte_0)
		: this(new Class1393(new MemoryStream(byte_0)))
	{
	}

	public Class1020(Class1393 class1393_0)
	{
		long_0 = class1393_0.method_0().Position;
		method_0(class1393_0);
	}

	private void method_0(Class1393 class1393_0)
	{
		short num = class1393_0.method_3();
		bool bool_ = num == 19789;
		ushort num2 = smethod_0(class1393_0, bool_);
		if (num2 != 42)
		{
			return;
		}
		uint num3 = smethod_1(class1393_0, bool_);
		class1393_0.method_0().Position = long_0 + num3;
		ushort num4 = smethod_0(class1393_0, bool_);
		long num5 = class1393_0.method_0().Position;
		for (int i = 0; i < num4; i++)
		{
			class1393_0.method_0().Position = num5;
			num5 += 12;
			ushort num6 = smethod_0(class1393_0, bool_);
			ushort num7 = smethod_0(class1393_0, bool_);
			uint num8 = smethod_1(class1393_0, bool_);
			if (((num7 == 1 || num7 == 2) && num8 > 4) || (num7 == 3 && num8 > 2) || (num7 == 4 && num8 > 1) || num7 == 5)
			{
				uint num9 = smethod_1(class1393_0, bool_);
				class1393_0.method_0().Position = long_0 + num9;
			}
			switch (num6)
			{
			case 277:
				ushort_0 = smethod_0(class1393_0, bool_);
				break;
			case 256:
				uint_0 = ((num7 == 3) ? smethod_0(class1393_0, bool_) : smethod_1(class1393_0, bool_));
				break;
			case 257:
				uint_1 = ((num7 == 3) ? smethod_0(class1393_0, bool_) : smethod_1(class1393_0, bool_));
				break;
			case 258:
				ushort_2 = smethod_2(class1393_0, bool_, num8);
				break;
			case 259:
				enum201_0 = (Enum201)smethod_0(class1393_0, bool_);
				break;
			case 262:
				enum140_0 = (Enum140)smethod_0(class1393_0, bool_);
				break;
			case 332:
				enum139_0 = (Enum139)smethod_0(class1393_0, bool_);
				break;
			case 334:
				ushort_1 = smethod_0(class1393_0, bool_);
				break;
			case 296:
				enum142_0 = (Enum142)smethod_0(class1393_0, bool_);
				break;
			case 282:
				double_0 = smethod_3(class1393_0, bool_);
				break;
			case 283:
				double_1 = smethod_3(class1393_0, bool_);
				break;
			case 284:
				enum141_0 = (Enum141)smethod_0(class1393_0, bool_);
				break;
			}
		}
	}

	private static ushort smethod_0(Class1393 class1393_0, bool bool_0)
	{
		ushort result = class1393_0.method_4();
		if (!bool_0)
		{
			result = Class1010.smethod_2(result);
		}
		return result;
	}

	private static uint smethod_1(Class1393 class1393_0, bool bool_0)
	{
		uint result = class1393_0.method_2();
		if (!bool_0)
		{
			result = Class1010.smethod_0(result);
		}
		return result;
	}

	private static ushort[] smethod_2(Class1393 class1393_0, bool bool_0, uint uint_2)
	{
		ushort[] array = new ushort[uint_2];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = smethod_0(class1393_0, bool_0);
		}
		return array;
	}

	private static double smethod_3(Class1393 class1393_0, bool bool_0)
	{
		uint num = smethod_1(class1393_0, bool_0);
		uint num2 = smethod_1(class1393_0, bool_0);
		return (num2 != 0) ? (num / num2) : 0u;
	}

	[SpecialName]
	public bool method_1()
	{
		if (enum142_0 != Enum142.const_0 && enum142_0 != Enum142.const_1 && enum142_0 != Enum142.const_2)
		{
			return false;
		}
		if (!method_2() && !method_3() && !method_4() && !method_5())
		{
			return method_6();
		}
		return true;
	}

	[SpecialName]
	private bool method_2()
	{
		if ((enum140_0 == Enum140.const_0 || enum140_0 == Enum140.const_1) && ushort_2[0] == 0)
		{
			if (enum201_0 != Enum201.const_0 && enum201_0 != Enum201.const_1 && enum201_0 != Enum201.const_3 && enum201_0 != Enum201.const_4 && enum201_0 != Enum201.const_2)
			{
				return enum201_0 == Enum201.const_6;
			}
			return true;
		}
		return false;
	}

	[SpecialName]
	private bool method_3()
	{
		if ((enum140_0 != 0 && enum140_0 != Enum140.const_1) || (ushort_2[0] != 4 && ushort_2[0] != 8 && ushort_2[0] != 16))
		{
			return false;
		}
		if (enum201_0 != Enum201.const_0 && enum201_0 != Enum201.const_1)
		{
			return enum201_0 == Enum201.const_6;
		}
		return true;
	}

	[SpecialName]
	private bool method_4()
	{
		if (enum140_0 == Enum140.const_3 && (ushort_2[0] == 1 || ushort_2[0] == 4 || ushort_2[0] == 8))
		{
			if (enum201_0 != Enum201.const_0 && enum201_0 != Enum201.const_2)
			{
				return enum201_0 == Enum201.const_6;
			}
			return true;
		}
		return false;
	}

	[SpecialName]
	private bool method_5()
	{
		if (enum140_0 == Enum140.const_2 && enum141_0 == Enum141.const_0 && ushort_2.Length == ushort_0 && method_7())
		{
			if (enum201_0 != Enum201.const_0 && enum201_0 != Enum201.const_2 && enum201_0 != Enum201.const_5)
			{
				return enum201_0 == Enum201.const_6;
			}
			return true;
		}
		return false;
	}

	[SpecialName]
	private bool method_6()
	{
		if (enum140_0 == Enum140.const_5 && enum141_0 == Enum141.const_0 && enum139_0 == Enum139.const_0 && ushort_1 == 4 && ushort_2.Length == ushort_0 && method_7())
		{
			if (enum201_0 != Enum201.const_0 && enum201_0 != Enum201.const_2 && enum201_0 != Enum201.const_5)
			{
				return enum201_0 == Enum201.const_6;
			}
			return true;
		}
		return false;
	}

	[SpecialName]
	private bool method_7()
	{
		bool flag = ushort_2[0] == 8 || ushort_2[0] == 16;
		for (int i = 0; i < ushort_2.Length; i++)
		{
			flag = flag && ushort_2[i] == ushort_2[0];
		}
		return flag;
	}
}

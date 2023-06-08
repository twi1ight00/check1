using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace ns45;

internal class Class1165
{
	internal ushort ushort_0;

	internal int int_0;

	internal Enum185 enum185_0;

	internal ArrayList arrayList_0;

	internal int int_1;

	internal int[] int_2;

	internal Class1165(int[] int_3)
	{
		int_0 = int_3[0];
		enum185_0 = (Enum185)int_3[1];
		int_1 = int_3[2];
		ushort_0 = (ushort)int_3[3];
		int_2 = new int[int_3.Length - 4];
		Array.Copy(int_3, 4, int_2, 0, int_2.Length);
	}

	internal Class1165(int[] int_3, ArrayList arrayList_1, bool bool_0)
	{
		int_0 = int_3[0];
		enum185_0 = (Enum185)int_3[1];
		int_1 = int_3[2];
		ushort_0 = (ushort)int_3[3];
		int_2 = new int[int_3.Length - 4];
		Array.Copy(int_3, 4, int_2, 0, int_2.Length);
		arrayList_0 = arrayList_1;
	}

	internal Class1165(int[] int_3, ArrayList arrayList_1)
	{
		int_0 = int_3[0];
		enum185_0 = (Enum185)int_3[1];
		int_1 = int_3[2];
		ushort_0 = (ushort)int_3[3];
		int_2 = new int[int_3.Length - 4];
		Array.Copy(int_3, 4, int_2, 0, int_2.Length);
	}

	[SpecialName]
	internal int method_0()
	{
		return (ushort_0 & 0x1FE) >> 1;
	}

	[SpecialName]
	internal string method_1()
	{
		return enum185_0 switch
		{
			Enum185.const_1 => " Total", 
			Enum185.const_2 => " Sum", 
			Enum185.const_3 => " Count", 
			Enum185.const_4 => " Count", 
			Enum185.const_5 => " Average", 
			Enum185.const_6 => " Max", 
			Enum185.const_7 => " Min", 
			Enum185.const_8 => " Product", 
			Enum185.const_9 => " StdDev", 
			Enum185.const_10 => " StdDevp", 
			Enum185.const_11 => " Var", 
			Enum185.const_12 => " Varp", 
			_ => " Total", 
		};
	}

	[SpecialName]
	internal bool method_2()
	{
		if ((ushort_0 & 0x200u) != 0 && enum185_0 >= Enum185.const_1 && enum185_0 <= Enum185.const_13 && !method_6() && !method_3())
		{
			return true;
		}
		return false;
	}

	[SpecialName]
	internal bool method_3()
	{
		return (ushort_0 & 0x800) != 0;
	}

	[SpecialName]
	internal bool method_4()
	{
		return (ushort_0 & 0x1000) != 0;
	}

	[SpecialName]
	internal int method_5()
	{
		return (ushort_0 & 0x1FE) >> 1;
	}

	[SpecialName]
	internal bool method_6()
	{
		return (ushort_0 & 0x400) != 0;
	}
}

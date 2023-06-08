using System;
using System.Collections;
using System.Runtime.CompilerServices;
using ns59;

namespace ns2;

internal class Class1734
{
	private ushort ushort_0 = 14;

	private ArrayList arrayList_0;

	private byte[] byte_0;

	private ArrayList arrayList_1;

	private byte[] byte_1;

	private byte[] byte_2;

	private byte[] byte_3;

	internal Class1734()
	{
	}

	[SpecialName]
	internal void method_0(ushort ushort_1)
	{
		ushort_0 = ushort_1;
	}

	[SpecialName]
	internal ArrayList method_1()
	{
		return arrayList_0;
	}

	[SpecialName]
	internal void method_2(ArrayList arrayList_2)
	{
		arrayList_0 = arrayList_2;
	}

	[SpecialName]
	internal void method_3(byte[] byte_4)
	{
		byte_0 = byte_4;
	}

	[SpecialName]
	internal ArrayList method_4()
	{
		if (arrayList_1 == null)
		{
			arrayList_1 = new ArrayList();
		}
		return arrayList_1;
	}

	[SpecialName]
	internal void method_5(byte[] byte_4)
	{
		byte_1 = byte_4;
	}

	[SpecialName]
	internal void method_6(byte[] byte_4)
	{
		byte_2 = byte_4;
	}

	[SpecialName]
	internal byte[] method_7()
	{
		return byte_3;
	}

	[SpecialName]
	internal void method_8(byte[] byte_4)
	{
		byte_3 = byte_4;
	}

	internal void Copy(Class1734 class1734_0)
	{
		ushort_0 = class1734_0.ushort_0;
		if (class1734_0.arrayList_0 != null && class1734_0.arrayList_0.Count != 0)
		{
			arrayList_0 = new ArrayList();
			for (int i = 0; i < class1734_0.arrayList_0.Count; i++)
			{
				byte[] array = (byte[])class1734_0.arrayList_0[i];
				byte[] array2 = new byte[array.Length];
				Array.Copy(array, array2, array.Length);
				arrayList_0.Add(array2);
			}
		}
		if (class1734_0.byte_0 != null && class1734_0.byte_0.Length != 0)
		{
			byte_0 = new byte[class1734_0.byte_0.Length];
			Array.Copy(class1734_0.byte_0, byte_0, byte_0.Length);
		}
		if (class1734_0.byte_1 != null)
		{
			byte_1 = new byte[class1734_0.byte_1.Length];
			Array.Copy(class1734_0.byte_1, byte_1, class1734_0.byte_1.Length);
		}
		if (class1734_0.arrayList_1 != null && class1734_0.arrayList_1.Count > 0)
		{
			arrayList_1 = new ArrayList();
			for (int j = 0; j < class1734_0.arrayList_1.Count; j++)
			{
				byte[] array3 = (byte[])class1734_0.arrayList_1[j];
				byte[] array4 = new byte[array3.Length];
				Array.Copy(array3, array4, array3.Length);
				arrayList_1.Add(array4);
			}
		}
		if (class1734_0.byte_2 != null && class1734_0.byte_2.Length > 0)
		{
			byte_2 = new byte[class1734_0.byte_2.Length];
			Array.Copy(class1734_0.byte_2, byte_2, byte_2.Length);
		}
		if (class1734_0.byte_3 != null && class1734_0.byte_3.Length != 0)
		{
			byte_3 = new byte[class1734_0.byte_3.Length];
			Array.Copy(class1734_0.byte_3, byte_3, class1734_0.byte_3.Length);
		}
		else
		{
			byte_3 = null;
		}
	}

	internal void method_9(Class1725 class1725_0)
	{
		class1725_0.method_8(431);
		if (byte_1 == null)
		{
			class1725_0.method_8(2);
			class1725_0.method_8(0);
		}
		else
		{
			class1725_0.method_7((short)byte_1.Length);
			class1725_0.method_3(byte_1);
		}
		class1725_0.method_8(444);
		if (byte_2 == null)
		{
			class1725_0.method_8(2);
			class1725_0.method_8(0);
		}
		else
		{
			class1725_0.method_7((short)byte_2.Length);
			class1725_0.method_3(byte_2);
		}
	}

	internal void method_10(Class1725 class1725_0)
	{
		if (arrayList_1 != null && arrayList_1.Count > 0)
		{
			for (int i = 0; i < arrayList_1.Count; i++)
			{
				class1725_0.method_8(2148);
				byte[] array = (byte[])arrayList_1[i];
				class1725_0.method_7((short)array.Length);
				class1725_0.method_3(array);
			}
		}
	}

	internal void method_11(Class1725 class1725_0)
	{
		if (byte_3 != null)
		{
			class1725_0.method_6(2147);
			class1725_0.method_7((short)byte_3.Length);
			class1725_0.method_3(byte_3);
		}
	}
}

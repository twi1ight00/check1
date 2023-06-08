using System;
using System.Collections.Generic;
using ns33;

namespace ns45;

internal class Class1106 : Class1105, Interface35
{
	private byte[] byte_1;

	public Class1106()
		: this(10)
	{
	}

	public Class1106(string name)
		: this(10)
	{
		base.EntryName = name;
	}

	public Class1106(int firstSID, Class1099 sat, Interface36 reader)
	{
		method_5(firstSID, sat, reader);
		short_0 = 2;
	}

	public Class1106(int initCap)
	{
		byte_1 = new byte[initCap];
		short_0 = 2;
	}

	private void method_0(int index)
	{
		if (index >= int_1)
		{
			throw new IndexOutOfRangeException("Index: " + index + ", Size: " + int_1);
		}
	}

	public void Clear()
	{
		byte_1 = new byte[10];
		int_1 = 0;
	}

	public bool Add(byte val)
	{
		method_4(int_1 + 1);
		byte_1[int_1++] = val;
		return true;
	}

	public void Add(int index, byte val)
	{
		if (index > int_1 || index < 0)
		{
			throw new IndexOutOfRangeException("Index: " + index + ", Size: " + int_1);
		}
		method_4(int_1 + 1);
		Array.Copy(byte_1, index, byte_1, index + 1, int_1 - index);
		byte_1[index] = val;
		int_1++;
	}

	public bool method_1(byte[] d)
	{
		int num = d.Length;
		method_4(int_1 + num);
		Array.Copy(d, 0, byte_1, int_1, num);
		int_1 += num;
		return num != 0;
	}

	public byte method_2(int i)
	{
		method_0(i);
		return byte_1[i];
	}

	public byte method_3(int i, byte value)
	{
		method_4(i);
		if (i > int_1 - 1)
		{
			int_1 = i + 1;
		}
		method_0(i);
		byte result = byte_1[i];
		byte_1[i] = value;
		return result;
	}

	private void method_4(int minCapacity)
	{
		int num = byte_1.Length;
		if (minCapacity > num)
		{
			int num2 = num * 3 / 2 + 1;
			if (num2 < minCapacity)
			{
				num2 = minCapacity;
			}
			byte[] destinationArray = new byte[num2];
			Array.Copy(byte_1, destinationArray, byte_1.Length);
			byte_1 = destinationArray;
		}
	}

	public List<Class1111> imethod_1(int sectorSize)
	{
		List<Class1111> list = new List<Class1111>();
		int num = 0;
		do
		{
			byte[] array = new byte[sectorSize];
			Class1165.smethod_15(array, byte.MaxValue);
			int length = ((num + sectorSize >= int_1) ? (int_1 - num) : sectorSize);
			Array.Copy(byte_1, num, array, 0, length);
			list.Add(new Class1111(array));
			num += sectorSize;
		}
		while (num < int_1);
		return list;
	}

	public int imethod_0(int sectorSize)
	{
		return (int)Math.Ceiling((double)int_1 / (double)sectorSize);
	}

	public void method_5(int firstSID, Class1099 sat, Interface36 reader)
	{
		int[] array = sat.method_1(firstSID);
		int num = reader.imethod_1(0).method_0().Length;
		byte_1 = new byte[array.Length * num];
		for (int i = 0; i < array.Length; i++)
		{
			Class1111 @class = reader.imethod_1(array[i]);
			Array.Copy(@class.method_0(), 0, byte_1, i * num, num);
		}
	}

	public void method_6(int firstSID, Class1099 sat, List<Class1111> shortSectors)
	{
		if (firstSID >= 0)
		{
			int[] array = sat.method_1(firstSID);
			int num = shortSectors[0].method_0().Length;
			byte_1 = new byte[array.Length * num];
			for (int i = 0; i < array.Length; i++)
			{
				Class1111 @class = shortSectors[array[i]];
				Array.Copy(@class.method_0(), 0, byte_1, i * num, num);
			}
		}
	}

	public byte[] method_7()
	{
		return byte_1;
	}

	public byte[] method_8()
	{
		byte[] array = new byte[int_1];
		Array.Copy(byte_1, array, int_1);
		return array;
	}
}

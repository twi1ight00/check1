using System;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class1398
{
	public int[] int_0;

	public object[] object_0;

	private int int_1;

	public object this[int int_2]
	{
		get
		{
			int num = method_4(int_2);
			if (num >= 0)
			{
				return object_0[num];
			}
			return null;
		}
		set
		{
			int num = Class1392.smethod_0(int_0, 0, int_1, int_2);
			if (num >= 0)
			{
				object_0[num] = value;
			}
			else
			{
				Insert(~num, int_2, value);
			}
		}
	}

	public int Count => int_1;

	public Class1398()
	{
		int_0 = new int[16];
		object_0 = new object[16];
	}

	public void Add(int int_2, object object_1)
	{
		int num = Class1392.smethod_0(int_0, 0, int_1, int_2);
		if (num >= 0)
		{
			throw new ArgumentException("duplicate");
		}
		Insert(~num, int_2, object_1);
	}

	[SpecialName]
	public void method_0(int int_2)
	{
		if (int_2 == int_0.Length)
		{
			return;
		}
		if (int_2 < int_1)
		{
			throw new ArgumentOutOfRangeException("value");
		}
		if (int_2 > 0)
		{
			int[] destinationArray = new int[int_2];
			object[] destinationArray2 = new object[int_2];
			if (int_1 > 0)
			{
				Array.Copy(int_0, 0, destinationArray, 0, int_1);
				Array.Copy(object_0, 0, destinationArray2, 0, int_1);
			}
			int_0 = destinationArray;
			object_0 = destinationArray2;
		}
		else
		{
			int_0 = new int[16];
			object_0 = new object[16];
		}
	}

	public bool method_1(int int_2)
	{
		return method_4(int_2) >= 0;
	}

	private void method_2(int int_2)
	{
		int num = ((int_0.Length == 0) ? 16 : (int_0.Length * 2));
		if (num < int_2)
		{
			num = int_2;
		}
		method_0(num);
	}

	public object GetByIndex(int int_2)
	{
		if (int_2 < 0 || int_2 >= int_1)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		return object_0[int_2];
	}

	public int method_3(int int_2)
	{
		if (int_2 < 0 || int_2 >= int_1)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		return int_0[int_2];
	}

	public int method_4(int int_2)
	{
		int num = Class1392.smethod_0(int_0, 0, int_1, int_2);
		if (num < 0)
		{
			return -1;
		}
		return num;
	}

	private void Insert(int int_2, int int_3, object object_1)
	{
		if (int_1 == int_0.Length)
		{
			method_2(int_1 + 1);
		}
		if (int_2 < int_1)
		{
			Array.Copy(int_0, int_2, int_0, int_2 + 1, int_1 - int_2);
			Array.Copy(object_0, int_2, object_0, int_2 + 1, int_1 - int_2);
		}
		int_0[int_2] = int_3;
		object_0[int_2] = object_1;
		int_1++;
	}
}

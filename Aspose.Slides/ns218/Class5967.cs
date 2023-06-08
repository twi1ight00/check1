using System;
using System.Diagnostics;

namespace ns218;

[DebuggerStepThrough]
internal class Class5967
{
	private const int int_0 = 16;

	private int[] int_1;

	private object[] object_0;

	private int int_2;

	public int Capacity
	{
		get
		{
			return int_1.Length;
		}
		set
		{
			if (value == int_1.Length)
			{
				return;
			}
			if (value < int_2)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			if (value > 0)
			{
				int[] destinationArray = new int[value];
				object[] destinationArray2 = new object[value];
				if (int_2 > 0)
				{
					Array.Copy(int_1, 0, destinationArray, 0, int_2);
					Array.Copy(object_0, 0, destinationArray2, 0, int_2);
				}
				int_1 = destinationArray;
				object_0 = destinationArray2;
			}
			else
			{
				int_1 = new int[16];
				object_0 = new object[16];
			}
		}
	}

	public int Count => int_2;

	public object this[int key]
	{
		get
		{
			int num = method_5(key);
			if (num < 0)
			{
				return null;
			}
			return object_0[num];
		}
		set
		{
			int num = Class5948.smethod_7(int_1, 0, int_2, key);
			if (num >= 0)
			{
				object_0[num] = value;
			}
			else
			{
				Insert(~num, key, value);
			}
		}
	}

	public Class5967()
	{
		int_1 = new int[16];
		object_0 = new object[16];
	}

	public Class5967(int initialCapacity)
	{
		if (initialCapacity < 0)
		{
			throw new ArgumentOutOfRangeException("initialCapacity");
		}
		int_1 = new int[initialCapacity];
		object_0 = new object[initialCapacity];
	}

	public void Add(int key, object value)
	{
		int num = Class5948.smethod_7(int_1, 0, int_2, key);
		if (num >= 0)
		{
			throw new ArgumentException("duplicate");
		}
		Insert(~num, key, value);
	}

	public void Clear()
	{
		int_2 = 0;
		int_1 = new int[16];
		object_0 = new object[16];
	}

	public Class5967 method_0()
	{
		Class5967 @class = (Class5967)MemberwiseClone();
		@class.int_2 = 0;
		@class.int_1 = new int[int_1.Length];
		@class.object_0 = new object[object_0.Length];
		return @class;
	}

	public bool Contains(int key)
	{
		return method_5(key) >= 0;
	}

	public bool ContainsKey(int key)
	{
		return method_5(key) >= 0;
	}

	public bool method_1(object value)
	{
		return method_6(value) >= 0;
	}

	private void method_2(int min)
	{
		int num = ((int_1.Length == 0) ? 16 : (int_1.Length * 2));
		if (num < min)
		{
			num = min;
		}
		Capacity = num;
	}

	public object method_3(int index)
	{
		if (index < 0 || index >= int_2)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		return object_0[index];
	}

	public int method_4(int index)
	{
		if (index < 0 || index >= int_2)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		return int_1[index];
	}

	public int method_5(int key)
	{
		int num = Class5948.smethod_7(int_1, 0, int_2, key);
		if (num < 0)
		{
			return -1;
		}
		return num;
	}

	public int method_6(object value)
	{
		return Array.IndexOf(object_0, value, 0, int_2);
	}

	private void Insert(int index, int key, object value)
	{
		if (int_2 == int_1.Length)
		{
			method_2(int_2 + 1);
		}
		if (index < int_2)
		{
			Array.Copy(int_1, index, int_1, index + 1, int_2 - index);
			Array.Copy(object_0, index, object_0, index + 1, int_2 - index);
		}
		int_1[index] = key;
		object_0[index] = value;
		int_2++;
	}

	public void RemoveAt(int index)
	{
		if (index >= 0 && index < int_2)
		{
			int_2--;
			if (index < int_2)
			{
				Array.Copy(int_1, index + 1, int_1, index, int_2 - index);
				Array.Copy(object_0, index + 1, object_0, index, int_2 - index);
			}
			int_1[int_2] = 0;
			object_0[int_2] = null;
			return;
		}
		throw new ArgumentOutOfRangeException("index");
	}

	public void Remove(int key)
	{
		int num = method_5(key);
		if (num >= 0)
		{
			RemoveAt(num);
		}
	}

	public void method_7(int index, object value)
	{
		if (index < 0 || index >= int_2)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		object_0[index] = value;
	}

	public void method_8()
	{
		Capacity = int_2;
	}
}

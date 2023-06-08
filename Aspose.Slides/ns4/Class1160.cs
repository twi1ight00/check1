using System;

namespace ns4;

internal class Class1160
{
	private const int int_0 = 128;

	private int[] int_1;

	private int int_2;

	public Class1160()
		: this(128)
	{
	}

	public Class1160(Class1160 list)
		: this(list.int_1.Length)
	{
		Array.Copy(list.int_1, 0, int_1, 0, int_1.Length);
		int_2 = list.int_2;
	}

	public Class1160(int initialCapacity)
	{
		int_1 = new int[initialCapacity];
		int_2 = 0;
	}

	public virtual void Add(int index, int value1)
	{
		if (index > int_2)
		{
			throw new IndexOutOfRangeException();
		}
		if (index == int_2)
		{
			Add(value1);
			return;
		}
		if (int_2 == int_1.Length)
		{
			method_0(int_2 * 2);
		}
		Array.Copy(int_1, index, int_1, index + 1, int_2 - index);
		int_1[index] = value1;
		int_2++;
	}

	public virtual bool Add(int value1)
	{
		if (int_2 == int_1.Length)
		{
			method_0(int_2 * 2);
		}
		int_1[int_2++] = value1;
		return true;
	}

	public virtual bool vmethod_0(Class1160 c)
	{
		if (c.int_2 != 0)
		{
			if (int_2 + c.int_2 > int_1.Length)
			{
				method_0(int_2 + c.int_2);
			}
			Array.Copy(c.int_1, 0, int_1, int_2, c.int_2);
			int_2 += c.int_2;
		}
		return true;
	}

	public virtual bool vmethod_1(int index, Class1160 c)
	{
		if (index > int_2)
		{
			throw new IndexOutOfRangeException();
		}
		if (c.int_2 != 0)
		{
			if (int_2 + c.int_2 > int_1.Length)
			{
				method_0(int_2 + c.int_2);
			}
			Array.Copy(int_1, index, int_1, index + c.int_2, int_2 - index);
			Array.Copy(c.int_1, 0, int_1, index, c.int_2);
			int_2 += c.int_2;
		}
		return true;
	}

	public virtual void Clear()
	{
		int_2 = 0;
	}

	public virtual bool Contains(int o)
	{
		bool flag = false;
		int num = 0;
		while (!flag && num < int_2)
		{
			if (int_1[num] == o)
			{
				flag = true;
			}
			num++;
		}
		return flag;
	}

	public virtual bool vmethod_2(Class1160 c)
	{
		bool flag = true;
		if (this != c)
		{
			int num = 0;
			while (flag && num < c.int_2)
			{
				if (!Contains(c.int_1[num]))
				{
					flag = false;
				}
				num++;
			}
		}
		return flag;
	}

	public override bool Equals(object o)
	{
		bool flag;
		if (!(flag = this == o) && o != null && o.GetType() == GetType())
		{
			Class1160 @class = (Class1160)o;
			if (@class.int_2 == int_2)
			{
				flag = true;
				int num = 0;
				while (flag && num < int_2)
				{
					flag = int_1[num] == @class.int_1[num];
					num++;
				}
			}
		}
		return flag;
	}

	public virtual int vmethod_3(int index)
	{
		if (index >= int_2)
		{
			throw new IndexOutOfRangeException();
		}
		return int_1[index];
	}

	public virtual int vmethod_4()
	{
		int num = 0;
		for (int i = 0; i < int_2; i++)
		{
			num = 31 * num + int_1[i];
		}
		return num;
	}

	public override int GetHashCode()
	{
		return vmethod_4();
	}

	public virtual int IndexOf(int o)
	{
		int i;
		for (i = 0; i < int_2 && o != int_1[i]; i++)
		{
		}
		if (i == int_2)
		{
			i = -1;
		}
		return i;
	}

	public virtual bool vmethod_5()
	{
		return int_2 == 0;
	}

	public virtual int vmethod_6(int o)
	{
		int num = int_2 - 1;
		while (num >= 0 && o != int_1[num])
		{
			num--;
		}
		return num;
	}

	public virtual int Remove(int index)
	{
		if (index >= int_2)
		{
			throw new IndexOutOfRangeException();
		}
		int result = int_1[index];
		Array.Copy(int_1, index + 1, int_1, index, int_2 - index);
		int_2--;
		return result;
	}

	public virtual bool vmethod_7(int o)
	{
		bool flag = false;
		int num = 0;
		while (!flag && num < int_2)
		{
			if (o == int_1[num])
			{
				Array.Copy(int_1, num + 1, int_1, num, int_2 - num);
				int_2--;
				flag = true;
			}
			num++;
		}
		return flag;
	}

	public virtual bool vmethod_8(Class1160 c)
	{
		bool result = false;
		for (int i = 0; i < c.int_2; i++)
		{
			if (vmethod_7(c.int_1[i]))
			{
				result = true;
			}
		}
		return result;
	}

	public virtual bool vmethod_9(Class1160 c)
	{
		bool result = false;
		int num = 0;
		while (num < int_2)
		{
			if (!c.Contains(int_1[num]))
			{
				Remove(num);
				result = true;
			}
			else
			{
				num++;
			}
		}
		return result;
	}

	public virtual int vmethod_10(int index, int element)
	{
		if (index >= int_2)
		{
			throw new IndexOutOfRangeException();
		}
		int result = int_1[index];
		int_1[index] = element;
		return result;
	}

	public virtual int vmethod_11()
	{
		return int_2;
	}

	public virtual int[] ToArray()
	{
		int[] array = new int[int_2];
		Array.Copy(int_1, 0, array, 0, int_2);
		return array;
	}

	public virtual int[] ToArray(int[] a)
	{
		if (a.Length == int_2)
		{
			Array.Copy(int_1, 0, a, 0, int_2);
			return a;
		}
		return ToArray();
	}

	private void method_0(int new_size)
	{
		int num = ((new_size == int_1.Length) ? (new_size + 1) : new_size);
		int[] destinationArray = new int[num];
		Array.Copy(int_1, 0, destinationArray, 0, int_2);
		int_1 = destinationArray;
	}
}

using System;
using System.Text;

namespace ns218;

internal class Class5962
{
	private const int int_0 = 16;

	private int[] int_1;

	private int int_2;

	public virtual int Capacity
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
				if (int_2 > 0)
				{
					Array.Copy(int_1, 0, destinationArray, 0, int_2);
				}
				int_1 = destinationArray;
			}
			else
			{
				int_1 = new int[16];
			}
		}
	}

	public virtual int Count => int_2;

	public virtual bool IsFixedSize => false;

	public virtual bool IsReadOnly => false;

	public virtual bool IsSynchronized => false;

	public virtual object SyncRoot => this;

	public virtual int this[int index]
	{
		get
		{
			if (index < 0 || index >= int_2)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return int_1[index];
		}
		set
		{
			if (index < 0 || index >= int_2)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int_1[index] = value;
		}
	}

	public Class5962()
	{
		int_1 = new int[16];
	}

	public Class5962(int capacity)
	{
		if (capacity < 0)
		{
			throw new ArgumentOutOfRangeException("capacity");
		}
		int_1 = new int[capacity];
	}

	public virtual int Add(int value)
	{
		if (int_2 == int_1.Length)
		{
			method_0(int_2 + 1);
		}
		int_1[int_2] = value;
		return int_2++;
	}

	public virtual int vmethod_0(int index, int count, int value)
	{
		if (index >= 0 && count >= 0)
		{
			if (int_2 - index < count)
			{
				throw new ArgumentException("index and count");
			}
			return Class5948.smethod_7(int_1, index, count, value);
		}
		throw new ArgumentOutOfRangeException((index < 0) ? "index" : "count");
	}

	public virtual int vmethod_1(int value)
	{
		return vmethod_0(0, Count, value);
	}

	public virtual void Clear()
	{
		Array.Clear(int_1, 0, int_2);
		int_2 = 0;
	}

	public virtual Class5962 Clone()
	{
		Class5962 @class = new Class5962(int_2);
		@class.int_2 = int_2;
		Array.Copy(int_1, 0, @class.int_1, 0, int_2);
		return @class;
	}

	public virtual bool Contains(int item)
	{
		int num = 0;
		while (true)
		{
			if (num < int_2)
			{
				if (item == int_1[num])
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	private void method_0(int min)
	{
		if (int_1.Length < min)
		{
			int num = ((int_1.Length == 0) ? 16 : (int_1.Length * 2));
			if (num < min)
			{
				num = min;
			}
			Capacity = num;
		}
	}

	public virtual int IndexOf(int value)
	{
		return Array.IndexOf(int_1, value, 0, int_2);
	}

	public virtual int IndexOf(int value, int startIndex)
	{
		if (startIndex > int_2)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return Array.IndexOf(int_1, value, startIndex, int_2 - startIndex);
	}

	public virtual int IndexOf(int value, int startIndex, int count)
	{
		if (startIndex + count > int_2)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		return Array.IndexOf(int_1, value, startIndex, count);
	}

	public virtual void Insert(int index, int value)
	{
		if (index >= 0 && index <= int_2)
		{
			if (int_2 == int_1.Length)
			{
				method_0(int_2 + 1);
			}
			if (index < int_2)
			{
				Array.Copy(int_1, index, int_1, index + 1, int_2 - index);
			}
			int_1[index] = value;
			int_2++;
			return;
		}
		throw new ArgumentOutOfRangeException("index");
	}

	public virtual int vmethod_2(int value)
	{
		return vmethod_4(value, int_2 - 1, int_2);
	}

	public virtual int vmethod_3(int value, int startIndex)
	{
		if (startIndex >= int_2)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return vmethod_4(value, startIndex, startIndex + 1);
	}

	public virtual int vmethod_4(int value, int startIndex, int count)
	{
		if (int_2 == 0)
		{
			return -1;
		}
		if (startIndex >= 0 && count >= 0)
		{
			if (startIndex >= int_2 || count > startIndex + 1)
			{
				throw new ArgumentOutOfRangeException((startIndex >= int_2) ? "startIndex" : "count");
			}
			return Array.LastIndexOf(int_1, value, startIndex, count);
		}
		throw new ArgumentOutOfRangeException((startIndex < 0) ? "startIndex" : "count");
	}

	public virtual void Remove(int obj)
	{
		int num = IndexOf(obj);
		if (num >= 0)
		{
			RemoveAt(num);
		}
	}

	public virtual void RemoveAt(int index)
	{
		if (index >= 0 && index < int_2)
		{
			int_2--;
			if (index < int_2)
			{
				Array.Copy(int_1, index + 1, int_1, index, int_2 - index);
			}
			int_1[int_2] = 0;
			return;
		}
		throw new ArgumentOutOfRangeException("index");
	}

	public virtual void vmethod_5(int index, int count)
	{
		if (index >= 0 && count >= 0)
		{
			if (int_2 - index < count)
			{
				throw new ArgumentException("index and count");
			}
			if (count > 0)
			{
				int num = int_2;
				int_2 -= count;
				if (index < int_2)
				{
					Array.Copy(int_1, index + count, int_1, index, int_2 - index);
				}
				while (num > int_2)
				{
					int_1[--num] = 0;
				}
			}
			return;
		}
		throw new ArgumentOutOfRangeException((index < 0) ? "index" : "count");
	}

	public virtual void vmethod_6()
	{
		vmethod_7(0, Count);
	}

	public virtual void vmethod_7(int index, int count)
	{
		if (index >= 0 && count >= 0)
		{
			if (int_2 - index < count)
			{
				throw new ArgumentException("index and count");
			}
			Array.Reverse(int_1, index, count);
			return;
		}
		throw new ArgumentOutOfRangeException((index < 0) ? "index" : "count");
	}

	public virtual void vmethod_8()
	{
		vmethod_9(0, Count);
	}

	public virtual void vmethod_9(int index, int count)
	{
		if (index >= 0 && count >= 0)
		{
			if (int_2 - index < count)
			{
				throw new ArgumentException("index and count");
			}
			Array.Sort(int_1, index, count);
			return;
		}
		throw new ArgumentOutOfRangeException((index < 0) ? "index" : "count");
	}

	public virtual int[] ToArray()
	{
		int[] array = new int[int_2];
		Array.Copy(int_1, 0, array, 0, int_2);
		return array;
	}

	public virtual void vmethod_10()
	{
		Capacity = int_2;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < Count; i++)
		{
			stringBuilder.Append(this[i]);
			if (i < Count - 1)
			{
				stringBuilder.Append(" ");
			}
		}
		return stringBuilder.ToString();
	}
}

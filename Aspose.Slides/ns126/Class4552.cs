using System;
using System.Collections;

namespace ns126;

internal class Class4552
{
	private class Class4553
	{
		public byte[] byte_0;

		public int int_0;

		public int int_1;
	}

	private ArrayList arrayList_0 = new ArrayList();

	private int int_0 = -1;

	private int int_1 = -1;

	private Class4553 currentSnapshot => (Class4553)arrayList_0[int_0];

	public long Length
	{
		get
		{
			Class4553 @class = (Class4553)arrayList_0[int_0];
			return @class.int_1;
		}
	}

	public byte this[int index]
	{
		get
		{
			if (index >= currentSnapshot.int_1)
			{
				throw new IndexOutOfRangeException();
			}
			return currentSnapshot.byte_0[currentSnapshot.int_0 + index];
		}
		set
		{
			if (index >= currentSnapshot.int_1)
			{
				throw new IndexOutOfRangeException();
			}
			currentSnapshot.byte_0[currentSnapshot.int_0 + index] = value;
		}
	}

	public Class4552()
	{
	}

	public Class4552(byte[] array)
	{
		method_0(array);
	}

	public Class4552(byte[] array, int offset, int length)
	{
		method_1(array, offset, length);
	}

	public void method_0(byte[] array)
	{
		method_1(array, 0, array.Length);
	}

	public void method_1(byte[] array, int offset, int length)
	{
		if (int_0 < int_1)
		{
			int_0++;
		}
		else
		{
			int_0++;
			int_1++;
			arrayList_0.Add(new Class4553());
		}
		currentSnapshot.byte_0 = array;
		currentSnapshot.int_0 = offset;
		currentSnapshot.int_1 = length;
	}

	public void method_2()
	{
		if (int_0 > 0)
		{
			int_0--;
		}
	}
}

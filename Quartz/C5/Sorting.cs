using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace C5;

internal class Sorting
{
	private class Sorter<T>
	{
		private T[] a;

		private IComparer<T> c;

		internal Sorter(T[] a, IComparer<T> c)
		{
			this.a = a;
			this.c = c;
		}

		internal void IntroSort(int f, int b)
		{
			if (b - f > 31)
			{
				int depth_limit = (int)Math.Floor(2.5 * Math.Log(b - f, 2.0));
				introSort(f, b, depth_limit);
			}
			else
			{
				InsertionSort(f, b);
			}
		}

		private void introSort(int f, int b, int depth_limit)
		{
			if (depth_limit-- == 0)
			{
				HeapSort(f, b);
				return;
			}
			if (b - f <= 14)
			{
				InsertionSort(f, b);
				return;
			}
			int num = partition(f, b);
			introSort(f, num, depth_limit);
			introSort(num, b, depth_limit);
		}

		private int compare(T i1, T i2)
		{
			return c.Compare(i1, i2);
		}

		private int partition(int f, int b)
		{
			int num = (b + f) / 2;
			int num2 = b - 1;
			T val = a[f];
			T val2 = a[num];
			T val3 = a[num2];
			if (compare(val, val2) < 0)
			{
				if (compare(val3, val) < 0)
				{
					a[num2] = val2;
					val2 = (a[num] = val);
					a[f] = val3;
				}
				else if (compare(val3, val2) < 0)
				{
					a[num2] = val2;
					val2 = (a[num] = val3);
				}
			}
			else if (compare(val2, val3) > 0)
			{
				a[f] = val3;
				a[num2] = val;
			}
			else if (compare(val, val3) > 0)
			{
				a[f] = val2;
				val2 = (a[num] = val3);
				a[num2] = val;
			}
			else
			{
				a[f] = val2;
				val2 = (a[num] = val);
			}
			int num3 = f;
			int num4 = num2;
			while (true)
			{
				if (compare(a[++num3], val2) >= 0)
				{
					while (compare(val2, a[--num4]) < 0)
					{
					}
					if (num3 >= num4)
					{
						break;
					}
					T val4 = a[num3];
					a[num3] = a[num4];
					a[num4] = val4;
				}
			}
			return num3;
		}

		internal void InsertionSort(int f, int b)
		{
			for (int i = f + 1; i < b; i++)
			{
				T val = a[i];
				int num = i - 1;
				T val2;
				if (c.Compare(val2 = a[num], val) > 0)
				{
					a[i] = val2;
					while (num > f && c.Compare(val2 = a[num - 1], val) > 0)
					{
						a[num--] = val2;
					}
					a[num] = val;
				}
			}
		}

		internal void HeapSort(int f, int b)
		{
			for (int num = (b + f) / 2; num >= f; num--)
			{
				heapify(f, b, num);
			}
			for (int num2 = b - 1; num2 > f; num2--)
			{
				T val = a[f];
				a[f] = a[num2];
				a[num2] = val;
				heapify(f, num2, f);
			}
		}

		private void heapify(int f, int b, int i)
		{
			T val = a[i];
			T val2 = val;
			int num = i;
			int num2 = num;
			while (true)
			{
				int num3 = 2 * num - f + 1;
				int num4 = num3 + 1;
				T val3;
				if (num3 < b && compare(val3 = a[num3], val2) > 0)
				{
					num2 = num3;
					val2 = val3;
				}
				T val4;
				if (num4 < b && compare(val4 = a[num4], val2) > 0)
				{
					num2 = num4;
					val2 = val4;
				}
				if (num2 == num)
				{
					break;
				}
				a[num] = val2;
				val2 = val;
				num = num2;
			}
			if (num > i)
			{
				a[num] = val;
			}
		}
	}

	private Sorting()
	{
	}

	[Tested]
	[ComVisible(true)]
	public static void IntroSort<T>(T[] array, int start, int count, IComparer<T> comparer)
	{
		if (start < 0 || count < 0 || start + count > array.Length)
		{
			throw new ArgumentOutOfRangeException();
		}
		new Sorter<T>(array, comparer).IntroSort(start, start + count);
	}

	[Tested]
	[ComVisible(true)]
	public static void IntroSort<T>(T[] array)
	{
		new Sorter<T>(array, Comparer<T>.Default).IntroSort(0, array.Length);
	}

	[Tested]
	[ComVisible(true)]
	public static void InsertionSort<T>(T[] array, int start, int count, IComparer<T> comparer)
	{
		if (start < 0 || count < 0 || start + count > array.Length)
		{
			throw new ArgumentOutOfRangeException();
		}
		new Sorter<T>(array, comparer).InsertionSort(start, start + count);
	}

	[Tested]
	[ComVisible(true)]
	public static void HeapSort<T>(T[] array, int start, int count, IComparer<T> comparer)
	{
		if (start < 0 || count < 0 || start + count > array.Length)
		{
			throw new ArgumentOutOfRangeException();
		}
		new Sorter<T>(array, comparer).HeapSort(start, start + count);
	}
}

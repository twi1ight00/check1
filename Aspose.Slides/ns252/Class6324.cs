using System;
using System.Collections.Generic;

namespace ns252;

internal class Class6324<T>
{
	private List<T> list_0;

	private int int_0;

	private int int_1;

	public T FirstItem => method_0(0);

	public bool HasItems => Count > 0;

	public T LastItem => method_0(Count - 1);

	public int StartIndex
	{
		get
		{
			return int_1;
		}
		set
		{
			int endIndex = EndIndex;
			if (value <= EndIndex)
			{
				int_1 = value;
			}
			else
			{
				int_1 = EndIndex;
			}
			Count = endIndex - int_1;
		}
	}

	public int EndIndex
	{
		get
		{
			return int_1 + Count;
		}
		set
		{
			if (value < StartIndex)
			{
				Count = 0;
			}
			else
			{
				Count = value - int_1;
			}
		}
	}

	public int Count
	{
		get
		{
			return int_0;
		}
		set
		{
			if (StartIndex + value > Array.Count)
			{
				int_0 = Array.Count - StartIndex;
			}
			else
			{
				int_0 = value;
			}
		}
	}

	public List<T> Array
	{
		get
		{
			return list_0;
		}
		set
		{
			list_0 = value;
		}
	}

	public Class6324(List<T> array)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		list_0 = array;
		StartIndex = 0;
		Count = array.Count;
	}

	public T method_0(int index)
	{
		if (index < 0 || index >= Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		return list_0[StartIndex + index];
	}

	public void method_1(int itemsNumber)
	{
		StartIndex += itemsNumber;
	}

	public void method_2(int itemsNumber)
	{
		EndIndex -= itemsNumber;
	}

	public Class6324<T> Clone()
	{
		return (Class6324<T>)MemberwiseClone();
	}
}

using System;
using Aspose.Cells;

namespace ns13;

internal class Class933
{
	private int[] int_0;

	private int int_1;

	public int this[int int_2] => int_0[int_2];

	public int Count => int_1;

	public Class933(int int_2)
	{
		int_0 = new int[int_2];
		int_1 = 0;
	}

	public Class933()
	{
		int_0 = new int[8];
		int_1 = 0;
	}

	public void Add(int int_2)
	{
		method_1(1);
		int_0[int_1++] = int_2;
	}

	internal int method_0()
	{
		if (int_1 == 0)
		{
			throw new CellsException(ExceptionType.InvalidData, "No data in the stack");
		}
		int result = int_0[int_1 - 1];
		method_1(-1);
		int_1--;
		return result;
	}

	internal void Clear()
	{
		int_1 = 0;
		int_0 = new int[8];
	}

	internal void method_1(int int_2)
	{
		int num = int_1 + int_2;
		if (num > int_0.Length)
		{
			int[] destinationArray = new int[num * 2];
			Array.Copy(int_0, 0, destinationArray, 0, int_1);
			int_0 = destinationArray;
		}
		else if (num > 8 && num < int_0.Length / 3)
		{
			int[] destinationArray2 = new int[int_0.Length / 2];
			Array.Copy(int_0, 0, destinationArray2, 0, num);
			int_0 = destinationArray2;
		}
	}
}

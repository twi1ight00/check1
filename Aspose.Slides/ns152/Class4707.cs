using System;
using ns131;
using ns133;

namespace ns152;

internal class Class4707
{
	private double[] double_0;

	private int int_0;

	private int[] int_1;

	private int int_2;

	private string[] string_0;

	private int int_3;

	private Enum650[] enum650_0;

	private int int_4;

	public int Count => int_4 + 1;

	public Class4707()
	{
		string_0 = new string[10];
		double_0 = new double[100];
		int_1 = new int[100];
		enum650_0 = new Enum650[100];
		Clear();
	}

	public void Clear()
	{
		int_0 = -1;
		int_2 = -1;
		int_3 = -1;
		int_4 = -1;
	}

	public void method_0(double operand)
	{
		method_7();
		int_4++;
		int_0++;
		double_0[int_0] = operand;
		enum650_0[int_4] = Enum650.const_2;
	}

	public Enum650 method_1()
	{
		return enum650_0[int_4];
	}

	public Enum650 method_2(int stackOperandIndex)
	{
		if (int_4 - stackOperandIndex <= 0)
		{
			throw new IndexOutOfRangeException();
		}
		return enum650_0[int_4 - stackOperandIndex];
	}

	public double method_3()
	{
		return method_1() switch
		{
			Enum650.const_1 => method_4(), 
			Enum650.const_2 => method_5(), 
			_ => throw new Exception49("Unexpected PS object type in PS program."), 
		};
	}

	public double Peek(int index)
	{
		return method_1() switch
		{
			Enum650.const_1 => int_1[int_2 - index], 
			Enum650.const_2 => double_0[int_0 - index], 
			_ => throw new Exception49("Unexpected PS object type in PS program."), 
		};
	}

	public int method_4()
	{
		int_4--;
		return int_1[int_2--];
	}

	public double method_5()
	{
		int_4--;
		return double_0[int_0--];
	}

	public string method_6()
	{
		int_4--;
		return string_0[int_3--];
	}

	private void method_7()
	{
		if (int_0 + 1 >= double_0.Length)
		{
			double[] array = new double[double_0.Length * 2];
			for (int i = 0; i < double_0.Length; i++)
			{
				array[i] = double_0[i];
			}
			double_0 = array;
			method_8(double_0.Length);
		}
	}

	private void method_8(int size)
	{
		if (size > enum650_0.Length)
		{
			Enum650[] array = new Enum650[size];
			for (int i = 0; i < enum650_0.Length; i++)
			{
				array[i] = enum650_0[i];
			}
			enum650_0 = array;
		}
	}
}

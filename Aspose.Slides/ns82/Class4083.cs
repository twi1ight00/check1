using System;

namespace ns82;

internal abstract class Class4083
{
	public delegate int Delegate2775(Class4083 dfa, int s, Interface107 input);

	protected short[] short_0;

	protected short[] short_1;

	protected char[] char_0;

	protected char[] char_1;

	protected short[] short_2;

	protected short[] short_3;

	protected short[][] short_4;

	protected int int_0;

	public Delegate2775 delegate2775_0;

	protected Class4075 class4075_0;

	private bool bool_0;

	public virtual string Description => "n/a";

	public bool method_0(bool enable)
	{
		bool result = bool_0;
		bool_0 = enable;
		return result;
	}

	private void method_1(string errorMsg)
	{
		if (bool_0)
		{
			Console.Error.WriteLine(errorMsg);
		}
	}

	public int method_2(Interface107 input)
	{
		method_1("Enter DFA.predict for decision " + int_0);
		int marker = input.imethod_2();
		int num = 0;
		try
		{
			char c;
			while (true)
			{
				method_1("DFA " + int_0 + " state " + num + " LA(1)=" + (char)input.imethod_1(1) + "(" + input.imethod_1(1) + "), index=" + input.imethod_3());
				int num2 = short_3[num];
				if (num2 < 0)
				{
					if (short_2[num] >= 1)
					{
						method_1("accept; predict " + short_2[num] + " from state " + num);
						return short_2[num];
					}
					c = (char)input.imethod_1(1);
					if (c >= char_0[num] && c <= char_1[num])
					{
						int num3 = short_4[num][c - char_0[num]];
						if (num3 < 0)
						{
							if (short_0[num] < 0)
							{
								method_3(num, input);
								return 0;
							}
							method_1("EOT transition");
							num = short_0[num];
							input.imethod_0();
						}
						else
						{
							num = num3;
							input.imethod_0();
						}
					}
					else
					{
						if (short_0[num] < 0)
						{
							break;
						}
						method_1("EOT transition");
						num = short_0[num];
						input.imethod_0();
					}
				}
				else
				{
					method_1("DFA " + int_0 + " state " + num + " is special state " + num2);
					num = delegate2775_0(this, num2, input);
					if (bool_0)
					{
						Console.Error.WriteLine("DFA " + int_0 + " returns from special state " + num2 + " to " + num);
					}
					if (num == -1)
					{
						method_3(num, input);
						return 0;
					}
					input.imethod_0();
				}
			}
			if (c == (ushort)Class4398.int_7 && short_1[num] >= 0)
			{
				method_1("accept via EOF; predict " + short_2[short_1[num]] + " from " + short_1[num]);
				return short_2[short_1[num]];
			}
			if (bool_0)
			{
				Console.Error.WriteLine("min[" + num + "]=" + char_0[num]);
				Console.Error.WriteLine("max[" + num + "]=" + char_1[num]);
				Console.Error.WriteLine("eot[" + num + "]=" + short_0[num]);
				Console.Error.WriteLine("eof[" + num + "]=" + short_1[num]);
				for (int i = 0; i < short_4[num].Length; i++)
				{
					Console.Error.Write(short_4[num][i] + " ");
				}
				Console.Error.WriteLine();
			}
			method_3(num, input);
			return 0;
		}
		finally
		{
			input.imethod_4(marker);
		}
	}

	protected void method_3(int s, Interface107 input)
	{
		if (class4075_0.class4397_0.int_3 <= 0)
		{
			Exception27 exception = new Exception27(Description, int_0, s, input);
			vmethod_0(exception);
			throw exception;
		}
		class4075_0.class4397_0.bool_1 = true;
	}

	public virtual void vmethod_0(Exception27 nvae)
	{
	}

	public virtual int vmethod_1(int s, Interface107 input)
	{
		return -1;
	}

	public static short[] smethod_0(string encodedString)
	{
		int num = 0;
		for (int i = 0; i < encodedString.Length; i += 2)
		{
			num += encodedString[i];
		}
		short[] array = new short[num];
		int num2 = 0;
		for (int j = 0; j < encodedString.Length; j += 2)
		{
			char c = encodedString[j];
			char c2 = encodedString[j + 1];
			for (int k = 1; k <= c; k++)
			{
				array[num2++] = (short)c2;
			}
		}
		return array;
	}

	public static short[][] smethod_1(string[] encodedStrings)
	{
		short[][] array = new short[encodedStrings.Length][];
		for (int i = 0; i < encodedStrings.Length; i++)
		{
			array[i] = smethod_0(encodedStrings[i]);
		}
		return array;
	}

	public static char[] smethod_2(string encodedString)
	{
		int num = 0;
		for (int i = 0; i < encodedString.Length; i += 2)
		{
			num += encodedString[i];
		}
		char[] array = new char[num];
		int num2 = 0;
		for (int j = 0; j < encodedString.Length; j += 2)
		{
			char c = encodedString[j];
			char c2 = encodedString[j + 1];
			for (int k = 1; k <= c; k++)
			{
				array[num2++] = c2;
			}
		}
		return array;
	}

	public static int smethod_3(int state, int symbol)
	{
		return 0;
	}
}

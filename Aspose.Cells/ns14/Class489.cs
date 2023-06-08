using System;
using System.Runtime.CompilerServices;
using System.Text;
using ns2;

namespace ns14;

internal abstract class Class489 : Class488
{
	private char char_0;

	private char char_1;

	private Class494 class494_0;

	private Class505[][] class505_0;

	private int[][] int_0;

	private bool[] bool_0;

	private int[] int_1;

	private int[] int_2;

	private int[] int_3;

	private int[][] int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private int[] int_8;

	private int[] int_9;

	internal Class489(Class509 class509_1, string string_0)
		: base(class509_1, string_0)
	{
	}

	protected abstract char[] vmethod_5(char[] char_2, int[] int_10, int[] int_11);

	protected abstract void vmethod_6(char[] char_2, int int_10, int int_11, Class510 class510_0);

	[SpecialName]
	protected char method_5()
	{
		return char_0;
	}

	internal override void vmethod_4(Class515 class515_0, double double_0, Class518 class518_1)
	{
		class494_0.vmethod_4(class515_0, double_0, class518_1);
		method_6(class518_1.Value, class515_0, class518_1);
	}

	internal void method_6(char[] char_2, Class515 class515_0, Class518 class518_1)
	{
		int_8[0] = 0;
		if (char_2.Length > 0 && char_2[0] == '-')
		{
			int_9[0] = 1;
		}
		else
		{
			int_9[0] = 0;
		}
		int_8[int_8.Length - 1] = char_2.Length;
		int_9[int_8.Length - 1] = 0;
		char_2 = vmethod_5(char_2, int_8, int_9);
		char c = '\0';
		int num = 0;
		int[] array = null;
		if (int_6 > 0)
		{
			array = new int[int_6];
		}
		char[] array2 = null;
		int num2 = 0;
		int num3 = 0;
		if (int_6 + int_7 > 0)
		{
			int[] array3 = null;
			for (int i = 0; i < int_4.Length; i++)
			{
				int[] array4 = int_4[i];
				if (array4 == null)
				{
					continue;
				}
				int num4 = int_8[i] + int_9[i];
				int num5 = int_8[i + 1];
				int num6 = num5 - num4;
				if (bool_0[i])
				{
					int num7 = array4.Length - 1;
					while (num7 > -1)
					{
						int num8 = array4[num7];
						if (num8 < 0)
						{
							num8 = -num8 - 1;
						}
						if (num8 < num6)
						{
							num7--;
							continue;
						}
						if (array2 == null)
						{
							array2 = new char[char_2.Length + (class511_0.method_6() ? (int_6 + int_7 + 1 + (int_6 + int_7 - 1) / 3) : (int_6 + int_7))];
							Array.Copy(char_2, 0, array2, 0, num4);
							num2 = num4;
							array3 = new int[int_8.Length];
							Array.Copy(int_8, 0, array3, 0, int_8.Length);
						}
						else
						{
							Array.Copy(char_2, num3, array2, num2, num4 - num3);
							num2 += num4 - num3;
						}
						num3 = num4;
						int num9 = 0;
						int num10 = 0;
						if (class511_0.method_6())
						{
							int num11 = num3 + num10;
							while (num11 < num5 && char_2[num11] != char_1)
							{
								if (char_2[num11] >= '0' && char_2[num11] <= '9')
								{
									num10++;
									if (num10 > 2)
									{
										num9 = 1;
										num10 = 0;
										break;
									}
									num11++;
								}
								else
								{
									num11++;
								}
							}
							num9 += (num7 + num10) / 3;
						}
						for (int j = i + 1; j < int_8.Length; j++)
						{
							array3[j] += num7 + 1 + num9;
						}
						for (int k = 0; k <= num7; k++)
						{
							if (array4[k] < 0)
							{
								array2[num2] = c;
								array[num] = num2;
								num++;
							}
							else
							{
								array2[num2] = '0';
							}
							num2++;
							if (class511_0.method_6() && num9 > 0 && (num7 - k + num10) % 3 == 0)
							{
								if (array4[k] < 0)
								{
									array2[num2] = c;
									array[num] = num2;
									num++;
								}
								else
								{
									array2[num2] = char_1;
								}
								num2++;
								num9--;
							}
						}
						Array.Copy(char_2, num3, array2, num2, num6);
						num3 = num5;
						num2 += num6;
						break;
					}
					continue;
				}
				for (int l = 0; l < array4.Length; l++)
				{
					int num8 = array4[l];
					if (num8 < 0)
					{
						num8 = -num8 - 1;
					}
					if (num8 < num6)
					{
						continue;
					}
					if (array2 == null)
					{
						array2 = new char[char_2.Length + int_6 + int_7];
						Array.Copy(char_2, 0, array2, 0, num5);
						num2 = num5;
						array3 = new int[int_8.Length];
						Array.Copy(int_8, 0, array3, 0, int_8.Length);
					}
					else
					{
						num6 = num5 - num3;
						Array.Copy(char_2, num3, array2, num2, num6);
						num2 += num6;
					}
					num3 = num5;
					l = array4.Length - l;
					for (int m = i + 1; m < int_8.Length; m++)
					{
						array3[m] += l;
					}
					for (l = array4.Length - l; l < array4.Length; l++)
					{
						if (array4[l] < 0)
						{
							array2[num2] = c;
							array[num] = num2;
							num++;
						}
						else
						{
							array2[num2] = '0';
						}
						num2++;
					}
					break;
				}
			}
			if (array2 != null)
			{
				Array.Copy(char_2, num3, array2, num2, char_2.Length - num3);
				num2 += char_2.Length - num3;
				char_2 = new char[num2];
				Array.Copy(array2, 0, char_2, 0, num2);
				int_8 = array3;
			}
		}
		if (num > 0)
		{
			Array.Sort(array, 0, num);
		}
		if (int_5 > 0 || int_3 != null)
		{
			array2 = new char[char_2.Length + int_5];
			if (int_3 != null)
			{
				class518_1.method_7(int_3);
			}
			int num12 = 0;
			num2 = 0;
			num3 = 0;
			int num6;
			for (int n = 0; n < class505_0.Length; n++)
			{
				if (class505_0[n] == null)
				{
					continue;
				}
				int num4 = int_8[n] + int_9[n];
				int num5 = int_8[n + 1];
				num6 = num4 - num3;
				if (num6 > 0)
				{
					Array.Copy(char_2, num3, array2, num2, num6);
					num3 = num4;
					num2 += num6;
				}
				if (bool_0[n])
				{
					if (int_2 != null)
					{
						num12 = int_2[n] - 1;
					}
					num2 += int_1[n] + num5 - num4;
					num3 = num5;
					for (int num13 = class505_0[n].Length - 1; num13 > -1; num13--)
					{
						num6 = Math.Min(num3 - num4, int_0[n][num13]);
						if (num6 > 0)
						{
							num2 -= num6;
							num3 -= num6;
							Array.Copy(char_2, num3, array2, num2, num6);
						}
						Class518 @class = class505_0[n][num13].Format(class515_0, TypeCode.Double, 0.0);
						char[] value = @class.Value;
						if (value != null)
						{
							num2 -= value.Length;
							Array.Copy(value, 0, array2, num2, value.Length);
							if (num > 0)
							{
								for (int num14 = 0; num14 < num; num14++)
								{
									if (array[num14] >= num3)
									{
										for (; num14 < num; num14++)
										{
											array[num14] += value.Length;
										}
										break;
									}
								}
							}
						}
						num6 = @class.method_9();
						if (num6 > 0)
						{
							for (int num15 = num6 - 1; num15 > -1; num15--)
							{
								class518_1.method_12(num12, num2 + @class.method_11(num15));
								num12--;
							}
						}
					}
					num6 = num3 - num4;
					if (num6 > 0)
					{
						num2 -= num6;
						num3 -= num6;
						Array.Copy(char_2, num3, array2, num2, num6);
					}
					num2 += int_1[n] + num5 - num4;
					num3 = num5;
					if (int_2 != null)
					{
						num12 = int_2[n];
					}
					continue;
				}
				for (int num16 = 0; num16 < class505_0[n].Length; num16++)
				{
					num6 = Math.Min(num5 - num3, int_0[n][num16]);
					if (num6 > 0)
					{
						Array.Copy(char_2, num3, array2, num2, num6);
						num2 += num6;
						num3 += num6;
					}
					Class518 class2 = class505_0[n][num16].Format(class515_0, TypeCode.Double, 0.0);
					num6 = class2.method_9();
					if (num6 > 0)
					{
						for (int num17 = 0; num17 < num6; num17++)
						{
							class518_1.method_12(num12, num2 + class2.method_11(num17));
							num12++;
						}
					}
					char[] value2 = class2.Value;
					if (value2 == null)
					{
						continue;
					}
					Array.Copy(value2, 0, array2, num2, value2.Length);
					num2 += value2.Length;
					if (num <= 0)
					{
						continue;
					}
					for (int num18 = 0; num18 < num; num18++)
					{
						if (array[num18] >= num3)
						{
							for (; num18 < num; num18++)
							{
								array[num18] += value2.Length;
							}
							break;
						}
					}
				}
			}
			num6 = char_2.Length - num3;
			Array.Copy(char_2, num3, array2, num2, num6);
			char_2 = array2;
		}
		if (num > 0)
		{
			array2 = new char[char_2.Length - num];
			if (int_3 != null)
			{
				int[] array5 = new int[num + int_3.Length];
				class518_1.method_7(array5);
				int num19 = 0;
				int num20 = 0;
				num3 = 0;
				num2 = 0;
				int num6;
				for (int num21 = 0; num21 < num; num21++)
				{
					for (; num20 < int_3.Length; num20++)
					{
						array5[num19] = int_3[num20];
						int num22 = class518_1.method_11(num19);
						if (num22 > array[num21])
						{
							break;
						}
						class518_1.method_12(num19, num22 - num21);
						num19++;
					}
					num6 = array[num21] - num3;
					Array.Copy(char_2, num3, array2, num2, num6);
					num2 += num6;
					num3 += num6 + 1;
					array5[num19] = Class518.smethod_0(bool_1: false, array[num21] - num21, class515_0.method_3());
					num19++;
				}
				for (; num20 < int_3.Length; num20++)
				{
					array5[num19] = int_3[num20];
					class518_1.method_12(num19, class518_1.method_11(num19) - num);
					num19++;
				}
				num6 = char_2.Length - num3;
				Array.Copy(char_2, num3, array2, num2, num6);
			}
			else
			{
				int[] array6 = new int[num];
				class518_1.method_7(array6);
				num3 = 0;
				num2 = 0;
				int num6;
				for (int num23 = 0; num23 < num; num23++)
				{
					num6 = array[num23] - num3;
					Array.Copy(char_2, num3, array2, num2, num6);
					num2 += num6;
					num3 += num6 + 1;
					array6[num23] = Class518.smethod_0(bool_1: false, array[num23] - num23, class515_0.method_3());
				}
				num6 = char_2.Length - num3;
				Array.Copy(char_2, num3, array2, num2, num6);
			}
			char_2 = array2;
		}
		class518_1.method_1(Enum136.const_2, char_2);
	}

	protected override void vmethod_0(char[] char_2, int int_10, int int_11)
	{
		method_8(class509_0.method_0());
		StringBuilder stringBuilder = new StringBuilder(int_11 - int_10);
		method_4(char_2, int_10, int_11, stringBuilder);
		char_2 = stringBuilder.ToString().ToCharArray();
		stringBuilder.Length = 0;
		int_10 = 0;
		int_11 = char_2.Length;
		StringBuilder stringBuilder2 = new StringBuilder(int_11 - 0);
		Class510 @class = new Class510(class509_0, stringBuilder, stringBuilder2);
		vmethod_6(char_2, 0, int_11, @class);
		class505_0 = @class.method_6();
		if (class505_0 != null)
		{
			int_0 = @class.method_7();
			int_1 = @class.method_8();
			int_5 = @class.method_5();
			bool_0 = @class.method_9();
			int_3 = @class.method_10();
			int_2 = @class.method_11();
			int_4 = @class.method_12();
			for (int i = 0; i < int_0.Length; i++)
			{
				int[] array = int_0[i];
				if (array == null)
				{
					continue;
				}
				if (bool_0[i])
				{
					for (int j = 1; j < array.Length; j++)
					{
						array[j - 1] -= array[j];
					}
					continue;
				}
				for (int num = array.Length - 1; num > 0; num--)
				{
					array[num] -= array[num - 1];
				}
			}
			if (int_4 != null)
			{
				int_6 = 0;
				int_7 = 0;
				for (int k = 0; k < int_4.Length; k++)
				{
					if (int_4[k] == null)
					{
						continue;
					}
					int[] array2 = int_4[k];
					foreach (int num2 in array2)
					{
						if (num2 < 0)
						{
							int_6++;
						}
						else
						{
							int_7++;
						}
					}
				}
			}
			int_8 = new int[class505_0.Length + 1];
			int_9 = new int[int_8.Length];
		}
		class494_0 = new Class494(class509_0, stringBuilder2.ToString());
	}

	protected int method_7(char[] char_2, int int_10, int int_11, Class510 class510_0)
	{
		switch (char_2[int_10])
		{
		case ',':
			if (class511_0.method_4() < 0)
			{
				class510_0.method_4().Append(',');
			}
			else
			{
				class510_0.method_3().Append(',');
			}
			break;
		case '.':
			if (class511_0.method_4() < 0)
			{
				class510_0.method_1(bool_0: true, class510_0.method_4().Length);
				class511_0.method_5(class510_0.method_4().Length);
				class510_0.method_4().Append('.');
			}
			else
			{
				class510_0.method_3().Append(char_0);
			}
			break;
		case '0':
			class510_0.method_2(bool_0: true);
			class510_0.method_0();
			class510_0.method_4().Append('#');
			break;
		case '#':
			class510_0.method_0();
			class510_0.method_4().Append(char_2[int_10]);
			break;
		default:
			return vmethod_2(char_2, int_10, int_11, class510_0.method_3());
		case '[':
			return class509_0.method_3(char_2, int_10, int_11, class510_0.method_3(), bool_0: false);
		case '?':
			class510_0.method_2(bool_0: false);
			class510_0.method_0();
			class510_0.method_4().Append('#');
			break;
		}
		return int_10 + 1;
	}

	protected void method_8(Class516 class516_0)
	{
		char_0 = class516_0.method_4().method_2();
		char_1 = class516_0.method_4().method_3();
	}
}

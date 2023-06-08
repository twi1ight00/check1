using System;
using System.Drawing;
using System.Globalization;
using ns22;

namespace ns33;

internal class Class845
{
	private Color[] color_0 = new Color[12];

	public Class845()
	{
		method_0();
	}

	private void method_0()
	{
		for (int i = 0; i < color_0.Length; i++)
		{
			ref Color reference = ref color_0[i];
			reference = method_1(i);
		}
	}

	private Color method_1(int int_0)
	{
		return int_0 switch
		{
			0 => smethod_0("ffffff"), 
			1 => smethod_0("000000"), 
			2 => smethod_0("EEECE1"), 
			3 => smethod_0("1F497D"), 
			4 => smethod_0("4F81BD"), 
			5 => smethod_0("C0504D"), 
			6 => smethod_0("9BBB59"), 
			7 => smethod_0("8064A2"), 
			8 => smethod_0("4BACC6"), 
			9 => smethod_0("F79646"), 
			10 => smethod_0("0000FF"), 
			11 => smethod_0("800080"), 
			_ => smethod_0("000000"), 
		};
	}

	private static Color smethod_0(string string_0)
	{
		int argb = int.Parse(string_0, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
		Color baseColor = Color.FromArgb(argb);
		return Color.FromArgb(255, baseColor);
	}

	public void ChangePalette(Color[] color_1)
	{
		if (color_1 == null || color_1.Length == 0)
		{
			return;
		}
		int i;
		for (i = 0; i < color_1.Length && i < color_0.Length; i++)
		{
			if (!Class1178.smethod_0(color_1[i]))
			{
				ref Color reference = ref color_0[i];
				reference = Color.FromArgb(255, color_1[i].R, color_1[i].G, color_1[i].B);
			}
			else
			{
				ref Color reference2 = ref color_0[i];
				reference2 = method_1(i);
			}
		}
		if (i < color_0.Length)
		{
			for (; i < color_0.Length; i++)
			{
				ref Color reference3 = ref color_0[i];
				reference3 = method_1(i);
			}
		}
	}

	internal Color method_2(string string_0)
	{
		int num = method_3(string_0);
		return color_0[num];
	}

	private int method_3(string string_0)
	{
		int num = 0;
		if (!string_0.Equals("lt1") && !string_0.Equals("bg1"))
		{
			if (!string_0.Equals("dk1") && !string_0.Equals("tx1"))
			{
				if (!string_0.Equals("lt2") && !string_0.Equals("bg2"))
				{
					if (!string_0.Equals("dk2") && !string_0.Equals("tx2"))
					{
						if (string_0.Equals("accent1"))
						{
							return 4;
						}
						if (string_0.Equals("accent2"))
						{
							return 5;
						}
						if (string_0.Equals("accent3"))
						{
							return 6;
						}
						if (string_0.Equals("accent4"))
						{
							return 7;
						}
						if (string_0.Equals("accent5"))
						{
							return 8;
						}
						if (string_0.Equals("accent6"))
						{
							return 9;
						}
						if (string_0.Equals("hlink"))
						{
							return 10;
						}
						if (string_0.Equals("folHlink"))
						{
							return 11;
						}
						return 11;
					}
					return 3;
				}
				return 2;
			}
			return 1;
		}
		return 0;
	}

	public Color[] method_4(int int_0, int int_1)
	{
		if (int_1 <= 0)
		{
			return null;
		}
		Color[] array = new Color[6];
		for (int i = 1; i < 7; i++)
		{
			ref Color reference = ref array[i - 1];
			reference = method_2("accent" + i);
		}
		int num = int_0 % 8;
		Color[] array2;
		switch (num)
		{
		default:
			array2 = method_5(array, num, int_1);
			break;
		case 0:
			array2 = method_5(new Color[1] { array[5] }, num, int_1);
			break;
		case 1:
		{
			Color color_ = method_2("dk1");
			if (int_0 == 41)
			{
				double[] array3 = new double[6] { 0.05, 0.55, 0.78, 0.15, 0.7, 0.3 };
				for (int j = 0; j < 6; j++)
				{
					ref Color reference2 = ref array[j];
					reference2 = method_6(color_, array3[j]);
				}
				return method_5(array, num, int_1);
			}
			double[] array4 = new double[6] { 0.88, 0.55, 0.78, 0.92, 0.7, 0.3 };
			for (int k = 0; k < 6; k++)
			{
				ref Color reference3 = ref array[k];
				reference3 = method_6(color_, array4[k]);
			}
			array2 = method_5(array, num, int_1);
			break;
		}
		case 2:
			array2 = method_5(array, num, int_1);
			break;
		case 3:
			array2 = method_5(new Color[1] { array[0] }, num, int_1);
			break;
		case 4:
			array2 = method_5(new Color[1] { array[1] }, num, int_1);
			break;
		case 5:
			array2 = method_5(new Color[1] { array[2] }, num, int_1);
			break;
		case 6:
			array2 = method_5(new Color[1] { array[3] }, num, int_1);
			break;
		case 7:
			array2 = method_5(new Color[1] { array[4] }, num, int_1);
			break;
		}
		method_10(array2);
		return array2;
	}

	private Color[] method_5(Color[] color_1, int int_0, int int_1)
	{
		Color[] array = new Color[int_1];
		int i = 0;
		if (((int_0 != 1 && int_0 != 2) || color_1.Length != 6) && ((int_0 != 0 && int_0 <= 2) || color_1.Length != 1))
		{
			return null;
		}
		if (color_1.Length == 6)
		{
			if (int_1 < color_1.Length)
			{
				for (; i < int_1; i++)
				{
					ref Color reference = ref array[i];
					reference = color_1[i];
				}
				return array;
			}
		}
		else if (int_0 > 2 && int_1 == 1)
		{
			ref Color reference2 = ref array[0];
			reference2 = color_1[0];
			return array;
		}
		int num = 1;
		num = ((color_1.Length != 6) ? int_1 : (int_1 / 6 + 1));
		int num2 = (int)((double)num / 2.0 + 0.5);
		int j;
		for (j = 1; j < num2 + 1; j++)
		{
			if (i >= int_1)
			{
				break;
			}
			double double_ = Math.Floor(30.0 + 140.0 * (double)j / ((double)num + 1.0)) / 100.0;
			if (color_1.Length == 6)
			{
				for (int k = 0; k < 6; k++)
				{
					if (i >= int_1)
					{
						break;
					}
					Color color = method_7(color_1[k], double_);
					array[i] = color;
					i++;
				}
			}
			else
			{
				Color color2 = method_7(color_1[0], double_);
				array[i] = color2;
				i++;
			}
		}
		for (; j < num + 1; j++)
		{
			if (i >= int_1)
			{
				break;
			}
			double double_2 = Math.Ceiling(170.0 - 140.0 * (double)j / ((double)num + 1.0)) / 100.0;
			if (color_1.Length == 6)
			{
				for (int l = 0; l < 6; l++)
				{
					if (i >= int_1)
					{
						break;
					}
					Color color3 = method_6(color_1[l], double_2);
					array[i] = color3;
					i++;
				}
			}
			else
			{
				Color color4 = method_6(color_1[0], double_2);
				array[i] = color4;
				i++;
			}
		}
		return array;
	}

	internal Color method_6(Color color_1, double double_0)
	{
		int[] array = new int[3] { color_1.R, color_1.G, color_1.B };
		for (int i = 0; i < 3; i++)
		{
			double num = method_8(array[i]);
			double double_ = num * (1.0 + (1.0 - double_0));
			if (double_0 > 0.0)
			{
				double_ = num * (1.0 - (1.0 - double_0)) + (1.0 - double_0);
			}
			array[i] = method_9(double_);
		}
		return Color.FromArgb(array[0], array[1], array[2]);
	}

	internal Color method_7(Color color_1, double double_0)
	{
		int[] array = new int[3] { color_1.R, color_1.G, color_1.B };
		for (int i = 0; i < 3; i++)
		{
			double num = method_8(array[i]);
			double num2 = num * double_0;
			if (num2 < 0.0)
			{
				num2 = 0.0;
			}
			else if (num2 > 1.0)
			{
				num2 = 1.0;
			}
			array[i] = method_9(num2);
		}
		return Color.FromArgb(array[0], array[1], array[2]);
	}

	private double method_8(int int_0)
	{
		double num = (double)int_0 / 255.0;
		double num2 = 0.0;
		if (num < 0.0)
		{
			return 0.0;
		}
		if (num <= 0.04045)
		{
			return num / 12.92;
		}
		if (num <= 1.0)
		{
			return Math.Pow((num + 0.055) / 1.055, 2.4);
		}
		return 1.0;
	}

	private int method_9(double double_0)
	{
		double num = 0.0;
		num = ((double_0 < 0.0) ? 0.0 : ((double_0 <= 0.0031308) ? (double_0 * 12.92) : ((!(double_0 < 1.0)) ? 1.0 : (1.055 * Math.Pow(double_0, 5.0 / 12.0) - 0.055))));
		return (int)Math.Round(num * 255.0, 0, MidpointRounding.AwayFromZero);
	}

	private void method_10(Color[] color_1)
	{
		if (color_1 != null)
		{
			for (int i = 0; i < color_1.Length; i++)
			{
				Color baseColor = color_1[i];
				ref Color reference = ref color_1[i];
				reference = Color.FromArgb(255, baseColor);
			}
		}
	}
}

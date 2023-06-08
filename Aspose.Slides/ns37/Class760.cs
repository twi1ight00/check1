using System;
using System.Drawing;
using System.Globalization;

namespace ns37;

internal class Class760
{
	private Color[] color_0 = new Color[12];

	internal Color[] Colors => color_0;

	internal Color Light1 => color_0[0];

	internal Color Background1 => color_0[0];

	internal Color Dark1 => color_0[1];

	internal Color Text1 => color_0[1];

	internal Color Light2 => color_0[2];

	internal Color Background2 => color_0[2];

	internal Color Dark2 => color_0[3];

	internal Color Text2 => color_0[3];

	internal Color Accent1 => color_0[4];

	internal Color Accent2 => color_0[5];

	internal Color Accent3 => color_0[6];

	internal Color Accent4 => color_0[7];

	internal Color Accent5 => color_0[8];

	internal Color Accent6 => color_0[9];

	internal Color Hyperlink => color_0[10];

	internal Color FollowedHyperlink => color_0[11];

	public Class760()
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

	private Color method_1(int index)
	{
		return index switch
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

	private static Color smethod_0(string str)
	{
		int argb = int.Parse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
		Color baseColor = Color.FromArgb(argb);
		return Color.FromArgb(255, baseColor);
	}

	public void method_2(Color[] colors)
	{
		if (colors == null || colors.Length == 0)
		{
			return;
		}
		int i;
		for (i = 0; i < colors.Length && i < color_0.Length; i++)
		{
			if (colors[i] != Color.Empty)
			{
				ref Color reference = ref color_0[i];
				reference = Color.FromArgb(255, colors[i].R, colors[i].G, colors[i].B);
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

	internal Color method_3(string name)
	{
		int num = method_4(name);
		return color_0[num];
	}

	private int method_4(string name)
	{
		int num = 0;
		if (!name.Equals("lt1") && !name.Equals("bg1"))
		{
			if (!name.Equals("dk1") && !name.Equals("tx1"))
			{
				if (!name.Equals("lt2") && !name.Equals("bg2"))
				{
					if (!name.Equals("dk2") && !name.Equals("tx2"))
					{
						if (name.Equals("accent1"))
						{
							return 4;
						}
						if (name.Equals("accent2"))
						{
							return 5;
						}
						if (name.Equals("accent3"))
						{
							return 6;
						}
						if (name.Equals("accent4"))
						{
							return 7;
						}
						if (name.Equals("accent5"))
						{
							return 8;
						}
						if (name.Equals("accent6"))
						{
							return 9;
						}
						if (name.Equals("hlink"))
						{
							return 10;
						}
						if (name.Equals("folHlink"))
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

	public Color[] method_5(int style, int count)
	{
		if (count <= 0)
		{
			return null;
		}
		Color[] array = new Color[6];
		for (int i = 1; i < 7; i++)
		{
			ref Color reference = ref array[i - 1];
			reference = method_3("accent" + i);
		}
		int num = style % 8;
		Color[] array2;
		switch (num)
		{
		default:
			array2 = method_6(array, num, count);
			break;
		case 0:
			array2 = method_6(new Color[1] { array[5] }, num, count);
			break;
		case 1:
		{
			Color color = method_3("dk1");
			if (style == 41)
			{
				double[] array3 = new double[6] { 0.05, 0.55, 0.78, 0.15, 0.7, 0.3 };
				for (int j = 0; j < 6; j++)
				{
					ref Color reference2 = ref array[j];
					reference2 = method_7(color, array3[j]);
				}
				return method_6(array, num, count);
			}
			double[] array4 = new double[6] { 0.88, 0.55, 0.78, 0.92, 0.7, 0.3 };
			for (int k = 0; k < 6; k++)
			{
				ref Color reference3 = ref array[k];
				reference3 = method_7(color, array4[k]);
			}
			array2 = method_6(array, num, count);
			break;
		}
		case 2:
			array2 = method_6(array, num, count);
			break;
		case 3:
			array2 = method_6(new Color[1] { array[0] }, num, count);
			break;
		case 4:
			array2 = method_6(new Color[1] { array[1] }, num, count);
			break;
		case 5:
			array2 = method_6(new Color[1] { array[2] }, num, count);
			break;
		case 6:
			array2 = method_6(new Color[1] { array[3] }, num, count);
			break;
		case 7:
			array2 = method_6(new Color[1] { array[4] }, num, count);
			break;
		}
		method_11(array2);
		return array2;
	}

	private Color[] method_6(Color[] colors, int styleIdx, int count)
	{
		Color[] array = new Color[count];
		int i = 0;
		if (((styleIdx != 1 && styleIdx != 2) || colors.Length != 6) && ((styleIdx != 0 && styleIdx <= 2) || colors.Length != 1))
		{
			return null;
		}
		if (colors.Length == 6)
		{
			if (count < colors.Length)
			{
				for (; i < count; i++)
				{
					ref Color reference = ref array[i];
					reference = colors[i];
				}
				return array;
			}
		}
		else if (styleIdx > 2 && count == 1)
		{
			ref Color reference2 = ref array[0];
			reference2 = colors[0];
			return array;
		}
		int num = 1;
		num = ((colors.Length != 6) ? count : (count / 6 + 1));
		int num2 = (int)((double)num / 2.0 + 0.5);
		int j;
		for (j = 1; j < num2 + 1; j++)
		{
			if (i >= count)
			{
				break;
			}
			double shade = Math.Floor(30.0 + 140.0 * (double)j / ((double)num + 1.0)) / 100.0;
			if (colors.Length == 6)
			{
				for (int k = 0; k < 6; k++)
				{
					if (i >= count)
					{
						break;
					}
					Color color = method_8(colors[k], shade);
					array[i] = color;
					i++;
				}
			}
			else
			{
				Color color2 = method_8(colors[0], shade);
				array[i] = color2;
				i++;
			}
		}
		for (; j < num + 1; j++)
		{
			if (i >= count)
			{
				break;
			}
			double tint = Math.Ceiling(170.0 - 140.0 * (double)j / ((double)num + 1.0)) / 100.0;
			if (colors.Length == 6)
			{
				for (int l = 0; l < 6; l++)
				{
					if (i >= count)
					{
						break;
					}
					Color color3 = method_7(colors[l], tint);
					array[i] = color3;
					i++;
				}
			}
			else
			{
				Color color4 = method_7(colors[0], tint);
				array[i] = color4;
				i++;
			}
		}
		return array;
	}

	internal Color method_7(Color color, double tint)
	{
		int[] array = new int[3] { color.R, color.G, color.B };
		for (int i = 0; i < 3; i++)
		{
			double num = method_9(array[i]);
			double scrgbValue = num * (1.0 + (1.0 - tint));
			if (tint > 0.0)
			{
				scrgbValue = num * (1.0 - (1.0 - tint)) + (1.0 - tint);
			}
			array[i] = method_10(scrgbValue);
		}
		return Color.FromArgb(array[0], array[1], array[2]);
	}

	internal Color method_8(Color color, double shade)
	{
		int[] array = new int[3] { color.R, color.G, color.B };
		for (int i = 0; i < 3; i++)
		{
			double num = method_9(array[i]);
			double num2 = num * shade;
			if (num2 < 0.0)
			{
				num2 = 0.0;
			}
			else if (num2 > 1.0)
			{
				num2 = 1.0;
			}
			array[i] = method_10(num2);
		}
		return Color.FromArgb(array[0], array[1], array[2]);
	}

	private double method_9(int srgbValue)
	{
		double num = (double)srgbValue / 255.0;
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

	private int method_10(double scrgbValue)
	{
		double num = 0.0;
		num = ((scrgbValue < 0.0) ? 0.0 : ((scrgbValue <= 0.0031308) ? (scrgbValue * 12.92) : ((!(scrgbValue < 1.0)) ? 1.0 : (1.055 * Math.Pow(scrgbValue, 5.0 / 12.0) - 0.055))));
		return (int)Math.Round(num * 255.0, 0, MidpointRounding.AwayFromZero);
	}

	private void method_11(Color[] colors)
	{
		if (colors != null)
		{
			for (int i = 0; i < colors.Length; i++)
			{
				Color baseColor = colors[i];
				ref Color reference = ref colors[i];
				reference = Color.FromArgb(255, baseColor);
			}
		}
	}
}

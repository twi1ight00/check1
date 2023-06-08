using System;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using ns178;
using ns183;
using ns209;

namespace ns195;

internal class Class5482 : Class5481
{
	private Class5482()
	{
	}

	public static bool smethod_0(Interface236 attributes, string name, bool defaultValue)
	{
		string text = attributes.imethod_5(name);
		if (text == null)
		{
			return defaultValue;
		}
		bool result = false;
		if (text.Equals("True"))
		{
			result = true;
		}
		return result;
	}

	public static int smethod_1(Interface236 attributes, string name, int defaultValue)
	{
		string text = attributes.imethod_5(name);
		if (text == null)
		{
			return defaultValue;
		}
		return int.Parse(text);
	}

	public static int smethod_2(Interface236 attributes, string name)
	{
		string text = attributes.imethod_5(name);
		if (text == null)
		{
			throw new Exception51("Attribute '" + name + "' is missing");
		}
		return int.Parse(text);
	}

	public static int smethod_3(Interface236 attributes, string name)
	{
		string text = attributes.imethod_5(name);
		if (text == null)
		{
			return 0;
		}
		return int.Parse(text);
	}

	public static RectangleF smethod_4(Interface236 attributes, string name)
	{
		string baseString = attributes.imethod_5(name).Trim();
		double[] array = Class5478.smethod_1(baseString, "\\s");
		if (array.Length != 4)
		{
			throw new ArgumentException("Rectangle must consist of 4 double values!");
		}
		return new RectangleF((float)array[0], (float)array[1], (float)array[2], (float)array[3]);
	}

	public static RectangleF smethod_5(Interface236 attributes, string name)
	{
		string text = attributes.imethod_5(name);
		if (text == null)
		{
			return RectangleF.Empty;
		}
		int[] array = Class5478.smethod_0(text.Trim(), "\\s");
		if (array.Length != 4)
		{
			throw new ArgumentException("Rectangle must consist of 4 int values!");
		}
		return new RectangleF(array[0], array[1], array[2], array[3]);
	}

	public static int[] smethod_6(Interface236 attributes, string name)
	{
		string text = attributes.imethod_5(name);
		if (text == null)
		{
			return null;
		}
		return Class5478.smethod_0(text.Trim(), "\\s");
	}

	public static void smethod_7(Class5699 atts, Class5619 attribute, string value)
	{
		atts.method_1(attribute.method_0(), attribute.method_2(), attribute.method_3(), "CDATA", value);
	}

	public static void smethod_8(Class5699 atts, string localName, string value)
	{
		atts.method_1(string.Empty, localName, localName, "CDATA", value);
	}

	public static string smethod_9(int[][] dp, int paCount)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		stringBuilder.Append(paCount);
		for (int i = 0; i < paCount; i++)
		{
			int[] array = dp[i];
			for (int j = 0; j < 4; j++)
			{
				int num2 = array[j];
				if (num2 != 0)
				{
					smethod_11(stringBuilder, num, num2);
					num = 0;
				}
				else
				{
					num++;
				}
			}
		}
		smethod_11(stringBuilder, num, 0);
		return stringBuilder.ToString();
	}

	public static string smethod_10(int[][] dp)
	{
		return smethod_9(dp, dp.Length);
	}

	private static void smethod_11(StringBuilder sb, int nz, int a)
	{
		smethod_12(sb, nz);
		smethod_13(sb, a);
	}

	private static void smethod_12(StringBuilder sb, int nz)
	{
		if (nz > 0)
		{
			sb.Append(' ');
			if (nz == 1)
			{
				sb.Append('0');
				return;
			}
			sb.Append('Z');
			sb.Append(nz);
		}
	}

	private static void smethod_13(StringBuilder sb, int a)
	{
		if (a != 0)
		{
			sb.Append(' ');
			sb.Append(a);
		}
	}

	public static int[][] smethod_14(string value)
	{
		int[][] array = null;
		if (value != null)
		{
			string[] array2 = Regex.Split(value, "\\s");
			if (array2 != null && array2.Length > 0)
			{
				int num = int.Parse(array2[0]);
				array = new int[num][];
				for (int i = 0; i < num; i++)
				{
					array[i] = new int[4];
				}
				int j = 1;
				int num2 = array2.Length;
				int num3 = 0;
				for (; j < num2; j++)
				{
					string text = array2[j];
					if (text[0] == 'Z')
					{
						int num4 = int.Parse(text.Substring(1));
						num3 += num4;
					}
					else
					{
						array[num3 / 4][num3 % 4] = int.Parse(text);
						num3++;
					}
				}
			}
		}
		return array;
	}

	public static int[][] smethod_15(Interface236 attributes, string name)
	{
		string text = attributes.imethod_5(name);
		if (text == null)
		{
			return null;
		}
		return smethod_14(text.Trim());
	}
}

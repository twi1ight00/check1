using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Xml;
using Aspose.Slides;

namespace ns33;

internal class Class1149
{
	private readonly string string_0;

	private readonly int int_0;

	private readonly int int_1;

	private int int_2;

	public int Position
	{
		get
		{
			return int_2 - int_0;
		}
		set
		{
			int_2 = int_0 + value;
		}
	}

	public char CurrentChar
	{
		get
		{
			if (int_2 < int_1)
			{
				return string_0[int_2];
			}
			return '\uffff';
		}
	}

	public int CharsLeftCount => int_1 - int_2;

	public Class1149(string str)
		: this(str, 0, str?.Length ?? 0)
	{
	}

	public Class1149(string str, int start, int length)
	{
		string_0 = str;
		int_0 = start;
		int_1 = start + length;
		int_2 = start;
	}

	public void method_0(IColorFormat colorFormat)
	{
		method_1(colorFormat, null, null, null, null);
	}

	public void method_1(IColorFormat colorFormat, IColorFormat fillColor, IColorFormat fillBackColor, IColorFormat lineColor, IColorFormat lineBackColor)
	{
		while (int_2 < int_1 && string_0[int_2] <= ' ')
		{
			int_2++;
		}
		if (int_2 >= int_1)
		{
			return;
		}
		if (string_0[int_2] == '#')
		{
			colorFormat.ColorType = ColorType.RGB;
			int_2++;
			int num = int_2;
			while (int_2 < int_1 && ((string_0[int_2] >= '0' && string_0[int_2] <= '9') || (string_0[int_2] >= 'a' && string_0[int_2] <= 'f') || (string_0[int_2] >= 'A' && string_0[int_2] <= 'F')))
			{
				int_2++;
			}
			if (int_2 - num <= 3)
			{
				int num2 = Convert.ToInt32(string_0.Substring(num, int_2 - num), 16);
				int num3 = (num2 & 0xF00) >> 8;
				colorFormat.R = (byte)(num3 * 16 + num3);
				num3 = (num2 & 0xF0) >> 4;
				colorFormat.G = (byte)(num3 * 16 + num3);
				num3 = num2 & 0xF;
				colorFormat.B = (byte)(num3 * 16 + num3);
			}
			else if (int_2 - num <= 6)
			{
				colorFormat.Color = Color.FromArgb((int)Convert.ToUInt32(string_0.Substring(num, int_2 - num), 16) | -16777216);
			}
			else
			{
				colorFormat.B = 0;
				colorFormat.G = 0;
				colorFormat.R = 0;
			}
		}
		else
		{
			string text = method_2().ToLower(CultureInfo.InvariantCulture);
			string[] array = method_5();
			switch (text)
			{
			case "rgb":
				colorFormat.ColorType = ColorType.RGB;
				colorFormat.R = (byte)((array.Length >= 1) ? XmlConvert.ToByte(array[0]) : 0);
				colorFormat.G = (byte)((array.Length >= 2) ? XmlConvert.ToByte(array[1]) : 0);
				colorFormat.B = (byte)((array.Length >= 3) ? XmlConvert.ToByte(array[2]) : 0);
				break;
			case "fill":
				if (fillColor != null && fillColor.ColorType != ColorType.NotDefined)
				{
					colorFormat.CopyFrom(fillColor);
				}
				else
				{
					colorFormat.PresetColor = PresetColor.Black;
				}
				break;
			case "fillback":
				if (fillBackColor != null && fillBackColor.ColorType != ColorType.NotDefined)
				{
					colorFormat.CopyFrom(fillBackColor);
				}
				else
				{
					colorFormat.PresetColor = PresetColor.Black;
				}
				break;
			case "line":
				if (lineColor != null && lineColor.ColorType != ColorType.NotDefined)
				{
					colorFormat.CopyFrom(lineColor);
				}
				else
				{
					colorFormat.PresetColor = PresetColor.Black;
				}
				break;
			case "lineback":
				if (lineBackColor != null && lineBackColor.ColorType != ColorType.NotDefined)
				{
					colorFormat.CopyFrom(lineBackColor);
				}
				else
				{
					colorFormat.PresetColor = PresetColor.Black;
				}
				break;
			case "lineorfill":
				if (lineColor != null && lineColor.ColorType != ColorType.NotDefined)
				{
					colorFormat.CopyFrom(lineColor);
				}
				else if (fillColor != null && fillColor.ColorType != ColorType.NotDefined)
				{
					colorFormat.CopyFrom(fillColor);
				}
				else
				{
					colorFormat.PresetColor = PresetColor.Black;
				}
				break;
			case "fillthenline":
				if (fillColor != null && fillColor.ColorType != ColorType.NotDefined)
				{
					colorFormat.CopyFrom(fillColor);
				}
				else if (lineColor != null && lineColor.ColorType != ColorType.NotDefined)
				{
					colorFormat.CopyFrom(lineColor);
				}
				else
				{
					colorFormat.PresetColor = PresetColor.Black;
				}
				break;
			case "silver":
				colorFormat.PresetColor = PresetColor.Silver;
				break;
			case "gray":
				colorFormat.PresetColor = PresetColor.Gray;
				break;
			case "white":
				colorFormat.PresetColor = PresetColor.White;
				break;
			case "maroon":
				colorFormat.PresetColor = PresetColor.Maroon;
				break;
			case "red":
				colorFormat.PresetColor = PresetColor.Red;
				break;
			case "purple":
				colorFormat.PresetColor = PresetColor.Purple;
				break;
			case "fuchsia":
				colorFormat.PresetColor = PresetColor.Fuchsia;
				break;
			case "green":
				colorFormat.PresetColor = PresetColor.Green;
				break;
			case "lime":
				colorFormat.PresetColor = PresetColor.Lime;
				break;
			case "olive":
				colorFormat.PresetColor = PresetColor.Olive;
				break;
			case "yellow":
				colorFormat.PresetColor = PresetColor.Yellow;
				break;
			case "navy":
				colorFormat.PresetColor = PresetColor.Navy;
				break;
			case "blue":
				colorFormat.PresetColor = PresetColor.Blue;
				break;
			case "teal":
				colorFormat.PresetColor = PresetColor.Teal;
				break;
			case "aqua":
				colorFormat.PresetColor = PresetColor.Aqua;
				break;
			default:
				colorFormat.PresetColor = PresetColor.Black;
				break;
			}
		}
		method_6();
		if (int_2 >= int_1)
		{
			return;
		}
		string text2 = method_2().ToLower(CultureInfo.InvariantCulture);
		string[] array2 = method_5();
		if (text2.Length <= 0)
		{
			return;
		}
		if (text2 == "darken")
		{
			float parameter = 0.6f;
			if (array2.Length > 1)
			{
				parameter = Class1165.smethod_5((float)XmlConvert.ToInt32(array2[0]) / 255f, 0f, 1f);
			}
			colorFormat.ColorTransform.Add(ColorTransformOperation.Shade, parameter);
			return;
		}
		switch (text2)
		{
		case "darken":
		{
			float parameter2 = 0.6f;
			if (array2.Length > 1)
			{
				parameter2 = Class1165.smethod_5((float)XmlConvert.ToInt32(array2[0]) / 255f, 0f, 1f);
			}
			colorFormat.ColorTransform.Add(ColorTransformOperation.Tint, parameter2);
			break;
		}
		case "add":
		{
			float parameter3 = 0.6f;
			if (array2.Length > 1)
			{
				parameter3 = Class1165.smethod_5((float)XmlConvert.ToInt32(array2[0]) / 255f, 0f, 1f);
			}
			colorFormat.ColorTransform.Add(ColorTransformOperation.AddRed, parameter3);
			colorFormat.ColorTransform.Add(ColorTransformOperation.AddGreen, parameter3);
			colorFormat.ColorTransform.Add(ColorTransformOperation.AddBlue, parameter3);
			break;
		}
		case "subtract":
		{
			float parameter4 = 0.6f;
			if (array2.Length > 1)
			{
				parameter4 = Class1165.smethod_5((float)XmlConvert.ToInt32(array2[0]) / 255f, 0f, 1f);
			}
			colorFormat.ColorTransform.Add(ColorTransformOperation.AddRed, parameter4);
			colorFormat.ColorTransform.Add(ColorTransformOperation.AddGreen, parameter4);
			colorFormat.ColorTransform.Add(ColorTransformOperation.AddBlue, parameter4);
			break;
		}
		case "reversesubtract":
		{
			int num4 = 255;
			if (array2.Length > 1)
			{
				num4 = Class1165.smethod_4(XmlConvert.ToInt32(array2[0]), 0, 255);
			}
			Color color2 = colorFormat.Color;
			colorFormat.Color = Color.FromArgb(num4 - color2.R, num4 - color2.G, num4 - color2.B);
			break;
		}
		case "blackwhite":
		{
			int num5 = 128;
			if (array2.Length > 1)
			{
				num5 = Class1165.smethod_4(XmlConvert.ToInt32(array2[0]), 0, 255);
			}
			Color color3 = colorFormat.Color;
			colorFormat.Color = Color.FromArgb((color3.R >= num5) ? 255 : 0, (color3.G >= num5) ? 255 : 0, (color3.B >= num5) ? 255 : 0);
			break;
		}
		case "gray":
			colorFormat.ColorTransform.Add(ColorTransformOperation.Grayscale);
			break;
		case "invert":
			colorFormat.ColorTransform.Add(ColorTransformOperation.Inverse);
			break;
		case "invert128":
		{
			Color color = colorFormat.Color;
			colorFormat.Color = Color.FromArgb((color.R < 128) ? (color.R + 128) : (color.R - 128), (color.G < 128) ? (color.G + 128) : (color.G - 128), (color.B < 128) ? (color.B + 128) : (color.B - 128));
			break;
		}
		}
	}

	public string method_2()
	{
		while (int_2 < int_1 && string_0[int_2] <= ' ')
		{
			int_2++;
		}
		int num = int_2;
		while (int_2 < int_1 && ((string_0[int_2] >= 'A' && string_0[int_2] <= 'Z') || (string_0[int_2] >= 'a' && string_0[int_2] <= 'z') || (string_0[int_2] >= '0' && string_0[int_2] <= '9') || string_0[int_2] == '_'))
		{
			int_2++;
		}
		return string_0.Substring(num, int_2 - num);
	}

	public string method_3()
	{
		while (int_2 < int_1 && string_0[int_2] <= ' ')
		{
			int_2++;
		}
		if (int_2 < int_1)
		{
			if (string_0[int_2] != '\'' && string_0[int_2] != '"')
			{
				int num = int_2;
				while (int_2 < int_1 && ((string_0[int_2] >= 'A' && string_0[int_2] <= 'Z') || (string_0[int_2] >= 'a' && string_0[int_2] <= 'z') || (string_0[int_2] >= '0' && string_0[int_2] <= '9') || string_0[int_2] == '_'))
				{
					int_2++;
				}
				return string_0.Substring(num, int_2 - num);
			}
			char c = string_0[int_2];
			int_2++;
			int num2 = int_2;
			bool flag = false;
			while (int_2 < int_1 && (string_0[int_2] != c || flag))
			{
				flag = !flag && string_0[int_2] == '\\';
				int_2++;
			}
			return string_0.Substring(num2, int_2 - num2);
		}
		return "";
	}

	public float method_4()
	{
		while (int_2 < int_1 && string_0[int_2] <= ' ')
		{
			int_2++;
		}
		int num = int_2;
		int num2 = 0;
		double num3 = 0.0;
		while (int_2 < int_1 && string_0[int_2] >= '0' && string_0[int_2] <= '9')
		{
			num2 = num2 * 10 + string_0[int_2++] - 48;
		}
		if (int_2 < int_1)
		{
			if (num < int_2 && (string_0[int_2] == 'f' || string_0[int_2] == 'F'))
			{
				int_2++;
				return (float)num2 / 65536f;
			}
			if (string_0[int_2] == '.')
			{
				int_2++;
				double num4 = 0.10000000149011612;
				while (int_2 < int_1 && string_0[int_2] >= '0' && string_0[int_2] <= '9')
				{
					num3 += (double)(string_0[int_2++] - 48) * num4;
					num4 /= 10.0;
				}
			}
		}
		if (num < int_2 && int_2 < int_1 && string_0[int_2] == '%')
		{
			int_2++;
			return (float)(((double)num2 + num3) / 100.0);
		}
		if (int_2 == num)
		{
			return float.NaN;
		}
		return (float)((double)num2 + num3);
	}

	private string[] method_5()
	{
		while (int_2 < int_1 && string_0[int_2] <= ' ')
		{
			int_2++;
		}
		if (int_2 < int_1 && string_0[int_2] == '(')
		{
			List<string> list = new List<string>();
			while (int_2 < int_1 && string_0[int_2] != ')')
			{
				int_2++;
				while (int_2 < int_1 && string_0[int_2] <= ' ')
				{
					int_2++;
				}
				int num = int_2;
				while (int_2 < int_1 && string_0[int_2] != ',' && string_0[int_2] != ')')
				{
					int_2++;
				}
				int num2 = int_2;
				while (num < num2 && string_0[num2 - 1] <= '0')
				{
					num2--;
				}
				list.Add(string_0.Substring(num, num2 - num + 1));
			}
			return list.ToArray();
		}
		return null;
	}

	private int[] method_6()
	{
		while (int_2 < int_1 && string_0[int_2] <= ' ')
		{
			int_2++;
		}
		if (int_2 < int_1 && string_0[int_2] == '[')
		{
			List<int> list = new List<int>();
			while (int_2 < int_1 && string_0[int_2] != ']')
			{
				int_2++;
				while (int_2 < int_1 && string_0[int_2] <= ' ')
				{
					int_2++;
				}
				int num = int_2;
				while (int_2 < int_1 && string_0[int_2] != ',' && string_0[int_2] != ']')
				{
					int_2++;
				}
				int num2 = int_2;
				while (num < num2 && string_0[num2 - 1] <= '0')
				{
					num2--;
				}
				list.Add(int.Parse(string_0.Substring(num, num2 - num)));
			}
			return list.ToArray();
		}
		return null;
	}

	public char method_7()
	{
		if (int_2 < int_1)
		{
			return string_0[int_2++];
		}
		return '\uffff';
	}

	public void method_8()
	{
		while (int_2 < int_1 && string_0[int_2] <= ' ')
		{
			int_2++;
		}
	}

	public char method_9()
	{
		if (int_2 < int_1)
		{
			return string_0[int_2];
		}
		return '\uffff';
	}

	public float method_10()
	{
		float num = method_12(float.NaN);
		if (float.IsNaN(num))
		{
			throw new InvalidOperationException("Can't parse coordinate.");
		}
		return num;
	}

	public float method_11(float defaultValue)
	{
		float num = 0f;
		int num2 = 1;
		while (int_2 < int_1 && string_0[int_2] <= ' ')
		{
			int_2++;
		}
		if (int_2 >= int_1)
		{
			return float.NaN;
		}
		if (string_0[int_2] == '-')
		{
			int_2++;
			num2 = -1;
			while (int_2 < int_1 && string_0[int_2] <= ' ')
			{
				int_2++;
			}
		}
		else if (string_0[int_2] == '+')
		{
			int_2++;
			while (int_2 < int_1 && string_0[int_2] <= ' ')
			{
				int_2++;
			}
		}
		if (int_2 >= int_1)
		{
			return defaultValue;
		}
		if ((string_0[int_2] < '0' || string_0[int_2] > '9') && string_0[int_2] != '.')
		{
			return defaultValue;
		}
		while (int_2 < int_1 && string_0[int_2] >= '0' && string_0[int_2] <= '9')
		{
			num = num * 10f + (float)(int)string_0[int_2++] - 48f;
		}
		if (int_2 < int_1 && string_0[int_2] == '.')
		{
			int_2++;
			float num3 = 0.1f;
			while (int_2 < int_1 && string_0[int_2] >= '0' && string_0[int_2] <= '9')
			{
				num += num3 * (float)(string_0[int_2++] - 48);
				num3 /= 10f;
			}
		}
		return num * (float)num2;
	}

	public float method_12(float defaultValue)
	{
		float num = method_11(float.NaN);
		if (float.IsNaN(num))
		{
			return num;
		}
		return method_2() switch
		{
			"px" => num * 72f / 96f, 
			"in" => num * 72f, 
			"cm" => num * 72f / 2.54f, 
			"mm" => num * 72f / 25.4f, 
			"em" => num * 72f / 90f, 
			"pc" => num * 12f, 
			_ => num, 
		};
	}

	public float method_13()
	{
		float num = method_14(float.NaN);
		if (float.IsNaN(num))
		{
			throw new InvalidOperationException("Can't parse percentage.");
		}
		return num;
	}

	public float method_14(float defaultValue)
	{
		float num = 0f;
		int num2 = 1;
		while (int_2 < int_1 && string_0[int_2] <= ' ')
		{
			int_2++;
		}
		if (int_2 >= int_1)
		{
			return float.NaN;
		}
		if (string_0[int_2] == '-')
		{
			int_2++;
			num2 = -1;
			while (int_2 < int_1 && string_0[int_2] <= ' ')
			{
				int_2++;
			}
		}
		else if (string_0[int_2] == '+')
		{
			int_2++;
			while (int_2 < int_1 && string_0[int_2] <= ' ')
			{
				int_2++;
			}
		}
		if (int_2 >= int_1)
		{
			return defaultValue;
		}
		while (int_2 < int_1 && string_0[int_2] >= '0' && string_0[int_2] <= '9')
		{
			num = num * 10f + (float)(int)string_0[int_2++] - 48f;
		}
		if (int_2 < int_1 && string_0[int_2] == '.')
		{
			int_2++;
			float num3 = 0.1f;
			while (int_2 < int_1 && string_0[int_2] >= '0' && string_0[int_2] <= '9')
			{
				num += num3 * (float)(string_0[int_2++] - 48);
				num3 /= 10f;
			}
		}
		num *= (float)num2;
		int num4 = int_1;
		while (num4 > int_2 && string_0[num4 - 1] <= ' ')
		{
			num4--;
		}
		string text = ((int_2 < int_1) ? string_0.Substring(int_2, num4 - int_2) : "");
		if (text != "%")
		{
			return defaultValue;
		}
		return num;
	}

	public int method_15(int defaultValue)
	{
		int num = 0;
		int num2 = 1;
		while (int_2 < int_1 && string_0[int_2] <= ' ')
		{
			int_2++;
		}
		if (int_2 >= int_1)
		{
			return defaultValue;
		}
		if (string_0[int_2] == '-')
		{
			int_2++;
			num2 = -1;
			while (int_2 < int_1 && string_0[int_2] <= ' ')
			{
				int_2++;
			}
		}
		else if (string_0[int_2] == '+')
		{
			int_2++;
			while (int_2 < int_1 && string_0[int_2] <= ' ')
			{
				int_2++;
			}
		}
		if (int_2 >= int_1)
		{
			return defaultValue;
		}
		while (int_2 < int_1 && string_0[int_2] >= '0' && string_0[int_2] <= '9')
		{
			num = num * 10 + string_0[int_2++] - 48;
		}
		return num * num2;
	}
}

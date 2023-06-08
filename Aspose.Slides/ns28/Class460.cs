using System;
using System.Drawing;
using System.Globalization;

namespace ns28;

internal class Class460
{
	protected string string_0;

	protected double double_0;

	protected string string_1;

	protected string string_2;

	public double BorderWidth
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public string BorderStyle
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public Color OuterLine
	{
		get
		{
			return smethod_0(string_2);
		}
		set
		{
			string_2 = smethod_1(value);
		}
	}

	public Class460()
	{
	}

	public Class460(Class369 source, string AttributeName, string NameSpace)
	{
		if (source != null)
		{
			method_0(source, AttributeName, NameSpace);
		}
	}

	internal void method_0(Class369 source, string AttributeName, string NameSpace)
	{
		if (source != null)
		{
			string_0 = source.method_0(AttributeName, NameSpace, "0cm solid #ffffff");
		}
		else
		{
			string_0 = "0.05cm solid #ffffff";
		}
		string[] array = string_0.Split(' ');
		double_0 = double.Parse(array[0], CultureInfo.InvariantCulture);
		string_1 = array[1];
		string_2 = array[2];
	}

	internal void Write(Class369 target, string AttributeName, string NameSpace)
	{
		if (!double.IsNaN(double_0) && string_1 != "" && string_2 != "")
		{
			string value = $"{double_0.ToString(CultureInfo.InvariantCulture)} {string_1} {string_2}";
			target.SetAttribute(AttributeName, NameSpace, value);
		}
	}

	private static Color smethod_0(string hexColor)
	{
		if (hexColor.IndexOf('#') != -1)
		{
			hexColor = hexColor.Replace("#", "");
		}
		int red = 0;
		int green = 0;
		int blue = 0;
		if (hexColor.Length == 6)
		{
			red = int.Parse(hexColor.Substring(0, 2), NumberStyles.AllowHexSpecifier);
			green = int.Parse(hexColor.Substring(2, 2), NumberStyles.AllowHexSpecifier);
			blue = int.Parse(hexColor.Substring(4, 2), NumberStyles.AllowHexSpecifier);
		}
		else if (hexColor.Length == 3)
		{
			red = int.Parse(hexColor[0].ToString() + hexColor[0], NumberStyles.AllowHexSpecifier);
			green = int.Parse(hexColor[1].ToString() + hexColor[1], NumberStyles.AllowHexSpecifier);
			blue = int.Parse(hexColor[2].ToString() + hexColor[2], NumberStyles.AllowHexSpecifier);
		}
		return Color.FromArgb(red, green, blue);
	}

	private static string smethod_1(Color color)
	{
		int r = color.R;
		int g = color.G;
		int b = color.B;
		string text = Convert.ToString(r, 16);
		string text2 = Convert.ToString(g, 16);
		string text3 = Convert.ToString(b, 16);
		if (text.Length == 1)
		{
			text = "0" + text;
		}
		if (text2.Length == 1)
		{
			text2 = "0" + text2;
		}
		if (text3.Length == 1)
		{
			text3 = "0" + text3;
		}
		return "#" + text + text2 + text3;
	}
}

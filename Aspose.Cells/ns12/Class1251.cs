using System;
using System.Runtime.CompilerServices;

namespace ns12;

internal class Class1251
{
	private double double_0;

	private double double_1;

	private string string_0 = "i";

	[SpecialName]
	public double method_0()
	{
		return double_0;
	}

	[SpecialName]
	public double method_1()
	{
		return double_1;
	}

	public Class1251()
	{
		double_0 = 0.0;
		double_1 = 0.0;
		string_0 = "i";
	}

	public Class1251(double double_2, double double_3)
	{
		double_0 = double_2;
		double_1 = double_3;
		string_0 = "i";
	}

	public Class1251(double double_2, double double_3, string string_1)
	{
		double_0 = double_2;
		double_1 = double_3;
		string_0 = string_1;
	}

	public Class1251(string string_1)
	{
		string string_2 = method_2(string_1);
		string_0 = method_3(string_1);
		method_4(string_1, string_2, string_0);
	}

	private string method_2(string string_1)
	{
		int num = string_1.IndexOf("-");
		if (string_1.IndexOf("+") != -1)
		{
			return "+";
		}
		if (num != -1 && num != 0)
		{
			return "-";
		}
		return "";
	}

	private string method_3(string string_1)
	{
		if (string_1.IndexOf("i") != -1)
		{
			return "i";
		}
		if (string_1.IndexOf("j") != -1)
		{
			return "j";
		}
		return "";
	}

	private void method_4(string string_1, string string_2, string string_3)
	{
		int num = 0;
		int length = string_1.Length;
		if (string_2.Length == 0)
		{
			if (string_3.Length == 0)
			{
				double_0 = double.Parse(string_1);
				return;
			}
			string text = string_1.Substring(0, length - 1);
			if (text.Equals("-"))
			{
				double_1 = -1.0;
			}
			else if (text.Length == 0)
			{
				double_1 = 1.0;
			}
			else
			{
				double_1 = double.Parse(text);
			}
			return;
		}
		num = string_1.IndexOf(string_2);
		length = string_1.Length;
		string text2 = string_1.Substring(0, num);
		string text3 = string_1.Substring(num + 1, length - num - 2);
		if (text3.Length == 0)
		{
			text3 = "1";
		}
		text2 = text2.Trim();
		text3 = text3.Trim();
		if (text2.Length != 0)
		{
			double_0 = double.Parse(text2);
		}
		if (string_2.Equals("-"))
		{
			double_1 = 0.0 - double.Parse(text3);
		}
		else
		{
			double_1 = double.Parse(text3);
		}
	}

	public override string ToString()
	{
		if (double_0 != 0.0)
		{
			if (double_1 > 0.0)
			{
				if (double_1 == 1.0)
				{
					return double_0 + "+" + string_0;
				}
				return double_0 + "+" + double_1 + string_0;
			}
			if (double_1 < 0.0)
			{
				if (double_1 == -1.0)
				{
					return double_0 + "-" + string_0;
				}
				double num = -1.0 * double_1;
				return double_0 + "-" + num + string_0;
			}
			return double_0.ToString();
		}
		if (double_1 == 0.0)
		{
			return double_0.ToString();
		}
		if (double_1 == -1.0)
		{
			return "-" + string_0;
		}
		if (double_1 == 1.0)
		{
			return string_0;
		}
		return double_1 + string_0;
	}

	public Class1251 Add(Class1251 class1251_0)
	{
		double double_ = double_0 + class1251_0.double_0;
		double double_2 = double_1 + class1251_0.double_1;
		string string_ = "i";
		if (class1251_0.string_0.Equals("j") || string_0.Equals("j"))
		{
			string_ = "j";
		}
		return new Class1251(double_, double_2, string_);
	}

	public Class1251 method_5(Class1251 class1251_0)
	{
		double double_ = double_0 - class1251_0.double_0;
		double double_2 = double_1 - class1251_0.double_1;
		string string_ = "i";
		if (class1251_0.string_0.Equals("j") || string_0.Equals("j"))
		{
			string_ = "j";
		}
		return new Class1251(double_, double_2, string_);
	}

	public Class1251 method_6(Class1251 class1251_0)
	{
		double double_ = double_0 * class1251_0.double_0 - double_1 * class1251_0.double_1;
		double double_2 = double_0 * class1251_0.double_1 + double_1 * class1251_0.double_0;
		string string_ = "i";
		if (class1251_0.string_0.Equals("j") || string_0.Equals("j"))
		{
			string_ = "j";
		}
		return new Class1251(double_, double_2, string_);
	}

	public Class1251 method_7(Class1251 class1251_0)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		num = double_0 * class1251_0.double_0 + double_1 * class1251_0.double_1;
		num2 = double_1 * class1251_0.double_0 - double_0 * class1251_0.double_1;
		num3 = class1251_0.double_0 * class1251_0.double_0 + class1251_0.double_1 * class1251_0.double_1;
		double double_ = num / num3;
		double double_2 = num2 / num3;
		string string_ = "i";
		if (class1251_0.string_0.Equals("j") || string_0.Equals("j"))
		{
			string_ = "j";
		}
		return new Class1251(double_, double_2, string_);
	}

	public double method_8()
	{
		return Math.Sqrt(double_0 * double_0 + double_1 * double_1);
	}

	public Class1251 method_9()
	{
		double double_ = Math.Log(Math.Sqrt(double_0 * double_0 + double_1 * double_1));
		return new Class1251(double_, Math.Atan2(double_1, double_0), string_0);
	}

	public Class1251 method_10()
	{
		double d = Math.Sqrt(double_0 * double_0 + double_1 * double_1);
		double num = Math.Atan2(double_1, double_0);
		if (string_0.Length == 0)
		{
			string_0 = "i";
		}
		return new Class1251(Math.Sqrt(d) * Math.Cos(num / 2.0), Math.Sqrt(d) * Math.Sin(num / 2.0), string_0);
	}

	public Class1251 method_11()
	{
		if (string_0.Length == 0)
		{
			string_0 = "i";
		}
		return new Class1251(Math.Sin(double_0) * Math.Cosh(double_1), Math.Cos(double_0) * Math.Sinh(double_1), string_0);
	}

	public Class1251 method_12()
	{
		if (string_0.Length == 0)
		{
			string_0 = "i";
		}
		double double_ = Math.Cos(double_0) * Math.Cosh(double_1);
		double double_2 = 0.0 - Math.Sin(double_0) * Math.Sinh(double_1);
		return new Class1251(double_, double_2, string_0);
	}

	public Class1251 method_13(double double_2)
	{
		if (string_0.Length == 0)
		{
			string_0 = "i";
		}
		double x = Math.Sqrt(double_0 * double_0 + double_1 * double_1);
		double num = Math.Atan2(double_1, double_0);
		double double_3 = Math.Pow(x, double_2) * Math.Cos(double_2 * num);
		double double_4 = Math.Pow(x, double_2) * Math.Sin(double_2 * num);
		return new Class1251(double_3, double_4, string_0);
	}

	public Class1251 method_14()
	{
		if (string_0.Length == 0)
		{
			string_0 = "i";
		}
		double double_ = Math.Pow(Math.E, double_0) * Math.Cos(double_1);
		double double_2 = Math.Pow(Math.E, double_0) * Math.Sin(double_1);
		return new Class1251(double_, double_2, string_0);
	}

	public double method_15()
	{
		return Math.Atan2(double_1, double_0);
	}

	public Class1251 method_16()
	{
		return new Class1251(double_0, 0.0 - double_1, string_0);
	}
}

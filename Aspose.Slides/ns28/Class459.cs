using System;
using System.Globalization;

namespace ns28;

internal class Class459
{
	protected string string_0;

	protected double double_0;

	protected double double_1;

	protected double double_2;

	public double InnerLine
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

	public double DistanceBetweenTwoLines
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public double OuterLine
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	public Class459()
	{
	}

	public Class459(Class369 source, string AttributeName)
	{
		if (source != null)
		{
			method_0(source, AttributeName);
		}
	}

	internal void method_0(Class369 source, string AttributeName)
	{
		if (source != null)
		{
			string_0 = source.method_0(AttributeName, source.NamespaceURI, "0 0 0");
		}
		else
		{
			string_0 = "0 0 0";
		}
		string[] array = string_0.Split(' ');
		double_0 = double.Parse(array[0], CultureInfo.InvariantCulture);
		double_1 = Convert.ToDouble(array[1]);
		double_2 = Convert.ToDouble(array[2]);
	}

	internal void Write(Class369 target, string AttributeName)
	{
		if (!double.IsNaN(double_0) && !double.IsNaN(double_1) && !double.IsNaN(double_2))
		{
			string value = $"{double_0.ToString(CultureInfo.InvariantCulture)} {double_1.ToString(CultureInfo.InvariantCulture)} {double_2.ToString(CultureInfo.InvariantCulture)}";
			target.SetAttribute(AttributeName, target.NamespaceURI, value);
		}
	}
}

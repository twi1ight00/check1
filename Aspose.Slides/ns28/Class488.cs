using System;
using System.Globalization;

namespace ns28;

internal class Class488
{
	protected string string_0;

	protected double double_0;

	protected double double_1;

	protected double double_2;

	public double X
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

	public double Y
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

	public double Z
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

	public Class488()
	{
	}

	public Class488(Class369 source, string AttributeName, string defaultValue)
	{
		if (source != null)
		{
			method_0(source, AttributeName, defaultValue);
		}
	}

	internal void method_0(Class369 source, string AttributeName, string defaultValue)
	{
		if (source != null)
		{
			string_0 = source.method_0(AttributeName, source.NamespaceURI, defaultValue);
		}
		else
		{
			string_0 = defaultValue;
		}
		if (string_0 != "")
		{
			string[] array = string_0.Split(' ');
			double_0 = Convert.ToDouble(array[0], CultureInfo.InvariantCulture);
			double_1 = Convert.ToDouble(array[1], CultureInfo.InvariantCulture);
			double_2 = Convert.ToDouble(array[2], CultureInfo.InvariantCulture);
		}
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

using System.Globalization;

namespace ns28;

internal class Class468
{
	private string string_0;

	private double double_0;

	private double double_1;

	public double Fraction
	{
		get
		{
			return double_1;
		}
		set
		{
			if (value < 0.0)
			{
				double_1 = 0.0;
			}
			else if (value > 1.0)
			{
				double_1 = 1.0;
			}
			else
			{
				double_1 = value;
			}
		}
	}

	public double Depth
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

	public Class468()
	{
	}

	public Class468(Class369 source, string AttributeName, string defaultValue)
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
			if (string_0 != "")
			{
				string[] array = string_0.Split(' ');
				double_0 = source.method_34(array[0]);
				double_1 = double.Parse(array[1], CultureInfo.InvariantCulture);
			}
		}
	}

	internal void Write(Class369 target, string AttributeName)
	{
		if (double_0.ToString() != "" && !double.IsNaN(double_1))
		{
			string value = $"{(0.0 * double_0).ToString(CultureInfo.InvariantCulture)}cm {double_1.ToString(CultureInfo.InvariantCulture)}";
			target.SetAttribute(AttributeName, target.NamespaceURI, value);
		}
	}
}

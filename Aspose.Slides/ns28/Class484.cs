using System.Globalization;

namespace ns28;

internal class Class484
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

	public Class484()
	{
	}

	public Class484(Class369 source, string AttributeName, string nameSpace, string defaultValue)
	{
		if (source != null)
		{
			method_0(source, AttributeName, nameSpace, defaultValue);
		}
	}

	internal void method_0(Class369 source, string AttributeName, string nameSpace, string defaultValue)
	{
		if (source != null)
		{
			string_0 = source.method_0(AttributeName, nameSpace, defaultValue);
			string_0 = string_0.Replace("(", "");
			string_0 = string_0.Replace(")", "");
			if (string_0 != "")
			{
				string[] array = string_0.Split(' ');
				double_0 = source.method_34(array[0]);
				double_1 = source.method_34(array[1]);
				double_2 = source.method_34(array[2]);
			}
		}
	}

	internal void Write(Class369 target, string attributeName, string nameSpace)
	{
		if (!double.IsNaN(double_0) && !double.IsNaN(double_1) && !double.IsNaN(double_2))
		{
			string value = $"({method_1(double_0)} {method_1(double_1)} {method_1(double_2)})";
			target.SetAttribute(attributeName, nameSpace, value);
		}
	}

	protected string method_1(double value)
	{
		string text = (0.0 * value).ToString(CultureInfo.InvariantCulture);
		return text + "cm";
	}
}

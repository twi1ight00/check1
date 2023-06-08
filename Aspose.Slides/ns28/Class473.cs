namespace ns28;

internal class Class473
{
	protected double double_0 = double.NaN;

	protected double double_1 = double.NaN;

	protected double double_2 = double.NaN;

	protected double double_3 = double.NaN;

	private string string_0 = "urn:oasis:names:tc:opendocument:xmlns:svg-compatible:1.0";

	public double X1
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

	public double X2
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

	public double Y1
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

	public double Y2
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = value;
		}
	}

	public Class473(Class369 source)
	{
		if (source != null)
		{
			method_0(source);
		}
	}

	public Class473()
	{
	}

	internal void method_0(Class369 source)
	{
		if (source != null)
		{
			double_0 = source.method_7("x1", string_0, double.NaN);
			double_1 = source.method_7("y1", string_0, double.NaN);
			double_2 = source.method_7("x2", string_0, double.NaN);
			double_3 = source.method_7("y2", string_0, double.NaN);
		}
		else
		{
			double num = double.NaN;
			double_3 = double.NaN;
			double num2 = double.NaN;
			double_2 = num;
			double num3 = double.NaN;
			double_1 = num2;
			double_0 = num3;
		}
	}

	internal void Write(Class369 target)
	{
		if (!double.IsNaN(double_0) && !double.IsNaN(double_1) && !double.IsNaN(double_2) && !double.IsNaN(double_3))
		{
			target.method_8("x1", string_0, double_0);
			target.method_8("y1", string_0, double_1);
			target.method_8("x2", string_0, double_2);
			target.method_8("y2", string_0, double_3);
		}
	}
}

namespace ns28;

internal class Class486
{
	protected double double_0 = double.NaN;

	protected double double_1 = double.NaN;

	protected double double_2 = double.NaN;

	protected double double_3 = double.NaN;

	private string string_0 = "urn:oasis:names:tc:opendocument:xmlns:svg-compatible:1.0";

	public float X
	{
		get
		{
			return (float)double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public float Y
	{
		get
		{
			return (float)double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public float Width
	{
		get
		{
			return (float)double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	public float Height
	{
		get
		{
			return (float)double_3;
		}
		set
		{
			double_3 = value;
		}
	}

	public Class486()
	{
	}

	public Class486(Class369 source)
	{
		if (source != null)
		{
			method_0(source);
		}
	}

	internal void method_0(Class369 source)
	{
		if (source != null)
		{
			double_0 = source.method_7("x", string_0, double.NaN);
			double_1 = source.method_7("y", string_0, double.NaN);
			double_2 = source.method_7("width", string_0, double.NaN);
			double_3 = source.method_7("height", string_0, double.NaN);
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
			target.method_8("x", string_0, double_0);
			target.method_8("y", string_0, double_1);
			target.method_8("width", string_0, double_2);
			target.method_8("height", string_0, double_3);
		}
	}
}

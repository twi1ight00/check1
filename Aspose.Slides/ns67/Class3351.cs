namespace ns67;

internal sealed class Class3351 : Class3344
{
	private double double_0;

	private double double_1;

	public double Brightness
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

	public double Contrast
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

	public Class3351(double brightness, double contrast)
	{
		double_0 = brightness;
		double_1 = contrast;
	}

	public override Class3344 vmethod_0()
	{
		return new Class3351(double_0, double_1);
	}
}

namespace ns67;

internal sealed class Class3385 : Class3384
{
	private double double_0;

	public double Z
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

	public Class3385(double z)
	{
		double_0 = z;
	}

	public override Class3384 vmethod_0()
	{
		return new Class3385(double_0);
	}
}

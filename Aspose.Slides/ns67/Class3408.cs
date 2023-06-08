namespace ns67;

internal sealed class Class3408 : Class3407
{
	private double double_0;

	public double Value
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

	public Class3408(double value)
	{
		Value = value;
	}

	public override Class3407 vmethod_0()
	{
		return new Class3408(double_0);
	}
}

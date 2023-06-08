namespace ns224;

internal abstract class Class5992 : Class5991
{
	private float[] float_0;

	private float[] float_1;

	private Class6000[] class6000_0;

	public Class6000[] InterpolationColors
	{
		get
		{
			return class6000_0;
		}
		set
		{
			class6000_0 = value;
		}
	}

	public float[] BlendPositions
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	public float[] BlendFactors
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	protected Class5992(Enum746 brushType)
		: base(brushType)
	{
	}
}

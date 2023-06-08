namespace ns67;

internal abstract class Class3332 : Class3331
{
	private readonly Class3330 class3330_0;

	private readonly Enum459 enum459_0;

	private bool bool_0;

	private Enum461 enum461_0;

	private Class3459 class3459_0;

	public Class3330 GradientStopList => class3330_0;

	public Enum459 GradientFillType => enum459_0;

	public bool RotateWithShape
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public Enum461 TileFlip
	{
		get
		{
			return enum461_0;
		}
		set
		{
			enum461_0 = value;
		}
	}

	public Class3459 TileRectangle
	{
		get
		{
			return class3459_0;
		}
		set
		{
			class3459_0 = value;
		}
	}

	protected internal Class3332(Enum459 gradientFillType)
	{
		class3330_0 = new Class3330();
		enum459_0 = gradientFillType;
		bool_0 = true;
		enum461_0 = Enum461.const_0;
	}

	protected void method_0(Class3332 clone)
	{
		clone.GradientStopList.Clear();
		for (int i = 0; i < GradientStopList.Count; i++)
		{
			clone.GradientStopList.Add(GradientStopList[i].method_0());
		}
		clone.RotateWithShape = RotateWithShape;
		clone.TileFlip = TileFlip;
		clone.TileRectangle = ((TileRectangle != null) ? TileRectangle.method_0() : null);
	}
}

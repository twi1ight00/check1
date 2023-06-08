namespace ns233;

internal class Class6144
{
	private readonly Enum787 enum787_0;

	private readonly float float_0;

	private readonly float float_1;

	public Enum787 ColorMode => enum787_0;

	public float Brightness => float_0;

	public float Contrast => float_1;

	public Class6144()
		: this(Enum787.const_0, 0.5f, 0.5f)
	{
	}

	public Class6144(Enum787 colorMode, float brightness, float contrast)
	{
		enum787_0 = colorMode;
		float_0 = ((brightness > 1f) ? 1f : ((brightness < 0f) ? 0f : brightness));
		float_1 = ((contrast > 1f) ? 1f : ((contrast < 0f) ? 0f : contrast));
	}

	public bool method_0()
	{
		if (smethod_0(ColorMode) && smethod_2(Brightness))
		{
			return smethod_1(Contrast);
		}
		return false;
	}

	public static bool smethod_0(Enum787 colorMode)
	{
		return colorMode == Enum787.const_0;
	}

	public static bool smethod_1(float contrast)
	{
		if (contrast > 0.49f && contrast < 0.51f)
		{
			return true;
		}
		return false;
	}

	public static bool smethod_2(float brightness)
	{
		if (brightness > 0.49f && brightness < 0.51f)
		{
			return true;
		}
		return false;
	}
}

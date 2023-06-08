namespace ns67;

internal sealed class Class3425 : Class3424
{
	private Class3390 class3390_0;

	public Class3390 ParagraphProperties
	{
		get
		{
			return class3390_0;
		}
		set
		{
			if (value != class3390_0)
			{
				class3390_0 = value?.method_0();
			}
		}
	}

	public Class3425(string textString)
		: base(textString)
	{
	}

	public override Class3423 vmethod_0()
	{
		return new Class3425(this);
	}

	private Class3425(Class3425 src)
		: base(src)
	{
		ParagraphProperties = src.ParagraphProperties;
	}
}

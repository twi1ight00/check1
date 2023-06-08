using ns24;

namespace Aspose.Slides;

public class AdjustValue : IAdjustValue
{
	private Class341 class341_0;

	public long RawValue
	{
		get
		{
			return class341_0.RawValue;
		}
		set
		{
			class341_0.RawValue = value;
		}
	}

	public float AngleValue
	{
		get
		{
			return class341_0.AngleValue;
		}
		set
		{
			class341_0.AngleValue = value;
		}
	}

	public string Name => class341_0.Name;

	internal AdjustValue(Class341 adjustValueData)
	{
		class341_0 = adjustValueData;
	}
}

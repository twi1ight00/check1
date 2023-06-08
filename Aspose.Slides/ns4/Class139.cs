using Aspose.Slides;

namespace ns4;

internal class Class139
{
	private Class148 class148_0;

	private Class147 class147_0;

	public Class148 FillFormat
	{
		get
		{
			return class148_0;
		}
		set
		{
			class148_0 = value;
		}
	}

	public Class147 EffectFormat
	{
		get
		{
			return class147_0;
		}
		set
		{
			class147_0 = value;
		}
	}

	internal uint Version => class148_0.Version + class147_0.Version;

	internal Class139(IPresentationComponent parent)
	{
		class148_0 = new Class148(parent);
		class147_0 = new Class147(parent);
	}
}

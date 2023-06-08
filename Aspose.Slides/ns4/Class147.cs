using Aspose.Slides;
using ns16;

namespace ns4;

internal class Class147
{
	private Enum272 enum272_0;

	private EffectFormat effectFormat_0;

	private ColorFormat colorFormat_0;

	private uint uint_0;

	private uint uint_1;

	public Enum272 Source
	{
		get
		{
			return enum272_0;
		}
		set
		{
			enum272_0 = value;
			method_0();
		}
	}

	public IEffectFormat EffectFormat => effectFormat_0;

	public IColorFormat StyleColor => colorFormat_0;

	public uint EffectStyleIndex
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
			method_0();
		}
	}

	internal uint Version => uint_1 + effectFormat_0.Version + colorFormat_0.Version;

	internal Class147(IPresentationComponent parent)
	{
		effectFormat_0 = new EffectFormat(parent);
		colorFormat_0 = new ColorFormat(parent as ISlideComponent);
	}

	private void method_0()
	{
		uint_1++;
	}
}

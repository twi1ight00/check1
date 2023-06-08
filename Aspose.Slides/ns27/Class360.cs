using Aspose.Slides.Animation;
using ns24;
using ns57;

namespace ns27;

internal class Class360 : Class278
{
	private Enum286 enum286_0 = Enum286.const_0;

	private string string_0;

	private string string_1;

	private EffectFillType effectFillType_0 = EffectFillType.NotDefined;

	private IEffect ieffect_0;

	public Enum286 Override
	{
		get
		{
			return enum286_0;
		}
		set
		{
			enum286_0 = value;
		}
	}

	public string RuntimeContext
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public string TimeFilter
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public EffectFillType FillType
	{
		get
		{
			return effectFillType_0;
		}
		set
		{
			effectFillType_0 = value;
		}
	}

	public IEffect ParentEffect
	{
		get
		{
			return ieffect_0;
		}
		set
		{
			ieffect_0 = value;
		}
	}
}

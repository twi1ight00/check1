using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Animation;
using ns24;

namespace ns27;

internal class Class365 : Class278
{
	private List<IEffect> list_0 = new List<IEffect>();

	private IEffect ieffect_0;

	private int int_0 = int.MinValue;

	private bool bool_0;

	private IShape ishape_0;

	public List<IEffect> ListEffects
	{
		get
		{
			return list_0;
		}
		set
		{
			list_0 = value;
		}
	}

	public IEffect EffectAnimBg
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

	public int AdvAuto
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public bool BRev
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

	public IShape ShapeRef
	{
		get
		{
			return ishape_0;
		}
		set
		{
			ishape_0 = value;
		}
	}
}

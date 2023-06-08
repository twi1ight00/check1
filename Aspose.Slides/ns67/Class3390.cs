using System;

namespace ns67;

internal sealed class Class3390 : ICloneable
{
	private Class3407 class3407_0;

	private Class3407 class3407_1;

	private Class3407 class3407_2;

	private Class3401 class3401_0;

	private Class3391 class3391_0;

	private Class3394 class3394_0;

	private Class3398 class3398_0;

	private Class3411 class3411_0;

	private Class3406 class3406_0;

	private Enum468 enum468_0;

	private double double_0;

	private bool bool_0 = true;

	private Enum471 enum471_0 = Enum471.const_4;

	private bool bool_1;

	private Class3382 class3382_0;

	private bool bool_2 = true;

	private Class3422 class3422_0;

	private Class3383 class3383_0;

	private Class3383 class3383_1;

	private bool bool_3;

	public Class3407 LineSpacing
	{
		get
		{
			return class3407_0;
		}
		set
		{
			class3407_0 = value;
		}
	}

	public Class3407 SpaceBefore
	{
		get
		{
			return class3407_1;
		}
		set
		{
			class3407_1 = value;
		}
	}

	public Class3407 SpaceAfter
	{
		get
		{
			return class3407_2;
		}
		set
		{
			class3407_2 = value;
		}
	}

	public Class3401 TextBullet
	{
		get
		{
			return class3401_0;
		}
		set
		{
			class3401_0 = value;
		}
	}

	public Class3391 TextBulletColor
	{
		get
		{
			return class3391_0;
		}
		set
		{
			class3391_0 = value;
		}
	}

	public Class3394 TextBulletSize
	{
		get
		{
			return class3394_0;
		}
		set
		{
			class3394_0 = value;
		}
	}

	public Class3398 TextBulletTypeface
	{
		get
		{
			return class3398_0;
		}
		set
		{
			if (class3398_0 != value)
			{
				class3398_0 = value?.vmethod_0();
			}
		}
	}

	public Class3411 TabStopList
	{
		get
		{
			return class3411_0;
		}
		set
		{
			class3411_0 = value;
		}
	}

	public Class3406 DefaultTextRunProperties
	{
		get
		{
			return class3406_0;
		}
		set
		{
			class3406_0 = value;
		}
	}

	public Enum468 Alignment
	{
		get
		{
			return enum468_0;
		}
		set
		{
			enum468_0 = value;
		}
	}

	public double DefaultTabSize
	{
		get
		{
			return double_0;
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_0 = value;
		}
	}

	public bool EastAsianLineBreak
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

	public Enum471 FontAlignment
	{
		get
		{
			return enum471_0;
		}
		set
		{
			enum471_0 = value;
		}
	}

	public bool HangingPunctuation
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public Class3382 Indent
	{
		get
		{
			return class3382_0;
		}
		set
		{
			class3382_0 = value;
		}
	}

	public bool LatinLineBreak
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public Class3422 Level
	{
		get
		{
			return class3422_0;
		}
		set
		{
			class3422_0 = value;
		}
	}

	public Class3383 LeftMargin
	{
		get
		{
			return class3383_0;
		}
		set
		{
			class3383_0 = value;
		}
	}

	public Class3383 RightMargin
	{
		get
		{
			return class3383_1;
		}
		set
		{
			class3383_1 = value;
		}
	}

	public bool RightToLeft
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public Class3390()
	{
		TextBulletColor = new Class3393();
		TextBulletSize = new Class3395();
		TextBulletTypeface = new Class3399();
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3390 method_0()
	{
		return new Class3390(this);
	}

	private Class3390(Class3390 src)
	{
		LineSpacing = ((src.class3407_0 != null) ? src.class3407_0.vmethod_0() : null);
		SpaceBefore = ((src.class3407_1 != null) ? src.class3407_1.vmethod_0() : null);
		SpaceAfter = ((src.class3407_2 != null) ? src.SpaceAfter.vmethod_0() : null);
		TextBullet = ((src.class3401_0 != null) ? src.class3401_0.vmethod_0() : null);
		TextBulletColor = ((src.class3391_0 != null) ? src.class3391_0.vmethod_0() : null);
		TextBulletSize = ((src.class3394_0 != null) ? src.TextBulletSize.vmethod_0() : null);
		TextBulletTypeface = ((src.class3398_0 != null) ? src.class3398_0.vmethod_0() : null);
		TabStopList = ((src.class3411_0 != null) ? src.class3411_0.method_1() : null);
		DefaultTextRunProperties = ((src.class3406_0 != null) ? src.class3406_0.method_0() : null);
		Alignment = src.enum468_0;
		DefaultTabSize = src.double_0;
		EastAsianLineBreak = src.bool_0;
		FontAlignment = src.enum471_0;
		HangingPunctuation = src.bool_1;
		Indent = ((src.class3382_0 != null) ? src.class3382_0.method_0() : null);
		LatinLineBreak = src.bool_2;
		Level = ((src.class3422_0 != null) ? src.class3422_0.method_0() : null);
		LeftMargin = ((src.class3383_0 != null) ? src.class3383_0.vmethod_0() : null);
		RightMargin = ((src.class3383_1 != null) ? src.class3383_1.vmethod_0() : null);
		RightToLeft = src.bool_3;
	}
}

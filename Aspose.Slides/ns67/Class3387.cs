using System;

namespace ns67;

internal sealed class Class3387 : ICloneable
{
	private Class3280 class3280_0;

	private Class3418 class3418_0;

	private Class3372 class3372_0;

	private Class3384 class3384_0;

	private Enum475 enum475_0;

	private bool bool_0;

	private double double_0 = 91440.0;

	private double double_1 = 45720.0;

	private double double_2 = 91440.0;

	private double double_3 = 45720.0;

	private bool bool_1;

	private bool bool_2;

	private Enum476 enum476_0 = Enum476.const_1;

	private int int_0 = 1;

	private double double_4;

	private bool bool_3;

	private double double_5;

	private bool bool_4;

	private bool bool_5;

	private Enum478 enum478_0;

	private Enum477 enum477_0 = Enum477.const_2;

	private Enum479 enum479_0 = Enum479.const_1;

	public Class3280 TextWarp
	{
		get
		{
			return class3280_0;
		}
		set
		{
			if (class3280_0 != value)
			{
				class3280_0 = value?.vmethod_1();
			}
		}
	}

	public Class3418 TextAutofit
	{
		get
		{
			return class3418_0;
		}
		set
		{
			if (class3418_0 != value)
			{
				class3418_0 = value?.vmethod_0();
			}
		}
	}

	public Class3372 Scene3D
	{
		get
		{
			return class3372_0;
		}
		set
		{
			if (value != class3372_0)
			{
				class3372_0 = value?.method_0();
			}
		}
	}

	public Class3384 Text3D
	{
		get
		{
			return class3384_0;
		}
		set
		{
			if (value != class3384_0)
			{
				class3384_0 = value?.vmethod_0();
			}
		}
	}

	public Enum475 Anchor
	{
		get
		{
			return enum475_0;
		}
		set
		{
			enum475_0 = value;
		}
	}

	public bool AnchorCenter
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

	public double LeftInset
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public double TopInset
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public double RightInset
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	public double BottomInset
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = value;
		}
	}

	public bool CompatibleLineSpacing
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

	public bool ForceAntiAlias
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

	public Enum476 TextHorizontalOverflow
	{
		get
		{
			return enum476_0;
		}
		set
		{
			enum476_0 = value;
		}
	}

	public int NumberOfColumns
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value < 1 || 16 < value)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			int_0 = value;
		}
	}

	public double Rotation
	{
		get
		{
			return double_4;
		}
		set
		{
			double_4 = value;
		}
	}

	public bool ColumnsRightToLeft
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

	public double SpaceBetweenColumns
	{
		get
		{
			return double_5;
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_5 = value;
		}
	}

	public bool ParagraphSpacing
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public bool TextUpright
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	public Enum478 VerticalText
	{
		get
		{
			return enum478_0;
		}
		set
		{
			enum478_0 = value;
		}
	}

	public Enum477 TextVerticalOverflow
	{
		get
		{
			return enum477_0;
		}
		set
		{
			enum477_0 = value;
		}
	}

	public Enum479 TextWrappingType
	{
		get
		{
			return enum479_0;
		}
		set
		{
			enum479_0 = value;
		}
	}

	public Class3387()
	{
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3387 method_0()
	{
		return new Class3387(this);
	}

	public Class3387(Class3387 src)
	{
	}
}

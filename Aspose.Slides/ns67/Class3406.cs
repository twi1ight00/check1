using System;

namespace ns67;

internal sealed class Class3406 : ICloneable
{
	private Class3441 class3441_0;

	private Class3331 class3331_0;

	private Class3331 class3331_1;

	private Class3326 class3326_0;

	private Class3415 class3415_0;

	private Class3412 class3412_0;

	private Class3449 class3449_0;

	private Class3449 class3449_1;

	private Class3449 class3449_2;

	private Class3449 class3449_3;

	private Enum480 enum480_0;

	private string string_0;

	private string string_1;

	private bool bool_0;

	private bool bool_1;

	private Enum474 enum474_0;

	private Enum472 enum472_0;

	private double double_0 = 100.0;

	private Enum470 enum470_0;

	private double double_1;

	private bool bool_2;

	private bool bool_3;

	private double double_2;

	private double double_3;

	public Class3441 LineStyle
	{
		get
		{
			return class3441_0;
		}
		set
		{
			if (class3441_0 != value)
			{
				class3441_0 = value?.method_0();
			}
		}
	}

	public Class3331 FillMode
	{
		get
		{
			return class3331_0;
		}
		set
		{
			if (class3331_0 != value)
			{
				class3331_0 = value?.vmethod_0();
			}
		}
	}

	public Class3331 LineFillMode
	{
		get
		{
			return class3331_1;
		}
		set
		{
			if (class3331_1 != value)
			{
				class3331_1 = value?.vmethod_0();
			}
		}
	}

	public Class3326 EffectProperties
	{
		get
		{
			return class3326_0;
		}
		set
		{
			if (class3326_0 != value)
			{
				class3326_0 = value?.vmethod_0();
			}
		}
	}

	public Class3415 TextUnderlineLine
	{
		get
		{
			return class3415_0;
		}
		set
		{
			if (value != class3415_0)
			{
				class3415_0 = value?.vmethod_0();
			}
		}
	}

	public Class3412 TextUnderlineFill
	{
		get
		{
			return class3412_0;
		}
		set
		{
			if (value != class3412_0)
			{
				class3412_0 = value?.vmethod_0();
			}
		}
	}

	public Class3449 LatinFont
	{
		get
		{
			return class3449_0;
		}
		set
		{
			if (value != class3449_0)
			{
				class3449_0 = value?.method_0();
			}
		}
	}

	public Class3449 EastAsianFont
	{
		get
		{
			return class3449_1;
		}
		set
		{
			if (value != class3449_1)
			{
				class3449_1 = value?.method_0();
			}
		}
	}

	public Class3449 ComplexScriptFont
	{
		get
		{
			return class3449_2;
		}
		set
		{
			if (value != class3449_2)
			{
				class3449_2 = value?.method_0();
			}
		}
	}

	public Class3449 SymbolFont
	{
		get
		{
			return class3449_3;
		}
		set
		{
			if (value != class3449_3)
			{
				class3449_3 = value?.method_0();
			}
		}
	}

	public Enum480 RightToLeftRun
	{
		get
		{
			return enum480_0;
		}
		set
		{
			enum480_0 = value;
		}
	}

	public string Language
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

	public string AlternativeLanguage
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

	public bool Bold
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

	public bool Italics
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

	public Enum474 Underline
	{
		get
		{
			return enum474_0;
		}
		set
		{
			enum474_0 = value;
		}
	}

	public Enum472 Strikethrough
	{
		get
		{
			return enum472_0;
		}
		set
		{
			enum472_0 = value;
		}
	}

	public double Baseline
	{
		get
		{
			return double_0;
		}
		set
		{
			if (value <= 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_0 = value;
		}
	}

	public Enum470 Capitalization
	{
		get
		{
			return enum470_0;
		}
		set
		{
			enum470_0 = value;
		}
	}

	public double Kerning
	{
		get
		{
			return double_1;
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_1 = value;
		}
	}

	public bool Kumimoji
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

	public bool NormalizeHeights
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

	public double Spacing
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

	public double FontSize
	{
		get
		{
			return double_3;
		}
		set
		{
			if (value < 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			double_3 = value;
		}
	}

	public Class3406()
	{
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3406 method_0()
	{
		return new Class3406(this);
	}

	private Class3406(Class3406 src)
	{
		LineStyle = src.class3441_0;
		FillMode = src.class3331_0;
		LineFillMode = src.class3331_1;
		EffectProperties = src.class3326_0;
		TextUnderlineLine = src.class3415_0;
		TextUnderlineFill = src.class3412_0;
		LatinFont = src.class3449_0;
		EastAsianFont = src.class3449_1;
		ComplexScriptFont = src.class3449_2;
		SymbolFont = src.class3449_3;
		RightToLeftRun = src.enum480_0;
		Language = src.string_0;
		AlternativeLanguage = src.string_1;
		Bold = src.bool_0;
		Italics = src.bool_1;
		Underline = src.enum474_0;
		Strikethrough = src.enum472_0;
		Baseline = src.double_0;
		Capitalization = src.enum470_0;
		Kerning = src.double_1;
		Kumimoji = src.bool_2;
		NormalizeHeights = src.bool_3;
		Spacing = src.double_2;
		FontSize = src.double_3;
	}
}

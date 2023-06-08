using System.Drawing;
using System.Runtime.CompilerServices;
using ns22;

namespace ns5;

internal class Class889
{
	private Class898 class898_0;

	private bool bool_0;

	private Enum99 enum99_0;

	private Enum97 enum97_0 = Enum97.const_6;

	private Color color_0 = Color.Black;

	private Color color_1 = Color.White;

	private Enum98 enum98_0;

	private float float_0;

	private Enum95 enum95_0;

	private Enum96 enum96_0;

	private Enum94 enum94_0;

	private Enum95 enum95_1;

	private Enum96 enum96_1;

	private Enum94 enum94_1;

	public Enum99 Style
	{
		get
		{
			return enum99_0;
		}
		set
		{
			enum99_0 = value;
		}
	}

	public Color ForeColor
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
		}
	}

	public Enum97 DashStyle
	{
		get
		{
			return enum97_0;
		}
		set
		{
			enum97_0 = value;
		}
	}

	public Enum98 Pattern => enum98_0;

	public float Weight
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	internal Class889(Class898 class898_1)
	{
		class898_0 = class898_1;
	}

	[SpecialName]
	public bool method_0()
	{
		if (Class1178.smethod_0(color_0) && Pattern == Enum98.const_0)
		{
			return true;
		}
		return bool_0;
	}

	[SpecialName]
	public void method_1(bool bool_1)
	{
		bool_0 = bool_1;
	}

	[SpecialName]
	public Enum95 method_2()
	{
		return enum95_0;
	}

	[SpecialName]
	public void method_3(Enum95 enum95_2)
	{
		enum95_0 = enum95_2;
	}

	[SpecialName]
	public Enum96 method_4()
	{
		return enum96_0;
	}

	[SpecialName]
	public void method_5(Enum96 enum96_2)
	{
		enum96_0 = enum96_2;
	}

	[SpecialName]
	public Enum94 method_6()
	{
		return enum94_0;
	}

	[SpecialName]
	public void method_7(Enum94 enum94_2)
	{
		enum94_0 = enum94_2;
	}

	[SpecialName]
	public Enum95 method_8()
	{
		return enum95_1;
	}

	[SpecialName]
	public void method_9(Enum95 enum95_2)
	{
		enum95_1 = enum95_2;
	}

	[SpecialName]
	public Enum96 method_10()
	{
		return enum96_1;
	}

	[SpecialName]
	public void method_11(Enum96 enum96_2)
	{
		enum96_1 = enum96_2;
	}

	[SpecialName]
	public Enum94 method_12()
	{
		return enum94_1;
	}

	[SpecialName]
	public void method_13(Enum94 enum94_2)
	{
		enum94_1 = enum94_2;
	}
}

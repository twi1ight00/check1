using System.Drawing;
using System.Runtime.CompilerServices;
using ns22;

namespace ns6;

internal class Class906
{
	private Class913 class913_0;

	private bool bool_0;

	private Enum118 enum118_0;

	private Enum116 enum116_0 = Enum116.const_6;

	private Color color_0 = Color.Black;

	private Color color_1 = Color.White;

	private Enum117 enum117_0;

	private float float_0;

	private Enum114 enum114_0;

	private Enum115 enum115_0;

	private Enum113 enum113_0;

	private Enum114 enum114_1;

	private Enum115 enum115_1;

	private Enum113 enum113_1;

	public Enum118 Style
	{
		get
		{
			return enum118_0;
		}
		set
		{
			enum118_0 = value;
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

	public Enum116 DashStyle
	{
		get
		{
			return enum116_0;
		}
		set
		{
			enum116_0 = value;
		}
	}

	public Enum117 Pattern => enum117_0;

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

	internal Class906(Class913 class913_1)
	{
		class913_0 = class913_1;
	}

	[SpecialName]
	public bool method_0()
	{
		if (Class1178.smethod_0(color_0) && Pattern == Enum117.const_0)
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
	public Enum114 method_2()
	{
		return enum114_0;
	}

	[SpecialName]
	public void method_3(Enum114 enum114_2)
	{
		enum114_0 = enum114_2;
	}

	[SpecialName]
	public Enum115 method_4()
	{
		return enum115_0;
	}

	[SpecialName]
	public void method_5(Enum115 enum115_2)
	{
		enum115_0 = enum115_2;
	}

	[SpecialName]
	public Enum113 method_6()
	{
		return enum113_0;
	}

	[SpecialName]
	public void method_7(Enum113 enum113_2)
	{
		enum113_0 = enum113_2;
	}

	[SpecialName]
	public Enum114 method_8()
	{
		return enum114_1;
	}

	[SpecialName]
	public void method_9(Enum114 enum114_2)
	{
		enum114_1 = enum114_2;
	}

	[SpecialName]
	public Enum115 method_10()
	{
		return enum115_1;
	}

	[SpecialName]
	public void method_11(Enum115 enum115_2)
	{
		enum115_1 = enum115_2;
	}

	[SpecialName]
	public Enum113 method_12()
	{
		return enum113_1;
	}

	[SpecialName]
	public void method_13(Enum113 enum113_2)
	{
		enum113_1 = enum113_2;
	}
}

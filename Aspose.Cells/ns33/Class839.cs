using System;
using System.Runtime.CompilerServices;
using ns3;

namespace ns33;

internal class Class839 : ICloneable, Interface24
{
	private double double_0;

	private Enum78 enum78_0;

	private Enum79 enum79_0;

	private Enum77 enum77_0;

	private Enum80 enum80_0;

	private Enum59 enum59_0;

	private Enum60 enum60_0;

	private Enum58 enum58_0;

	private Enum59 enum59_1;

	private Enum60 enum60_1;

	private Enum58 enum58_1;

	public double Width
	{
		get
		{
			return double_0;
		}
		set
		{
			if (double_0 > 0.0 && double_0 < 1.0)
			{
				double_0 = 1.0;
			}
			else
			{
				double_0 = value;
			}
		}
	}

	public Enum79 DashStyle
	{
		get
		{
			return enum79_0;
		}
		set
		{
			enum79_0 = value;
		}
	}

	internal Class839()
	{
		double_0 = 0.0;
		enum78_0 = Enum78.const_0;
		enum79_0 = Enum79.const_6;
		enum59_0 = Enum59.const_0;
		enum60_0 = Enum60.const_0;
		enum58_0 = Enum58.const_0;
		enum59_1 = Enum59.const_0;
		enum60_1 = Enum60.const_0;
		enum58_1 = Enum58.const_0;
	}

	[SpecialName]
	public Enum78 vmethod_0()
	{
		return enum78_0;
	}

	[SpecialName]
	public void imethod_0(Enum78 enum78_1)
	{
		enum78_0 = enum78_1;
	}

	[SpecialName]
	public Enum77 vmethod_1()
	{
		return enum77_0;
	}

	[SpecialName]
	public void imethod_1(Enum77 enum77_1)
	{
		enum77_0 = enum77_1;
	}

	[SpecialName]
	public Enum80 vmethod_2()
	{
		return enum80_0;
	}

	[SpecialName]
	public void imethod_2(Enum80 enum80_1)
	{
		enum80_0 = enum80_1;
	}

	[SpecialName]
	public Enum59 vmethod_3()
	{
		return enum59_0;
	}

	[SpecialName]
	public void imethod_3(Enum59 enum59_2)
	{
		enum59_0 = enum59_2;
	}

	[SpecialName]
	public Enum60 vmethod_4()
	{
		return enum60_0;
	}

	[SpecialName]
	public void imethod_4(Enum60 enum60_2)
	{
		enum60_0 = enum60_2;
	}

	[SpecialName]
	public Enum58 vmethod_5()
	{
		return enum58_0;
	}

	[SpecialName]
	public void imethod_5(Enum58 enum58_2)
	{
		enum58_0 = enum58_2;
	}

	[SpecialName]
	public Enum59 vmethod_6()
	{
		return enum59_1;
	}

	[SpecialName]
	public void imethod_6(Enum59 enum59_2)
	{
		enum59_1 = enum59_2;
	}

	[SpecialName]
	public Enum60 vmethod_7()
	{
		return enum60_1;
	}

	[SpecialName]
	public void imethod_7(Enum60 enum60_2)
	{
		enum60_1 = enum60_2;
	}

	[SpecialName]
	public Enum58 vmethod_8()
	{
		return enum58_1;
	}

	[SpecialName]
	public void imethod_8(Enum58 enum58_2)
	{
		enum58_1 = enum58_2;
	}

	internal bool method_0(Class839 class839_0)
	{
		if (Width != class839_0.Width)
		{
			return false;
		}
		if (vmethod_0() != class839_0.vmethod_0())
		{
			return false;
		}
		if (DashStyle != class839_0.DashStyle)
		{
			return false;
		}
		if (vmethod_1() != class839_0.vmethod_1())
		{
			return false;
		}
		if (vmethod_2() != class839_0.vmethod_2())
		{
			return false;
		}
		if (vmethod_3() != class839_0.vmethod_3())
		{
			return false;
		}
		if (vmethod_4() != class839_0.vmethod_4())
		{
			return false;
		}
		if (vmethod_5() != class839_0.vmethod_5())
		{
			return false;
		}
		if (vmethod_6() != class839_0.vmethod_6())
		{
			return false;
		}
		if (vmethod_7() != class839_0.vmethod_7())
		{
			return false;
		}
		if (vmethod_8() != class839_0.vmethod_8())
		{
			return false;
		}
		if (vmethod_3() == Enum59.const_0 && vmethod_6() == Enum59.const_0)
		{
			return true;
		}
		return false;
	}

	public object Clone()
	{
		Class839 @class = new Class839();
		@class.Width = Width;
		@class.imethod_0(vmethod_0());
		@class.DashStyle = DashStyle;
		@class.imethod_1(vmethod_1());
		@class.imethod_2(vmethod_2());
		@class.imethod_3(vmethod_3());
		@class.imethod_4(vmethod_4());
		@class.imethod_5(vmethod_5());
		@class.imethod_6(vmethod_6());
		@class.imethod_7(vmethod_7());
		@class.imethod_8(vmethod_8());
		return @class;
	}
}

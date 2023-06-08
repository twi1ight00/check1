using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns3;

namespace ns31;

internal class Class807 : IDisposable, Interface26
{
	private Class788 class788_0;

	private Class806 class806_0;

	private Color color_0 = Color.Empty;

	private Color color_1 = Color.Empty;

	private int int_0;

	private Enum65 enum65_0;

	private Enum71 enum71_0 = Enum71.const_1;

	private object object_0;

	private bool bool_0;

	public Interface8 Area => class788_0;

	public Interface25 Border => class806_0;

	public int MarkerSize
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

	public Enum65 MarkerStyle
	{
		get
		{
			if (enum71_0 == Enum71.const_0)
			{
				return Enum65.const_5;
			}
			return enum65_0;
		}
		set
		{
			enum65_0 = value;
		}
	}

	public bool IsVisible
	{
		get
		{
			if (MarkerStyle == Enum65.const_5)
			{
				return false;
			}
			return true;
		}
	}

	internal Class807(Class787 class787_0, object object_1)
	{
		object_0 = object_1;
		int_0 = (int)(5f * ((class787_0.imethod_0() != null) ? class787_0.imethod_0().imethod_51() : 96f) / 72f + 0.5f);
		class788_0 = new Class788(class787_0);
		class806_0 = new Class806(class787_0);
	}

	[SpecialName]
	internal Class788 method_0()
	{
		return class788_0;
	}

	[SpecialName]
	internal Class806 method_1()
	{
		return class806_0;
	}

	public bool method_2(Class807 class807_0)
	{
		if (IsVisible == class807_0.IsVisible && IsVisible)
		{
			if (MarkerStyle != class807_0.MarkerStyle)
			{
				return false;
			}
			if (!class788_0.method_4(class807_0.method_0()))
			{
				return false;
			}
			if (!class806_0.method_1(class807_0.method_1()))
			{
				return false;
			}
			if (MarkerStyle != class807_0.MarkerStyle)
			{
				return false;
			}
			if (MarkerSize != class807_0.MarkerSize)
			{
				return false;
			}
		}
		return true;
	}

	~Class807()
	{
		Dispose(bool_1: false);
	}

	public void Dispose()
	{
		Dispose(bool_1: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool bool_1)
	{
		if (!bool_0)
		{
			if (bool_1 && class788_0 != null)
			{
				class788_0.Dispose();
			}
			bool_0 = true;
		}
	}
}

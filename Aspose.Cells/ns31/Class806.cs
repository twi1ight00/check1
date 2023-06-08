using System.Drawing;
using System.Runtime.CompilerServices;
using ns3;

namespace ns31;

internal class Class806 : Interface25
{
	private Class787 class787_0;

	private Color color_0;

	private Class805 class805_0;

	private Enum71 enum71_0;

	private bool bool_0 = true;

	public Color Color
	{
		get
		{
			if (enum71_0 == Enum71.const_0)
			{
				return Color.Empty;
			}
			return color_0;
		}
		set
		{
			color_0 = value;
		}
	}

	public Interface24 LineStyle => class805_0;

	public Enum71 Formatting
	{
		get
		{
			return enum71_0;
		}
		set
		{
			enum71_0 = value;
		}
	}

	public Interface35 GradientFill => null;

	public bool IsVisible
	{
		get
		{
			if (enum71_0 == Enum71.const_0)
			{
				return false;
			}
			return true;
		}
	}

	internal Class806(Class787 class787_1)
	{
		enum71_0 = Enum71.const_1;
		class787_0 = class787_1;
		color_0 = Color.Black;
		class805_0 = new Class805();
	}

	[SpecialName]
	public bool vmethod_0()
	{
		return bool_0;
	}

	[SpecialName]
	public void imethod_0(bool bool_1)
	{
		bool_0 = bool_1;
	}

	internal void method_0(Color color_1)
	{
		if (enum71_0 == Enum71.const_1 || (vmethod_0() && Formatting != 0))
		{
			Color = color_1;
		}
	}

	public bool method_1(Class806 class806_0)
	{
		if (IsVisible != class806_0.IsVisible)
		{
			return false;
		}
		if (IsVisible && class806_0.IsVisible)
		{
			if (Formatting != class806_0.Formatting)
			{
				return false;
			}
			if (LineStyle.DashStyle != class806_0.LineStyle.DashStyle)
			{
				return false;
			}
			if (!Color.Equals(class806_0.Color))
			{
				return false;
			}
			if (LineStyle.Width != class806_0.LineStyle.Width)
			{
				return false;
			}
		}
		return true;
	}
}

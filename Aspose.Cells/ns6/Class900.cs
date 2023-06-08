using System.Drawing;
using System.Runtime.CompilerServices;
using ns22;

namespace ns6;

internal class Class900
{
	private Class913 class913_0;

	private bool bool_0;

	private Color color_0 = Color.Empty;

	private Class899 class899_0;

	public Class899 FillFormat
	{
		get
		{
			if (class899_0 == null)
			{
				return new Class899(this);
			}
			return class899_0;
		}
	}

	internal Class900(Class913 class913_1)
	{
		class913_0 = class913_1;
	}

	[SpecialName]
	public bool method_0()
	{
		if (Class1178.smethod_0(color_0) && FillFormat == null)
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
	public Color method_2()
	{
		return color_0;
	}

	[SpecialName]
	public void method_3(Color color_1)
	{
		color_0 = color_1;
	}

	[SpecialName]
	public void method_4(Class899 class899_1)
	{
		class899_0 = class899_1;
	}

	[SpecialName]
	public bool method_5()
	{
		if (class899_0 == null)
		{
			return false;
		}
		return true;
	}
}

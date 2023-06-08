using System.Drawing;
using System.Runtime.CompilerServices;
using ns22;

namespace ns5;

internal class Class884
{
	private Class898 class898_0;

	private bool bool_0;

	private Color color_0 = Color.Empty;

	private Class883 class883_0;

	public Class883 FillFormat
	{
		get
		{
			if (class883_0 == null)
			{
				return new Class883();
			}
			return class883_0;
		}
	}

	internal Class884(Class898 class898_1)
	{
		class898_0 = class898_1;
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
	public void method_4(Class883 class883_1)
	{
		class883_0 = class883_1;
	}

	[SpecialName]
	public bool method_5()
	{
		if (class883_0 == null)
		{
			return false;
		}
		return true;
	}
}

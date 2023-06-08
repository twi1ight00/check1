using System.Collections.Generic;
using ns224;
using ns249;
using ns251;
using ns261;

namespace ns250;

internal abstract class Class6284 : Interface273, Interface274
{
	private List<Interface275> list_0;

	public List<Interface275> ColorModifiers
	{
		get
		{
			if (list_0 == null)
			{
				list_0 = new List<Interface275>();
			}
			return list_0;
		}
		set
		{
			list_0 = value;
		}
	}

	public Class5998 imethod_1(Interface297 themeProvider, Interface275 additionalModifier)
	{
		Class5998 color = vmethod_0(themeProvider);
		return method_0(color, additionalModifier);
	}

	public abstract Interface274 Clone();

	public virtual void imethod_0(Interface274 styleColor)
	{
	}

	private Class5998 method_0(Class5998 color, Interface275 additionalModifier)
	{
		foreach (Interface275 colorModifier in ColorModifiers)
		{
			color = colorModifier.imethod_0(color);
		}
		if (additionalModifier != null)
		{
			color = additionalModifier.imethod_0(color);
		}
		return color;
	}

	protected abstract Class5998 vmethod_0(Interface297 themeProvider);

	protected void method_1(Class6284 color)
	{
		List<Interface275> list = new List<Interface275>(ColorModifiers.Count);
		foreach (Class6292 colorModifier in ColorModifiers)
		{
			list.Add(colorModifier.Clone());
		}
		color.ColorModifiers = list;
	}
}
